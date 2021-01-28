//******************************************************************/
//  Event and Delegate
//  ----------------------------------------------------------------
//  September/2020                        MahirKoding.id
//                                        Dian Nandiwardhana
//******************************************************************/
using System;

namespace WorkingWithEvents
{
    // [1] Create a delegate. 
    // By convention, choose the delegate name with the EventHandler suffix;
    public delegate void ValueChangedEventHandler(string msg);

    public class Demo1Sender
    {
        // [2] Define your event
        // As a convention, you can drop the  EventHandler suffix from the delegate name 
        // and set your event name.
        public event ValueChangedEventHandler ValueChanged;

        private int myInt;
        public int MyIntNumber
        {
            get { return myInt; }
            set 
            { 
                myInt = value;

                RaiseValueChangedEvent();
            }
        }

        // [3] Raise the event.
        // In general, instead of making the method public, 
        // it is suggested that you make the method protected virtual.
        protected virtual void RaiseValueChangedEvent()
        {
            ValueChanged?.Invoke("Nilai MyIntNumber telah berubah");

            // this statement is equivalent to the above statement
            // if (ValueChanged != null)
            // {
            //     ValueChanged("Nilai MyIntNumber telah berubah");
            // }
        }
    }

    public class Demo1Receiver
    {
        // [4] Handle the event
        public void OnMyIntNumberValueChanged(string msg) => Console.WriteLine($"Notifikasi dari pengirim: {msg}");
    }

    public class Demo1
    {
        public static void Run()
        {
            Demo1Sender demo1Sender = new Demo1Sender();
            Demo1Receiver demo1Receiver = new Demo1Receiver();

            // demo1Receiver is registering for a notification from demo1Sender
            demo1Sender.ValueChanged += demo1Receiver.OnMyIntNumberValueChanged;

            demo1Sender.MyIntNumber = 1;
            demo1Sender.MyIntNumber = 2;

            // unregistering now
            demo1Sender.ValueChanged -= demo1Receiver.OnMyIntNumberValueChanged;

            // No notification sent for the receiver now.
            demo1Sender.MyIntNumber = 3;
        }
    }
}