using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<double> nums = new List<double>();
        List<string> func = new List<string>();
       // double[] nums = new double[100];
       // char[] function = new char[100];
     
        bool eqpress = false;
        bool square = false;
        bool scoregot = false;

        double result = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string btnchar = b.Text.ToString();
            if(!isspecial(btnchar)) tb.Text += b.Text.ToString();

            if (isspecial(btnchar))
            {
                
                result = double.Parse(tb.Text.ToString());
                func.Clear();
                nums.Clear();
                if (btnchar == "SQRT") result = Math.Sqrt(result);
                if (btnchar == "1/x") result = 1 / result;
                if (btnchar == "x^2") result = result*result;
                tb.Text = result.ToString();
            }
           else if (isop(btnchar))
            {
                string txt = tb.Text.ToString();
                txt = txt.Remove(txt.Length - 1);
                if(!scoregot)nums.Add(double.Parse(txt));
                func.Add(btnchar);
                
                tb.Text = "";
            }
            
            eqpress = false;
            scoregot = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string temp = tb.Text.ToString();
            temp = temp.Remove(temp.Length-1);
            tb.Text = temp;
        }

        private Boolean isspecial(string a)
        {
            if ((a.Equals("SQRT")) || (a.Equals("1/x")) || (a.Equals("x^2"))) return true;
            else return false;
            
        }

        private Boolean isop(string a)
        {
            if ((a.Equals("+")) || (a.Equals("-")) || (a.Equals("*")) || (a.Equals("/"))) return true;
            else return false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (nums.Count == func.Count) { func.RemoveAt(func.Count - 1); tb.Text = calculate().ToString(); }

                if (square) squareing(double.Parse(tb.Text.ToString()));

            if((!eqpress)|| (nums.Count == func.Count))
            {
nums.Add(double.Parse(tb.Text.ToString()));
tb.Text = calculate().ToString();

            }
            
            
            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;
        }

        private double calculate()
        {
            
            if (eqpress)
            {
                nums.Add(nums.Last());
                func.Add(func.Last());
                
            }
            
            double[] numbers = nums.ToArray();
            string[] operators = func.ToArray();
           // MessageBox.Show(string.Join(" ", numbers) + "\n" + string.Join(" ", operators), "lol");
            int i = operators.Length;
           double value = numbers[0];
            for(int k=0;k<i;k++)
            {
                
                if (operators[k] == "+") value +=numbers[k + 1];
                if (operators[k] == "-") value =value -numbers[k + 1];
                if (operators[k] == "*") value =value*numbers[k + 1];
                if (operators[k] == "/") value =value/numbers[k + 1];
               

            }
            eqpress = true;
            scoregot = true;
            return value;
        }

        private void button17_Click(object sender, EventArgs e) // CE
        {
            tb.Text = "";
        }

        private void button18_Click(object sender, EventArgs e) //C
        {
            nums.Clear();
            func.Clear();
            eqpress = false;
            scoregot = false;
            tb.Text = "";
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',') e.Handled = false;
           else if((!Char.IsNumber(e.KeyChar))&&(!Char.IsControl(e.KeyChar)))
            {
                
                 if (e.KeyChar == '+') add("+");
                else if (e.KeyChar == '-') add("-");
                else if (e.KeyChar == '*') add("*");
                else if (e.KeyChar == '/') add("/");
              
                else if (e.KeyChar == '=')
                {

                    if (nums.Count == func.Count) { func.RemoveAt(func.Count - 1); tb.Text = calculate().ToString(); }

                    if (square) squareing(double.Parse(tb.Text.ToString()));

                    if ((!eqpress) || (nums.Count == func.Count))
                    {
                        nums.Add(double.Parse(tb.Text.ToString()));
                        tb.Text = calculate().ToString();

                    }
                    tb.Text = calculate().ToString();
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                    e.Handled = true;
                }
                else if (e.KeyChar == '^')
                {
                    square = true;
                    result = double.Parse(tb.Text.ToString());
                    tb.Text = "";
                }
                else
                {
                    e.Handled = false;
                    
                }
              
                    
                

                
                 e.Handled = true;
            }
           else if ((e.KeyChar == (char)Keys.Enter))
            {
                if(square) squareing(double.Parse(tb.Text.ToString()));
                else {
                    if ((!eqpress))
                        nums.Add(double.Parse(tb.Text.ToString()));
                    tb.Text = calculate().ToString();
                    tb.SelectionStart = tb.Text.Length;
                    tb.SelectionLength = 0;
                }
            }
           
        }
        private void add(string oper)
        {
                string txt = tb.Text.ToString();
                //txt = txt.Remove(txt.Length - 1);
            //MessageBox.Show(txt,txt);
                if (!scoregot) nums.Add(double.Parse(txt));
                func.Add(oper);
                tb.Text = "";
            eqpress = false;
        }
        private void squareing(double num)
        {
            tb.Text = "";
            func.Clear();
            nums.Clear();
            result=Math.Pow(result,num);
            tb.Text = result.ToString();
            scoregot = true;
            square = false;
        }
    }
       
    }

