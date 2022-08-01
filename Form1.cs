namespace PRG281_Project
{
    public partial class Form1 : Form
    {
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

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAmountPaid.Text = "";
            lblChangeDisp.Text = "";
            lblTotal.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            cboPayment.Text = "";

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
                if (found == false)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item.Name;
                    dataGridView1.Rows[n].Cells[1].Value = item.Quantity;
                    dataGridView1.Rows[n].Cells[2].Value = item.Amount;
                }
            }
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
    }
}