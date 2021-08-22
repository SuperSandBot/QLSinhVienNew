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
    public partial class FormQLKhoa : Form
    {
        ModelSinhVien data = new ModelSinhVien();
        public FormQLKhoa()
        {
            InitializeComponent();
        }

        private void FormQLKhoa_Load(object sender, EventArgs e)
        {
            cbbKhoa.SelectedIndex = 0;
            updatedgv();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(Check(tbMSSV.Text))
            {
                MessageBox.Show("MSSV Bị Trùng","Lỗi");
                return;
            }
            else
            {
                Them();
                MessageBox.Show("Thêm Thành Công", "Thông Báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Check(tbMSSV.Text))
            {
                Sua();
                MessageBox.Show("Sửa Thành Công", "Thông Báo");              
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy MSSV", "Thông Báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Check(tbMSSV.Text))
            {
                Xoa();
                MessageBox.Show("Xóa Thành Công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Không Tìm Thấy MSSV", "Thông Báo");
            }
        }

        private bool Check(string id)
        {
            return data.SinhViens.Any(p => p.MSSV == id);
        }

        private void Them()
        {
            SinhVien SV = new SinhVien();
            SV.MSSV = tbMSSV.Text;
            SV.HoTen = tbHoTen.Text.Trim();
            SV.KhoaID = cbbKhoa.Text.Trim();
            SV.DTB = float.Parse(tbDTB.Text);

            data.SinhViens.Add(SV);
            data.SaveChanges();
            updatedgv();
        }

        private void Sua()
        {
            SinhVien SV = data.SinhViens.Where(p => p.MSSV == tbMSSV.Text).FirstOrDefault();
            SV.HoTen = tbHoTen.Text;
            SV.DTB = float.Parse(tbDTB.Text);

            data.SaveChanges();
            updatedgv();
        }

        private void Xoa()
        {
            SinhVien SV = data.SinhViens.Where(p => p.MSSV == tbMSSV.Text).FirstOrDefault();
            data.SinhViens.Remove(SV);
            data.SaveChanges();
            updatedgv();
        }

        private void updatedgv()
        {
            dgv.Rows.Clear();
            List<SinhVien> q = data.SinhViens.ToList();
            int i = 0;
            foreach(SinhVien SV in q)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = (i + 1);
                dgv.Rows[i].Cells[1].Value = SV.MSSV;
                dgv.Rows[i].Cells[2].Value = SV.HoTen;
                dgv.Rows[i].Cells[3].Value = SV.Khoa.TenKhoa;
                dgv.Rows[i].Cells[4].Value = SV.DTB.ToString();
                i++;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormTimKiem form = new FormTimKiem();
            form.ShowDialog();
        }

        private void TimKiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiem form = new FormTimKiem();
            form.ShowDialog();
        }

        private void QuanLyKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
