using System;

namespace Bai5_SinhVienKhoaCNTT
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public bool Phai { get; set; } // true = Nam, false = Nữ
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Hinh { get; set; }

        public SinhVien() { }

        public SinhVien(string maSo, string hoTen, bool phai, DateTime ngaySinh, string lop, string soDT, string email, string diaChi, string hinh)
        {
            MaSo = maSo;
            HoTen = hoTen;
            Phai = phai;
            NgaySinh = ngaySinh;
            Lop = lop;
            SoDT = soDT;
            Email = email;
            DiaChi = diaChi;
            Hinh = hinh;
        }

        public string ToFileLine()
        {
            return $"{MaSo}\t{HoTen}\t{(Phai ? "1" : "0")}\t{NgaySinh:dd/MM/yyyy}\t{Lop}\t{SoDT}\t{Email}\t{DiaChi}\t{Hinh}";
        }

        public static SinhVien FromFileLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            string[] parts = line.Split('\t');
            if (parts.Length < 9) return null;

            DateTime.TryParseExact(parts[3].Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns);

            return new SinhVien(
                parts[0].Trim(),
                parts[1].Trim(),
                parts[2].Trim() == "1" || parts[2].Trim().ToLower() == "nam",
                ns,
                parts[4].Trim(),
                parts[5].Trim(),
                parts[6].Trim(),
                parts[7].Trim(),
                parts[8].Trim()
            );
        }
    }
}
