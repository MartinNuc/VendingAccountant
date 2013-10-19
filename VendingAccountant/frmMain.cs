using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VendingAccountant.Utils;
using VendingAccountant.VendingServerService;

namespace VendingAccountant
{
    public partial class frmMain : Form
    {
        private const int ITEMS_ON_PAGE = 40;

        private int page = 1;
        private int maxPage;

        public frmMain()
        {
            InitializeComponent();
        }

        private void RefreshAsync()
        {
            if (bwDataLoader.IsBusy == false)
            {
                bwDataLoader.RunWorkerAsync();
            }
        }

        private void bwDataLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            RefreshData();
        }


        private void RefreshData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id", typeof (long)));
            dt.Columns.Add(new DataColumn("Datum", typeof (DateTime)));
            dt.Columns.Add(new DataColumn("Technik", typeof(String)));
            dt.Columns.Add(new DataColumn("Automat", typeof (String)));
            dt.Columns.Add(new DataColumn("Zboží", typeof (String)));
            dt.Columns.Add(new DataColumn("Vybraná částka", typeof(int)));
            dt.Columns.Add(new DataColumn("Stav počítadla", typeof(int)));

            maxPage = ((int) VendingService.getService().getServiceVisitCount() - 1)/ITEMS_ON_PAGE + 1;
            var visits = VendingService.getService().getLastServiceVisits(page, ITEMS_ON_PAGE);
            if (visits != null)
            {
                foreach (serviceVisitDTO visit in visits)
                {
                    userDTO technician = VendingService.getService().getUserDetail(visit.userId);
                    String summary = "";
                    if (visit.items != null)
                    {
                        foreach (var item in visit.items)
                        {
                            summary += item.count + "x " + item.name + ", ";
                        }
                    }
                    dt.Rows.Add(visit.id, Utils.Utils.JavaUnixTimeStampToDateTime(visit.timestamp), technician.name, visit.machine.name,
                        summary, visit.withdrawnCash, visit.totalCounterState);
                }
            }
            ConcurrentHelper.Manipulate<DataGridView>(dgvServiceVisits, item => item.DataSource = dt);

            updatePagination();
        }

        private void updatePagination()
        {
            lbPage.Text = page + @" / " + maxPage;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RefreshAsync();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshAsync();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                RefreshAsync();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (page < maxPage)
            {
                page++;
                RefreshAsync();
            }
        }

        private void dgvServiceVisits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            var id = int.Parse(dgvServiceVisits.Rows[e.RowIndex].Cells[0].Value.ToString());
            setWithdrawnCashValue(id);
        }

        private long getSelectedMachineId()
        {
            int rowId = dgvServiceVisits.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            DataGridViewRow row = dgvServiceVisits.Rows[rowId];

            return long.Parse(row.Cells["id"].Value.ToString());
        }

        private void setWithdrawnCashValue()
        {
            setWithdrawnCashValue(getSelectedMachineId());
        }

        private void setWithdrawnCashValue(long id)
        {
            try
            {
                int withdrawnCash = 0;
                int totalCounterState = 0;
                string value = "";
                if (Utils.Utils.InputBox("Vybraná částka", "Kolik bylo z automatu vybráno?", ref value) ==
                    DialogResult.OK)
                {
                    withdrawnCash = int.Parse(value);
                    value = "";
                    if (Utils.Utils.InputBox("Stav počítadla", "Jaký byl stav počítadla?", ref value) ==
                        DialogResult.OK)
                    {
                        totalCounterState = int.Parse(value);
                        VendingService.getService().setCashWithdrawnForVisit(id, withdrawnCash, totalCounterState);
                        RefreshAsync();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            setWithdrawnCashValue();
        }
    }
}
