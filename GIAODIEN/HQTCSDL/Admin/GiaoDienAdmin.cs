using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class GiaoDienAdmin : Form
    {
        Thread t;
        public GiaoDienAdmin()
        {
            InitializeComponent();
        }

        // xử lí mở form con
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm_AD.Controls.Add(childForm);
            panelChildForm_AD.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        // xử lí đăng xuất + đăng nhập lại
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Form_DangNhap());
        }


        // xử lí khi load form thì hiện tab tài khoản
        private void FormMain_Admin_Load(object sender, EventArgs e)
        {
            button_dstk.PerformClick();
        }

        // xử lí thoát
        // chức năng quản lí DS tài khoản

        // chức năng tài khoản

        private void button_dstk_Click(object sender, EventArgs e)
        {
           
            openChildForm(new DSTaiKHoan_admin());
        }

        //private void button_tkcn_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new ThongTinChiTiet_admin());
           
        //}

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
