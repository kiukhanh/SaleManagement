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
    public partial class HopDong : Form
    {
        DataTable tbl_DoiTac_HD;
        DataTable tbl_ChiNhanh_HD;
        string MADT;
        public HopDong(string madt)
        {
            MADT= madt;
            InitializeComponent();
        }

        private void Reset_Data_HD()
        {
            dTp_NGAYLAP_KH_xemDH.CustomFormat = " ";
            dTP_ngayketthuc_HDHL.CustomFormat = " ";
        }

        private string tinhtrang_HD(string s)
        {
            string kq = "Chưa duyệt";
            if (s.Equals("1")) kq = "Đã duyệt";
            else if (s.Equals("2")) kq = "Đã bị hủy";
            else if (s.Equals("3"))
            {
                //textBox_thongbao_hopdong.Text = "Hợp đồng của bạn sắp hết hạn, bạn có muốn gia hạn không?";
                button_giahan.Enabled = true;
                kq = "Chờ gia hạn";
            }
            return kq;
        }

        private void LoadData_HD() // tải dữ liệu vào DataGridView
        {
            // xử lí lấy dữ liệu
            string sql = "SELECT HD.ID_HOPDONG, HD.DOITAC," +
                "HD.MST, DT.NG_DAIDIEN , HD.TINHTRANG, " +
                "NVHD.NGAYKIKET, HD.NGAYKETTHUCDK, DATEDIFF(DAY,NVHD.NGAYKIKET,HD.NGAYKETTHUCDK) AS HIEULUC " +
                "FROM HOPDONG HD,NHANVIEN_HOPDONG NVHD, DOITAC DT " +
                "WHERE HD.DOITAC = DT.ID_DOITAC AND NVHD.HOPDONG = HD.ID_HOPDONG " +
                "AND DT.ID_DOITAC ='"+MADT+"'";         
                     
            tbl_DoiTac_HD = connnection.GetDataToTable(sql);           
            datagid_DS_HDdalap.DataSource = tbl_DoiTac_HD;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DS_HDdalap.AllowUserToAddRows = false;
            datagid_DS_HDdalap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void HopDong_DT_Load(object sender, EventArgs e)
        {
            Reset_Data_HD();

            LoadData_HD();

            // ko cho người dùng nhấn nút gia hạn
            button_giahan.Enabled = false;
        }

        private void datagid_DS_HDdalap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dTp_NGAYLAP_KH_xemDH.CustomFormat = "yyyy-MM-dd";
            dTP_ngayketthuc_HDHL.CustomFormat = "yyyy-MM-dd";

            //Nếu không có dữ liệu
            if (tbl_DoiTac_HD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục    
            txt_MST.Text = datagid_DS_HDdalap.CurrentRow.Cells["MST"].Value.ToString();
            txt_Ngdaidien.Text = datagid_DS_HDdalap.CurrentRow.Cells["NG_DAIDIEN"].Value.ToString();
            txt_TT_HD.Text = tinhtrang_HD(datagid_DS_HDdalap.CurrentRow.Cells["TINHTRANG"].Value.ToString());
            dTp_NGAYLAP_KH_xemDH.Text = datagid_DS_HDdalap.CurrentRow.Cells["NGAYKIKET"].Value.ToString();
            dTP_ngayketthuc_HDHL.Text = datagid_DS_HDdalap.CurrentRow.Cells["NGAYKETTHUCDK"].Value.ToString();
            txt_Thoigianhieuluc.Text = datagid_DS_HDdalap.CurrentRow.Cells["HIEULUC"].Value.ToString();

            // tìm số chi nhánh ứng với hợp đồng được chọn
            string MAHD = datagid_DS_HDdalap.CurrentRow.Cells["ID_HOPDONG"].Value.ToString();
            string sql = "SELECT CN.ID_CHINHANH, CN.TEN_CHINHANH " +
                "FROM HOPDONG HD, CHINHANH_DK CN, DOITAC DT " +
                "WHERE HD.ID_HOPDONG = '" + MAHD + "' " +
                "AND CN.DOITAC = DT.ID_DOITAC AND DT.ID_DOITAC = HD.DOITAC";

            tbl_ChiNhanh_HD = connnection.GetDataToTable(sql);
            txt_soluong.Text = tbl_ChiNhanh_HD.Rows.Count.ToString();
        }

        private void button_xemchinhah_Click(object sender, EventArgs e)
        {
            // TH nếu chưa chọn hợp đồng nào
            if (txt_soluong.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ChiNhanh_ThuocHopDong chinhanh_thuochopdong = new ChiNhanh_ThuocHopDong();
                chinhanh_thuochopdong.tbl_ChiNhanh_CNTHD = tbl_ChiNhanh_HD;
                chinhanh_thuochopdong.Show();
            }
        }
    }
}
