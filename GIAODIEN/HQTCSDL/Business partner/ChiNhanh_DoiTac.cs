using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using HQTCSDL.Admin;
using HQTCSDL.DoiTac;

namespace HQTCSDL
{
    public partial class ChiNhanh_DoiTac : Form
    {
        DataTable tbl_DoiTac_CN;
        string dt;
        public ChiNhanh_DoiTac(string madt)
        {
            InitializeComponent();
            dt = madt;
        }
        
        private void LoadData_CN()//dữ liệu vào DataGridView
        {
            string sql = "SELECT CN.ID_CHINHANH,CN.TEN_CHINHANH, CN.DIACHI,CN.SDT, CN.TINHTRANG,CN.THOIGIANMO,CN.THOIGIANDONG" +
                " FROM CHINHANH_DK CN WHERE CN.DOITAC = " + "'" + dt + "'";
            tbl_DoiTac_CN = connnection.GetDataToTable(sql);
            datagid_chinhanhdt.DataSource = tbl_DoiTac_CN;


            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_chinhanhdt.AllowUserToAddRows = false;
            datagid_chinhanhdt.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ChiNhanh_DT_Load(object sender, EventArgs e)
        {
            LoadData_CN();
        }



        private void btn_DT_ThemCN_Click(object sender, EventArgs e)
        {
           txt_tenchinhanh.Text = "";
           txt_diachichinhanh.Text= "";
           txt_tinhtrang.Text = " ";
        }

        

        

        private void datagid_chinhanhdt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_DoiTac_CN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            
           txt_tenchinhanh.Text = datagid_chinhanhdt.CurrentRow.Cells["TEN_CHINHANH"].Value.ToString();
           txt_diachichinhanh.Text = datagid_chinhanhdt.CurrentRow.Cells["DIACHI"].Value.ToString();
            txt_tinhtrang.Text = datagid_chinhanhdt.CurrentRow.Cells["TINHTRANG"].Value.ToString();
        }

        private void button_themCN_Click(object sender, EventArgs e)
        {
            ThemCN t = new ThemCN(dt);
            this.Hide();
            t.Show();
        }

        private void button_LuuCN_Click(object sender, EventArgs e)
        {
            // TH người dùng chưa nhập đầy đủ dữ liệu chưa
            if (txt_tenchinhanh.Text.Trim().Length == 0 | txt_diachichinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                string sql = "SELECT TOP 1 ID_CHINHANH FROM CHINHANH ORDER BY MACHINHANH DESC";
                string macn = connnection.GetFieldValues(sql);
                string[] elements = macn.Split('N');
                int maso = Int32.Parse(elements[1]) + 1;
                macn = "CN" + maso.ToString();

                SqlCommand cmd = new SqlCommand(" sp_themCN_DT", connnection.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // set kiểu dữ liệu
                cmd.Parameters.Add("@maDT", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@maCN", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@tenCN", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar, 50);

                // set giá trị

                cmd.Parameters["@MADT"].Value = dt.Trim();
                cmd.Parameters["@MACHINHANH"].Value = macn.Trim();
                cmd.Parameters["@DIACHI"].Value = txt_diachichinhanh.Text.Trim();
                cmd.Parameters["@TEN"].Value = txt_tenchinhanh.Text.Trim();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_tenchinhanh.Text = "";
                txt_diachichinhanh.Text = "";
                txt_tinhtrang.Text = " ";
                LoadData_CN();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
