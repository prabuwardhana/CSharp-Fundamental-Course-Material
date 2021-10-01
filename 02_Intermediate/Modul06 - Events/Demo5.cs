//******************************************************************/
//  Implementing interface event
//  ----------------------------------------------------------------
//  September/2020                        MahirKoding.id
//                                        Dian Nandiwardhana
//******************************************************************/
using System;

namespace WorkingWithEvents
{
    public interface IAInterface
    {
        // Raise this when the value is about to change
        event EventHandler<ValueChangedEventArgsDemo5> onValueChanged;
    }

    public interface IBInterface
    {
        // Raise this event when the value has changed
        event EventHandler<ValueChangedEventArgsDemo5> onValueChanged;
    }

    public class ValueChangedEventArgsDemo5 : EventArgs
    {
        public string Message { get; }
        public int CurrentValue { get; }

        public ValueChangedEventArgsDemo5(string msg, int currVal)
        {
            this.Message = msg;
            this.CurrentValue = currVal;
        }
    }

    public class Demo5Publisher : IAInterface, IBInterface
    {
        private int myInt;
        public int MyIntNumber
        {
            get { return myInt; }
            set 
            { 
                RaiseOnValueWillChangeEvent();
                Console.WriteLine($"==> Mengubah nilai MyIntNumber dari {myInt} ke {value}.");
                myInt = value;
                RaiseOnValueHasChangedEvent();
            }
        }

        object objectLock = new Object();

        // delegate
        private EventHandler<ValueChangedEventArgsDemo5> onValueWillChange;

        // Explicit interface implementation required.
        event EventHandler<ValueChangedEventArgsDemo5> IAInterface.onValueChanged
        {
            add
            {
                lock (objectLock)
                {
                    onValueWillChange += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    onValueWillChange -= value;
                }
            }
        }

        // delegate
        private EventHandler<ValueChangedEventArgsDemo5> onValueHasChanged;

        // Explicit interface implementation required.
        event EventHandler<ValueChangedEventArgsDemo5> IBInterface.onValueChanged
        {
            add
            {
                lock (objectLock)
                {
                    onValueHasChanged += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    onValueHasChanged -= value;
                }
            }
        }

        protected virtual void RaiseOnValueWillChangeEvent()
        {
            onValueWillChange?.Invoke(this, new ValueChangedEventArgsDemo5("The value of MyIntNumber will be changed", myInt));
        }

        protected virtual void RaiseOnValueHasChangedEvent()
        {
            onValueHasChanged?.Invoke(this, new ValueChangedEventArgsDemo5("MyIntNumber value has changed", myInt));
        }
    }

    public class Demo5Subscriber1
    {
        private readonly IAInterface sender;

        public Demo5Subscriber1(Demo5Publisher sndr)
        {
            this.sender = (IAInterface)sndr;
            this.sender.onValueChanged += OnMyIntNumberValueChanged;
        }

        private void OnMyIntNumberValueChanged(object sender, ValueChangedEventArgsDemo5 e) 
            => Console.WriteLine($"[Penerima 1] Notifikasi dari pengirim: {e.Message}, nilai sekarang: {e.CurrentValue}");

        public void UnregisterEvent()
        {
            this.sender.onValueChanged -= OnMyIntNumberValueChanged;
        }
    }

    public class Demo5Subscriber2
    {
        private readonly IBInterface sender;

        public Demo5Subscriber2(Demo5Publisher sender)
        {
            this.sender = (IBInterface)sender;
            this.sender.onValueChanged += OnMyIntNumberValueChanged;
        }

        private void OnMyIntNumberValueChanged(object sender, ValueChangedEventArgsDemo5 e) 
            => Console.WriteLine($"[Penerima 2] Notifikasi dari pengirim: {e.Message}, nilai sekarang: {e.CurrentValue}\n");
        
        public void UnregisterEvent()
        {
            this.sender.onValueChanged -= OnMyIntNumberValueChanged;
        }
    }

    public class Demo5
    {
        public static void Run()
        {
            Demo5Publisher demo5Sender = new Demo5Publisher();
            Demo5Subscriber1 demo5Receiver1 = new Demo5Subscriber1(demo5Sender);
            Demo5Subscriber2 demo5Receiver2 = new Demo5Subscriber2(demo5Sender);

            // Sender changes its property
            demo5Sender.MyIntNumber = 1;
            demo5Sender.MyIntNumber = 2;

            // unregistering now
            demo5Receiver1.UnregisterEvent();

            // No notification sent for the receiver now.
            demo5Sender.MyIntNumber = 3;
        }
    }
}