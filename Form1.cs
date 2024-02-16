using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_app_test
{
    public partial class Calculator : Form
    {

        public Calculator()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string som = "";

        bool SwitchToNum2 = false;
        bool calculated = false;

        float memory = 0;

        string prev_operator = "";

        private void button1_Click_1(object sender, EventArgs e)
        {
            updatelabel("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatelabel("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatelabel("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updatelabel("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updatelabel("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updatelabel("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            updatelabel("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            updatelabel("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            updatelabel("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            updatelabel("0");
        }

        private void add_Click(object sender, EventArgs e)
        {
            operate("+");
        }

        private void min_Click(object sender, EventArgs e)
        {
            operate("-");
        }

        private void devide_Click(object sender, EventArgs e)
        {
            operate("/");
        }

        private void times_Click(object sender, EventArgs e)
        {
            operate("x");
        }

        private void procent_Click(object sender, EventArgs e)
        {
            operate("%");
        }

        private void wortel_Click(object sender, EventArgs e)
        {
            operate("√");
        }



        public void operate(string operator_used)
        {
            

            if (row1.Text != "" && row3.Text != "")
            {
                row1.Text = calc(prev_operator);
                row2.Text = "";
                row3.Text = "";
                row4.Text = "";
            }


            else if (calculated == true)
            {
                row1.Text = row4.Text;
                row2.Text = "";
                row3.Text = "";
                row4.Text = "";
            }

            if (row1.Text != "" && row3.Text == "")
            {

                
                if (operator_used == "√")
                {
                    calc_wortel(row1.Text);
                }

                else
                {
                    prev_operator = operator_used;
                    row2.Text = operator_used;
                    SwitchToNum2 = true;
                    som = "";
                }
            }
        }


        public void updatelabel(string num)
        {
            if (num == "remove")
            {
                if (!string.IsNullOrEmpty(som) && row1.Text.Length > 0)
                {
                    if (SwitchToNum2 == true)
                    {
                        som = som.Remove(row3.Text.Length - 1, 1);
                    }
                    else
                    {
                        som = som.Remove(row1.Text.Length - 1, 1);
                    }

                }
                else
                {
                    
                }
                
            }
            else
            {
                som = som + num;
            }


            if (SwitchToNum2 == false)
            {
                row1.Text = som;
            }

            else if (SwitchToNum2 == true)
            {
                row3.Text = som;
            }
            
        }



        public string calc(string operator_used)
        {
            float.TryParse(row1.Text, out float num1);
            float.TryParse(row3.Text, out float num2);

            if (row1.Text != "" && row3.Text != "")
            {
                calculated = true;

                if (operator_used == "+")
                {
                    return (num1 + num2).ToString();
                }
                else if (operator_used == "-")
                {
                    return (num1 - num2).ToString();
                }
                else if (operator_used == "x")
                {
                    return (num1 * num2).ToString();
                }
                else if (operator_used == "/")
                {
                    return (num1 / num2).ToString();
                }
                else if (operator_used == "%")
                {
                    return (num1 / 100 * num2).ToString();
                }
                else
                {
                    return row1.Text;
                }

            }
            else
            {
                return row1.Text;
            }
            SwitchToNum2 = false;
            calculated = false;

        }

        private void equals_Click(object sender, EventArgs e)
        {
            row4.Text = calc(prev_operator);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void coma_Click(object sender, EventArgs e)
        {   
            updatelabel(",".ToString());
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            updatelabel("remove");
        }

        private void CE_Click(object sender, EventArgs e)
        {
            som = "";
            row3.Text = som;
        }

        private void C_Click(object sender, EventArgs e)
        {
            som = "";
            row1.Text = som;
            row2.Text = som;
            row3.Text = som;
            row4.Text = som;
            SwitchToNum2 = false;
            calculated = false;
        }

        int count = 1;
        private void MR_Click(object sender, EventArgs e)
        {
            row1.Text = memory.ToString();
            count++;

            if (count >= 2)
            {
                memory = 0;
                count = 1;
            }
        }

        private void Mplus_Click(object sender, EventArgs e)
        {
            float.TryParse(row4.Text, out float memadd);

            float MemValue = memory + memadd;

            if (memadd != 0)
            {
                row4.Text = MemValue.ToString();
                memory = memory + memadd;
            }
            

        }

        private void Mmin_Click(object sender, EventArgs e)
        {
            float.TryParse(row4.Text, out float memmin);

            float MemValue = memory - memmin;

            if (memmin != 0)
            {
                row4.Text = MemValue.ToString();
                memory = memory - memmin;
            }
            
        }

        
        public void calc_wortel(string num_str)
        {
            float.TryParse(num_str, out float num);

            row4.Text =  Math.Sqrt(num).ToString();
        }

        
    }
}
