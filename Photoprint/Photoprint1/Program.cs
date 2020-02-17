//Program: C# application for a digital photo ordering system
//Student: Luis Araujo

/*=============================================================================
 * The user will be able to place an order for prints of three different sizes | 
 * and counts for each of those sizes. You can choose any THREE print sizes of |
 * your choice (e.g. 4” X 6”, 5” X 7” etc.).                                   |
 * =============================================================================
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Photoprint1
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating 3 instances to PhotoPrint class
            PhotoPrint smallSizePrint = new PhotoPrint(4, 6, "Small", 1);
            PhotoPrint mediumSizePrint = new PhotoPrint(5, 7, "Medium", 2);
            PhotoPrint largeSizePrint = new PhotoPrint(8, 10, "Large", 3);

            //calling GetNumberOfPrintsFromUser - This method takes one PhotoPrint class instance as its parameter and updates the count based on user input
            WriteLine("=====Please insert the number of prints for each size prompted=====\n");
            GetNumberOfPrintsFromUser(smallSizePrint);
            GetNumberOfPrintsFromUser(mediumSizePrint);
            GetNumberOfPrintsFromUser(largeSizePrint);
            WriteLine();
            Clear();
            PerformUserAction(smallSizePrint,mediumSizePrint,largeSizePrint);           

        }

        public static void GetNumberOfPrintsFromUser(PhotoPrint sizePrint)
        {
            /*This method displays the SizeName and Unit Price for the PhotoPrint class
            instance parameter and prompts the user to enter number of prints needed for that size.
            Then, the count of the PhotoPrint instance is updated based on user’s input.*/      
            Write("{0} ({2} X {3}) - {1:C} / print: ",sizePrint.SizeName,sizePrint.UnitPrice,sizePrint.Width,sizePrint.Length);
            bool convertSuccess = int.TryParse(ReadLine(), out int smallCount);
            if (!convertSuccess)
            {
                WriteLine("Error in quantity input");
            }
            else
            {
                sizePrint.Counter(smallCount);
            }                


        }

        public static void PerformUserAction(PhotoPrint smallSizePrint, PhotoPrint mediumSizePrint, PhotoPrint largeSizePrint)
        {
            /*This method takes as input the three instances of PhotoPrint. It displays three 
             * actions options for the user using a numbered input: Press 1 for View Cart, 
             * Press 2 for Update Cart, and Press 3 for quitting the application.*/
            WriteLine(new string('*', 20));
            WriteLine("{0,12}", "Menu");
            WriteLine(new string('*', 20));
            //WriteLine("== Menu ==");
            WriteLine("1 - View Cart");
            WriteLine("2 - Update Cart");
            WriteLine("3 - Quit");
            WriteLine(new string('-', 20));
            Write("Press the selected option> ");
            int menuOption = int.Parse(ReadLine());

            if (menuOption == 1)
            {
                Clear();
                ViewCart(smallSizePrint, mediumSizePrint, largeSizePrint);
                
            } else if (menuOption == 2)
            {
                Clear();
                UpdateCart(smallSizePrint, mediumSizePrint, largeSizePrint);
            } else if (menuOption == 3)
            {
                WriteLine("Thank you for placing an order with us");
                ReadKey();
            }
            else
            {
                WriteLine("Invalid Option");
                ReadKey();
            }
            Clear();
        }

        public static void ViewCart(PhotoPrint smallSizePrintLocal, PhotoPrint mediumSizePrintLocal, PhotoPrint largeSizePrintLocal)
        {
            WriteLine(new string('*', 20));
            WriteLine("{0,14}", "View Cart");
            WriteLine(new string('*', 20));
            //WriteLine("== View Cart ==");
            WriteLine(smallSizePrintLocal.ToString());
            WriteLine(new string('-', 20));
            WriteLine(mediumSizePrintLocal.ToString());
            WriteLine(new string('-', 20));
            WriteLine(largeSizePrintLocal.ToString());
            WriteLine(new string('-', 20));

            /*The ViewCart() method takes the
            three instances of PhotoPrint as input, for each of those three instances, display
            SizeName, UnitPrice, Count and SubTotal(by calling the ToString() method defined in
            the class) for each print size*/
            ComputeOrderAmount(smallSizePrintLocal, mediumSizePrintLocal, largeSizePrintLocal, out double total1, out double tax, out double disc, out double total2);
            WriteLine("{0,12}", "Summary of order");
            //WriteLine("== Summary of order ==");
            WriteLine("Total Before Taxes and Discounts: {0:C}", total1);
            WriteLine("Discounts: {0:C}", disc);
            WriteLine("Taxes (12%): {0:C}", tax);
            WriteLine("Total After Taxes and Discounts: {0:C}", total2);
            WriteLine(new string('-', 20));

            WriteLine("\nPress a key to go back to Menu...");
            ReadKey();
            Clear();
            PerformUserAction(smallSizePrintLocal, mediumSizePrintLocal, largeSizePrintLocal);
        }

        public static void ComputeOrderAmount(PhotoPrint smallSizePrintLocal, PhotoPrint mediumSizePrintLocal, PhotoPrint largeSizePrintLocal, out double totalBeforeTandD, 
            out double taxes, out double discount, out double totalAfterTandD)
        {
            ///*This method takes the
            //three instances of PhotoPrint and gets as out parameter the total (before taxes and
            //discount), taxes, discount amount, total (after taxes and discount). 

            //Based on the sub total for the three instances passed into the method, compute the Total for the cart by summing
            //all the sub totals of the three print sizes, and then compute tax as 12 % of the Total
            //Amount(before any discount is applied)
            totalBeforeTandD = (double)smallSizePrintLocal.SubTotal + (double)mediumSizePrintLocal.SubTotal + (double)largeSizePrintLocal.SubTotal;
            discount = 0;
            //If the pre - tax total amount exceeds $50.00, then
            //the customer gets a 5 % discount on the pre - tax amount
            if (totalBeforeTandD > 50)
            {
                discount = totalBeforeTandD * 0.05;                
            }
            taxes = (totalBeforeTandD - discount) * 0.12;
            totalAfterTandD = (totalBeforeTandD - discount) + taxes;          
            
        }

        public static void UpdateCart(PhotoPrint smallSizePrintLocal, PhotoPrint mediumSizePrintLocal, PhotoPrint largeSizePrintLocal)
        {
            /*This method takes the three
            instances of PhotoPrint. It a number set of options of all three sizes (Press 1 to update
            counts for 4 X 6, 2 to update counts for 5 X 7, and so on). Depending on what number the
            user has pressed, update the count to the new number the user has inputted for that size.
            Note that the user can only update one size at a time.*/
            WriteLine(new string('*', 20));
            WriteLine("{0,14}", "Update Cart");
            WriteLine(new string('*', 20));
            //WriteLine("==Update Cart Menu ==");
            WriteLine("1 - Small size");
            WriteLine("2 - Medium size");
            WriteLine("3 - Large size");
            WriteLine(new string('-', 20));
            Write("Please select which size to update: ");
            int option = int.Parse(ReadLine());
            if(option == 1)
            {
                WriteLine("\nSet the new units for {0} size: ", smallSizePrintLocal.SizeName);
                smallSizePrintLocal.counter = int.Parse(ReadLine());
            } else if(option == 2 )
            {
                WriteLine("\nSet the new units for {0} size: ", mediumSizePrintLocal.SizeName);
                mediumSizePrintLocal.counter = int.Parse(ReadLine());
            } else if(option == 3)
            {
                WriteLine("\nSet the new units for {0} size: ", largeSizePrintLocal.SizeName);
                largeSizePrintLocal.counter = int.Parse(ReadLine());
            } else
            {
                WriteLine("Invalid Option");
                ReadKey();
            }
            WriteLine(new string('-', 20));
            WriteLine("Press a key to go back to Menu...");
            ReadKey();
            Clear();
            PerformUserAction(smallSizePrintLocal,mediumSizePrintLocal,largeSizePrintLocal);
        }

    }
}
