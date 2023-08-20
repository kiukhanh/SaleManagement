using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class FormMain_KhachHang : Form
    {
        Thread t;
        private string tendangnhap;
        public FormMain_KhachHang(string tendangnhap)
        {
            this.tendangnhap = tendangnhap;
            InitializeComponent();
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
            panelChildForm_KH.Controls.Add(childForm);
            panelChildForm_KH.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        
        // xử lí đăng xuất + đăng nhập lại
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Form_DangNhap());
        }

        

        // xử lí khi load form thì hiện tab tài khoản
        private void FormMain_KhachHang_Load(object sender, EventArgs e)
        {         
            button_TTKH.PerformClick();
        }

        
        // chức năng đặt hàng
        

        private void button_DH_Click(object sender, EventArgs e)
        {
            openChildForm(new DSDoiTac_KH(tendangnhap));
        }

        private void button_DHCN_Click(object sender, EventArgs e)
        {
            openChildForm(new DonDaDat(tendangnhap));
        }

        private void button_TTKH_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinChiTiet_KH(tendangnhap));
        }

        private void button_daangxuatadmin_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
