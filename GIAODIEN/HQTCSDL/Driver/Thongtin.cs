using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL
{
    
    public partial class Thongtin : Form
    {
        string return_value_true , return_value_true_1;
        string matx;
        string hoten, cmnd, diachi, sdt, bsxe, kvhd, stk, nganhang;
        string phithuechan;

        private void button_capnhatthongtin_Click(object sender, EventArgs e)
        {
            hoten = txt_hoten.Text;
            cmnd = txt_cmnd.Text;
            diachi = txt_diachi.Text;
            kvhd = txt_khuvuchoatdong.Text;
            bsxe = txt_biensoxe.Text;
            sdt = txt_sdt.Text;
            stk = txt_stk.Text;
            phithuechan = txt_thechan.Text;
            nganhang = txt_nganhang.Text;
            if (hoten.Trim().Length == 0 | cmnd.Trim().Length == 0 | diachi.Trim().Length == 0 |
                kvhd.Trim().Length == 0 | bsxe.Trim().Length == 0 | sdt.Trim().Length == 0 | stk.Trim().Length == 0 | nganhang.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_TX_Update(matx, hoten, cmnd, sdt, diachi, bsxe, kvhd, stk, nganhang, phithuechan);

                if (return_value_true_1.Equals("0"))
                    MessageBox.Show("Cập nhật không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                hoten = " ";
                cmnd = " ";
                diachi = " ";
                kvhd = " ";
                bsxe = " ";
                sdt = " ";
                stk = " ";
                phithuechan = " ";
                nganhang = " ";
                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Load_Data();
        }

        DataTable tbl_TT_TX;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_TT_TX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // set giá trị cho các mục            

            txt_hoten.Text= datagid_ttTX.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_cmnd.Text = datagid_ttTX.CurrentRow.Cells["CMND"].Value.ToString();
            txt_diachi.Text= datagid_ttTX.CurrentRow.Cells["DIACHI"].Value.ToString();
            txt_sdt.Text= datagid_ttTX.CurrentRow.Cells["SDT"].Value.ToString();
            txt_biensoxe.Text= datagid_ttTX.CurrentRow.Cells["BIENSOXE"].Value.ToString();
            txt_khuvuchoatdong.Text= datagid_ttTX.CurrentRow.Cells["KHUVUC_HOATDONG"].Value.ToString();
            txt_stk.Text= datagid_ttTX.CurrentRow.Cells["SOTAIKHOAN"].Value.ToString();
            txt_nganhang.Text = datagid_ttTX.CurrentRow.Cells["NGANHANG"].Value.ToString();
            txt_thechan.Text= datagid_ttTX.CurrentRow.Cells["PHITHUECHAN"].Value.ToString();
            //cn =datagid_DSMA.CurrentRow.Cells["CHINHANH"].Value.ToString();
        }

        public Thongtin(string MaTX)
        {
            matx =  MaTX;
            InitializeComponent();
        }
        void Load_Data()
        {
            string sql = "SELECT * FROM TAIXE WHERE ID_TAIXE = '" + matx + "'";


            tbl_TT_TX = connnection.GetDataToTable(sql);
            datagid_ttTX.DataSource = tbl_TT_TX;



            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_ttTX.AllowUserToAddRows = false;
            datagid_ttTX.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Run_TX(string idtx, string hoten, string cmnd, string sdt, string diachi, string bsxe, string kvhd, string stk, string nganhang ,string phi)
        {
            SqlCommand cmd = new SqlCommand("insert_TAIXE", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id_TX", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@hoten", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@cmnd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@dchi", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@bsxe", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@kvhd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@stk", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@nganhang", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@phi", SqlDbType.Money);



            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            
            cmd.Parameters["@id_TX"].Value=idtx;
            cmd.Parameters["@hoten"].Value = hoten;
            cmd.Parameters["@cmnd"].Value = cmnd;
            cmd.Parameters["@sdt"].Value = sdt;
            cmd.Parameters["@dchi"].Value = diachi;
            cmd.Parameters["@bsxe"].Value = bsxe;
            cmd.Parameters["@kvhd"].Value = kvhd;
            cmd.Parameters["@stk"].Value = stk;
            cmd.Parameters["@nganhang"].Value = nganhang;
            cmd.Parameters["@phi"].Value = phi;

            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }
        private void Run_TX_Update(string idtx, string hoten, string cmnd, string sdt, string diachi, string bsxe, string kvhd, string stk, string nganhang, string phi)
        {
            SqlCommand cmd = new SqlCommand("update_TAIXE", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id_TX", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@hoten", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@cmnd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@dchi", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@bsxe", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@kvhd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@stk", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@nganhang", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@phi", SqlDbType.Money);



            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị

            cmd.Parameters["@id_TX"].Value = idtx;
            cmd.Parameters["@hoten"].Value = hoten;
            cmd.Parameters["@cmnd"].Value = cmnd;
            cmd.Parameters["@sdt"].Value = sdt;
            cmd.Parameters["@dchi"].Value = diachi;
            cmd.Parameters["@bsxe"].Value = bsxe;
            cmd.Parameters["@kvhd"].Value = kvhd;
            cmd.Parameters["@stk"].Value = stk;
            cmd.Parameters["@nganhang"].Value = nganhang;
            cmd.Parameters["@phi"].Value = phi;

            cmd.ExecuteNonQuery();
            return_value_true_1 = returnParameter.Value.ToString();
        }

        private void button_nhandonhang_Click(object sender, EventArgs e)
        {
            hoten = txt_hoten.Text;
            cmnd = txt_cmnd.Text;
            diachi= txt_diachi.Text;
            kvhd = txt_khuvuchoatdong.Text;
            bsxe = txt_biensoxe.Text;
            sdt= txt_sdt.Text;
            stk= txt_stk.Text;
            phithuechan= txt_thechan.Text;
            nganhang  = txt_nganhang.Text;
            if (hoten.Trim().Length == 0 | cmnd.Trim().Length == 0 | diachi.Trim().Length == 0 |
                kvhd.Trim().Length == 0| bsxe.Trim().Length==0 | sdt.Trim().Length == 0 | stk.Trim().Length == 0 | nganhang.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_TX(matx, hoten.Trim().ToString(), cmnd.Trim().ToString(), sdt.Trim().ToString(), diachi.Trim().ToString(), bsxe.Trim().ToString(), kvhd.Trim().ToString(), stk.Trim().ToString(), nganhang.Trim().ToString(),phithuechan.Trim().ToString());
               
                if (return_value_true.Equals("0"))
                    MessageBox.Show("Thêm thông tin không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                hoten = " ";
                cmnd = " ";
                diachi= " ";
                kvhd= " ";
                bsxe= " ";
                sdt= " ";
                stk= " ";
                phithuechan= " ";
                nganhang= " ";
                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }
    }
}
