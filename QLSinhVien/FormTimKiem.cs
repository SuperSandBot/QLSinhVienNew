using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSinhVien.Entites;

namespace QLSinhVien
{
    public partial class FormTimKiem : Form
    {
        ModelSinhVien data = new ModelSinhVien();
        public FormTimKiem()
        {
            InitializeComponent();           
        }

        private void FormTimKiem_Load(object sender, EventArgs e)
        {
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string MSSV = tbMSSV.Text.Trim();
            string HoTen = tbHoTen.Text.Trim();
            string Khoa = cbbKhoa.Text;
            TimKiem(MSSV, HoTen, Khoa);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Check(tbMSSV.Text))
            {
                Xoa();               
                MessageBox.Show("Xóa Thành Công", "Thông Báo");
                reset();
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy MSSV", "Thông Báo");
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Check(string id)
        {
            return data.SinhViens.Any(p => p.MSSV == id);
        }

        private void TimKiem(string MSSV, string HoTen, string KhoaID)
        {
            List<SinhVien> SVs = new List<SinhVien>();

            if(KhoaID != "")
            {
                SVs = data.SinhViens.Where(p => p.KhoaID == KhoaID).ToList();
            }

            if (HoTen != "")
            {
                SVs = data.SinhViens.Where(p => p.HoTen.StartsWith(HoTen)).ToList();
            }

            if (MSSV != "") 
            {
                SVs = data.SinhViens.Where(p => p.MSSV == MSSV).ToList();
            }

            updatedgv(SVs);
        }

        private void Xoa()
        {
            SinhVien SV = data.SinhViens.Where(p => p.MSSV == tbMSSV.Text).FirstOrDefault();
            data.SinhViens.Remove(SV);
            data.SaveChanges();
            updatedgv(data.SinhViens.ToList());
            reset();
        }

        private void updatedgv(List<SinhVien> q)
        {
            dgv.Rows.Clear();
            int i = 0;
            int tong = 0;
            foreach (SinhVien SV in q)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = (i + 1);
                dgv.Rows[i].Cells[1].Value = SV.MSSV;
                dgv.Rows[i].Cells[2].Value = SV.HoTen;
                dgv.Rows[i].Cells[3].Value = SV.Khoa.TenKhoa;
                dgv.Rows[i].Cells[4].Value = SV.DTB.ToString();
                i++;
                tong++;
            }
            tbTong.Text = tong.ToString();
        }

        private void reset()
        {
            tbMSSV.Text = "";
            tbMSSV.Text = "";
            cbbKhoa.SelectedItem = "";
        }
    }
}
