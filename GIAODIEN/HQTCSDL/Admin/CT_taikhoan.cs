using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL.Admin
{
    public partial class CT_taikhoan : Form
    {
        string maacc;
        string loaiacc;
        public CT_taikhoan(string MACCC,string LOAIACC)
        {
            maacc = MACCC;
            loaiacc = LOAIACC;
            InitializeComponent();
        }

        DataTable tbl_account_acc;
        private void Load_Data() // tải dữ liệu vào DataGridView
        {
            if (loaiacc.Equals("0"))
            {
                string sql = "SELECT DT.* FROM DOITAC DT WHERE DT.ID_DOITAC ='"+ maacc +"'";
                tbl_account_acc = connnection.GetDataToTable(sql);
                datagid_DSTK.DataSource = tbl_account_acc;


                //Không cho người dùng thêm dữ liệu trực tiếp
                datagid_DSTK.AllowUserToAddRows = false;
                datagid_DSTK.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else if(loaiacc.Equals("1"))
            {
                string sql = "SELECT KH.* FROM KHACHHANG KH WHERE KH.ID_KHACHHANG ='" + maacc + "'";
                tbl_account_acc = connnection.GetDataToTable(sql);
                datagid_DSTK.DataSource = tbl_account_acc;


                //Không cho người dùng thêm dữ liệu trực tiếp
                datagid_DSTK.AllowUserToAddRows = false;
                datagid_DSTK.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else if (loaiacc.Equals("2"))
            {
                string sql = "SELECT TX.* FROM TAIXE TX WHERE TX.ID_TAIXE ='" + maacc + "'";
                tbl_account_acc = connnection.GetDataToTable(sql);
                datagid_DSTK.DataSource = tbl_account_acc;


                //Không cho người dùng thêm dữ liệu trực tiếp
                datagid_DSTK.AllowUserToAddRows = false;
                datagid_DSTK.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else if (loaiacc.Equals("3"))
            {
                string sql = "SELECT NV.* FROM NHANVIEN WHERE NV. ='" + maacc + "'";
                tbl_account_acc = connnection.GetDataToTable(sql);
                datagid_DSTK.DataSource = tbl_account_acc;


                //Không cho người dùng thêm dữ liệu trực tiếp
                datagid_DSTK.AllowUserToAddRows = false;
                datagid_DSTK.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void CT_taikhoan_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void datagid_DSTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
