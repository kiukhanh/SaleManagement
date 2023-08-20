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
    public partial class DSDoiTac_KH : Form
    {
        DataTable tbl_DSDoitac_KH;
        private string MAACC;
        string maDT;
        public DSDoiTac_KH(string MAACC)
        {
            this.MAACC = MAACC;
            InitializeComponent();
        }

       
        private void LoadData_DSDT() // tải dữ liệu vào DataGridView
        {
            string sql = "sp_KH_XEMDT";
            tbl_DSDoitac_KH = connnection.GetDataToTable(sql);
            datagid_DS_DT.DataSource = tbl_DSDoitac_KH;

            

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DS_DT.AllowUserToAddRows = false;
            datagid_DS_DT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DSDoiTac_KH_Load(object sender, EventArgs e)
        {
            LoadData_DSDT();
        }


        private void datagid_DS_DT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_DSDoitac_KH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            txt_tenDT.Text = datagid_DS_DT.CurrentRow.Cells["TEN"].Value.ToString();
            txt_diachi.Text = datagid_DS_DT.CurrentRow.Cells["DIACHI_KD"].Value.ToString();
            txt_sochinhanh.Text = datagid_DS_DT.CurrentRow.Cells["SL_CHINHANH"].Value.ToString();
            txt_loaiamthuc.Text = datagid_DS_DT.CurrentRow.Cells["LOAI_AMTHUC"].Value.ToString();
            txt_sdt.Text = datagid_DS_DT.CurrentRow.Cells["SDT"].Value.ToString();
            maDT = datagid_DS_DT.CurrentRow.Cells["ID_DOITAC"].Value.ToString();
        }

        private void button_DUYETHD_Click(object sender, EventArgs e)
        {
            DanhSachMonAn ds_sanpham = new DanhSachMonAn(MAACC, maDT);
            this.Hide();
            ds_sanpham.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
