using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoprint1
{
    class PhotoPrint
    {
        //declaring read-only properties
        public int Width { get; }
        public int Length { get; }
        public string SizeName { get; }
        public decimal UnitPrice { get; }
        public decimal SubTotal
        {
            get { return counter * UnitPrice; }
        } //will return the total for each print size given unit price and count for that size
        public int counter;
        //public int Count { get; }
        //declaring read-write properties

        public int Counter(int counterLocal)
        {
            return counter += counterLocal;
        }
        
        public PhotoPrint() {} //dummy class declaration

        public PhotoPrint(int width, int lenght, string sizeName, decimal unitPrice) //setting locally as this are READ-only variables outside the class
        {
            Width = width;
            Length = lenght;
            SizeName = sizeName;
            UnitPrice = unitPrice;
        }
        //display each print size details of SizeName, UnitPrice, Count and SubTotal
        public override string ToString() //formatting output using concatenate signs
        {
            string outputStr = "Size: " + SizeName  + " (" + Width + " X " + Length + ") \n";
            outputStr += "Unit Price: " + UnitPrice.ToString("C") + "\n";
            outputStr += "Count: " + counter + "\n";
            outputStr += "Sub Total: " + SubTotal.ToString("C") + "\n";
            
            return outputStr;
        }
    }
}
