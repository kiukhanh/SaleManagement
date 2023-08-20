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
    public partial class DatHang : Form
    {
        
        private string MAACC;
        private string maDT;
        private string maSP;
        private string tenSP;
        private string giaBan;
        private string soluongmua;
        public DatHang(string MAACC,string maDT, string maSP, string tenSP, string giaBan, string soluongmua)
        {
            this.MAACC = MAACC;
            this.maDT = maDT;
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.giaBan = giaBan;
            this.soluongmua = soluongmua;
            InitializeComponent();
        }
      
        
        private void DatHang_KH_Load(object sender, EventArgs e)
        {
           txt_TenSP.Text = tenSP;
            txt_giaban.Text = giaBan;
            txt_soluong.Text = soluongmua;
            float temp = Int32.Parse(soluongmua) * float.Parse(giaBan);
            txt_Tongtien.Text = temp.ToString();

            string sql = "SELECT KH.DIACHI FROM KHACHHANG KH WHERE KH.ID_KHACHHANG = '" + MAACC + "'";
            string diachi = connnection.GetFieldValues(sql);
            ComboBox_HTTT.Items.Add("Tiền mặt");
            ComboBox_HTTT.Items.Add("Ví điện tử");
            ComboBox_HTTT.Items.Add("Thẻ ngân hàng");
            txt_DCGH.Text = diachi;
            txt_phivanchuyen.Text = "30000";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_DH_Click(object sender, EventArgs e)
        {
            int count = 0;
            string sql1 = "SELECT COUNT(*) FROM DONHANG";
            string temp = connnection.GetFieldValues(sql1);
            count = Int32.Parse(temp) + 1;
            string maDH;
            if(count < 10)
            {
                maDH = "DH00" + count;
            }
            else if(count < 100)
            {
                maDH = "DH0" + count;
            }
            else
            {
                maDH = "DH" + count;
            }

            
            if(ComboBox_HTTT.Text.Trim().Length == 0 || txt_DCGH.Text.Trim().Length ==0
                || txt_soluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime now = DateTime.Now;
            
            float tongtien = float.Parse(txt_Tongtien.Text.ToString()) + float.Parse(txt_phivanchuyen.Text.ToString());
            string sql2 = "INSERT INTO DONHANG(ID_DONHANG, NGAYLAP, DIACHIGIAOHANG, SDT_NHANHANG,PHIVANCHUYEN,PHUONGTHUCTHANHTOAN,TONGTIEN, KHACH HANG, TRANGTHAIVANCHUYEN) " +
                "VALUES('" + maDH + "',"
                + "'"+now.ToString()+"'"
                + "N'" + txt_DCGH.Text.Trim().ToString() + "',"
                + txt_sdt.Text.ToString() + ","
                + txt_phivanchuyen.Text.ToString() + ","
                + ComboBox_HTTT.Text.Trim().ToString() + ","
                + tongtien + ","
                + "'" + MAACC + "',"
                + "Chờ Nhận" + ")";
            connnection.RunSQL(sql2);

            
            string slq3 = "INSERT INTO CT_DATHANG(DONHANG, MONAN, SOLUONG, TUYCHON) "
                + "VALUES('" + maDH + "','" + tenSP +"','" + txt_soluong.Text.Trim().ToString() +")";

            connnection.RunSQL(slq3);

            MessageBox.Show("Đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string sql4 = "sp_KH_MUA" + tenSP + "'," + txt_soluong.Text.Trim().ToString();
            connnection.RunSQL(sql4);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_DUYETHD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string sql1 = "SELECT COUNT(*) FROM DONHANG";
            string temp = connnection.GetFieldValues(sql1);
            count = Int32.Parse(temp) + 1;
            string maDH;
            if (count < 10)
            {
                maDH = "DH00" + count;
            }
            else if (count < 100)
            {
                maDH = "DH0" + count;
            }
            else
            {
                maDH = "DH" + count;
            }


            if (ComboBox_HTTT.Text.Trim().Length == 0 || txt_DCGH.Text.Trim().Length == 0
                || txt_soluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime now = DateTime.Now;
            
            float tongtien = float.Parse(txt_Tongtien.Text.ToString()) + float.Parse(txt_phivanchuyen.Text.ToString());
            string sql2 = "INSERT INTO DONHANG(ID_DONHANG, NGAYLAP, DIACHIGIAOHANG, SDT_NHANHANG,PHIVANCHUYEN,PHUONGTHUCTHANHTOAN,TONGTIEN, KHACH HANG, TRANGTHAIVANCHUYEN) " +
                "VALUES('" + maDH + "',"
                + "'" + now.ToString() + "'"
                + "N'" + txt_DCGH.Text.Trim().ToString() + "',"
                + txt_sdt.Text.ToString() + ","
                + txt_phivanchuyen.Text.ToString() + ","
                + ComboBox_HTTT.Text.Trim().ToString() + ","
                + tongtien + ","
                + "'" + MAACC + "',"
                + "Chờ Nhận" + ")";
            connnection.RunSQL(sql2);


            string slq3 = "INSERT INTO CT_DATHANG(DONHANG, MONAN, SOLUONG, TUYCHON) "
                + "VALUES('" + maDH + "','" + tenSP + "','" + txt_soluong.Text.Trim().ToString() + ")";

            connnection.RunSQL(slq3);

            MessageBox.Show("Đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string sql4 = "sp_KH_MUA" + tenSP + "'," + txt_soluong.Text.Trim().ToString();
            connnection.RunSQL(sql4);
            this.Close();
        }
    }
}
