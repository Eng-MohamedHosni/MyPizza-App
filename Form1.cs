using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Form1 : Form
    {
        void ResetTheForm()
        {
            gbCrustType.Enabled = true;
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrderPizza.Enabled = true;

            rbTakeout.Checked = true;
            rbMedium.Checked = true;
            rbThinCrust.Checked = true;

            chkCheese.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatoes.Checked = false;
            chkOnion.Checked = false;
            chkOlives.Checked = false;
            chkPappers.Checked = false;

            UpdateTotalPrice();
        }
        string ToppingsLabel()
        {
            string text="";

            if (chkCheese.Checked) text += chkCheese.Text+",";
            if(chkMushrooms.Checked) text += chkMushrooms.Text + ",";
            if(chkOlives.Checked) text += chkOlives.Text + ",";
            if(chkOnion.Checked) text += chkOnion.Text + ",";
            if(chkTomatoes.Checked) text += chkTomatoes.Text + ",";
            if(chkPappers.Checked) text += chkPappers.Text + ",";

            if (text.Length == 0)
                text = "No Toppings";
            else
            text=text.Substring(0, text.Length - 1);

            return text;
        }
        float CalculateSizePrice()
        {
            float Price = 0;
            if (rbSmall.Checked) Price = Convert.ToSingle(rbSmall.Tag);

            else if (rbLarge.Checked) Price = Convert.ToSingle( rbLarge.Tag);

            else  Price = Convert.ToSingle(rbMedium.Tag);

            return Price;
        }

        float CalculateToppingPrice()
        {
            float Price = 0;
            if (chkCheese.Checked) Price += Convert.ToSingle(chkCheese.Tag);
            if (chkMushrooms.Checked) Price += Convert.ToSingle(chkMushrooms.Tag);
            if (chkOlives.Checked) Price += Convert.ToSingle(chkOlives.Tag);
            if (chkOnion.Checked) Price += Convert.ToSingle(chkOnion.Tag);
            if (chkPappers.Checked) Price += Convert.ToSingle(chkPappers.Tag);
            if (chkTomatoes.Checked) Price += Convert.ToSingle(chkTomatoes.Tag);
            return Price;
        }
        float CalculateCrustTypePrice()
        {
            float Price = 0;
            if (rbThickCrust.Checked) Price = Convert.ToSingle(rbThickCrust.Tag);
            else  Price = Convert.ToSingle(rbThinCrust.Tag);
            return Price;
        }
        
        float CalculateTotalPrice()
        {
           return CalculateSizePrice()+ CalculateToppingPrice()+CalculateCrustTypePrice();
        }
        void UpdateTotalPrice()
        {
            lbPrice.Text = "$" + CalculateTotalPrice().ToString();
        }
        void UpdateSize()
        {
            lbPrice.Text = CalculateTotalPrice().ToString();
            if (rbSmall.Checked)
            {
                lbSize.Text = "Small";
                return;
            }
            if (rbMedium.Checked)
            {
                lbSize.Text = "Medium";
                return;
            }
            if (rbLarge.Checked)
            {
                lbSize.Text = "Large";
                return;
            }

        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            lbToppings.Text = ToppingsLabel();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text=rbThinCrust.Text;
            UpdateTotalPrice() ;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            lbSize.Text = gbSize.Text;   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbSmall.Checked = true;
            rbThinCrust.Checked = true;
            rbTakeout.Checked = true;
            lbPrice.Text = CalculateTotalPrice().ToString();
        }

        private void lbPrice_Click(object sender, EventArgs e)
        {

        }

       
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
               UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize() ;
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

      

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text= rbThickCrust.Text;
            UpdateTotalPrice();
        }

        private void rbEatIN_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text=rbEatIN.Text;

        }

        private void rbTakeout_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text=rbTakeout.Text;
        }

        private void chkCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkPappers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

       

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Do you want to confirm the order?", "Order Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                MessageBox.Show("Order Placed Successfully");
                gbCrustType.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                btnOrderPizza.Enabled = false;
            }
                   
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetTheForm();
        }
    }
}
