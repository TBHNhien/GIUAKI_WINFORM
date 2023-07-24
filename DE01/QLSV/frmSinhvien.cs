using QLSV.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSV
{
    public partial class FQLSV : Form
    {
        public FQLSV()
        {
            InitializeComponent();
            cmb_Falculty.SelectedIndex = 0;
            Load_dtgv();
        }

        #region method

        //Load datagridview 
        public void Load_dtgv()
        {

            //tạo column
            dtgvStudent.Columns.Add("MASV", "MASV");
            dtgvStudent.Columns.Add("HOTEN", "HOTEN");
            dtgvStudent.Columns.Add("NGAYSINH", "NGAYSINH");
            dtgvStudent.Columns.Add("LOP", "LOP");

            dtgvStudent.Columns["MASV"].Width = 200;
            dtgvStudent.Columns["HOTEN"].Width = 200;
            dtgvStudent.Columns["NGAYSINH"].Width = 200;
            dtgvStudent.Columns["LOP"].Width = 200;

            dtgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        //Hàm Binding list có tên hiển thị là tên khoa , giá trị là Mã Khoa
        private void FillLOPCombobox(List<LOP> listLOPs)
        {
            this.cmb_Falculty.DataSource = listLOPs;
            this.cmb_Falculty.DisplayMember = "TENLOP";
            this.cmb_Falculty.ValueMember = "MALOP";
        }

        //HÀM binding gridview từ list sinh viên
        private void BindGrid(List<SINHVIEN> listSINHVIENs)
        {
            dtgvStudent.Rows.Clear();
            foreach(var item in listSINHVIENs)
            {
                int index = dtgvStudent.Rows.Add();
                dtgvStudent.Rows[index].Cells[0].Value = item.MASV;
                dtgvStudent.Rows[index].Cells[1].Value = item.HOTENSV;
                dtgvStudent.Rows[index].Cells[2].Value = item.NGAYSINH;
                dtgvStudent.Rows[index].Cells[3].Value = item.LOP.TENLOP;
            }
        }


        #endregion

        #region Event
        private void FQLSV_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                

                List<LOP> listLOP = context.LOPs.ToList();//lấy các khoa
                List<SINHVIEN> listSINHVIEN = context.SINHVIENs.ToList();//lấy sinh viên
                FillLOPCombobox(listLOP);
                BindGrid(listSINHVIEN);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //sự kiện thêm
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Model1 context = new Model1();
            SINHVIEN s = new SINHVIEN()
            {
                MASV = txb_MSSV.Text.ToString(),
                HOTENSV = txb_Name.Text.ToString(),
                MALOP =   cmb_Falculty.SelectedValue.ToString(),
                NGAYSINH = DateTime.Parse(dtpNgaySinh.Text)
            };
            context.SINHVIENs.Add(s);
            context.SaveChanges();
            List<SINHVIEN> ListSINHVIENs = context.SINHVIENs.ToList();
            BindGrid(ListSINHVIENs);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Lưu vùng chọn hiện tại
            //int rowIndex = dtgvStudent.CurrentRow.Index;
            int columnIndex = dtgvStudent.CurrentCell.ColumnIndex;

            Model1 context = new Model1();
            SINHVIEN dbUpdate = context.SINHVIENs.FirstOrDefault(p => p.MASV.ToString() == txb_MSSV.Text.ToString());
            if (dbUpdate != null)
            {
                dbUpdate.HOTENSV = txb_Name.Text.ToString();
                dbUpdate.MALOP = cmb_Falculty.SelectedValue.ToString();
                dbUpdate.NGAYSINH = DateTime.Parse(dtpNgaySinh.Text.ToString());

                context.SaveChanges();
                List<SINHVIEN> ListSINHVIENs = context.SINHVIENs.ToList();

                BindGrid(ListSINHVIENs);
            }

            //dtgvStudent.CurrentCell = dtgvStudent.Rows[rowIndex].Cells[columnIndex];
            //dtgvStudent.Rows[rowIndex].Selected = true;
            
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Model1 context = new Model1();
                SINHVIEN dbDelete = context.SINHVIENs.FirstOrDefault(p => p.MASV.ToString() == txb_MSSV.Text.ToString());
                if (dbDelete != null)
                {
                    context.SINHVIENs.Remove(dbDelete);
                    context.SaveChanges();
                    List<SINHVIEN> ListSINHVIENs = context.SINHVIENs.ToList();
                    BindGrid(ListSINHVIENs);
                }
            }
        }

        private void dtgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lấy chỉ số dòng được chọn
            int rowIndex = e.RowIndex;

            //kiểm tra nếu chỉ số dòng hợp lệ
            if (rowIndex >= 0 && rowIndex < dtgvStudent.Rows.Count-1)
            {
                DataGridViewRow selectedRow = dtgvStudent.Rows[rowIndex];

                txb_MSSV.Text = selectedRow.Cells[0].Value.ToString();
                txb_Name.Text = selectedRow.Cells[1].Value.ToString();
                
                dtpNgaySinh.Text = selectedRow.Cells[2].Value.ToString();
                cmb_Falculty.Text = selectedRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("dong khong hop le");
            }

        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }
    }
}
