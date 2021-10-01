//******************************************************************/
//  Predefined delegate for event
//  ----------------------------------------------------------------
//  September/2020                        MahirKoding.id
//                                        Dian Nandiwardhana
//******************************************************************/
using System;

namespace WorkingWithEvents
{
    public class Demo2Publisher
    {
        /**********************************************
        # [1] Define your event type using predifined delegate
        # using predefined delegate
        # signature: public delegate void System.EventHandler(object sender, System.EventArgs e)
        **********************************************/
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
            /**********************************************
            # [2] Raise the event.
            # param1 = the sender is the object itself
            # param2 = send an empty event arguments
            **********************************************/
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Demo2Subscriber
    {
        /**********************************************
        # [3] Handle the event
        **********************************************/
        public void OnMyIntNumberValueChanged(object sender, EventArgs e) => Console.WriteLine($"Notification from publisher: {e}");
    }

    public class Demo2
    {
        public static void Run()
        {
            Demo2Publisher demo2Publisher = new Demo2Publisher();
            Demo2Subscriber demo2Subscriber = new Demo2Subscriber();

            // demo2Subscriber is registering for a notification from demo2Publisher
            Console.WriteLine("=> demo2Subscriber is registering for a notification from demo2Publisher");
            demo2Publisher.ValueChanged += demo2Subscriber.OnMyIntNumberValueChanged;

            Console.WriteLine("=> demo2Publisher.MyIntNumber = 1");
            demo2Publisher.MyIntNumber = 1;
            Console.WriteLine("=> demo2Publisher.MyIntNumber = 2");
            demo2Publisher.MyIntNumber = 2;

            // unregistering now
            Console.WriteLine("=> Unsubscribing");
            demo2Publisher.ValueChanged -= demo2Subscriber.OnMyIntNumberValueChanged;

            // No notification sent for the receiver now.
            Console.WriteLine("=> demo2Publisher.MyIntNumber = 2");
            demo2Publisher.MyIntNumber = 3;

            /** OUTPUT **/
            /**********************************************
            # => demo2Subscriber is registering for a notification from demo2Publisher
            # => demo2Publisher.MyIntNumber = 1
            # Notification from publisher: System.EventArgs
            # => demo2Publisher.MyIntNumber = 2
            # Notification from publisher: System.EventArgs
            # => Unsubscribing
            # => demo2Publisher.MyIntNumber = 3
            **********************************************/
        }
    }
}