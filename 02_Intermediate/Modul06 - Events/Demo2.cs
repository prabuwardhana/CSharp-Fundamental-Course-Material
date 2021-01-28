//******************************************************************/
//  Predefined delegate for event
//  ----------------------------------------------------------------
//  September/2020                        MahirKoding.id
//                                        Dian Nandiwardhana
//******************************************************************/
using System;

namespace WorkingWithEvents
{
    public class Demo2Sender
    {
        // using predefined delegate
        // signature: delegate void System.EventHandler(object sender, System.EventArgs e)
        public event EventHandler ValueChanged;

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

        protected virtual void RaiseValueChangedEvent()
        {
            // param1 = the sender is the object itself
            // param2 = send an empty event arguments
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Demo2Receiver
    {
        // [4] Handle the event
        public void OnMyIntNumberValueChanged(object sender, EventArgs e) => Console.WriteLine($"Notifikasi dari pengirim: {e}");
    }

    public class Demo2
    {
        public static void Run()
        {
            Demo2Sender demo2Sender = new Demo2Sender();
            Demo2Receiver demo2Receiver = new Demo2Receiver();

            // demo2Receiver is registering for a notification from demo2Sender
            demo2Sender.ValueChanged += demo2Receiver.OnMyIntNumberValueChanged;

            demo2Sender.MyIntNumber = 1;
            demo2Sender.MyIntNumber = 2;

            // unregistering now
            demo2Sender.ValueChanged -= demo2Receiver.OnMyIntNumberValueChanged;

            // No notification sent for the receiver now.
            demo2Sender.MyIntNumber = 3;
        }
    }
}