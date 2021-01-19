using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 
 * 	    Write a C# GUI program that calculates and displays 
 * 	    a person's body mass index (BMI). The BMI is often used 
 * 	    to determine whether a person is underweight, of optimal
 * 	    weight, overweight, or obese for his or her height. 
 * 	    
 * 	    A person's BMI is calculated with the following formula: 
 * 	    
 * 	    bmi = weight * 703/height * height
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
 * 	    And do the following:
 * 	    
 * 	    1.	Validate height >= 12 & <= 96 (MINHEIGHT & MAXHEIGHT).
 * 	    
 * 	    2.  Validate weight >= 1 & <= 777 (MINWEIGHT & MAXWEIGHT).
 * 	    
 * 	    Finally, the program is now designed to NOT ACCEPT
 * 	    non-numeric input for height or weight but not end
 * 	    the program.  Rather, an error message will be given.
 * 	    
 */

namespace BMIGUI
{
    public partial class FormBMI : Form
    {
        public FormBMI()
        {
            InitializeComponent();
        }

        //  Declare and Initialize Global Constants
        const int MINHEIGHT = 12;       //  Minimum Height Allowed
        const int MAXHEIGHT = 96;       //  Maximum Height Allowed
        const int MINWEIGHT = 1;        //  Maximum Weight Allowed
        const int MAXWEIGHT = 777;      //  Minimum Height Allowed
        const double MINOPT = 18.5;     //  Minimum BMI for optimal weight
        const double MAXOVER = 25.0;    //  Maximum BMI for overweight
        const double MINOBESE = 30.0;   //  Minimum BMI for obese

        //  Declare and Initialize Global Variable
        static int height = 0;          //  Person's height
        static int weight = 0;          //  Person's weight
        static double bmi = 0.0;        //  Person's height
        static string bmiStatus = "";   //  Person's BMI status

        //  This is the function that runs when the Calculate
        //  button is clicked.  It is similar to the Main()
        //  function in the C# BMI Console Program, in that it
        //  acts like the program "driver".
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            bool keepGoing = true;      //  Program continue flag

            if (keepGoing)
            {
                keepGoing = inputHeight();
            }
            else
            {
                return;
            }

            if (keepGoing)
            {
                keepGoing = inputWeight();
            }
            else
            {
                return;
            }

            if (keepGoing)
            {
                calculateBMI();
                calculateBMIStatus();
                displayAll();
            }
            else
            {
                return;
            }
        }

        private bool inputHeight()
        {
            string hStr = "";              //  Height as a string
            bool isHeightNumeric = true;   //  Numeric height flag

            hStr = textBoxHeight.Text;

            //  Verify that the inputted height
            //  was indeed a numeric value.
            isHeightNumeric = isNumeric(hStr);

            //  If the inputted height was NOT
            //  numeric (i.e. isNumeric returned false):
            //  1) Print out an error MessageBox.
            //  2) Clear out current heightTextBox contents.
            //  3) Set the focus to this textbox.
            //  4) Return false.
            if (!isHeightNumeric)   //  if (isHeightNumeric == false)
            {
                printMessageBox("The inputted value was not numeric." +
                                "You must enter a value between 12 - 96\n",
                                "NON-NUMERIC HEIGHT INPUTTED!");
                textBoxHeight.Text = "";
                textBoxHeight.Focus();
                return false;
            }
            else
            {
                //  height inputted was numeric.
                height = Convert.ToInt32(hStr);

                //  If the inputted height was NOT
                //  within valid range (< 12 or > 96):
                //  1) Print out an error MessageBox.
                //  2) Clear out current heightTextBox contents.
                //  3) Set the focus to this textbox.
                //  4) Return false.
                if ((height < MINHEIGHT) || (height > MAXHEIGHT))
                {
                    printMessageBox("The inputted value was not out of range." +
                                    "You must enter a value between 12 - 96\n",
                                    "OUT-OF-RANGE HEIGHT INPUTTED!");
                    textBoxHeight.Text = "";
                    textBoxHeight.Focus();
                    return false;

                }

                return true;
            }
        }

        private bool inputWeight()
        {
            string wStr = "";              //  Weight as a string
            bool isWeightNumeric = true;   //  Numeric height flag

            wStr = textBoxWeight.Text;

            //  Verify that the inputted weight
            //  was indeed a numeric value.
            isWeightNumeric = isNumeric(wStr);

            //  If the inputted weight was NOT
            //  numeric (i.e. isNumeric returned false):
            //  1) Print out an error MessageBox.
            //  2) Clear out current weightTextBox contents.
            //  3) Set the focus to this textbox.
            //  4) Return false.
            if (!isWeightNumeric)   //  if (isWeightNumeric == false)
            {
                printMessageBox("The inputted value was not numeric." +
                                "You must enter a value between 1 - 777\n",
                                "NON-NUMERIC WEIGHT INPUTTED!");
                textBoxWeight.Text = "";
                textBoxWeight.Focus();
                return false;
            }
            else
            {
                //  weight inputted was numeric.
                weight = Convert.ToInt32(wStr);

                //  If the inputted weight was NOT
                //  within valid range (< 1 or > 777):
                //  1) Print out an error MessageBox.
                //  2) Clear out current weightTextBox contents.
                //  3) Set the focus to this textbox.
                //  4) Return false.
                if ((weight < MINWEIGHT) || (weight > MAXWEIGHT))
                {
                    printMessageBox("The inputted value was not out of range." +
                                    "You must enter a value between 1 - 777\n",
                                    "OUT-OF-RANGE WEIGHT INPUTTED!");
                    textBoxWeight.Text = "";
                    textBoxWeight.Focus();
                    return false;
                }

                return true;
            }
        }

        //  Function to test whether the
        //  input passed in is numeric or not
        private bool isNumeric(string input)
        {
            int test = 0;

            return int.TryParse(input, out test);
        }

        //  Function to calculate the body mass index
        //  (BMI) using the associated formula.
        private void calculateBMI()
        {
            bmi = ((weight / Math.Pow(height, 2))) * 703.0;
        }

        //  Calculate the BMI status, i.e. underweight,
        //  optimal weight, overweight, or obese.
        private void calculateBMIStatus()
        { 
            if (bmi < MINOPT)               //  BMI < 18.5
            {
                bmiStatus = "UNDERWEIGHT";
            }
            else if (bmi < MAXOVER)         //  BMI >= 18.5 but < 25.0
            {
                bmiStatus = "OPTIMAL WEIGHT";
            }
            else if (bmi < MINOBESE)        //  BMI >= 25.0 but < 30
            {
                bmiStatus = "OVERWEIGHT";
            }
            else
            {
                bmiStatus = "OBESE";
            }
        }

        private void printMessageBox(string text, string title)
        {
            MessageBox.Show(text, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void displayAll()
        {
            textBoxHeight.Text = height.ToString();
            textBoxWeight.Text = weight.ToString();
            textBoxBMI.Text = bmi.ToString("f2");
            textBoxBMIStatus.Text = bmiStatus;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxHeight.Text = "";
            textBoxWeight.Text = "";
            textBoxBMI.Text = "";
            textBoxBMIStatus.Text = "";
            textBoxHeight.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Program Now?",
                                "EXIT PROGRAM?",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
