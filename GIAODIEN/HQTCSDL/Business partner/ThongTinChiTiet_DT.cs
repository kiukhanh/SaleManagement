using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class ThongTinChiTiet_DT : Form
    {
        string madt;
        DataTable tbl_TT_DT;
        string return_value_true, return_value_true_1;
        string iddt; string ten; string ndd; string tp; string quan; int slcn; int sldon; string loaiat; string dchi;
        public ThongTinChiTiet_DT(string MADT)
        {
            madt = MADT;
            InitializeComponent();
        }
        void Load_Data()
        {
            string sql = "SELECT * FROM DOITAC WHERE ID_DOITAC = '" + madt + "'";

            tbl_TT_DT = connnection.GetDataToTable(sql);
            datagid_TT_DT.DataSource = tbl_TT_DT;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_TT_DT.AllowUserToAddRows = false;
            datagid_TT_DT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Load_Data();
        }
        private void Run_DT_TT(string iddt, string ten, string ndd, string tp, string quan, int slcn, int sldon, string loaiat, string dchi)
        {
            SqlCommand cmd = new SqlCommand("insert_DOITAC", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ten", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ndd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@tpho", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@quan", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@slcn", SqlDbType.Int);
            cmd.Parameters.Add("@sl_don", SqlDbType.Int);
            cmd.Parameters.Add("@loaAT", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@dchi", SqlDbType.VarChar, 15);
           



            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị

            cmd.Parameters["@id"].Value = iddt;
            cmd.Parameters["@ten"].Value= ten;
            cmd.Parameters["@ndd"].Value = ndd;
            cmd.Parameters["@tpho"].Value = tp;
            cmd.Parameters["@quan"].Value = quan;
            cmd.Parameters["@slcn"].Value = slcn;
            cmd.Parameters["@sl_don"].Value = sldon;
            cmd.Parameters["@loaAT"].Value = loaiat;
            cmd.Parameters["@dchi"].Value = dchi;

            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }

        private void button_themthongtin_Click(object sender, EventArgs e)
        {
            ten = txt_hoten.Text;
            ndd = txt_nguoidaidien.Text;
            tp = txt_thanhpho.Text;
            quan = txt_quan.Text;
            slcn = Int32.Parse(txt_slcn.Text);
            sldon= Int32.Parse(txt_soluongdon.Text);
            loaiat= txt_loaiamthuc.Text;
            dchi=txt_diachi.Text;
            if (ten.Trim().Length == 0 | ndd.Trim().Length == 0 | tp.Trim().Length == 0 |
                quan.Trim().Length == 0 | slcn == 0 | sldon== 0 | loaiat.Trim().Length == 0 | dchi.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_DT_TT(madt, ten.Trim().ToString(), ndd.Trim().ToString(), tp.Trim().ToString(), quan.Trim().ToString(), slcn, sldon, loaiat, dchi);

                if (return_value_true.Equals("0"))
                    MessageBox.Show("Thêm thông tin không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ten = " ";
                ndd= " ";
                tp = " ";
                quan = " ";
                slcn = 0;
                sldon = 0;
                loaiat = " ";
                dchi= " ";
                
                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void datagid_TT_DT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_TT_DT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            

            txt_hoten.Text = datagid_TT_DT.CurrentRow.Cells["TEN"].Value.ToString();
            txt_nguoidaidien.Text = datagid_TT_DT.CurrentRow.Cells["NG_DAIDIEN"].Value.ToString();
            txt_thanhpho.Text = datagid_TT_DT.CurrentRow.Cells["THANHPHO"].Value.ToString();
            txt_quan.Text = datagid_TT_DT.CurrentRow.Cells["QUAN"].Value.ToString();
            //txt_slcn.Text = datagid_TT_DT.CurrentRow.Cells["SO"].Value.ToString();
            txt_soluongdon.Text = datagid_TT_DT.CurrentRow.Cells["SL_DONMOINGAY"].Value.ToString();
            txt_loaiamthuc.Text = datagid_TT_DT.CurrentRow.Cells["LOAI_AMTHUC"].Value.ToString();
            txt_diachi.Text = datagid_TT_DT.CurrentRow.Cells["DIACHI_KD"].Value.ToString();
            
        }

        private void button_capnhatthongtin_Click(object sender, EventArgs e)
        {
            ten = txt_hoten.Text;
            ndd = txt_nguoidaidien.Text;
            tp = txt_thanhpho.Text;
            quan = txt_quan.Text;
            //slcn = Int32.Parse(txt_slcn.Text);
            sldon = Int32.Parse(txt_soluongdon.Text);
            loaiat = txt_loaiamthuc.Text;
            dchi = txt_diachi.Text;
            if (ten.Trim().Length == 0 | ndd.Trim().Length == 0 | tp.Trim().Length == 0 |
                quan.Trim().Length == 0 | slcn == 0 | sldon == 0 | loaiat.Trim().Length == 0 | dchi.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                Run_DT_Update(madt, ten.Trim().ToString(), ndd.Trim().ToString(), tp.Trim().ToString(), quan.Trim().ToString(),  sldon, loaiat, dchi);

                if (return_value_true_1.Equals("0"))
                    MessageBox.Show("Thêm thông tin không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ten = " ";
                ndd = " ";
                tp = " ";
                quan = " ";
                slcn = 0;
                sldon = 0;
                loaiat = " ";
                dchi = " ";

                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void Run_DT_Update(string iddt, string ten, string ndd, string tp, string quan, int sldon, string loaiat, string dchi)
        {
            SqlCommand cmd = new SqlCommand("update_DOITAC", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ten", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ndd", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@tpho", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@quan", SqlDbType.VarChar, 15);
            //cmd.Parameters.Add("@slcn", SqlDbType.Int);
            cmd.Parameters.Add("@sl_don", SqlDbType.Int);
            cmd.Parameters.Add("@loaAT", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@dchi", SqlDbType.VarChar, 15);




            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị

            cmd.Parameters["@id"].Value = iddt;
            cmd.Parameters["@ten"].Value = ten;
            cmd.Parameters["@ndd"].Value = ndd;
            cmd.Parameters["@tpho"].Value = tp;
            cmd.Parameters["@quan"].Value = quan;
            //cmd.Parameters["@slcn"].Value = slcn;
            cmd.Parameters["@sl_don"].Value = sldon;
            cmd.Parameters["@loaAT"].Value = loaiat;
            cmd.Parameters["@dchi"].Value = dchi;


            cmd.ExecuteNonQuery();
            return_value_true_1 = returnParameter.Value.ToString();
        }

    }
}
