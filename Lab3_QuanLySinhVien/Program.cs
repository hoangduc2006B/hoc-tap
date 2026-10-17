using System;
using System.Windows.Forms;

namespace Lab3_QuanLySinhVien
{
    static class Program
    {
        /// <summary>
        /// Điểm vào (Entry Point) chính của ứng dụng Quản lý sinh viên Lab 3.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSinhVien());
        }
    }
}
