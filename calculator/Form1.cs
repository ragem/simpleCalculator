using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        bool operationCheck;
        bool functionCheck;
        bool clearNext;
        bool isResult;
        bool isOldText;
        string previousText;
        operations currentOperation = operations.NULL;
        enum operations
        {
            plus,
            minus,
            dalit,
            reizinat,
            kapinat,
            NULL
        }


        private void showText(string text, bool clear = true)
        {
            try
            {
                if (text.Equals("0,")) text = "0,";
               else if (double.Parse(text) == 0)
                    text = "0";
            }
            catch
            {

            }
            clearNext = clear;
            tb.Text = text;
        }



        private void updatehistory(string equation, bool pievienot = false)
        {
           // equation = Regex.Replace(equation, @"(\d+)\.\s", "$1 ");
            if (!pievienot)
                history.Text = equation;
            else
                history.Text += equation;
        }




        private double getNumber()
        {
            double number = double.Parse(tb.Text);
            return number;
        }

        private void calculateResult()
        {
            if (currentOperation == operations.NULL)
                return;

            double a = double.Parse(previousText);
            double b = double.Parse(tb.Text);
            double result;

            switch (currentOperation)
            {
                case operations.dalit:
                    result = a / b;
                    break;
                case operations.reizinat:
                    result = a * b;
                    break;
                case operations.plus:
                    result = a + b;
                    break;
                case operations.minus:
                    result = a - b;
                    break;
                case operations.kapinat:
                    result = Math.Pow(a, b);
                    break;
                default:
                    return;
            }


            operationCheck = false;
            previousText = null;
            string equation;
            if (!functionCheck)
                equation = history.Text + b.ToString();
            else
            {
                equation = history.Text;
                functionCheck = false;
            }
            updatehistory(equation);
            showText(result.ToString());
            currentOperation = operations.NULL;
            isResult = true;
        }

 
        private void numberClick(object sender, EventArgs e)
        {
            isResult = false;
            Button button = (Button)sender;

            if (tb.Text == "0")
                tb.Clear();

            string text;

            if (clearNext)
            {
                
                text = button.Text.ToString();
                isOldText = false;
            }
            else
                text = tb.Text + button.Text.ToString();

            if (!operationCheck && history.Text != "")
                updatehistory("");
            showText(text, false);
        }


        private void function(object sender, EventArgs e)
        {


            Button button = (Button)sender;
            string buttonText = button.Text.ToString();
            double number = getNumber();
            string equation = "";
            string result = "";

            switch (buttonText)
            {
                case "1/x":
                    equation = "1 / " + number;
                    double temp = 1 / number;
                    result = temp.ToString();
                    break;

                case "√":
                    equation = "√(" + number + ")";
                    result = Math.Sqrt(number).ToString();
                    break;
            }

            if (operationCheck)
            {
                equation = history.Text + equation;
                functionCheck = true;
            }

            updatehistory(equation);
            showText(result);
        }




        private void operation(object sender, EventArgs e)
        {

            if (operationCheck && !isOldText)
                calculateResult();

            Button button = (Button)sender;

            operationCheck = true;
            previousText = tb.Text;
            string buttonText = button.Text.ToString();
            string equation = previousText + " " + buttonText + " ";
            switch (buttonText)
            {
                case "/":
                    currentOperation = operations.dalit;
                    break;
                case "*":
                    currentOperation = operations.reizinat;
                    break;
                case "-":
                    currentOperation = operations.minus;
                    break;
                case "+":
                    currentOperation = operations.plus;
                    break;
                case "^":
                    currentOperation = operations.kapinat;
                    break;
            }
            updatehistory(equation);
            
            showText(tb.Text);
            isOldText = true;
        }
        private void komat_Click(object sender, EventArgs e)
        {
            if (!tb.Text.Contains(","))
            {
                string text = tb.Text += ",";
               // MessageBox.Show(text,text);
                showText(text, false);
            }
        }


        private void C_Click(object sender, EventArgs e)
        {
            tb.Text = "0";
            operationCheck = false;
            previousText = null;
            updatehistory("");
           
        }

        private void CE_Click(object sender, EventArgs e)
        {
            tb.Text = "0";
            
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (isResult)
                return;

            string text;

            if (tb.Text.Length == 1)
                text = "0";
            else
                text = tb.Text.Substring(0, tb.Text.Length - 1);

            showText(text, false);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            calculateResult();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            double number = getNumber();
            double last = double.Parse(previousText);
            double result1 = number * 0.01 * last;
            tb.Text = result1.ToString();

        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (tb.Text.Contains("-"))
                tb.Text = tb.Text.Replace("-", "");
            else tb.Text = tb.Text.Insert(0,"-");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13) { MessageBox.Show("lol","lol"); button12.PerformClick();}
            else
            switch(e.KeyChar.ToString())
            {
                case "0":
                    button0.PerformClick();
                    break;
                case "1":
                    button1.PerformClick();
                    break;
                case "2":
                    button2.PerformClick();
                    break;
                case "3":
                    button3.PerformClick();
                    break;
                case "4":
                    button4.PerformClick();
                    break;
                case "5":
                    button5.PerformClick();
                    break;
                case "6":
                    button6.PerformClick();
                    break;
                case "7":
                    button7.PerformClick();
                    break;
                case "8":
                    button8.PerformClick();
                    break;
                case "9":
                    button9.PerformClick();
                    break;
                case "+":
                    button13.PerformClick();
                    break;
                case "-":
                    button14.PerformClick();
                    break;
                case "/":
                    button16.PerformClick();
                    break;
                case "*":
                    button15.PerformClick();
                    break;
                case "^":
                    button22.PerformClick();
                    break;
            }
            tb.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
       
    }

