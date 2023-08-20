using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class FormMain_DoiTac : Form
    {

        Thread t;
        string maacc = "";
        string madt = "";
        public FormMain_DoiTac(string maacc)
        {
            InitializeComponent();

            string sql = "SELECT DT.ID_DOITAC FROM DOITAC DT " +
                " WHERE DT.ID_DOITAC = '" + maacc + "'";
            madt = connnection.GetFieldValues(sql).Trim();
            //madt = "DT111";
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
            panelChildForm_DT.Controls.Add(childForm);
            panelChildForm_DT.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        

        // xử lí đăng xuất + đăng nhập lại
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Form_DangNhap());
        }

        

        // xử lí khi load form thì hiện tab tài khoản
        private void FormMain_DoiTac_Load(object sender, EventArgs e)
        {
            button_taikhoan.PerformClick();
        }

    

        private void button_dsmonan_Click(object sender, EventArgs e)
        {
            openChildForm(new MonAn(madt));

        }

        private void button_themHD_Click(object sender, EventArgs e)
        {
            openChildForm(new LapHopDong(madt));
        }

        private void button_chinhanh_Click(object sender, EventArgs e)
        {
            openChildForm(new ChiNhanh_DoiTac(madt));

        }

        private void button_donhang_Click(object sender, EventArgs e)
        {
            openChildForm(new Xemdonhang(madt));

        }

        private void button_taikhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinChiTiet_DT(madt));

        }


        private void button_hopdongdalap_Click(object sender, EventArgs e)
        {
            openChildForm(new HopDong(madt));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_DX_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
    }
}
