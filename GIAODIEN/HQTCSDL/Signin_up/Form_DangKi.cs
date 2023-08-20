using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class Form_DangKi : Form
    {
        string return_value_id;
        public Form_DangKi()
        {
            InitializeComponent();
        }

        // xử lí quay lại
        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void Form_DangKi_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Run_sp_insert_USER(string id, string us, string ps,int loaitk)
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
            if (check_DT.Checked == true)
            {
                s = "0";
            }
            else if (check_KH.Checked == true) { s = "1"; }
            else if (check_TX.Checked == true) { s = "2"; }
            else if (check_NV.Checked == true) { s = "3"; }
            

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
                    maACC = "US000" + count;
                }
                else if (count < 100)
                {
                    maACC = "US00" + count;
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

        private void check_DT_CheckedChanged(object sender, EventArgs e)
        {
            if (check_DT.Checked == true)
            {
                check_KH.Checked = false;
                check_TX.Checked = false;
                check_NV.Checked = false;
               
            }
        }

        private void check_KH_CheckedChanged(object sender, EventArgs e)
        {
            if (check_KH.Checked == true)
            {
                check_DT.Checked = false;
                check_TX.Checked = false;
                check_NV.Checked = false;
               
            }
        }

        private void check_TX_CheckedChanged(object sender, EventArgs e)
        {
            if (check_TX.Checked == true)
            {
                check_DT.Checked = false;
                check_KH.Checked = false;
                check_NV.Checked = false;
               
            }
        }

        private void check_NV_CheckedChanged(object sender, EventArgs e)
        {
            if (check_NV.Checked == true)
            {
                check_DT.Checked = false;
                check_KH.Checked = false;
                check_TX.Checked = false;
            } 
        }

       
    }
}
