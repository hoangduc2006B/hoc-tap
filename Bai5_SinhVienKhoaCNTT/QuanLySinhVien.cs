using System;
using System.Collections;
using System.IO;

namespace Bai5_SinhVienKhoaCNTT
{
    public class QuanLySinhVien
    {
        public ArrayList DanhSach { get; set; }

        public QuanLySinhVien()
        {
            DanhSach = new ArrayList();
        }

        public SinhVien this[int index]
        {
            get => (SinhVien)DanhSach[index];
            set => DanhSach[index] = value;
        }

        public SinhVien TimTheoMa(string maSo)
        {
            foreach (SinhVien sv in DanhSach)
            {
                if (sv.MaSo.Equals(maSo, StringComparison.OrdinalIgnoreCase))
                    return sv;
            }
            return null;
        }

        public bool Them(SinhVien sv)
        {
            if (TimTheoMa(sv.MaSo) != null)
                return false;
            DanhSach.Add(sv);
            return true;
        }

        public bool CapNhat(SinhVien svMoi)
        {
            for (int i = 0; i < DanhSach.Count; i++)
            {
                if (((SinhVien)DanhSach[i]).MaSo.Equals(svMoi.MaSo, StringComparison.OrdinalIgnoreCase))
                {
                    DanhSach[i] = svMoi;
                    return true;
                }
            }
            return false;
        }

        public void Xoa(string maSo)
        {
            for (int i = 0; i < DanhSach.Count; i++)
            {
                if (((SinhVien)DanhSach[i]).MaSo.Equals(maSo, StringComparison.OrdinalIgnoreCase))
                {
                    DanhSach.RemoveAt(i);
                    return;
                }
            }
        }

        public void DocTuFile(string filePath)
        {
            DanhSach.Clear();
            if (!File.Exists(filePath)) return;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    SinhVien sv = SinhVien.FromFileLine(line);
                    if (sv != null)
                    {
                        DanhSach.Add(sv);
                    }
                }
            }
        }

        public void GhiRaFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (SinhVien sv in DanhSach)
                {
                    writer.WriteLine(sv.ToFileLine());
                }
            }
        }
    }
}
