using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HQTCSDL
{
    public partial class Donhangtheokhuvuc : Form
    {
        DataTable tbl_TaiXe_DSDH;
        string MATX;
        string IDhd, IDtx;
        string return_value_true;
        public Donhangtheokhuvuc(string MaTX)
        {
            InitializeComponent();
            MATX= MaTX;
        }

        private void LoadData_DSDH()//dữ liệu vào DataGridView
        {
            string sql = "EXEC show_DONHANG_TAIXE '"+ MATX +"'";

            
            tbl_TaiXe_DSDH = connnection.GetDataToTable(sql);
            datagid_DS_donhangtheokhuvuc.DataSource = tbl_TaiXe_DSDH;



            //Không cho người dùng thêm dữ liệu trực tiếp
            datagid_DS_donhangtheokhuvuc.AllowUserToAddRows = false;
            datagid_DS_donhangtheokhuvuc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DS_DonHang_TX_Load(object sender, System.EventArgs e)
        {
            LoadData_DSDH();
        }

        private void dGV_TaiXe_DSDH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_TaiXe_DSDH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
        }

        private void datagid_DS_dhdanhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_TaiXe_DSDH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            
           
            IDhd = datagid_DS_donhangtheokhuvuc.CurrentRow.Cells["ID_DONHANG"].Value.ToString();
            //cn =datagid_DSMA.CurrentRow.Cells["CHINHANH"].Value.ToString();
        }
        private void Run_SP_DT_NHANDON(string idvc, string idhd, string idTX)
        {
            SqlCommand cmd = new SqlCommand("insert_CTVC", connnection.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@id_VC", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@id_DH", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@id_TX", SqlDbType.VarChar, 15);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@id_VC"].Value = idvc;
            cmd.Parameters["@id_DH"].Value = idhd;
            cmd.Parameters["@id_TX"].Value = idTX;

            cmd.ExecuteNonQuery();
            return_value_true = returnParameter.Value.ToString();
        }

        private void button_nhandonhang_Click(object sender, System.EventArgs e)
        {
            int count = 0;
            string sql1 = "SELECT COUNT(*) CT_VANCHUYEN";
            string temp = connnection.GetFieldValues(sql1);
            count = Int32.Parse(temp) + 1;
            string idvc;
            if (count < 10)
            {
                idvc = "VC000" + count;
            }
            else if (count < 100)
            {
                idvc = "VC00" + count;
            }
            else
            {
                idvc = "DH0" + count;
            }

            Run_SP_DT_NHANDON(idvc, IDhd, MATX);
            if (return_value_true.Equals("0"))
                MessageBox.Show("Đăng kí không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            


        }
    }
}

        