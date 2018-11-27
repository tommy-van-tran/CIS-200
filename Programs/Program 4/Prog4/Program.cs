// W8449
// Program 4
// April 24, 2018
// CIS199-01
// This assignment explores the creation of a reusable class and separate GUI application that creates an array of objects.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_4
{
    class GroundPackage
    {
            // Constructor for Data values
        private int originZipCode;
        private int destinationZipCode;
        private double LENGTH;
        private double WIDTH;
        private double HEIGHT;
        private double WEIGHT;

        
    

        public GroundPackage(int ori, int des, double len, double wid, double hei, double wei) // Using properties to set values
        {
            OriginZipCode = ori;
            DestinationZipCode = des;
            length = len;
            width = wid;
            height = hei;
            weight = wei;
        }

        public int OriginZipCode // All data value properties
        {
            get
            {
                return originZipCode;
            }
            set
            {
                if (value >= 10000 && value <= 99999) // If the value isn't accurate, set the zipcode to 40202
                    originZipCode = value;
                else
                {
                    originZipCode = 40202;
                }
            }
        }

        public int DestinationZipCode
        {
            get
            {
                return destinationZipCode;
            }
            set
            {
                if (value >= 10000 && value <= 99999) // If the value isn't accurate, set the zipcode to 90210
                    destinationZipCode = value;
                else
                {
                    destinationZipCode = 90210;
                }  

            }
        }

        public double length
        {
            get
            {
                return LENGTH;
            }
            set
            {
                if (value > 0) // If the value isn't accurate, set the length to 1
                    LENGTH = value;
                else
                {
                    LENGTH = 1.0;
                }
            }
        }

        public double width
        {
            get
            {
                return WIDTH;
            }
            set
            {
                if (value > 0) // If the value isn't accurate, set the width to 1
                    WIDTH = value;
                else
                {
                    WIDTH = 1.0;
                }
            }
        }

        public double height
        {
            get
            {
                return HEIGHT;
            }
            set
            {
                if (value > 0) // If the value isn't accurate, set the height to 1
                    HEIGHT = value;
                else
                {
                    HEIGHT = 1.0;
                }
            }
        }

        public double weight
        {
            get
            {
                return WEIGHT;
            }
            set
            {
                if (value > 0) // If the value isn't accurate, set the weight to 1
                    WEIGHT = value;
                else
                {
                    WEIGHT = 1.0;
                }
            }
        }
        
        public int ZoneDistance
        {
            get
            {
                int firstOriginZip = originZipCode / 10000; // Finding the first digit of the origin zipcode
                int firstDestinationZip = destinationZipCode / 10000; // Finding the first digit of the destination zipcode

                return Math.Abs(firstOriginZip - firstDestinationZip); // Returning the absolute value of the origin subtracting the destination
            }
        }

        public override string ToString()
        {
            return // Formatting string with string interpolation and will set the width to the left of 20
                $"{"Origin zipcode",-20}: {OriginZipCode}" + Environment.NewLine +
                $"{"Destination zipcode",-20}: {DestinationZipCode}" + Environment.NewLine +
                $"{"Length",-20}: {length}" + Environment.NewLine +
                $"{"Height",-20}: {height}" + Environment.NewLine +
                $"{"Width",-20}: {width}" + Environment.NewLine +
                $"{"Weight",-20}: {weight}";
        }

        public double CalcCost()
        {
            double cost = .20 * (length + width + height) + .5 * (ZoneDistance + 1) * (weight); // Calculating the cost
            return cost;
        }
    }
}

namespace Program_4
{
    class GroundPackageTestClass
    {
        static void Main(string[] args)
        {
            GroundPackage firstPackage = new GroundPackage(12345, 54321, 10, 20, 10, 50); // First object of the GroundPackage
            GroundPackage secondPackage = new GroundPackage(1111, 54321, 50, 50, 40, 150); // Second object of the GroundPackage
            GroundPackage thirdPackage = new GroundPackage(50000, 10000, 70, 50, 40, 250); // Third object of the GroundPackage
            GroundPackage fourthPackage = new GroundPackage(12345, 9999, 70.5, 50.65, 30, 78); // Fourth object of the GroundPackage
            GroundPackage fifthPackage = new GroundPackage(54321, 99723, 100, 85, 55, 120); // Fifth object of the GroundPackage

            GroundPackage[] allPackages = { firstPackage, secondPackage, thirdPackage, fourthPackage, fifthPackage }; // Package array

            DisplayPackages(allPackages); // Call function to show packages

            firstPackage.OriginZipCode = 55555; // Displaying first package
            firstPackage.length = 25.5;
            display(firstPackage);

            secondPackage.length = -1; // Displaying second package
            display(secondPackage);
        }

        static void DisplayPackages(GroundPackage[] allPackages)
        {
            for(int i = 0; i < allPackages.Length; i++) // Iterate loop over the allPackages array
            {
                Console.WriteLine("Packages " + (i + 1) + "\n------------------------------"); // Printing package number
                Console.WriteLine(allPackages[i]);
                Console.WriteLine($"{"Shipping Cost",-20}: ${allPackages[i].CalcCost()}"); // Printing the shipping cost with call function
                Console.WriteLine();
            }
        }

        static void display(GroundPackage allpackages) 
        {
            Console.WriteLine(allpackages); // Printing packages
            Console.WriteLine($"{"Shipping Cost",-20}: ${allpackages.CalcCost()}"); // Printing the shipping costs with call function
            Console.WriteLine();
        }
    }
}