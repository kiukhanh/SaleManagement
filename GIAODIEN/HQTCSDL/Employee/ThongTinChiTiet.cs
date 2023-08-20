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
using System.Data.SqlTypes;
using Microsoft.CSharp.RuntimeBinder;

namespace HQTCSDL
{
    public partial class ThongTinChiTiet : Form
    {
         
        DataTable tbl_TTCT_NV;
        string return_value_true;
        string return_value_true_1;
        string TENDANGNHAP;
        string MATKHAU;
        string MAACC_TTCTNV;
        string MANV;
        string id; string tennv; string email; string ngaysinh; string chucvu; string sdt; string diachi; string luong;
        public ThongTinChiTiet(string tendangnhap, string matkhau)
        {
            InitializeComponent();           
            TENDANGNHAP = tendangnhap;
            MATKHAU = matkhau;

            string sql = "SELECT NV.ID_NHANVIEN " +
                "FROM NHANVIEN NV, ACCOUNT A " +
                "WHERE A.TENDANGNHAP = '" + TENDANGNHAP + "' " +
                "AND A.MATKHAU = '" + MATKHAU + "' " +
                "AND A.MAACC = NV.ID_NHANVIEN";
            MANV = connnection.GetFieldValues(sql);
        }
        void Load_Data()
        {
            string sql = "SELECT * FROM NHANVIEN WHERE ID_NHANVIEN = '" + MANV + "'";

            tbl_TTCT_NV = connnection.GetDataToTable(sql);
            datagid_TT_NV.DataSource = tbl_TTCT_NV;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_TT_NV.AllowUserToAddRows = false;
            datagid_TT_NV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Load_Data();
        }

        private void Run_NV_TT(string id, string tennv, string email, string ngaysinh , string chucvu, string sdt,string diachi, string luong)
        {
            SqlCommand cmd = new SqlCommand("insert_NHANVIEN", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@tennv", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ngaysinh", SqlDbType.Date);
            cmd.Parameters.Add("@chucvu", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@diachi", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@luong", SqlDbType.Money);


            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị

            cmd.Parameters["@id"].Value = id;
            cmd.Parameters["@tennv"].Value = tennv;
            cmd.Parameters["@email"].Value= email;
            cmd.Parameters["@ngaysinh"].Value = ngaysinh;
            cmd.Parameters["@chucvu"].Value = chucvu;
            cmd.Parameters["@sdt"].Value = sdt;
            cmd.Parameters["@diachi"].Value = diachi;
            cmd.Parameters["@luong"].Value = luong;

            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }

        private void Run_NV_Upgrate(string id, string tennv, string email, string ngaysinh, string chucvu, string sdt, string diachi, string luong)
        {
            SqlCommand cmd = new SqlCommand("upDate_NHANVIEN", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@tennv", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ngaysinh", SqlDbType.Date);
            cmd.Parameters.Add("@chucvu", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@diachi", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@luong", SqlDbType.Money);


            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị

            cmd.Parameters["@id"].Value = id;
            cmd.Parameters["@tennv"].Value = tennv;
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@ngaysinh"].Value = ngaysinh;
            cmd.Parameters["@chucvu"].Value = chucvu;
            cmd.Parameters["@sdt"].Value = sdt;
            cmd.Parameters["@diachi"].Value = diachi;
            cmd.Parameters["@luong"].Value = luong;

            cmd.ExecuteNonQuery();
            return_value_true_1 = returnParameter.Value.ToString();
        }

        private void button_capnhatthongtin_Click(object sender, EventArgs e)
        {
            tennv = txt_hoten.Text;
            email = txt_email.Text;
            ngaysinh = dTp_NGAYLAP_KH_xemDH.Text;
            chucvu = txt_chucvu.Text;
            sdt = txt_sdt.Text;
            diachi = txt_diachi.Text;
            luong = txt_luong.Text;
            if (tennv.Trim().Length == 0 | sdt.Trim().Length == 0 | email.Trim().Length == 0 | ngaysinh.Trim().Length == 0 | chucvu.Trim().Length == 0 | diachi.Trim().Length == 0 | luong.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_NV_Upgrate(MANV, tennv.Trim().ToString(), email.Trim().ToString(), ngaysinh.Trim().ToString(), chucvu.Trim().ToString(), sdt.Trim().ToString(), diachi.Trim().ToString(), luong.Trim().ToString());

                if (return_value_true_1.Equals("0"))
                    MessageBox.Show("Cập nhật thông tin không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tennv = " ";
                sdt = " ";
                diachi = " ";
                luong = " ";
                ngaysinh = " ";
                email = " ";
                chucvu = " ";

                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

            private void button_themthongtin_Click(object sender, EventArgs e)
        {
            tennv = txt_hoten.Text;
            email = txt_email.Text;
            ngaysinh = dTp_NGAYLAP_KH_xemDH.Text;
            chucvu = txt_chucvu.Text;
            sdt = txt_sdt.Text;
            diachi = txt_diachi.Text;
            luong = txt_luong.Text;
            if (tennv.Trim().Length == 0 | sdt.Trim().Length == 0 | email.Trim().Length == 0 | ngaysinh.Trim().Length == 0 | chucvu.Trim().Length == 0 | diachi.Trim().Length == 0 | luong.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_NV_TT(MANV, tennv.Trim().ToString(), email.Trim().ToString(), ngaysinh.Trim().ToString(), chucvu.Trim().ToString(), sdt.Trim().ToString(), diachi.Trim().ToString(), luong.Trim().ToString());

                if (return_value_true.Equals("0"))
                    MessageBox.Show("Thêm thông tin không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tennv = " ";
                sdt = " ";
                diachi = " ";
                luong = " ";
                ngaysinh = " ";
                email = " ";
                chucvu = " ";

                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void datagid_TT_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_TTCT_NV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            

            txt_hoten.Text = datagid_TT_NV.CurrentRow.Cells["TENNHANVIEN"].Value.ToString();
            txt_email.Text = datagid_TT_NV.CurrentRow.Cells["EMAIL"].Value.ToString();
            txt_diachi.Text = datagid_TT_NV.CurrentRow.Cells["DIACHI"].Value.ToString();
            txt_chucvu.Text = datagid_TT_NV.CurrentRow.Cells["CHUCVU"].Value.ToString();
            txt_sdt.Text = datagid_TT_NV.CurrentRow.Cells["SDT"].Value.ToString();
            txt_diachi.Text = datagid_TT_NV.CurrentRow.Cells["DIACHI"].Value.ToString();
            dTp_NGAYLAP_KH_xemDH.Text= datagid_TT_NV.CurrentRow.Cells["NGAYSINH"].Value.ToString();
        }
    }
}
