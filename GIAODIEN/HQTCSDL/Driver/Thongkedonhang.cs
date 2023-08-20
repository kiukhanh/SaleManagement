using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class Thongkedonhang : Form
    {
        DataTable tbl_TaiXe_TK;
        string maTX = " ";
        public Thongkedonhang(string matx)
        {
            maTX = matx;
            InitializeComponent();
        }
        private void LoadData_ThongKe()//dữ liệu vào DataGridView
        {
            string sql = "SELECT DH.* " +
                " FROM  DONHANG DH,CT_VANCHUYEN CTVC, TAIXE TX " +
                " WHERE DH.TRANGTHAIXULY  LIKE N'NHẬN ĐƠN' AND CTVC.DON = DH.ID_DONHANG " +
                "AND TX.ID_TAIXE = CTVC.TAIXE " +
                "AND TX.ID_TAIXE = '" + maTX + "'";

            
            tbl_TaiXe_TK = connnection.GetDataToTable(sql);
            datagid_ThongKe.DataSource = tbl_TaiXe_TK;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_ThongKe.AllowUserToAddRows = false;
            datagid_ThongKe.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ThongKe_TX_Load(object sender, EventArgs e)
        {
            LoadData_ThongKe();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
