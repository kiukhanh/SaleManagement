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
    public partial class ChiNhanh_ThuocHopDong : Form
    {
        public DataTable tbl_ChiNhanh_CNTHD;
        public ChiNhanh_ThuocHopDong()
        {
            InitializeComponent();
        }

        private void Load_Data_CNTH()
        {
            datagid_DSCHINHANHTHUOCHD.DataSource = tbl_ChiNhanh_CNTHD;
        }

        private void ChiNhanh_ThuocHopDong_Load(object sender, EventArgs e)
        {
            Load_Data_CNTH();
        }
    }
}
