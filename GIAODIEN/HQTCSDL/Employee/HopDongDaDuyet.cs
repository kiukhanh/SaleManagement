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
    public partial class HopDongDaDuyet : Form
    {
        DataTable tbl_HDDD;
        public HopDongDaDuyet()
        {
            InitializeComponent();
        }

        private void LoadData_HDDD()//dữ liệu vào DataGridView
        {
            string sql = "SELECT HD.ID_HOPDONG, HD.DOITAC, DT.ID_DOITAC, DT.TEN, DT.NG_DAIDIEN, " +
                "HD.SL_CHINHANHDK, " +
                "HD.THOIHANHOPDONG, NVHD.NGAYKIKET, HD.NGAYBATDAUDK, HD.NGAYKETTHUCDK, " +
                "DATEDIFF(DAY,NVHD.NGAYKIKET,HD.NGAYKETTHUCDK) AS TGHIEULUC" +
                " FROM HOPDONG HD, DOITAC DT,NHANVIEN_HOPDONG NVHD" +
                " WHERE HD.TINHTRANG = 1 " +
                "AND HD.DOITAC = DT.ID_DOITAC AND NVHD.HOPDONG = HD.ID_HOPDONG";

            
            tbl_HDDD = connnection.GetDataToTable(sql);
            datagid_DS_HD_DD.DataSource = tbl_HDDD;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DS_HD_DD.AllowUserToAddRows = false;
            datagid_DS_HD_DD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
  
        private void HopDongDaDuyet_NV_Load(object sender, EventArgs e)
        {
            LoadData_HDDD();
        }

        private void datagid_DS_HD_DD_Click(object sender, EventArgs e) // xử lí khi click vào datagridview
        {
            //Nếu không có dữ liệu
            if (tbl_HDDD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            //txt_ngaylap.CustomFormat = "yyyy-MM-dd";
            //dTP_ngaybd_HHDDNV.CustomFormat = "yyyy-MM-dd";
            //txt_Ngàykt.CustomFormat = "yyyy-MM-dd";

            txt_MAHD.Text = datagid_DS_HD_DD.CurrentRow.Cells["ID_HOPDONG"].Value.ToString();
            txt_soluongcn.Text = datagid_DS_HD_DD.CurrentRow.Cells["SL_CHINHANHDK"].Value.ToString();
            txt_MADT.Text = datagid_DS_HD_DD.CurrentRow.Cells["ID_DOITAC"].Value.ToString();
            txt_tendoitac.Text = datagid_DS_HD_DD.CurrentRow.Cells["TEN"].Value.ToString();
            txt_nguoidaidien.Text = datagid_DS_HD_DD.CurrentRow.Cells["NG_DAIDIEN"].Value.ToString();
            //txtBox_pthoahong_HHDDNV.Text = datagid_DS_HD_DD.CurrentRow.Cells["PTHOAHONG"].Value.ToString();
            txt_thoihanhopdong.Text = datagid_DS_HD_DD.CurrentRow.Cells["THOIHANHOPDONG"].Value.ToString();
            txt_ngaylap.Text = datagid_DS_HD_DD.CurrentRow.Cells["NGAYKIKET"].Value.ToString();
            //dTP_ngaybd_HHDDNV.Text = datagid_DS_HD_DD.CurrentRow.Cells["NGAYBATDAUDK"].Value.ToString();
            txt_Ngàykt.Text = datagid_DS_HD_DD.CurrentRow.Cells["NGAYKETTHUCDK"].Value.ToString();
            txt_hieuluc.Text = datagid_DS_HD_DD.CurrentRow.Cells["TGHIEULUC"].Value.ToString();
        }

        private void txtBox_pthoahong_HHDDNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void datagid_DS_HD_DD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu không có dữ liệu
            if (tbl_HDDD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            //txt_ngaylap.CustomFormat = "yyyy-MM-dd";
            //dTP_ngaybd_HHDDNV.CustomFormat = "yyyy-MM-dd";
            //txt_Ngàykt.CustomFormat = "yyyy-MM-dd";

            txt_MAHD.Text = datagid_DS_HD_DD.CurrentRow.Cells["ID_HOPDONG"].Value.ToString();
            txt_soluongcn.Text = datagid_DS_HD_DD.CurrentRow.Cells["SL_CHINHANHDK"].Value.ToString();
            txt_MADT.Text = datagid_DS_HD_DD.CurrentRow.Cells["ID_DOITAC"].Value.ToString();
            txt_tendoitac.Text = datagid_DS_HD_DD.CurrentRow.Cells["TEN"].Value.ToString();
            txt_nguoidaidien.Text = datagid_DS_HD_DD.CurrentRow.Cells["NG_DAIDIEN"].Value.ToString();
            //txtBox_pthoahong_HHDDNV.Text = datagid_DS_HD_DD.CurrentRow.Cells["PTHOAHONG"].Value.ToString();
            txt_thoihanhopdong.Text = datagid_DS_HD_DD.CurrentRow.Cells["THOIHANHOPDONG"].Value.ToString();
            txt_ngaylap.Text = datagid_DS_HD_DD.CurrentRow.Cells["NGAYKIKET"].Value.ToString();
            //dTP_ngaybd_HHDDNV.Text = datagid_DS_HD_DD.CurrentRow.Cells["NGAYBATDAUDK"].Value.ToString();
            txt_Ngàykt.Text = datagid_DS_HD_DD.CurrentRow.Cells["NGAYKETTHUCDK"].Value.ToString();
            txt_hieuluc.Text = datagid_DS_HD_DD.CurrentRow.Cells["TGHIEULUC"].Value.ToString();
        }

        private void guna2CirclePictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void txt_nguoidaidien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
