using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD_Driving_License_Management
{
    public partial class frmLocalDrivingLicensesApplications : Form
    {
        public frmLocalDrivingLicensesApplications()
        {
            InitializeComponent();

            comboFilter.SelectedIndex = 0;

            _RefreshGridView();

        }


        private void _RefreshGridView()
        {

            AllApplications = BusinessLayer.LDLApplicationsBusinessLayer.GetAllApplications();

            dataGridView1.DataSource = AllApplications;

        }

        private void comboFilter_TextChanged(object sender, EventArgs e)
        {

            string colName = comboFilter.Text;

            if (!string.IsNullOrEmpty(colName) && dataGridView1.Columns.Contains(colName))
            {
                dataGridView1.Sort(dataGridView1.Columns[colName], ListSortDirection.Ascending);
            }


        }

        private DataTable AllApplications = new DataTable();

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            object search;

            if (tbFilter.Text.Length <= 0)
            {

                _RefreshGridView();

                return;
            }


            if (comboFilter.SelectedItem?.ToString() == "LocalDrivingLicenseApplicationID")
            {
                if (tbFilter.Text.Length > 0)
                {
                    char lastChar = tbFilter.Text[tbFilter.Text.Length - 1];

                    if (!char.IsDigit(lastChar))
                    {
                        tbFilter.Text = tbFilter.Text.Substring(0, tbFilter.Text.Length - 1);

                        tbFilter.SelectionStart = tbFilter.Text.Length;

                        return;
                    }
                }


                search = Convert.ToInt32(tbFilter.Text);

            }
            else
            {
                search = tbFilter.Text.ToString();
            }



            string columnName = comboFilter.SelectedItem.ToString();

            if (AllApplications != null && AllApplications.Columns.Contains(columnName))
            {
                DataView dv = new DataView(AllApplications);

                if (int.TryParse(search.ToString(), out int result) && (comboFilter.SelectedItem?.ToString() == "LocalDrivingLicenseApplicationID"))
                {
                    dv.RowFilter = $"{columnName} = {result}";

                }
                else
                {
                    dv.RowFilter = $"{columnName} LIKE '{search}%'";
                }

                dataGridView1.DataSource = dv;
            }
        }


    }
}
