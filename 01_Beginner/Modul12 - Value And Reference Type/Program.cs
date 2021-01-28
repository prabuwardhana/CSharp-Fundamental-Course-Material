using System;

namespace ValRefType
{
    class Program
    {
        static void Main(string[] args)
        {
            PassRefTypeByReference();
            PassRefTypeByValue();
            ValTypeContainingRefType();
            CopyClassAndStruct();
        }

        #region Helper Methods
        private static void PassRefTypeByReference()
        {
            Console.WriteLine("\n***** Pass An Object By Reference *****");
            Person person = new Person("Sitorus", 38);
            Console.WriteLine("\nBefore passing person by reference, person is:");
            person.Display();

            Console.WriteLine("Calling ReferenceParameter(ref person)");
            ReferenceParameter(ref person);
            Console.WriteLine("After passing person by reference, person is:");
            person.Display();
        }

        static void ReferenceParameter(ref Person p)
        {
            // change the age.
            p.personAge = 65;
            // "p" is now pointing to a new object on the heap!
            // Assigning a new object to "p" means that "p" is now referencing different object on the heap.
            // When it's passed as argument, the location of 'person' (not the object referenced by 'person') on the stack will be stored in 'p'.
            // Now, 'p' is acting as 'person'. Doing something with 'p' is actaully doing something with 'person'
            // That is why, when a new object is assigned to 'p', it is actually assigning new object to 'person'.
            p = new Person("Acong", 12);
        }

        private static void PassRefTypeByValue()
        {
            Console.WriteLine("***** Pass An Object By Value *****");
            Person person = new Person("Sitorus", 38);
            Console.WriteLine("\nBefore passing person by value, person is:");
            person.Display();
            ValueParameter(person);
            Console.WriteLine("\nAfter passing person by value, person is:");
            person.Display();
        }

        static void ValueParameter(Person p)
        {
            // Let's try to change the value
            p.personAge = 65;
            // Will the caller now see this reassignment?
            // No, it is not!
            p = new Person("Acong", 12);
            // When person is passed by value, 'p' is just the copy of 'person'.
            // Means that they are located in two different location on the stack, but referencing the same object on the heap.
            // 'p' has no idea what 'person' is (where person is located in the memory), 
            // it only knows that 'person' holds a reference to an object and copy the same reference for its value.
            // That is why when 'p' is assigned with a new object, it's no longer referencing the same object as 'person'.

        }

        private static void ValTypeContainingRefType()
        {
            // Instantiate the first rectangle (rect1)
            Console.WriteLine("-> Instantiate rect1");
            Rectangle rect1 = new Rectangle("Segi empat pertama", 10, 10, 50, 50);
            
            // Assigned rect1 to rect2
            Console.WriteLine("-> Declare an instance variable called rect2, then assign rect1 to it.");
            Rectangle rect2 = rect1;
            
            // Change some value in the second rectangle (rect2)
            Console.WriteLine("-> Changing some value on rect2");
            // This change will be applied to both rectangle
            rect2.RectInfo.InfoString = "New info!!";
            // This change will only applied to the second rectangle
            rect2.bottomSide = 4444;
            
            // Display both rectangle
            Console.Write("First rectangle: ");
            rect1.Display();
            Console.Write("Second rectangle: ");
            rect2.Display();
        }

        private static void CopyClassAndStruct()
        {
            Console.WriteLine("==== Copying Struct ====\n");

            // Initialize all the fields for p1
            // All the field then will be allocated on the stack
            Coordinate p1 = new Coordinate(10, 10);
            // All the value for each field in p1 will be copied to p2 and is allocated in different location
            Coordinate p2 = p1;

            p1.DisplayCoordinate();
            p2.DisplayCoordinate();

            Console.WriteLine("\n-> Change the value of p1.X");
            p1.X = 100;
            // p1.X is now 100
            p1.DisplayCoordinate();
            // p2.X remains the same
            // Of course this is because p2 has no idea what p2 is.
            // They are independent to each other. p2 only copied the value of each field from p1.
            p2.DisplayCoordinate();

            Console.WriteLine("\n==== Copying Class ====\n");

            // Instantiate an object
            // p3 is now pointing to a location on the heap
            CoordinateRef p3 = new CoordinateRef(10, 10);            
            // p4 copies the value of p3, which is the reference to an object on the heap.
            // Now, p3 and p4 are pointing at the same location on the heap.
            CoordinateRef p4 = p3;

            p3.DisplayCoordinate();
            p4.DisplayCoordinate();

            Console.WriteLine("\n-> Changing the value of p3.X");
            p3.X = 100;
            // p1.X is changed to 100
            p3.DisplayCoordinate();
            // p2.X is also changed to 100
            p4.DisplayCoordinate();
        }
        #endregion        

        
    }
}
