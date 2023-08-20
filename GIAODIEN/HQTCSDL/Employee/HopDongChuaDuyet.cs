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

namespace HQTCSDL
{
    public partial class HopDongChuaDuyet : Form
    {
        string MANV;
        string MAHD;
        DataTable tbl_HDCD;
        string return_value_DuyetHD;
        string return_value_LoaiBoHD;
        string return_value_them_HD;
        public HopDongChuaDuyet(string manv)
        {
            InitializeComponent();
            MANV = manv;
        }

        private void Reset_value()
        {
           // txt_ngaylap.CustomFormat = "";
            txt_MAHD.Text = "";
            txt_soluongcn.Text = "";
            txt_ngaylap.Text = "";
            txt_MADT.Text = "";
            txt_tendoitac.Text = "";
            txt_nguoidaidien.Text = "";
            //txtBox_pthoahong_HHCDNV.Text = "";
            txt_thoihanhopdong.Text = "";
        }
        private string Get_ngayketthuc(string thoihanhd) // set up ngày kết thúc dựa trên ngày bắt đầu và thời hạn hợp đồng
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string kq = "";
            int year_end = year + Int32.Parse(thoihanhd);


            kq = year_end.ToString() + "-" + month.ToString() + "-" + day.ToString();
            return kq;
        }

        private void LoadData_HDCD() //dữ liệu vào DataGridView
        {
            string sql = "SELECT HD.ID_HOPDONG, HD.DOITAC, DT.ID_DOITAC, DT.TEN, DT.NG_DAIDIEN, " +
                "HD.SL_CHINHANHDK, " +
                "HD.THOIHANHOPDONG, HD.NGAYBATDAUDK, HD.NGAYKETTHUCDK, " +
                "DATEDIFF(DAY,HD.NGAYBATDAUDK,HD.NGAYKETTHUCDK) AS TGHIEULUC" +
                " FROM HOPDONG HD, DOITAC DT" +
                " WHERE HD.TINHTRANG = 0 " +
                "AND HD.DOITAC = DT.ID_DOITAC ";
            tbl_HDCD = connnection.GetDataToTable(sql);
           datagid_DS_HD_CD.DataSource = tbl_HDCD;

            

            //Không cho người dùng thêm dữ liệu trực tiếp
           datagid_DS_HD_CD.AllowUserToAddRows = false;
           datagid_DS_HD_CD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    
        private void HopDongChuaDuyet_NV_Load(object sender, EventArgs e)
        {
            //txt_ngaylap.CustomFormat = " ";
            LoadData_HDCD();
        }

        
        private void Run_SP_DuyetHopDong(string manv, string mahd,string ngaybd, string ngaykt)
        {
            SqlCommand cmd = new SqlCommand("P_NHANVIENDUYETHOPDONG", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@MAHD", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@NGAYBATDAU", SqlDbType.Date);
            cmd.Parameters.Add("@NGAYKETTHUC", SqlDbType.Date);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@MANV"].Value = manv;
            cmd.Parameters["@MAHD"].Value = mahd;
            cmd.Parameters["@NGAYBATDAU"].Value = ngaybd;
            cmd.Parameters["@NGAYKETTHUC"].Value = ngaykt;
            

            cmd.ExecuteNonQuery();

            return_value_DuyetHD = returnParameter.Value.ToString();          
        }
        private void Run_sp_nhanvienhopdong(string manv, string mahd, string ngaykk)
        {
            SqlCommand cmd = new SqlCommand("P_NHANVIEN_HOPDONG", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@MAHD", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@NGAYKIKET", SqlDbType.Date);
            

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@MANV"].Value = manv;
            cmd.Parameters["@MAHD"].Value = mahd;
            cmd.Parameters["@NGAYKIKET"].Value = ngaykk;
            


            cmd.ExecuteNonQuery();

            return_value_them_HD = returnParameter.Value.ToString();
        }

        
        private void Run_SP_LoaiBoHopDong(string manv, string mahd)
        {
            SqlCommand cmd = new SqlCommand("P_NV_LOAIBOHOPDONG ", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;               

            // set kiểu dữ liệu        
            cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 15);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị        
            cmd.Parameters["@MANV"].Value = manv;
            cmd.Parameters["@MAHD"].Value = mahd;

            cmd.ExecuteNonQuery();
          
            return_value_LoaiBoHD = returnParameter.Value.ToString();
        }

        private void datagid_DS_HD_CD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Nếu không có dữ liệu
            if (tbl_HDCD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            txt_MAHD.Text = datagid_DS_HD_CD.CurrentRow.Cells["ID_HOPDONG"].Value.ToString();
            txt_soluongcn.Text = datagid_DS_HD_CD.CurrentRow.Cells["SL_CHINHANHDK"].Value.ToString();
            txt_ngaylap.Text = datagid_DS_HD_CD.CurrentRow.Cells["NGAYBATDAUDK"].Value.ToString();
            txt_MADT.Text = datagid_DS_HD_CD.CurrentRow.Cells["ID_DOITAC"].Value.ToString();
            txt_tendoitac.Text = datagid_DS_HD_CD.CurrentRow.Cells["TEN"].Value.ToString();
            txt_nguoidaidien.Text = datagid_DS_HD_CD.CurrentRow.Cells["NG_DAIDIEN"].Value.ToString();
            txt_thoihanhopdong.Text = datagid_DS_HD_CD.CurrentRow.Cells["THOIHANHOPDONG"].Value.ToString();
            MAHD = datagid_DS_HD_CD.CurrentRow.Cells["ID_HOPDONG"].Value.ToString();
        }

        private void button_DUYETHD_Click(object sender, EventArgs e)
        {
            // TH nếu chưa chọn hợp đồng nào 
            if (txt_MAHD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // hỏi người dùng có muốn duyệt không
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn duyệt hợp đồng này không?" +
                "", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // nếu đã thỏa hết các điều kiện 
            try
            {
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                string kq = "";

                kq = year.ToString() + "-" + month.ToString() + "-" + day.ToString();

                Run_SP_DuyetHopDong(MANV, txt_MAHD.Text.Trim().ToString(), kq, Get_ngayketthuc(txt_thoihanhopdong.Text.Trim().ToString())
                    );
                Run_sp_nhanvienhopdong(MANV, MAHD, kq);
                if (return_value_DuyetHD.Equals("0"))
                    MessageBox.Show("Duyệt hợp đồng thất bại!!!");
                else
                {
                    //MessageBox.Show("Duyệt hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (return_value_them_HD.Equals("1"))
                    {
                        MessageBox.Show("Duyệt hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("Thêm hợp đồng thất bại!!!"); }
                }



                LoadData_HDCD();
                Reset_value();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyệt hợp đồng Thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void button_LoaiHD_Click(object sender, EventArgs e)
        {
            // TH nếu chưa chọn hợp đồng nào 
            if (txt_MAHD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // hỏi người dùng có muốn loại bỏ hợp đồng này không
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn loại bỏ hợp đồng này không?" +
                "", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // nếu đã thỏa hết các điều kiện 
            try
            {
                Run_SP_LoaiBoHopDong(MANV, txt_MAHD.Text.Trim().ToString());

                if (return_value_LoaiBoHD.Equals("0"))
                    MessageBox.Show("Loại bỏ hợp đồng thất bại!!!");
                else MessageBox.Show("Loại bỏ hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData_HDCD();
                Reset_value();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loại bỏ hợp đồng Thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }
    }
}