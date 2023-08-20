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

namespace HQTCSDL
{
    public partial class ThongTinChiTiet_KH : Form
    {

        string makh;
        DataTable tbl_TT_KH;
        string return_value_true, return_value_true_1;
        string idKH; string ten; string sdt; string diachi;

        public ThongTinChiTiet_KH(string ma)
        {
            makh = ma;
            InitializeComponent();
        }

        void Load_Data()
        {
            string sql = "SELECT * FROM KHACHHANG WHERE ID_KHACHHANG = '" + makh + "'";

            tbl_TT_KH = connnection.GetDataToTable(sql);
           datagid_TT_KH.DataSource = tbl_TT_KH;

            //Không cho người dùng thêm dữ liệu trực tiếp
           datagid_TT_KH.AllowUserToAddRows = false;
           datagid_TT_KH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Load_Data();
        }

        private void button_themthongtin_Click(object sender, EventArgs e)
        {
            ten = txt_hoten.Text;
            sdt = txt_SDT.Text;
            diachi = txt_diachi.Text;
            if (ten.Trim().Length == 0 | sdt.Trim().Length == 0 | diachi.Trim().Length == 0 )
            { 
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_KH_TT(makh, ten.Trim().ToString(), sdt.Trim().ToString(), diachi.Trim().ToString());

                if (return_value_true_1.Equals("0"))
                    MessageBox.Show("Thêm thông tin không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ten = " ";
                sdt = " ";
                diachi = " ";

                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void datagid_TT_KH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_TT_KH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            

            txt_hoten.Text =datagid_TT_KH.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_SDT.Text =datagid_TT_KH.CurrentRow.Cells["SDT_KH"].Value.ToString();
            txt_diachi.Text = datagid_TT_KH.CurrentRow.Cells["DIACHI"].Value.ToString();
            
        }

        private void Run_KH_TT(string idKH, string ten, string sdt, string diachi)
        {
            SqlCommand cmd = new SqlCommand("insert_KHACHHANG", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ten", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@diachi", SqlDbType.VarChar, 15);
            
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị

            cmd.Parameters["@id"].Value = idKH;
            cmd.Parameters["@ten"].Value = ten;
            cmd.Parameters["@sdt"].Value = sdt;
            cmd.Parameters["@diachi"].Value = diachi;
           

            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }

        private void button_capnhatthongtin_Click(object sender, EventArgs e)
        {
            ten = txt_hoten.Text;
            sdt = txt_SDT.Text;
            diachi = txt_diachi.Text;
            
            
            if (ten.Trim().Length == 0 | sdt.Trim().Length == 0 | diachi.Trim().Length == 0 )
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_KH_Update(makh, ten.Trim().ToString(), sdt.Trim().ToString(), diachi.Trim().ToString());

                if (return_value_true.Equals("0"))
                    MessageBox.Show("Thêm thông tin không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ten = " ";
                sdt = " ";
                diachi = " ";

                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void Run_KH_Update(string idKH, string ten, string sdt, string diachi)
        {
            SqlCommand cmd = new SqlCommand("insert_KHACHHANG", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ten", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@diachi", SqlDbType.VarChar, 15);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị

            cmd.Parameters["@id"].Value = idKH;
            cmd.Parameters["@ten"].Value = ten;
            cmd.Parameters["@sdt"].Value = sdt;
            cmd.Parameters["@diachi"].Value = diachi;


            cmd.ExecuteNonQuery();
            return_value_true_1 = returnParameter.Value.ToString();
        }
    }
}
