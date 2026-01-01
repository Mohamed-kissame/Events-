using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsArgs_Exercice
{
    public partial class MyOrder : UserControl
    {
        public MyOrder()
        {
            InitializeComponent();
        }

        public class OrderEventArgs : EventArgs
        {

            public int OrderID { get; }
            public double TotalAmount { get; }

            public OrderEventArgs(int OrderID , double TotalAmount)
            {

                this.OrderID = OrderID;
                this.TotalAmount = TotalAmount;

            }


        }

        public event EventHandler<OrderEventArgs> OrderCompleted;


        public void CompleteOrder(int id, double total)
        {

            CompleteOrder(new OrderEventArgs(id, total));


        }

        protected virtual void CompleteOrder(OrderEventArgs e)
        {

            OrderCompleted.Invoke(this, e);

        }


        private void MyOrder_Load(object sender, EventArgs e)
        {


        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            int OrderId = Convert.ToInt32(txtId.Text);
            double TotalAmount = Convert.ToDouble(txtTotalAmount.Text);


            if (OrderCompleted != null)
            {

                CompleteOrder(OrderId, TotalAmount);

            }

        }
    }
}
