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
    public partial class DonDaDat : Form
    {
        DataTable tbl_DSDonhang_KH;
        private string maacc;
        public DonDaDat(string tendangnhap)
        {
            this.maacc = tendangnhap;
            InitializeComponent();
            
        }

        private void LoadData_DSDonhang() // tải dữ liệu vào DataGridView
        {
            string sql = "SELECT DH.ID_DONHANG, CT.SOLUONG,DH.DIACHIGIAOHANG, DH.PHIVANCHUYEN," +
                "DH.TONGTIEN, DH.PHUONGTHUCTHANHTOAN, DH.NGAYLAP, DH.TRANGTHAIXULY,KH.SDT_KH " +
                "FROM DONHANG DH JOIN CT_MONDAT CT ON DH.ID_DONHANG = CT.DONHANG  " +
                "JOIN KHACHHANG KH ON KH.ID_KHACHHANG = DH.KHACHHANG " +
                "WHERE DH.KHACHHANG = '" + maacc + "'";


            tbl_DSDonhang_KH = connnection.GetDataToTable(sql);
            datagid_DS_HD_DD.DataSource = tbl_DSDonhang_KH;

           
            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DS_HD_DD.AllowUserToAddRows = false;
            datagid_DS_HD_DD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DS_DonHang_KH_Load(object sender, EventArgs e)
        {
    
            LoadData_DSDonhang();
        }


       

        private void datagid_DS_HD_DD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_DSDonhang_KH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            txt_MADH.Text = datagid_DS_HD_DD.CurrentRow.Cells["ID_DONHANG"].Value.ToString();
            txt_soluong.Text = datagid_DS_HD_DD.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txt_DCGH.Text = datagid_DS_HD_DD.CurrentRow.Cells["DIACHIGIAOHANG"].Value.ToString();
            txt_phivanchuyen.Text = datagid_DS_HD_DD.CurrentRow.Cells["PHIVANCHUYEN"].Value.ToString();
            txt_Tongtien.Text = datagid_DS_HD_DD.CurrentRow.Cells["TONGTIEN"].Value.ToString();
            txt_sdt.Text = datagid_DS_HD_DD.CurrentRow.Cells["SDT_KH"].Value.ToString();
            txt_HHHT.Text = datagid_DS_HD_DD.CurrentRow.Cells["PHUONGTHUCTHANHTOAN"].Value.ToString();
            dTp_NGAYLAP_KH_xemDH.Text = datagid_DS_HD_DD.CurrentRow.Cells["NGAYLAP"].Value.ToString();
            txt_TTGH.Text = datagid_DS_HD_DD.CurrentRow.Cells["TRANGTHAIXULY"].Value.ToString();

        }
    }
  
}
