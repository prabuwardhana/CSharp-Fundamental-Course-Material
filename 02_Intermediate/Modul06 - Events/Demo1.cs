//******************************************************************/
//  Event and Delegate
//  ----------------------------------------------------------------
//  September/2020                        MahirKoding.id
//                                        Dian Nandiwardhana
//******************************************************************/
using System;

namespace WorkingWithEvents
{
    /**********************************************
    # [1] Create a delegate. 
    # By convention, choose the delegate name with the EventHandler suffix;
    **********************************************/
    public delegate void ValueChangedEventHandler(string msg);

    public class Demo1Publisher
    {
        /**********************************************
        # [2] Define your event type
        # As a convention, you can drop the  EventHandler suffix from the delegate name 
        # and set your event name.
        **********************************************/
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

        /**********************************************
        # [3] Raise the event.
        # In general, instead of making the method public, 
        # it is suggested that you make the method protected virtual.
        **********************************************/
        protected virtual void RaiseValueChangedEvent()
        {
            ValueChanged?.Invoke("MyIntNumber value has changed");

            // this statement is equivalent to the above statement
            // if (ValueChanged != null)
            // {
            //     ValueChanged("MyIntNumber value has changed");
            // }
        }
    }

    public class Demo1Subscriber
    {
        /**********************************************
        # [4] Handle the event
        **********************************************/
        public void OnMyIntNumberValueChanged(string msg) => Console.WriteLine($"Notification from publisher: {msg}");
    }

    public class Demo1
    {
        public static void Run()
        {
            Demo1Publisher demo1Publisher = new Demo1Publisher();
            Demo1Subscriber demo1Subscriber = new Demo1Subscriber();

            // demo1Publisher is registering for a notification from demo1Subscriber
            Console.WriteLine("=> demo1Publisher is registering for a notification from demo1Subscriber");
            demo1Publisher.ValueChanged += demo1Subscriber.OnMyIntNumberValueChanged;

            Console.WriteLine("=> demo1Publisher.MyIntNumber = 1");
            demo1Publisher.MyIntNumber = 1;
            Console.WriteLine("=> demo1Publisher.MyIntNumber = 2");
            demo1Publisher.MyIntNumber = 2;

            // unregistering now
            Console.WriteLine("=> Unsubscribing");
            demo1Publisher.ValueChanged -= demo1Subscriber.OnMyIntNumberValueChanged;

            // No notification sent for the receiver now.
            Console.WriteLine("=> demo1Publisher.MyIntNumber = 3");
            demo1Publisher.MyIntNumber = 3;

            /** OUTPUT **/
            /**********************************************
            # => Subscribing
            # => demo1Publisher.MyIntNumber = 1
            # Notification from publisher: MyIntNumber value has changed
            # => demo1Publisher.MyIntNumber = 2
            # Notification from publisher: MyIntNumber value has changed
            # => Unsubscribing
            # => demo1Publisher.MyIntNumber = 3
            **********************************************/
        }
    }
}