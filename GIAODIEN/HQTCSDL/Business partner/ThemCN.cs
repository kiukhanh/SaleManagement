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

namespace HQTCSDL.DoiTac
{
    public partial class ThemCN : Form
    {
        string return_value_id;
        string MADT;
        public ThemCN(string madt)
        {
            MADT= madt;
            InitializeComponent();
        }

        private void Run_sp_Them_CN(string madt, string macn, string tencn, string diachi, string sdt, string tinhtrang)
        {
            SqlCommand cmd = new SqlCommand("sp_themCN_DT", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@maDT", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@maCN", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@tenCN", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@diachi", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@TINHTRANG", SqlDbType.VarChar, 15);
            

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@maDT"].Value = madt;
            cmd.Parameters["@maCN"].Value = macn;
            cmd.Parameters["@tenCN"].Value = tencn;
            cmd.Parameters["@diachi"].Value = diachi;
            cmd.Parameters["@SDT"].Value = sdt;
            cmd.Parameters["@TINHTRANG"].Value = tinhtrang;

            cmd.ExecuteNonQuery();

            return_value_id = returnParameter.Value.ToString();
        }

        private void button_themCN_Click(object sender, EventArgs e)
        {
            if (txt_tenchinhanh.Text.Trim().Length == 0 | txt_diachichinhanh.Text.Trim().Length == 0 |txt_tinhtrang.Text.Trim().Length == 0|
                txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                string sql = "SELECT COUNT(*) FROM CHINHANH_DK CNDK ";
                   
                string temp = connnection.GetFieldValues(sql);
                int count;
                count = Int32.Parse(temp) + 1;
                string macn;
                if (count < 10)
                {
                    macn = "CN000" + count;
                }
                else if (count < 100)
                {
                    macn = "CN00" + count;
                }
                else
                {
                    macn = "CN0" + count;
                }

                Run_sp_Them_CN(MADT, macn, txt_tenchinhanh.Text.Trim().ToString(), txt_diachichinhanh.Text.Trim().ToString(), txtSDT.Text.Trim().ToString(), txt_tinhtrang.Text.Trim().ToString());
                if (return_value_id.Equals("0"))
                    MessageBox.Show("Đăng kí không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txt_tenchinhanh.Text = "";
                txt_diachichinhanh.Text = "";
                txt_tinhtrang.Text = " ";
                txtSDT.Text = " ";
                //LoadData_CN();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_quaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
