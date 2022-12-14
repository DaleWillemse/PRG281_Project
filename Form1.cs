namespace PRG281_Project
{
    public partial class Form1 : Form
    {
        int total = 0;
        int amtPaid = 0;
        bool paid = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //Adding items to the combo box.
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("Master Card");
            cboPayment.Items.Add("Visa Card");
        }

        // Method for adding items to a list of class "Items".
        // Displays item name, quantity and total cost in dataGridView1.
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

            total += amount;
            lblTotalDisp.Text = "R" + total.ToString();

            // Loop to place order with many items
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

                if (found == false)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item.Name;
                    dataGridView1.Rows[n].Cells[1].Value = item.Quantity;
                    dataGridView1.Rows[n].Cells[2].Value = item.Amount;
                }
            }
        }

        // Method that prints whatever is in the dataGridView1.
        public void Print()
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        // Method for reseting the entire order.
        public void Reset()
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

        // Exception Handeling for payment
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
                        // If the user paid in cash, the amount paid by the client is entered and the change the client will received is calculated. 
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
                                // Here the total cost and the payment method as well as the change the customer will recieve is added to the dataGridView .
                                int h = dataGridView1.Rows.Add();
                                dataGridView1.Rows[h].Cells[1].Value = "Total:";
                                dataGridView1.Rows[h].Cells[2].Value = "R" + total.ToString();
                                int g = dataGridView1.Rows.Add();
                                dataGridView1.Rows[g].Cells[1].Value = "Pay method:";
                                dataGridView1.Rows[g].Cells[2].Value = "Cash";
                                int j = dataGridView1.Rows.Add();
                                dataGridView1.Rows[j].Cells[1].Value = "Paid:";
                                dataGridView1.Rows[j].Cells[2].Value = "R" + amtPaid.ToString();
                                int k = dataGridView1.Rows.Add();
                                dataGridView1.Rows[k].Cells[1].Value = "Change:";
                                dataGridView1.Rows[k].Cells[2].Value = lblChangeDisp.Text;
                                paid = true;
                            }

                        }
                        break;

                    case 1:
                        amtPaid = Convert.ToInt32(total);
                        txtAmountPaid.Text = "R" + amtPaid.ToString();
                        lblChangeDisp.Text = "R0.00";
                        // Here the total cost and the payment method is added to the dataGridView .
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[1].Value = "Total:";
                        dataGridView1.Rows[n].Cells[2].Value = "R" + total.ToString();
                        int i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[1].Value = "Pay method:";
                        dataGridView1.Rows[i].Cells[2].Value = "Master Card";
                        paid = true;
                        break;

                    case 2:
                        amtPaid = Convert.ToInt32(total);
                        txtAmountPaid.Text = "R" + amtPaid.ToString();
                        lblChangeDisp.Text = "R0.00";
                        // Here the total cost and the payment method is added to the dataGridView .
                        int l = dataGridView1.Rows.Add();
                        dataGridView1.Rows[l].Cells[1].Value = "Total:";
                        dataGridView1.Rows[l].Cells[2].Value = "R" + total.ToString();
                        int m = dataGridView1.Rows.Add();
                        dataGridView1.Rows[m].Cells[1].Value = "Pay method:";
                        dataGridView1.Rows[m].Cells[2].Value = "Visa Card";
                        paid = true;
                        break;
                }
            }
            if (paid == true)
            {
                Print();
                Reset();
            }
        }

        // Button to reset order or start new order
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Here the reset method for reseting the entire order is called.
            Reset();
        }

        Bitmap bitmap;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        // Button to show receipt
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Method that prints whatever is in the dataGridView1 is called to create a receipt for the order.
            Print();
        }

        // Button to remove an item
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Exception handeling if user tries to remove item if there are not any items to remove
            try
            {
                if (dataGridView1.Rows.Count > 1 && dataGridView1.Rows != null)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    total -= Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[2].Value);
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    lblTotalDisp.Text = "R" + total.ToString();
                }
                else
                {
                    MessageBox.Show("There are no items in the order.");
                }
            }
            catch
            {
                MessageBox.Show("There is no item selected.");
            }
        }

        // Item buttons.
        // Button to add Appletizer
        private void btnDrinks1_Click(object sender, EventArgs e)
        {
            string name = "Appletizer";
            int quantity = 1;
            int amount = 25;
            AddItem(name, quantity, amount);

        }

        // Button to add Oros Bottle
        private void btnDrinks2_Click(object sender, EventArgs e)
        {
            string name = "Oros Bottle";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }

        // Button to add Lays/Simba chips
        private void btnSnacks1_Click(object sender, EventArgs e)
        {
            string name = "Lays / Simba";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }

        // Button to add Doritos/Fritos
        private void btnSnacks2_Click_1(object sender, EventArgs e)
        {
            string name = "Doritos / Fritos";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }

        // Button to add Flings/Cheese Curls
        private void btnSnacks3_Click_1(object sender, EventArgs e)
        {
            string name = "Flings / Cheese Curls";
            int quantity = 1;
            int amount = 5;
            AddItem(name, quantity, amount);
        }

        // Button to add Corn Nibs
        private void btnSnacks4_Click(object sender, EventArgs e)
        {
            string name = "Corn Nibs";
            int quantity = 1;
            int amount = 5;
            AddItem(name, quantity, amount);
        }

        // Button to add Good Morning Biscuits
        private void btnSnacks5_Click_1(object sender, EventArgs e)
        {
            string name = "Good Morning Biscuits";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }

        // Button to add Bar One
        private void btnSnacks6_Click_1(object sender, EventArgs e)
        {
            string name = "Bar One 40g";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        // Button to add Cooldrink Bottle
        private void btnDrinks3_Click(object sender, EventArgs e)
        {
            string name = "Cooldrink Bottle";
            int quantity = 1;
            int amount = 20;
            AddItem(name, quantity, amount);
        }

        // Button to add Jelly Tots
        private void btnSnacks7_Click_1(object sender, EventArgs e)
        {
            string name = "Jelly Tots Big";
            int quantity = 1;
            int amount = 20;
            AddItem(name, quantity, amount);
        }

        // Button to add Cooldrink Can
        private void btnDrinks4_Click(object sender, EventArgs e)
        {
            string name = "Cooldrink Can";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        // Button to add 5 Star
        private void btnSnacks8_Click_1(object sender, EventArgs e)
        {
            string name = "5 Star";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        // Button to add Flavoured Water
        private void btnDrinks5_Click(object sender, EventArgs e)
        {
            string name = "Flavoured Water";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        // Button to add Ice Tea (bottle)
        private void btnDrinks6_Click(object sender, EventArgs e)
        {
            string name = "Ice Tea Bottle";
            int quantity = 1;
            int amount = 20;
            AddItem(name, quantity, amount);
        }

        // Button to add Ice Tea (can)
        private void btnDrinks7_Click(object sender, EventArgs e)
        {
            string name = "Ice Tea Can";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }
        
        // Button to add Sour Punks
        private void btnSnacks9_Click_1(object sender, EventArgs e)
        {
            string name = "Sour Punks";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        // Button to add Still Water (330ml)
        private void btnDrinks8_Click(object sender, EventArgs e)
        {
            string name = "Still Water 330ml";
            int quantity = 1;
            int amount = 5;
            AddItem(name, quantity, amount);
        }

        // Button to add Still Water (500ml)
        private void btnDrinks9_Click(object sender, EventArgs e)
        {
            string name = "Still Water 500ml";
            int quantity = 1;
            int amount = 10;
            AddItem(name, quantity, amount);
        }

        // Button to add Sparkling Water 
        private void btnDrinks10_Click(object sender, EventArgs e)
        {
            string name = "Sparkling Water 330ml";
            int quantity = 1;
            int amount = 15;
            AddItem(name, quantity, amount);
        }

        // Button to add Jelly Sweets Assorted
        private void btnSnacks10_Click_1(object sender, EventArgs e)
        {
            string name = "Jelly Sweets Assorted";
            int quantity = 1;
            int amount = 13;
            AddItem(name, quantity, amount);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalDisp_Click(object sender, EventArgs e)
        {

        }
        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}