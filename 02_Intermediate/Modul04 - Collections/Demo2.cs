using System;
using System.Collections;

namespace WorkingWithCollections
{
    public class Demo2
    {
        public static void Run()
        {
            string[] strArray = { "Pertama", "Kedua", "Ketiga" };

            // Dynamically resized container
            ArrayList strArrayList = new ArrayList();
            // use AddRange() to add range of items
            strArrayList.AddRange(strArray);

            Console.WriteLine("'strArrayList' memiliki {0} elemen\n", strArrayList.Count);

            // use Add() to add single item
            Console.WriteLine("=> Tambah elemen keempat");
            strArrayList.Add("Keempat");
            Console.WriteLine("Sekarang 'strArrayList' memiliki {0} elemen\n", strArrayList.Count);

            Console.WriteLine("Elemen-elemen pada 'strArrayList': ");
            foreach (string s in strArrayList)
            {
                Console.Write($"{s} ");
            }

            /* ISSUE OF NON-GENERIC COLLECTIONS */

            // #1 Issue of performance (Boxing and Unboxing)
            ArrayList intArrayList = new ArrayList();
            // Value types are automatically boxed when passed to a member requesting an object.
            intArrayList.Add(10);
            intArrayList.Add(20);
            intArrayList.Add(30);

            // Unboxing occurs when an object is converted back to stack-based data.
            int iv = (int)intArrayList[0];

            /*************************************************************************************************
            these steps that must occur to box and unbox a simple integer:
            1. A new object must be allocated on the managed heap.
            2. The value of the stack-based data must be transferred into that memory location.
            3. When unboxed, the value stored on the heap-based object must be transferred back to the stack.
            4. The now unused object on the heap will (eventually) be garbage collected.
            *************************************************************************************************/

            // #2 Issue of Type Safety
            ArrayList objArray = new ArrayList();
            objArray.Add(true);
            objArray.Add(10);
            objArray.Add(5.6);
            objArray.Add("Halo!");

            // // Run-time error!
            // // InvalidCastException: Unable to cast object of type 'System.String' to type 'System.Int32'.
            // int varInt = (int)objArray[3];
            // Console.WriteLine("Nilai varInt: {0}", varInt);
        }

        public static void BoxUnboxOp()
        {
            // Make a value type (int) variable
            // the value of intVar is stored in the stack
            int intVar = 75;
            
            // Box the int into an object reference
            // CLR allocates a new object on the heap and copies the value of intVar into that instance
            // boxedInt holds the reference to the value of intVar on the heap
            object boxedInt = intVar;

            // // Error: Cannot implicitly convert type 'boxedInt' to 'unboxedInt'
            // int unboxedInt = boxedInt;

            // Semantic: CLR verifies that the receiving data type (unboxedInt) is equivalent to the boxed type (boxedInt)
            // and if so, it copies the value back into a local stack-based variable
            int unboxedInt = (int)boxedInt;

            // unlike when performing a typical cast, you must unbox into an appropriate data type.
            try
            {
                long unboxedLong = (long)boxedInt;
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        // CIL code for BoxUnboxOp()
        /*
        .method private hidebysig static void  BoxUnboxOp() cil managed
        {
        // code size       19 (0x13)
        .maxstack  1
        .locals init (int32 V_0, object V_1, int32 V_2)
        IL_0000:  nop
        IL_0001:  ldc.i4.s   75 # int intVar = 75;
        IL_0003:  stloc.0
        IL_0004:  ldloc.0
        IL_0005:  box        [System.Runtime]System.Int32 # [BOXING OPERATION] object boxedInt = intVar;
        IL_000a:  stloc.1
        IL_000b:  ldloc.1
        IL_000c:  unbox.any  [System.Runtime]System.Int32 # [UNBOXING OPERATION] int unboxedInt = (int)boxedInt;
        IL_0011:  stloc.2
        IL_0012:  ret
        }
        */
    }
}