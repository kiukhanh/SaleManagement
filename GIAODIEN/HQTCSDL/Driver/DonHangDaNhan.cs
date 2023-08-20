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
    public partial class DonHangDaNhan : Form
    {
        DataTable tbl_TaiXe_DHDN;
        string return_value_true;
        string MATX;
        string IDVC;
        string IDDH;
        public DonHangDaNhan(string maTX)
        {
            InitializeComponent();
            MATX = maTX;
        }
        
        private void LoadData_DHDN()//dữ liệu vào DataGridView
        {
            string sql = "SELECT DH.*,CTVC.ID_VANCHUYEN " +
                " FROM  DONHANG DH,CT_VANCHUYEN CTVC, TAIXE TX " +
                " WHERE DH.TRANGTHAIXULY  LIKE N'NHẬN ĐƠN' AND CTVC.DON = DH.ID_DONHANG " +
                "AND TX.ID_TAIXE = CTVC.TAIXE " +
                "AND TX.ID_TAIXE = '" + MATX + "'";
            tbl_TaiXe_DHDN = connnection.GetDataToTable(sql);
            datagid_DS_dhdanhan.DataSource = tbl_TaiXe_DHDN;

            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DS_dhdanhan.AllowUserToAddRows = false;
            datagid_DS_dhdanhan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DonHangDaNhan_TX_Load(object sender, EventArgs e)
        {
            LoadData_DHDN();
        }

        private void Run_SP_DT_UPDATE_TRANGTHAI(string idvc, string idhd)
        {
            SqlCommand cmd = new SqlCommand("update_TTVC", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id_VC", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@id_DH", SqlDbType.VarChar, 15);
            
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@id_VC"].Value = idvc;
            cmd.Parameters["@id_DH"].Value = idhd;
            
            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }
        
        private void button_capnhatdonhang_Click(object sender, EventArgs e)
        {


            Run_SP_DT_UPDATE_TRANGTHAI(IDVC, IDDH);

            if (return_value_true.Equals("0"))
                MessageBox.Show("Đăng kí không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadData_DHDN();

            
        }

        private void datagid_DS_dhdanhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_TaiXe_DHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            
            IDVC = datagid_DS_dhdanhan.CurrentRow.Cells["ID_VANCHUYEN"].Value.ToString();
            IDDH = datagid_DS_dhdanhan.CurrentRow.Cells["ID_DONHANG"].Value.ToString();
            //cn =datagid_DSMA.CurrentRow.Cells["CHINHANH"].Value.ToString();
        }
    }
}
