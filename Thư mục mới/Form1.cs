using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.Net.NetworkInformation;
using System.IO;
using System.Data.SqlClient;
using OfficeOpenXml;

namespace QuanLyDiemHS
{
    public partial class Form1 : Form
    {
        private bool isFileOpened = false;
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvHocSinh.DataSource = B_HocSinh.GetAllHocSinh();
        }
        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvHocSinh.Rows[e.RowIndex];
                txtHS.Text = row.Cells[0].Value.ToString();
                txtTHS.Text = row.Cells[1].Value.ToString();
                dtpNs.Text = row.Cells[2].Value.ToString();
                txtDc.Text = row.Cells[3].Value.ToString();
                txtD.Text = row.Cells[4].Value.ToString();
                txtXL.Text = row.Cells[5].Value.ToString();

            }
            catch
            {

            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string mahs = txtHS.Text;
                string tenhs = txtTHS.Text;
                DateTime ngays = dtpNs.Value;
                string diachi = txtDc.Text;
                float diem = float.Parse(txtD.Text);
                string xeploai = txtXL.Text;

                tblHocSinh hocsinh = new tblHocSinh(mahs, tenhs, ngays, diachi, diem, xeploai);
                B_HocSinh.InsertHocSinh(hocsinh);
                MessageBox.Show("Bạn đã thêm " + tenhs + " Thành công");
                dgvHocSinh.DataSource = B_HocSinh.GetAllHocSinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string mahs = txtHS.Text;
                string tenhs = txtTHS.Text;
                DateTime ngays = dtpNs.Value;
                string diachi = txtDc.Text;
                float diem = float.Parse(txtD.Text);
                string xeploai = txtXL.Text;

                tblHocSinh hocsinh = new tblHocSinh(mahs, tenhs, ngays, diachi, diem, xeploai);
                B_HocSinh.UpdateHocSinh(hocsinh);
                MessageBox.Show("Bạn đã sửa " + tenhs + " Thành công");
                dgvHocSinh.DataSource = B_HocSinh.GetAllHocSinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string mahs = txtHS.Text;
                string tenhs = txtTHS.Text;
                DateTime ngays = dtpNs.Value;
                string diachi = txtDc.Text;
                float diem = float.Parse(txtD.Text);
                string xeploai = txtXL.Text;



                tblHocSinh hocsinh = new tblHocSinh(mahs, tenhs, ngays, diachi, diem, xeploai);
                B_HocSinh.DeleteHocSinh(mahs);
                MessageBox.Show("Bạn đã xoá " + tenhs + " Thành công");
                dgvHocSinh.DataSource = B_HocSinh.GetAllHocSinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
             this.Close();
        }
        private void Export_Excel(DataGridView g, string duongdan, string tentap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for(int i = 1; i< g.Columns.Count +1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for(int i = 0; i< g.Rows.Count; i++)
            {
                for(int j = 0;j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i+2, j+1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }

            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;

        }


        private void xuấtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Export_Excel(dgvHocSinh, @"D:\", "xuatfile");

        }
        private void ImportFromExcel(string filePath)
        {
            string connectionString = "Data Source=Doug912\\SQLEXPRESS;Initial Catalog=DemoHocSinh;User ID=sa;Password=sa";


            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {

                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {

                        string MaHS = worksheet.Cells[row, 1].Value.ToString();
                        string TenHS  = worksheet.Cells[row, 2].Value.ToString();
                        string NgaySinh = worksheet.Cells[row, 3].Value.ToString();
                        string DiaChi = worksheet.Cells[row, 4].Value.ToString();
                        float Diem   = float.Parse(worksheet.Cells[row, 5].Value.ToString());
                        string XepLoai= worksheet.Cells[row, 6].Value.ToString();


                        string checkQuery = "SELECT COUNT(*) FROM HocSinh WHERE MaHS = @MaHS";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@MaHS", MaHS );
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        if (existingCount == 0)
                        {

                            string insertQuery = "INSERT INTO Human (MaHS, TenHS, NgaySinh, DiaChi, Diem, XepLoai) VALUES (@MaHS, @TenHS, @NgaySinh, @DiaChi, @Diem, @XepLoai)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@MaHS", MaHS);
                            insertCommand.Parameters.AddWithValue("@TenHS", TenHS);
                            insertCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                            insertCommand.Parameters.AddWithValue("@DiaChi", DiaChi);
                            insertCommand.Parameters.AddWithValue("@Diem", Diem);
                            insertCommand.Parameters.AddWithValue("@XepLoai", XepLoai);
                            insertCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }
            }

        }
 
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!isFileOpened)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Chọn tệp Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    isFileOpened = true;
                    ImportFromExcel(filePath);
                }
            }
        }

    
    }
}
