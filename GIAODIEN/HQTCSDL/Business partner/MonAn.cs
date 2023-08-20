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

namespace HQTCSDL
{
    public partial class MonAn : Form
    {
        DataTable tbl_DoiTac_SP;
        string MAMON;
        string MADT;
        string cn;
        string return_value_TRUE;
        public MonAn(string madt)
        {
            InitializeComponent();
            MADT = madt;
        }
        private void LoadData_SP()//dữ liệu vào DataGridView
        {
            string sql = "SELECT MA.TENMON,MA.MIEUTAMON,MA.LOAIMONAN,MA.GIA, MA.SL_TON,MA.CHINHANH," +
                "CN.TEN_CHINHANH " +
                "FROM MONAN MA, CHINHANH_DK CN " +
                "WHERE CN.ID_CHINHANH = MA.CHINHANH " +
                "AND CN.DOITAC = '" + MADT + "'";

           tbl_DoiTac_SP = connnection.GetDataToTable(sql);
           datagid_DSMA.DataSource = tbl_DoiTac_SP;

            //Không cho người dùng thêm dữ liệu trực tiếp
           datagid_DSMA.AllowUserToAddRows = false;
           datagid_DSMA.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void SanPham_DT_Load(object sender, EventArgs e)
        {
            LoadData_SP();
        }

        private void Run_SP_DT_UPDATE_GiASP(string masp, string giamoi, string loaimon,string mmt )
        {
            SqlCommand cmd = new SqlCommand("sp_updateMONAN", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@tenMA", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@mta", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@loai", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@gia", SqlDbType.Decimal, 19);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@tenMA"].Value = masp;
            cmd.Parameters["@mta"].Value = mmt;
            cmd.Parameters["@loai"].Value = loaimon;
            cmd.Parameters["@gia"].Value = giamoi;

            cmd.ExecuteNonQuery();
            return_value_TRUE = returnParameter.Value.ToString();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datagid_DSMA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_DoiTac_SP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            
            txt_chinhanh.Text = datagid_DSMA.CurrentRow.Cells["TEN_CHINHANH"].Value.ToString();
            txt_tenmon.Text = datagid_DSMA.CurrentRow.Cells["MIEUTAMON"].Value.ToString();
            txt_soluong.Text = datagid_DSMA.CurrentRow.Cells["SL_TON"].Value.ToString();
            txt_giaban.Text = datagid_DSMA.CurrentRow.Cells["GIA"].Value.ToString();
            txt_loaimon.Text = datagid_DSMA.CurrentRow.Cells["LOAIMONAN"].Value.ToString();
            MAMON = datagid_DSMA.CurrentRow.Cells["TENMON"].Value.ToString();
            //cn =datagid_DSMA.CurrentRow.Cells["CHINHANH"].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_capnhat_Click(object sender, EventArgs e)
        {
            // KT có nhập đầy đủ dữ liệu không
            if (txt_chinhanh.Text.Trim().Length == 0 | txt_soluong.Text.Trim().Length == 0
                | txt_tenmon.Text.Trim().Length == 0 | txt_giaban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Run_SP_DT_UPDATE_GiASP(MAMON, txt_giaban.Text.Trim().ToString(), txt_loaimon.Text.Trim().ToString(), txt_tenmon.Text.Trim().ToString());

            if (return_value_TRUE.Equals("0"))
                MessageBox.Show("Đăng kí không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            LoadData_SP();
            txt_giaban.Text = datagid_DSMA.CurrentRow.Cells["GIA"].Value.ToString();
            txt_tenmon.Text = datagid_DSMA.CurrentRow.Cells["MIEUTAMON"].Value.ToString();
            txt_loaimon.Text = datagid_DSMA.CurrentRow.Cells["LOAIMONAN"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
