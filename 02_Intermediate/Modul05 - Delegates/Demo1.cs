using System;

namespace WorkingWithDelegates
{
    public class Demo1
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Simple Delegate ===");
            /************************************
            # Create a SimpleMathDelegate delegate object that "points to" SimpleMath.Add().
            # This delegate object will point to Add() method that match exactly with the delegate signature.
            # It means that the delagate will invoke only Add() method with two int params and int return value.
            ************************************/
            // C#1.0 declaration:
            // SimpleMathDelegate simpleMathAdd = new SimpleMathDelegate(SimpleMath.Add);

            // C#2.0 declaration:
            SimpleMathDelegate simpleMathAdd = SimpleMath.Add;

            // Now the invocation of SimpleMath.Add() can be delegated to object 'simpleMathAdd'
            Console.WriteLine("simpleMathAdd.Invoke(10, 20) = {0}", simpleMathAdd.Invoke(10, 20));
            // Alternatively, you can invoke the delegate simply like below.
            Console.WriteLine("simpleMathAdd(10, 20) = {0}", simpleMathAdd(10, 20));

            /** OUTPUT **/
            /************************************
            # === Simple Delegate ===
            # simpleMathAdd.Invoke(10, 20) = 30
            # simpleMathAdd(10, 20) = 30
            ************************************/

            /************************************
            # .NET delegates are type-safe.
            # Therefore, if you attempt to create a delegate object pointing
            # to a method that does not match the pattern, you receive a compile-time error.
            ************************************/
            // // Error! No overload for 'Square' matches delegate 'SimpleMathDelegate'
            // SimpleMathDelegate square = SimpleMath.Square;
            
            SimpleMath simpleMath = new SimpleMath();

            // .NET delegates can also point to instance methods as well.
            SimpleMathDelegate simpleMathSub = simpleMath.Subtract;

            Console.WriteLine("\n=== Comparing Static Method With An Instance Method ===");
            // Static method
            DisplayDelegateInfo(simpleMathAdd);

            /** OUTPUT **/
            /************************************
            # Target method: Int32 Add(Int32, Int32)
            # Target class:
            # Target class (SimpleMath) is currently not displayed when calling the Target property.
            # The reason has to do with the fact that your ArithmeticOpDelegate delegate is pointing to a static method and,
            # therefore, there is no object to reference!
            *************************************/

            // Instance method
            DisplayDelegateInfo(simpleMathSub);
            
            /** OUTPUT **/
            /************************************
            # Target method: Int32 Add(Int32, Int32)
            # Target class: SimpleDelegate.Program+SimpleMath
            # When we assign a non-static method to a delegate object,
            # the object maintains a reference not only to the method,
            # but also to the instance to which this method belongs.
            *************************************/            
        }

        #region Helper
        private static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Target method: {0}", d.Method);
                Console.WriteLine("Target class: {0}", d.Target);
            }
        }
        #endregion        
    }
}