using System;
using System.Drawing;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class GiaodienNhanVien : Form
    {
        Thread t;
        string TENDANGNHAP;
        string MATKHAU;
        string MANV;

        public GiaodienNhanVien(string tendangnhap, string matkhau)
        {
            InitializeComponent();
            TENDANGNHAP = tendangnhap;
            MATKHAU = matkhau;
            Get_MANV();
        }

        private void Get_MANV()
        {
            string sql = "SELECT NV.ID_NHANVIEN " +
                 "FROM NHANVIEN NV, ACCOUNT A " +
                 "WHERE A.TENDANGNHAP = '" + TENDANGNHAP + "' " +
                 "AND A.MATKHAU = '" + MATKHAU + "' " +
                 "AND NV.ID_NHANVIEN = A.MAACC";
            MANV = connnection.GetFieldValues(sql);
        }

        // mở 1 form con
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm_NV.Controls.Add(childForm);
            panelChildForm_NV.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        

        // xử lí đăng xuất + đăng nhập lại
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Form_DangNhap());
        }

       

        // xử lí khi load form thì hiện tab tài khoản
        private void FormMain_NhanVien_Load(object sender, EventArgs e)
        {
            button_dstk.PerformClick();
        }

        // xử lí thoát
        

        private void txt_hopdongdaduyet_Click(object sender, EventArgs e)
        {
            openChildForm(new HopDongDaDuyet());
        }
        private void button_dstk_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinChiTiet(TENDANGNHAP, MATKHAU));
        }

        private void txt_hopdongchuaduyet_Click(object sender, EventArgs e)
        {
            openChildForm(new HopDongChuaDuyet(MANV));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void button_daangxuatadmin_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Close ();
        }
    }
}
