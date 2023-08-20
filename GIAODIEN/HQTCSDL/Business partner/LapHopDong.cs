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
    public partial class LapHopDong : Form
    {
        DataTable tbl_themhd;
        string MADT;
        string return_value_themhd;

        public LapHopDong(string madt)
        {
            MADT = madt;
            InitializeComponent();

        }
        private void Reset_value()
        {
            txt_MST.Text = " ";
            txt_nganhang.Text = " ";
            txt_Ngdaidien.Text = " ";
            txt_soluong.Text = " ";
            txt_sotaikhoan.Text = " ";
            txt_thoihanhd.Text = " ";
        }
        private string Get_ngayketthuc(string thoihanhd) // set up ngày kết thúc dựa trên ngày bắt đầu và thời hạn hợp đồng
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string kq = "";
            int year_end = year + Int32.Parse(thoihanhd);


            kq = year_end.ToString() + "-" + month.ToString() + "-" + day.ToString();
            return kq;
        }
        private void LoadData_DT() //dữ liệu vào DataGridView
        {
            string sql = "SELECT * FROM HOPDONG  WHERE DOITAC = '" + MADT + "'";
            tbl_themhd = connnection.GetDataToTable(sql);
            datagid_themhd.DataSource = tbl_themhd;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_themhd.AllowUserToAddRows = false;
            datagid_themhd.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void Run_sp_Them_HD(string mahd, string mst, string ndd, int slcn, string stk, string nganhang, string ngbd, string ngkt, int tt, string doitac, int thhd)
        {
            SqlCommand cmd = new SqlCommand("insert_HOPDONG", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@MST", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ndd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@slcn", SqlDbType.Int);
            cmd.Parameters.Add("@stk", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@nganhang", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ngayBD", SqlDbType.Date);
            cmd.Parameters.Add("@ngayKT", SqlDbType.Date);
            cmd.Parameters.Add("@tinhtrang", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@doitac", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@thoihanhd", SqlDbType.Int);



            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@id"].Value = mahd;
            cmd.Parameters["@MST"].Value = mst;
            cmd.Parameters["@ndd"].Value = ndd;
            cmd.Parameters["@slcn"].Value = slcn;
            cmd.Parameters["@stk"].Value = stk;
            cmd.Parameters["@nganhang"].Value = nganhang;
            cmd.Parameters["@ngayBD"].Value = ngbd;
            cmd.Parameters["@ngayKT"].Value = ngkt;
            cmd.Parameters["@tinhtrang"].Value = tt;
            cmd.Parameters["@doitac"].Value = doitac;
            cmd.Parameters["@thoihanhd"].Value = thhd;

            cmd.ExecuteNonQuery();

            return_value_themhd = returnParameter.Value.ToString();
        }

        
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadData_DT();
        }

        private void datagid_themhd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_themCN_Click_1(object sender, EventArgs e)
        {
            if (txt_MST.Text.Trim().Length == 0 | txt_nganhang.Text.Trim().Length == 0 | txt_sotaikhoan.Text.Trim().Length == 0 |
               txt_thoihanhd.Text.Trim().Length == 0 | txt_Ngdaidien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                string kq = "";

                kq = year.ToString() + "-" + month.ToString() + "-" + day.ToString();

                string sql = "SELECT COUNT(*) FROM HOPDONG  ";

                string temp = connnection.GetFieldValues(sql);
                int count;
                count = Int32.Parse(temp) + 1;
                string maHD;
                if (count < 10)
                {
                    maHD = "HD000" + count;
                }
                else if (count < 100)
                {
                    maHD = "CN00" + count;
                }
                else
                {
                    maHD = "CN0" + count;
                }
                int soluong = Int32.Parse(txt_soluong.Text.Trim().ToString());
                Run_sp_Them_HD(maHD, txt_MST.Text.Trim().ToString(), txt_Ngdaidien.Text.Trim().ToString(), soluong, txt_sotaikhoan.Text.Trim().ToString(), txt_nganhang.Text.Trim().ToString(), kq, Get_ngayketthuc(txt_thoihanhd.Text.Trim().ToString()), 0, MADT, Int32.Parse(txt_thoihanhd.Text.Trim().ToString()));
                if (return_value_themhd.Equals("0"))
                    MessageBox.Show("Đăng kí không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                Reset_value();
                LoadData_DT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }
    }
}
    
