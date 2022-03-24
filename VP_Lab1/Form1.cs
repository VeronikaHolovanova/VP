using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace VP_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateValues(null, null);
            numericUpDown_A.TextChanged += new EventHandler(UpdateValues);
            numericUpDown_B.TextChanged += new EventHandler(UpdateValues);
            numericUpDown_C.TextChanged += new EventHandler(UpdateValues);
            numericUpDown_A.Focus();
            numericUpDown_A.Select();
        }

        public void ResetValues()
        {
            label_equation.Text = "ax² + bx + c = 0";
            numericUpDown_A.Value = numericUpDown_B.Value = numericUpDown_C.Value = 0;
            textBox_discriminant.Text = "∆ = b² - 4ac = ";
            textBox_descSquareRoot.Text = "δ = √|Δ| =";
            textBox_x1.Hide();
            textBox_x2.Hide();
        }

        public void UpdateValues(object sender, EventArgs e)
        {
            try
            {
                errorProvider_main.Clear();
                if (numericUpDown_A.Value == 0)
                {
                    errorProvider_main.SetError(numericUpDown_A, "Quadratic coefficient must not be equal to 0, then the equation will be linear, not quadratic.");
                    numericUpDown_B.Enabled = numericUpDown_C.Enabled = false;
                    ResetValues();
                }
                else
                {
                    numericUpDown_B.Enabled = numericUpDown_C.Enabled = true;
                    decimal a = numericUpDown_A.Value;
                    decimal b = numericUpDown_B.Value;
                    decimal c = numericUpDown_C.Value;
                    label_equation.Text = string.Format("{0}x² + {1}x + {2} = 0", a, b, c);
                    QuadraticEquation equation = new QuadraticEquation(a, b, c);
                    textBox_discriminant.Text = "∆ = b² - 4ac = " + equation.Discriminant.ToString();
                    textBox_descSquareRoot.Text = "δ = √|Δ| = " + equation.DiscriminantSquareRoot.ToString();
                    if (equation.Discriminant > 0)
                    {
                        textBox_x1.Text = "X₁ = (-b - √Δ) / 2a ≈ " + equation.FirstRoot.RealPart.ToString();
                        textBox_x2.Text = "X₂ = (-b + √Δ) / 2a ≈ " + equation.SecondRoot.RealPart.ToString();
                        textBox_x1.Show();
                        textBox_x2.Show();
                    }
                    else if (equation.Discriminant == 0)
                    {
                        textBox_x1.Text = "X₀ = -b / 2a ≈ " + equation.FirstRoot.RealPart.ToString();
                        textBox_x2.Text = "";
                        textBox_x1.Show();
                        textBox_x2.Hide();
                    }
                    else
                    {
                        textBox_x1.Text = "X₁ = (-b + iδ) / 2a ≈ " + string.Format("{0} + {1}i",
                            equation.FirstRoot.RealPart, equation.FirstRoot.ImaginaryPart);
                        textBox_x2.Text = "X₂ = (-b + iδ) / 2a ≈ " + string.Format("{0} + ({1}i)",
                            equation.SecondRoot.RealPart, equation.SecondRoot.ImaginaryPart);
                        textBox_x1.Show();
                        textBox_x2.Show();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NEXT_Form_Main_Load(object sender, EventArgs e)
        {

        }
    }
}

