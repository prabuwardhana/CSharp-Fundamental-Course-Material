//******************************************************************/
//  Custom Event Args and Generic event
//  Bonus: How event works in .NET environment
//  ----------------------------------------------------------------
//  September/2020                        MahirKoding.id
//                                        Dian Nandiwardhana
//******************************************************************/
using System;
using System.Threading;

namespace WorkingWithEvents
{
    public class ValueChangedEventArgs : EventArgs
    {
        public string Message { get; }
        public int CurrentValue { get; }

        public ValueChangedEventArgs(string msg, int currVal)
        {
            this.Message = msg;
            this.CurrentValue = currVal;
        }
    }

    // public delegate void ValueChangedEventHandler2(object sender, ValueChangedEventArgs eventArgs);

    public class Demo3Sender
    {        
        // public event ValueChangedEventHandler2 ValueChanged;

        // equivalent code using generic EventHandler:
        public event EventHandler<ValueChangedEventArgs> ValueChanged; 

        // How C# compiler translates the above single line of code:
        #region C# compiler's generated code
        // // 1. A PRIVATE delegate field that is initialized to null (no listeners have registered interest in the event)
        //
        // private EventHandler<ValueChangedEventArgs> ValueChanged = null;
        
        // // 2. A PUBLIC add_Xxx method (where Xxx is the Event name)
        // // Allows methods to register interest in the event.
        //
        // public void add_ValueChanged(EventHandler<ValueChangedEventArgs> value)
        // {
        //     // The loop and the call to CompareExchange is all just a fancy way
        //     // of adding a delegate to the event in a thread-safe way
        //     EventHandler<ValueChangedEventArgs> prevHandler;
        //     EventHandler<ValueChangedEventArgs> valueChanged = this.ValueChanged;
        //     do 
        //     {
        //         prevHandler = valueChanged;

        //         // adds the instance of a delegate to the list of delegates and returns the new head of the list, 
        //         // which gets saved back in the field 
        //         EventHandler<ValueChangedEventArgs> newHandler =
        //         (EventHandler<ValueChangedEventArgs>) Delegate.Combine(prevHandler, value);

        //         valueChanged = Interlocked.CompareExchange<EventHandler<ValueChangedEventArgs>>(ref this.ValueChanged,
        //                                                                                         newHandler,
        //                                                                                         prevHandler);
        //     } while (valueChanged != prevHandler);
        // }

        // // 3. A PUBLIC remove_Xxx method (where Xxx is the Event name)
        // // Allows methods to unregister interest in the event.
        //
        // public void remove_ValueChanged(EventHandler<ValueChangedEventArgs> value) {
        //     // The loop and the call to CompareExchange is all just a fancy way
        //     // of removing a delegate from the event in a thread-safe way
        //     EventHandler<ValueChangedEventArgs> prevHandler;
        //     EventHandler<ValueChangedEventArgs> valueChanged = this.ValueChanged;
        //     do 
        //     {
        //         prevHandler = valueChanged;

        //         EventHandler<ValueChangedEventArgs> newHandler =
        //         (EventHandler<ValueChangedEventArgs>) Delegate.Remove(prevHandler, value);

        //         valueChanged = Interlocked.CompareExchange<EventHandler<ValueChangedEventArgs>>(ref this.ValueChanged,
        //                                                                                         newHandler,
        //                                                                                         prevHandler);
        //     } while (valueChanged != prevHandler);
        // }    
        #endregion        

        // // compiler will still generate private delegate EventHandler even if it is unused
        // // could be a waste of memory if a class has many unused event handlers.
        //
        // public event EventHandler UnusedEvent; => this code generates compiler warning CS0067

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
            ValueChanged?.Invoke(this, new ValueChangedEventArgs("Nilai MyIntNumber telah berubah", myInt));
        }
    }

    public class Demo3Receiver
    {
        public void OnMyIntNumberValueChanged(object sender, ValueChangedEventArgs e) 
            => Console.WriteLine($"Notifikasi dari pengirim: {e.Message}, nilai sekarang: {e.CurrentValue}");
    }

    public class Demo3
    {
        public static void Run()
        {
            Demo3Sender demo3Sender = new Demo3Sender();
            Demo3Receiver demo3Receiver = new Demo3Receiver();

            // // direct assignment is not allowed
            // // By using event keyword compiler protects our field from unwanted access.
            // // prevent code outside the defining class from manipulating it improperly
            //
            // demo3Sender.ValueChanged = demo3Receiver.OnMyIntNumberValueChanged;

            // demo3Receiver is registering for a notification from demo1Sender
            demo3Sender.ValueChanged += demo3Receiver.OnMyIntNumberValueChanged;

            demo3Sender.MyIntNumber = 1;
            demo3Sender.MyIntNumber = 2;

            // unregistering now
            demo3Sender.ValueChanged -= demo3Receiver.OnMyIntNumberValueChanged;

            // No notification sent for the receiver now.
            demo3Sender.MyIntNumber = 3;
        }
    }
}