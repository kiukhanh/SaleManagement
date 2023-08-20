﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HQTCSDL
{
    class connnection
    {
        // server chính xác
        //private static string servername = @"DESKTOP-0QKBNDR";     
        //private static string servername = @"LTBM-PC";
        private static string servername = @"DESKTOP-2HQ1IDD\KHANHSERVER";
      
        //Khai báo đối tượng kết nối  
        public static SqlConnection Con;
        public static void Connect(string ConnectString)
        {
            Con = new SqlConnection();
            Con.ConnectionString = ConnectString;
          
          
            Con.Open();

            
            if (Con.State == ConnectionState.Open)
            {              
                //MessageBox.Show("Kết nối DB thành công");
            }
            else MessageBox.Show("Không thể kết nối với DB");
        }

        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                
                Con.Close();
                Con.Dispose();
                Con = null;
            }
        }

        // lấy ConnectString với mỗi loại user
        public static string get_ConnectString(int type)
        {           
            string s = "";
            switch (type)
            {
                // vô danh
                case -2:
                    {
                        s = @"Data Source="+ servername + ";Initial Catalog=QL_DH_GH;Persist Security Info=True;User ID=QL_DH_GH_VODANH;Password=12345";
                        break;
                    }
                // đối tác
                case 0:
                    {
                        s = @"Data Source=" + servername + ";Initial Catalog=QL_DH_GH;Persist Security Info=True;User ID=QL_DH_GH_DOITAC;Password=12345";
                        break;
                    }
                // khách hàng
                case 1:
                    {
                        s = @"Data Source=" + servername + ";Initial Catalog=QL_DH_GH;Persist Security Info=True;User ID=QL_DH_GH_KHACHHANG;Password=12345";
                        break;
                    }
                // tài xế
                case 2:
                    {
                        s = @"Data Source=" + servername + ";Initial Catalog=QL_DH_GH;Persist Security Info=True;User ID=QL_DH_GH_TAIXE;Password=12345";
                        break;
                    }
                // nhân viên
                case 3:
                    {
                        s = @"Data Source=" + servername + ";Initial Catalog=QL_DH_GH;Persist Security Info=True;User ID=QL_DH_GH_NHANVIEN;Password=12345";
                        break;
                    }
                // admin
                case 4:
                    {
                        s = @"Data Source=" + servername + ";Initial Catalog=QL_DH_GH;Persist Security Info=True;User ID=QL_DH_GH_ADMIN;Password=12345";
                        break;
                    }
            }
            return s;
        }

        public static DataTable GetDataToTable(string sql) //Lấy dữ liệu đổ vào bảng
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand();

            //Kết nối cơ sở dữ liệu
            dap.SelectCommand.Connection = connnection.Con;
            dap.SelectCommand.CommandText = sql;

            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        public static bool CheckKey(string sql) // kiểm tra xem có trùng khóa hay không
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        public static void RunSQL(string sql) // chạy câu lệnh sql
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Giải phóng bộ nhớ
            cmd.Dispose();
            cmd = null;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten) { 
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }

        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
    }
}
