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
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        // Method for adding items to a list.
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
                        row.Cells[1].Value = item.Quantity + 1;
                        row.Cells[2].Value = item.Amount + amount;
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
    }
}