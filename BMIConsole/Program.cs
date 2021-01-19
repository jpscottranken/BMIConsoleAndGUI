using System;
using static System.Console;

/*
 * 
 * 	    Write a C# Console program that calculates and displays 
 * 	    a person's body mass index (BMI). The BMI is often used 
 * 	    to determine whether a person is underweight, of optimal
 * 	    weight, overweight, or obese for his or her height. 
 * 	    
 * 	    A person's BMI is calculated with the following formula: 
 * 	    
 * 	    bmi = ((weight / (Math.Pow(height, 2))) * 703.0);
 * 	    
 * 	    Where weight is measured in pounds and height is measured 
 * 	    in inches. The program should input the height and weight,
 * 	    verify that they are "valid", display a message indicating 
 * 	    whether the person underweight, of optimal weight, over-
 * 	    weight, or obese.
 * 	    
 * 	    A person is considered underweight if his or her BMI
 * 	    is < 18.5.
 * 	    
 * 	    A person is considered to be of optimal weight if his
 * 	    or her BMI is >= 18.5 and < 25.
 * 	    
 * 	    A person is considered overweight if his or her BMI
 * 	    is >= 25 and < 30.
 * 	    
 * 	    A person is considered obese if his or her BMI is
 * 	    >= 30.
 * 	    
 * 	    Also, in this program we have added arbitrary values
 * 	    for minimum height, maximum height, minimum weight,
 * 	    and maximum weight.
 * 	    
 * 	    We have added looping capabilities to do the following:
 * 	    
 * 	    1.	Validate height >= 12 & <= 96 (MINHEIGHT & MAXHEIGHT).
 * 	    
 * 	    2.  Validate weight >= 1 & <= 777 (MINWEIGHT & MAXWEIGHT).
 * 	    
 * 	    3.	Run the program multiple times if/as desired.
 * 	    
 * 	    Finally, the program is now designed to NOT ACCEPT
 * 	    non-numeric input for height or weight but not end
 * 	    the program.  Rather, an error message will be given.
 * 	    
 */

namespace BMIConsole
{
    class Program
    {
        //  Declare and initialize global constants
        const int MINHEIGHT = 12;
        const int MAXHEIGHT = 96;
        const int MINWEIGHT = 1;
        const int MAXWEIGHT = 777;
        const double MINOPTIMAL = 18.5;
        const double MAXOVER = 25.0;
        const double MINOBESE = 30.0;

        //  Declare and initialize global variables
        static int height = 0;
        static int weight = 0;
        static double bmi = 0.0;
        static string bmiStatus = "";

        //  This is the Main() program function.
        //  It acts as  program "driver", calling
        //  all of the other function that do the
        //  actual "work" of the program.
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                ReadLine();
                Clear();
                inputHeight();
                inputWeight();
                calculateBMI();
                calculateBMIStatus();
                displayAll();
            }
        }   //  End Main()

        //  This function lets the user input the
        //  height or the word QUIT (to end the program).
        //  The height is validated to make sure that:
        //  1) It is numeric.
        //  2) It is within range (12 - 96).
        static void inputHeight()
        {
            string hStr = "";
            bool isHeightNumeric = true;

            Write("\nPlease enter a height betweeen " +
                  MINHEIGHT + " and " + MAXHEIGHT +
                  "\nOr QUIT now to end the Program: ");
            hStr = ReadLine();

            //  Check for program terminate condition
            if (hStr.ToUpper() == "QUIT")
            {
                Environment.Exit(0);
            }

            //  Verify that the inputted height was numeric
            isHeightNumeric = isNumeric(hStr);

            //  If inputted height was not numeric,
            //  have the user input input it again.
            if (!isHeightNumeric)   // if (isHeightNumeric == false)
            {
                WriteLine("\nNon-Numeric Height Inputted!");
                inputHeight();
            }
            //  A numeric value was inputted.  Now you must
            //  verify that the inputted value was in range.
            //  If it is not within range, have them re-enter.
            else
            {
                height = Convert.ToInt32(hStr);

                if ((height < MINHEIGHT) || (height > MAXHEIGHT))
                {
                    WriteLine("\nOut-Of-Range Height Inputted!");
                    inputHeight();
                }
            }
        }

        //  This function lets the user input the
        //  weight.  The height is validated to make sure that:
        //  1) It is numeric.
        //  2) It is within range (1 - 777).
        static void inputWeight()
        {
            string wStr = "";
            bool isWeightNumeric = true;

            Write("\nPlease enter a weight betweeen " +
                  MINWEIGHT + " and " + MAXWEIGHT + " now: ");
            wStr = ReadLine();

            //  Verify that the inputted height was numeric
            isWeightNumeric = isNumeric(wStr);

            //  If inputted weight was not numeric,
            //  have the user input input it again.
            if (!isWeightNumeric)   // if (isWeightNumeric == false)
            {
                WriteLine("\nNon-Numeric Weight Inputted!");
                inputWeight();
            }
            //  A numeric value was inputted.  Now you must
            //  verify that the inputted value was in range.
            //  If it is not within range, have them re-enter.
            else
            {
                weight = Convert.ToInt32(wStr);

                if ((weight < MINWEIGHT) || (weight > MAXWEIGHT))
                {
                    WriteLine("\nOut-Of-Range Weight Inputted!");
                    inputWeight();
                }
            }
        }

        //  Return true if value passed in was numeric.
        //  Return false otherwise.
        static bool isNumeric(string input)
        {
            int test = 0;

            return int.TryParse(input, out test);
        }

        //  Calculate body mass index (BMI) using the
        //  formula shown below.
        static void calculateBMI()
        {
            bmi = ((weight / (Math.Pow(height, 2))) * 703.0);
        }

        //  Calculate BMI status of either underweight,
        //  optimal weight, overweight, or obese.
        static void calculateBMIStatus()
        {
            if (bmi < MINOPTIMAL)
            {
                bmiStatus = "UNDERWEIGHT";
            }
            else if (bmi < MAXOVER)
            {
                bmiStatus = "OPTIMAL WEIGHT";
            }
            else if (bmi < MINOBESE)
            {
                bmiStatus = "OVERWEIGHT";
            }
            else
            {
                bmiStatus = "OBSESE";
            }
        }

        //  Output all inputted values and the
        //  calculated BMI and BMI Status values.
        static void displayAll()
        {
            WriteLine("\nHeight: " + height.ToString());
            WriteLine("Weight: " + weight.ToString());
            WriteLine("BMI: " + bmi.ToString("f2"));
            WriteLine("Status: " + bmiStatus);
        }
    }
}
