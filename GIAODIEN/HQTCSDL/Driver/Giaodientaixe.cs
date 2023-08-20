using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class Giaodientaixe : Form
    {
        Thread t;
        string matx = "";
        public Giaodientaixe(string maacc)
        {
            InitializeComponent();
            string sql = "SELECT TX.ID_TAIXE FROM TAIXE TX " +
                " WHERE TX.ID_TAIXE = '" + maacc + "'";
            matx = connnection.GetFieldValues(sql).Trim();
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
            panelChildForm_TX.Controls.Add(childForm);
            panelChildForm_TX.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

       

        // xử lí đăng xuất + đăng nhập lại
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Form_DangNhap());
        }

        private void btn_dangxuat_TX_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        // xử lí khi load form thì hiện tab tài khoản
        private void FormMain_TaiXe_Load(object sender, EventArgs e)
        {
            guna2Button1.PerformClick();
        }

        

        private void button_DSDH_Click(object sender, EventArgs e)
        {
            openChildForm(new Donhangtheokhuvuc(matx));
        }

        private void button_DHDN_Click(object sender, EventArgs e)
        {
            openChildForm(new DonHangDaNhan(matx));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Thongkedonhang(matx));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Thongtin(matx));
        }

        private void button_daangxuatadmin_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
