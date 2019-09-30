using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class OrderUi : Form
    {
        OrderManager _orderRepository = new OrderManager();
        public OrderUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            

            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("quantity Can not be Empty!!!");
                return;
            }
            
            if (_orderRepository.ItemIsNameExists(itemNameTextBox.Text))
            {
                MessageBox.Show(itemNameTextBox.Text + "Already Exists! plz Enter Another Name");
                return;
            }
           
            
            bool isOrderAdded = _orderRepository.AddOrder(itemNameTextBox.Text, quantityTextBox.Text);

            if (isOrderAdded)
            {
                MessageBox.Show("Save Order");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            showDataGridView.DataSource = _orderRepository.Display();
        }

        private void showBhutton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderRepository.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(orderIdTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            if (_orderRepository.DeleteOrder(Convert.ToInt32(orderIdTextBox.Text)))
            {
                MessageBox.Show("Order Deleted");
            }
            else
            {
                MessageBox.Show("Order Not Deleted");
            }

            showDataGridView.DataSource = _orderRepository.Display();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(orderIdTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity Can not be Empty!!!");
                return;
            }
           
            if (_orderRepository.UpdateOrder(itemNameTextBox.Text, quantityTextBox.Text, Convert.ToInt32(orderIdTextBox.Text)))
            {
                
                MessageBox.Show("Order Updated");
                showDataGridView.DataSource = _orderRepository.Display();

            }
            else
            {
                MessageBox.Show(" Order Not Update");
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            DataTable dataTable = new DataTable();
            dataTable = _orderRepository.SearchOrder(itemNameTextBox.Text);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
                MessageBox.Show(itemNameTextBox.Text + " Item found");
                return;
            }
            else
            {
                MessageBox.Show("Item not found");
            }
        }
    }
}
