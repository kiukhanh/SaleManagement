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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HQTCSDL.Admin
{
    public partial class THEM_TK : Form
    {
        string return_value_id;
        public THEM_TK()
        {
            InitializeComponent();
        }
        private void Run_sp_insert_USER(string id, string us, string ps, int loaitk)
        {
            SqlCommand cmd = new SqlCommand("insert_USER", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@loaiTK", SqlDbType.Int);


            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@id"].Value = id;
            cmd.Parameters["@username"].Value = us;
            cmd.Parameters["@pwd"].Value = ps;
            cmd.Parameters["@loaiTK"].Value = loaitk;

            cmd.ExecuteNonQuery();

            return_value_id = returnParameter.Value.ToString();
        }

        private string checkbox_role()
        {
            string s = " ";
            if (check_NV.Checked == true)
            {
                s = "3";
            }
            else if (check_ad.Checked == true) { s = "4"; }

            return s;

        }

        private void button_dangki_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim().ToString() == txt_xacnhanmk.Text.Trim().ToString())
            {
                int count = 0;
                string sql1 = "SELECT COUNT(*) FROM ACCOUNT";
                string temp = connnection.GetFieldValues(sql1);
                count = Int32.Parse(temp) + 1;
                string maACC;
                if (count < 10)
                {
                    maACC = "US00" + count;
                }
                else if (count < 100)
                {
                    maACC = "US0" + count;
                }
                else
                {
                    maACC = "US" + count;
                }

                Run_sp_insert_USER(maACC, txtUserName.Text.Trim().ToString(), txtPassword.Text.Trim().ToString(), Int32.Parse(checkbox_role()));

                if (return_value_id.Equals("0"))
                    MessageBox.Show("Đăng kí không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không trùng nhau", "Thông báo");


            this.Close();
        }


        private void check_NV_CheckedChanged(object sender, EventArgs e)
        {
            if (check_NV.Checked == true)
            {
               
                check_ad.Checked = false;
            }
        }

        private void check_ad_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ad.Checked == true)
            {

                check_NV.Checked = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
