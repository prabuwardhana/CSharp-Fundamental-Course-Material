//******************************************************************/
//  Explicit event implementation
//  ----------------------------------------------------------------
//  September/2020                        MahirKoding.id
//                                        Dian Nandiwardhana
//******************************************************************/
using System;
using System.Collections.Generic;
using System.Threading;

namespace WorkingWithEvents
{
    public sealed class EventSet
    {
        // The private dictionary used to maintain event key (string) -> Delegate mappings
        private readonly Dictionary<string, Delegate> m_events = new Dictionary<string, Delegate>();

        // Adds an EventKey -> Delegate mapping if it doesn't exist or
        // combines a delegate to an existing EventKey
        public void Add(string eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventKey, out d);
            m_events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);
        }

        // Removes a delegate from an EventKey (if it exists) and
        // removes the event key (string) -> Delegate mapping the last delegate is removed
        public void Remove(string eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            // Call TryGetValue to ensure that an exception is not thrown if
            // attempting to remove a delegate from an event key not in the set
            Delegate d;
            if (m_events.TryGetValue(eventKey, out d))
            {
                d = Delegate.Remove(d, handler);
                // If a delegate remains, set the new head else remove the EventKey
                if (d != null) 
                    m_events[eventKey] = d;
                else 
                    m_events.Remove(eventKey);
            }
            Monitor.Exit(m_events);
        }

        // Raises the event for the indicated event key
        public void Raise(string eventKey, Object sender, EventArgs e) 
        {
            // Don't throw an exception if the event key is not in the set
            Delegate d;
            Monitor.Enter(m_events);
            m_events.TryGetValue(eventKey, out d);
            Monitor.Exit(m_events);
            if (d != null)
            {
                // Because the dictionary can contain several different delegate types,
                // it is impossible to construct a type-safe call to the delegate at
                // compile time. So, I call the System.Delegate type's DynamicInvoke
                // method, passing it the callback method's parameters as an array of
                // objects. Internally, DynamicInvoke will check the type safety of the
                // parameters with the callback method being called and call the method.
                // If there is a type mismatch, then DynamicInvoke will throw an exception.
                d.DynamicInvoke(new Object[] { sender, e });
            }
        }   
    }

    // Define the EventArgs-derived type for this event.
    public class ValueChangedEventArgsDemo4 : EventArgs
    {
        public string Message { get; }
        public int CurrentValue { get; }

        public ValueChangedEventArgsDemo4(string msg, int currVal)
        {
            this.Message = msg;
            this.CurrentValue = currVal;
        }
    }

    public class Demo4Sender 
    {
        // Define a private instance field that references a collection.
        // The collection manages a set of Event/Delegate pairs.
        private readonly EventSet m_eventSet = new EventSet();
        // The protected property allows derived types access to the collection.
        protected EventSet EventSet { get { return m_eventSet; } }

        #region Code to support the Foo event (repeat this pattern for additional events)
        // Define the members necessary for the ValueChanged event.
        // [1] Construct a static, read-only object to identify this event (the key).
        // Each object has its own hash code for looking up this
        // event's delegate linked list in the object's collection.
        protected static readonly string s_valueChangedEventKey = "valueChangedEventKey";

        // [2] Define the event's accessor methods that add/remove the delegate from the collection.
        public event EventHandler<ValueChangedEventArgsDemo4> ValueChanged 
        {
            add 
            { 
                m_eventSet.Add(s_valueChangedEventKey, value);
            }
            remove
            {
                m_eventSet.Remove(s_valueChangedEventKey, value);
            }
        }

        // Define the members necessary for another event.
        protected static readonly string s_unusedEventKey = "unusedEventKey";

        // having unused event doesn't generate compiler warning
        public event EventHandler UnusedEvent 
        {
            add 
            { 
                m_eventSet.Add(s_unusedEventKey, value);
            }
            remove
            {
                m_eventSet.Remove(s_unusedEventKey, value);
            }
        }

        private int myInt;
        public int MyIntNumber
        {
            get { return myInt; }
            set 
            { 
                myInt = value;
                RaiseValueChangedEvent(new ValueChangedEventArgsDemo4("Nilai MyIntNumber telah berubah", myInt));
            }
        }

        // [3] Define the protected, virtual method to raise ValueChanged event.
        protected virtual void RaiseValueChangedEvent(ValueChangedEventArgsDemo4 e) 
        {
            m_eventSet.Raise(s_valueChangedEventKey, this, e);
        }
        #endregion
    }

    public class Demo4Receiver
    {
        private readonly Demo4Sender sender;

        public Demo4Receiver(Demo4Sender sender)
        {
            this.sender = sender;
            this.sender.ValueChanged += OnMyIntNumberValueChanged;
        }

        public void OnMyIntNumberValueChanged(object sender, ValueChangedEventArgsDemo4 e) 
            => Console.WriteLine($"Notifikasi dari pengirim: {e.Message}, nilai sekarang: {e.CurrentValue}");

        public void UnregisterEvent() => this.sender.ValueChanged -= OnMyIntNumberValueChanged;
    }

    public class Demo4
    {
        public static void Run()
        {
            Demo4Sender demo4Sender = new Demo4Sender();
            Demo4Receiver demo4Receiver = new Demo4Receiver(demo4Sender);            

            // Sender changes its property
            demo4Sender.MyIntNumber = 1;
            demo4Sender.MyIntNumber = 2;

            // unregistering now
            demo4Receiver.UnregisterEvent();

            // No notification sent for the receiver now.
            demo4Sender.MyIntNumber = 3;
        }
    }
}