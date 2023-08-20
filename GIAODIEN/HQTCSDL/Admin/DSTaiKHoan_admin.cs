using HQTCSDL.Admin;
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
    public partial class DSTaiKHoan_admin : Form
    {
        DataTable tbl_account;
        string LOAIACC = "";
        string LOAIACC1 = "";
        string TENDANGNHAP = "";
        string MATKHAU = "";
        string MAACC = "";
        string return_value_true;
        public DSTaiKHoan_admin()
        {
            InitializeComponent();
        }

        private void LoadData_DSTaiKhoan() // tải dữ liệu vào DataGridView
        {
            string sql = "SELECT MAACC, TENDANGNHAP, MATKHAU, LOAIACC FROM ACCOUNT";
            tbl_account = connnection.GetDataToTable(sql);
           datagid_DSTK.DataSource = tbl_account;


            //Không cho người dùng thêm dữ liệu trực tiếp
           datagid_DSTK.AllowUserToAddRows = false;
           datagid_DSTK.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DSTaiKHoan_admin_Load(object sender, EventArgs e)
        {
            
            LoadData_DSTaiKhoan();
        }

        private string Get_LoaiTK(string loaiacc)
        {
            string loaitk = "";
            switch (loaiacc)
            {
                case "-1":
                    {
                        loaitk = "Tài khoản bị khóa";
                        break;
                    }

                case "0":
                    {
                        loaitk = "Đối tác";
                        break;
                    }
                case "1":
                    {
                        loaitk = "Khách hàng";
                        break;
                    }
                case "2":
                    {
                        loaitk = "Tài xế";
                        break;
                    }
                case "3":
                    {
                        loaitk = "Nhân viên";
                        break;
                    }
                case "4":
                    {
                        loaitk = "Admin";
                        break;
                    }
            }
            return loaitk;
        }

        

        
            
        private void thongTinChiTiet_FormClosed(object sender, FormClosedEventArgs e)
        {
            // cập nhật lại dữ liệu khi đóng form thông tin chi tiết của 1 acc bất kì
            LoadData_DSTaiKhoan();
        }

    

        private void button_themacc_Click(object sender, EventArgs e)
        {
            Form_DangKi form_signup = new Form_DangKi();
            form_signup.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            form_signup.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_xemchitiet_Click(object sender, EventArgs e)
        {
            if (LOAIACC.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else 
            {
                CT_taikhoan thongTinChiTiet_NV = new CT_taikhoan(MAACC,LOAIACC1);
                thongTinChiTiet_NV.StartPosition = FormStartPosition.CenterScreen;
                thongTinChiTiet_NV.Show();
                thongTinChiTiet_NV.FormClosed += thongTinChiTiet_FormClosed;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datagid_DSTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_account.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            txtUserName.Text = datagid_DSTK.CurrentRow.Cells["TENDANGNHAP"].Value.ToString();
            txt_mk_dstk.Text = datagid_DSTK.CurrentRow.Cells["MATKHAU"].Value.ToString();
            txt_loaitaikhoan.Text = Get_LoaiTK(datagid_DSTK.CurrentRow.Cells["LOAIACC"].Value.ToString());
            LOAIACC1 = datagid_DSTK.CurrentRow.Cells["LOAIACC"].Value.ToString();
            MAACC = datagid_DSTK.CurrentRow.Cells["MAACC"].Value.ToString();
            LOAIACC = datagid_DSTK.CurrentRow.Cells["LOAIACC"].Value.ToString();
            TENDANGNHAP = datagid_DSTK.CurrentRow.Cells["TENDANGNHAP"].Value.ToString();
            MATKHAU = datagid_DSTK.CurrentRow.Cells["MATKHAU"].Value.ToString();
        }

        private void Run_SP_KHOAACC(string MA)
        {
            SqlCommand cmd = new SqlCommand("SP_KHOA_ACC", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@maacc", SqlDbType.VarChar, 15);
            

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@macc"].Value = MA;
           

            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }
        private void Run_XOA_ACC(string MA)
        {
            SqlCommand cmd = new SqlCommand("SP_KHOA_ACC", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@maacc", SqlDbType.VarChar, 15);


            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@macc"].Value = MA;


            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Run_SP_KHOAACC(MAACC);
            if (return_value_true.Equals("0"))
                MessageBox.Show("Thao tác không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadData_DSTaiKhoan();
        }

        private void button_khoa_Click(object sender, EventArgs e)
        {
            Run_XOA_ACC(MAACC);
            if (return_value_true.Equals("0"))
                MessageBox.Show("Xóa không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadData_DSTaiKhoan();
        }
    }
}
