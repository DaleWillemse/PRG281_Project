namespace PRG281_Project
{
    public partial class Form1 : Form
    {
        int total = 0;
        int amtPaid = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("Master Card");
            cboPayment.Items.Add("Visa Card");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cboPayment.Text == "")
            {
                MessageBox.Show("Please choose a payment method.");
            }
            else
            {
                int paymethod = cboPayment.SelectedIndex;

                switch (paymethod)
                {
                    case 0:
                        if (txtAmountPaid.Text == "")
                        {
                            MessageBox.Show("Please enter the amount the customer paid");
                        }
                        else
                        {
                            amtPaid = Convert.ToInt32(txtAmountPaid.Text);
                            if (amtPaid < total)
                            {
                                MessageBox.Show("Please pay correct amount!");
                                txtAmountPaid.Text = "";
                            }
                            else if (amtPaid >= total)
                            {
                                int change = amtPaid - total;
                                lblChangeDisp.Text = "R" + change.ToString();
                            }
                        }
                        break;

                    case 1:
                        amtPaid = Convert.ToInt32(total);
                        txtAmountPaid.Text = "R" + amtPaid.ToString();
                        lblChangeDisp.Text = "R0.00";
                        break;

                    case 2:
                        amtPaid = Convert.ToInt32(total);
                        txtAmountPaid.Text = "R" + amtPaid.ToString();
                        lblChangeDisp.Text = "R0.00";
                        break;
                }
            }

            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAmountPaid.Text = "";
            lblChangeDisp.Text = "";
            lblTotal.Text = "";
            cboPayment.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            lblTotalDisp.Text = "";
            total = 0;
            amtPaid = 0;
        }
        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1 && dataGridView1.Rows != null)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
                //total = total - Convert.ToInt32(dataGridView1.SelectedRows[rowIndex].Cells[2].Value);
            }
            else
            {
                MessageBox.Show("There is no item selected.");
            }
        }
        
        /* 
         * Method for adding items to a list of class "Items".
         * Displays item name, quantity and total cost in dataGridView1.
         */
        public void AddItem(string name, int quantity, int amount)
        {
            List<Items> itemsList = new List<Items>();
            bool found = false;

            itemsList.Add(new Items
            {
                Name = name,
                Quantity = quantity,
                Amount = amount
            });

            foreach (Items item in itemsList)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    
                    if (row.Cells[0].Value == item.Name)
                    {
                        int currentQty = Convert.ToInt32(row.Cells[1].Value);
                        int currentAmount = Convert.ToInt32(row.Cells[2].Value);
                        row.Cells[1].Value = currentQty + 1;
                        row.Cells[2].Value = currentAmount + amount;
                        found = true;
                    }
                }

                total = total + amount;
                lblTotalDisp.Text = "R" + total.ToString();

                if (found == false)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item.Name;
                    dataGridView1.Rows[n].Cells[1].Value = item.Quantity;
                    dataGridView1.Rows[n].Cells[2].Value = item.Amount;
                }
            }
        }
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            

        }
        private void btnDrinks1_Click(object sender, EventArgs e)
        {
            string name = "Appletizer";
            int quantity = 1;
            int amount = 25;
            AddItem(name, quantity, amount);

        }
        
        private void btnDrinks2_Click(object sender, EventArgs e)
        {
            string name = "Oros Bottle";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }

        private void btnSnacks1_Click(object sender, EventArgs e)
        {
            string name = "Lays / Simba";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }
        private void btnSnacks2_Click_1(object sender, EventArgs e)
        {
            string name = "Doritos / Fritos";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }
        private void btnSnacks3_Click_1(object sender, EventArgs e)
        {
            string name = "Flings / Cheese Curls";
            int quantity = 1;
            int amount = 5;
            AddItem(name, quantity, amount);
        }

        private void btnSnacks4_Click(object sender, EventArgs e)
        {
            string name = "Corn Nibs";
            int quantity = 1;
            int amount = 5;
            AddItem(name, quantity, amount);
        }
        private void btnSnacks5_Click_1(object sender, EventArgs e)
        {
            string name = "Good Morning Biscuits";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }
        private void btnSnacks6_Click_1(object sender, EventArgs e)
        {
            string name = "Bar One 40g";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }


        private void btnDrinks3_Click(object sender, EventArgs e)
        {
            string name = "Cooldrink Bottle";
            int quantity = 1;
            int amount = 20;
            AddItem(name, quantity, amount);
        }

        private void btnSnacks7_Click_1(object sender, EventArgs e)
        {
            string name = "Jelly Tots Big";
            int quantity = 1;
            int amount = 20;
            AddItem(name, quantity, amount);
        }

        private void btnDrinks4_Click(object sender, EventArgs e)
        {
            string name = "Cooldrink Can";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }
        private void btnSnacks8_Click_1(object sender, EventArgs e)
        {
            string name = "5 Star";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        private void btnDrinks5_Click(object sender, EventArgs e)
        {
            string name = "Flavoured Water";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        private void btnDrinks6_Click(object sender, EventArgs e)
        {
            string name = "Ice Tea Bottle";
            int quantity = 1;
            int amount = 20;
            AddItem(name, quantity, amount);
        }

        private void btnDrinks7_Click(object sender, EventArgs e)
        {
            string name = "Ice Tea Can";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }
        private void btnSnacks9_Click_1(object sender, EventArgs e)
        {
            string name = "Sour Punks";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        private void btnDrinks8_Click(object sender, EventArgs e)
        {
            string name = "Still Water 330ml";
            int quantity = 1;
            int amount = 5;
            AddItem(name, quantity, amount);
        }

        private void btnDrinks9_Click(object sender, EventArgs e)
        {
            string name = "Still Water 500ml";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }

        private void btnDrinks10_Click(object sender, EventArgs e)
        {
            string name = "Sparkling Water 330ml";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }
        private void btnSnacks10_Click_1(object sender, EventArgs e)
        {
            string name = "Jelly Sweets Assorted";
            int quantity = 1;
            int amount = 13;
            AddItem(name, quantity, amount);
        }

    }
}