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
        event EventHandler<ValueChangedEventArgsDemo5> ValueChanged;
    }

    public interface IBInterface
    {
        event EventHandler<ValueChangedEventArgsDemo5> ValueChanged;
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

    public class Demo5Sender : IAInterface, IBInterface
    {
        private int myInt;
        public int MyIntNumber
        {
            get { return myInt; }
            set 
            { 
                RaiseValueChangedEvent_A();
                Console.WriteLine($"==> Mengubah nilai MyIntNumber dari {myInt} ke {value}.");
                myInt = value;
                RaiseValueChangedEvent_B();
            }
        }

        object objectLock = new Object();

        // delegate
        private EventHandler<ValueChangedEventArgsDemo5> ValueChangedA;

        // Explicit interface implementation required.
        event EventHandler<ValueChangedEventArgsDemo5> IAInterface.ValueChanged
        {
            add
            {
                lock (objectLock)
                {
                    ValueChangedA += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    ValueChangedA -= value;
                }
            }
        }

        // delegate
        private EventHandler<ValueChangedEventArgsDemo5> ValueChangedB;

        // Explicit interface implementation required.
        event EventHandler<ValueChangedEventArgsDemo5> IBInterface.ValueChanged
        {
            add
            {
                lock (objectLock)
                {
                    ValueChangedB += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    ValueChangedB -= value;
                }
            }
        }

        protected virtual void RaiseValueChangedEvent_A()
        {
            ValueChangedA?.Invoke(this, new ValueChangedEventArgsDemo5("Nilai MyIntNumber akan diubah", myInt));
        }

        protected virtual void RaiseValueChangedEvent_B()
        {
            ValueChangedB?.Invoke(this, new ValueChangedEventArgsDemo5("Nilai MyIntNumber telah diubah", myInt));
        }
    }

    public class Demo5Receiver1
    {
        private readonly IAInterface sender;

        public Demo5Receiver1(Demo5Sender sndr)
        {
            this.sender = (IAInterface)sndr;
            this.sender.ValueChanged += OnMyIntNumberValueChanged;
        }

        private void OnMyIntNumberValueChanged(object sender, ValueChangedEventArgsDemo5 e) 
            => Console.WriteLine($"[Penerima 1] Notifikasi dari pengirim: {e.Message}, nilai sekarang: {e.CurrentValue}");

        public void UnregisterEvent()
        {
            this.sender.ValueChanged -= OnMyIntNumberValueChanged;
        }
    }

    public class Demo5Receiver2
    {
        private readonly IBInterface sender;

        public Demo5Receiver2(Demo5Sender sender)
        {
            this.sender = (IBInterface)sender;
            this.sender.ValueChanged += OnMyIntNumberValueChanged;
        }

        private void OnMyIntNumberValueChanged(object sender, ValueChangedEventArgsDemo5 e) 
            => Console.WriteLine($"[Penerima 2] Notifikasi dari pengirim: {e.Message}, nilai sekarang: {e.CurrentValue}\n");
        
        public void UnregisterEvent()
        {
            this.sender.ValueChanged -= OnMyIntNumberValueChanged;
        }
    }

    public class Demo5
    {
        public static void Run()
        {
            Demo5Sender demo5Sender = new Demo5Sender();
            Demo5Receiver1 demo5Receiver1 = new Demo5Receiver1(demo5Sender);
            Demo5Receiver2 demo5Receiver2 = new Demo5Receiver2(demo5Sender);

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