using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUi
{
    class CashBoxView
    {
        CashDesk cashDesk;
        
        public Label CashNameDesk { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLength { get; set; }
        public Label LeavCustomersCount { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            CashNameDesk = new Label();
            Price = new NumericUpDown();
            QueueLength = new ProgressBar();
            LeavCustomersCount = new Label();

            CashNameDesk.AutoSize = true;
            CashNameDesk.Location = new System.Drawing.Point(x, y);
            CashNameDesk.Name = "label" + number;
            CashNameDesk.Size = new System.Drawing.Size(35, 13);
            CashNameDesk.TabIndex = number;
            CashNameDesk.Text = cashDesk.ToString();

            Price.Location = new System.Drawing.Point(x + 65, y);
            Price.Name = "NumericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 100000000000000000;

            QueueLength.Location = new System.Drawing.Point(x + 200, y);
            QueueLength.Maximum = cashDesk.MaxQueueLength;
            QueueLength.Name = "progressBar" + number;
            QueueLength.Size = new System.Drawing.Size(120, 23);
            QueueLength.TabIndex = number;
            QueueLength.Value = 0;

            LeavCustomersCount.AutoSize = true;
            LeavCustomersCount.Location = new System.Drawing.Point(x + 320, y);
            LeavCustomersCount.Name = "label2" + number;
            LeavCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeavCustomersCount.TabIndex = number;
            LeavCustomersCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action)delegate
            {
                Price.Value += e.Price;
                QueueLength.Value = cashDesk.Count;
                LeavCustomersCount.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
