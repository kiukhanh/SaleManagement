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
    
    public partial class DanhSachMonAn : Form
    {
        private string MAACC;
        private string maDT;
        DataTable tbl_DSSP_KH;
        string soluongmua;
        string maSP;
        string tenSP;
        string giaBan;
        
        public DanhSachMonAn(string MAACC, string maDT)
        {
            this.MAACC = MAACC;
            this.maDT = maDT;
            InitializeComponent();
        }

        
        private void LoadData_DSSP() // tải dữ liệu vào DataGridView
        {
            string sql = "sp_XEMMONAN '" + maDT + "'";                    
            tbl_DSSP_KH = connnection.GetDataToTable(sql);
            datagid_DS_DP_KH.DataSource = tbl_DSSP_KH;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DS_DP_KH.AllowUserToAddRows = false;
            datagid_DS_DP_KH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DS_SanPham_KH_Load(object sender, EventArgs e)
        {
            LoadData_DSSP();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void datagid_DS_DP_KH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu không có dữ liệu
            if (tbl_DSSP_KH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // set giá trị cho các mục 
            txt_tenmon.Text = datagid_DS_DP_KH.CurrentRow.Cells["TENMON"].Value.ToString();
            txt_soluong.Text = datagid_DS_DP_KH.CurrentRow.Cells["SL_TON"].Value.ToString();
            txt_diachi.Text = datagid_DS_DP_KH.CurrentRow.Cells["DIACHI"].Value.ToString();
            txt_giaban.Text = datagid_DS_DP_KH.CurrentRow.Cells["GIA"].Value.ToString();
            txt_mieutamon.Text = datagid_DS_DP_KH.CurrentRow.Cells["MIEUTAMON"].Value.ToString();
            txt_loaimon.Text = datagid_DS_DP_KH.CurrentRow.Cells["LOAIMONAN"].Value.ToString();

            maSP = datagid_DS_DP_KH.CurrentRow.Cells["TENMON"].Value.ToString();
            tenSP = datagid_DS_DP_KH.CurrentRow.Cells["MIEUTAMON"].Value.ToString();
            giaBan = datagid_DS_DP_KH.CurrentRow.Cells["GIA"].Value.ToString();
        }

        private void button_DUYETHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Muangay_Click(object sender, EventArgs e)
        {
            // TH người dùng chưa nhập đầy đủ dữ liệu chưa
            if (txt_nhapsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            soluongmua = txt_nhapsoluong.Text.Trim();
            if (Int32.Parse(soluongmua) > Int32.Parse(txt_soluong.Text.Trim().ToString()))
            {
                MessageBox.Show("Số lượng sản phẩm không đủ! Vui lòng nhập lại số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatHang dathang_kh = new DatHang(MAACC, maDT, maSP, tenSP, giaBan, soluongmua);
            dathang_kh.Show();
        }
    }
}
