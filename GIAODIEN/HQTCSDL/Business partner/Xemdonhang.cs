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
    public partial class Xemdonhang : Form
    {
        DataTable tbl_DonHang_DT;
        string MADT;
        public Xemdonhang(string madt)
        {
            MADT = madt;
            InitializeComponent();
        }
        private void LoadData_DH()//dữ liệu vào DataGridView
        {
            string sql = "SELECT DISTINCT DH.* " +
                "FROM DOITAC DT LEFT JOIN CHINHANH_DK CNDK ON DT.ID_DOITAC = CNDK.DOITAC " +
                "LEFT JOIN MONAN MA ON MA.CHINHANH = CNDK. ID_CHINHANH " +
                "LEFT JOIN CT_MONDAT CTMD ON CTMD.MONAN = MA.TENMON " +
                "LEFT JOIN DONHANG DH ON DH.ID_DONHANG = CTMD.DONHANG " +
                "WHERE DT.ID_DOITAC ='" + MADT + "'";


            tbl_DonHang_DT = connnection.GetDataToTable(sql);
            datagid_DH_DT.DataSource = tbl_DonHang_DT;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DH_DT.AllowUserToAddRows = false;
            datagid_DH_DT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Run_DH(string MADT)
        {
            SqlCommand cmd = new SqlCommand("SP_DT_DONHANG", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MADT", SqlDbType.VarChar, 15);
            
            // set giá trị
            cmd.Parameters["@MADT"].Value = MADT;
            

            cmd.ExecuteNonQuery();
            
        }
        private void SanPham_DT_Load(object sender, EventArgs e)
        {
            Run_DH(MADT);
        }


        private void datagid_DH_DT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadData_DH();
        }
    }
}
