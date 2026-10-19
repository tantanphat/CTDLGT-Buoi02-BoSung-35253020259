
using System;

// Lưu thông tin của một sinh viên.
public class Student
{
    // Lưu mã duy nhất dùng để nhận diện sinh viên.
    public string MaSV { get; set; } = "";
    // Lưu họ tên dùng cho hiển thị và tìm kiếm.
    public string HoTen { get; set; } = "";
    // Lưu điểm tổng kết trong đoạn từ 0 đến 10.
    public double Diem { get; set; }
}

class Bai3
{
    // Danh sách gồm 5 sinh viên ban đầu.
    private static readonly List<Student> DanhSach = [
        new Student { MaSV = "SV001", HoTen = "Nguyen Van An", Diem = 8.5 },
        new Student { MaSV = "SV002", HoTen = "Tran Thi Binh", Diem = 7.0 },
        new Student { MaSV = "SV003", HoTen = "Le Minh Chau", Diem = 4.5 },
        new Student { MaSV = "SV004", HoTen = "Pham Quoc Dung", Diem = 6.0 },
        new Student { MaSV = "SV005", HoTen = "Hoang Thu Ha", Diem = 3.5 }
    ];

    // Chạy menu đến khi người dùng chọn thoát.
    static void Main()
    {
        int luaChon;
        do
        {
            HienThiMenu();
            luaChon = NhapSoNguyen("Chon chuc nang: ");

            switch (luaChon)
            {
                case 1: ThemSinhVien(); break;
                case 2: CapNhatSinhVien(); break;
                case 3: XoaSinhVien(); break;
                case 4: TimSinhVien(); break;
                case 5: HienThiDanhSach(); break;
                case 6: ThongKe(); break;
                case 0: Console.WriteLine("Da thoat chuong trinh."); break;
                default: Console.WriteLine("Lua chon khong hop le."); break;
            }

            Console.WriteLine();
        } while (luaChon != 0);
    }

    // Hiển thị các chức năng.
    static void HienThiMenu()
    {
        Console.WriteLine("===== QUAN LY SINH VIEN =====");
        Console.WriteLine("1. Them sinh vien");
        Console.WriteLine("2. Cap nhat sinh vien");
        Console.WriteLine("3. Xoa sinh vien");
        Console.WriteLine("4. Tim theo ho ten");
        Console.WriteLine("5. Hien thi danh sach");
        Console.WriteLine("6. Thong ke");
        Console.WriteLine("0. Thoat");
    }

    // Thêm sinh viên nếu mã chưa trùng và điểm hợp lệ.
    static void ThemSinhVien()
    {
        string ma = NhapChuoi("Nhap ma sinh vien: ");

        if (TimViTri(ma) != -1)
        {
            Console.WriteLine("Ma sinh vien da ton tai.");
            return;
        }

        string ten = NhapChuoi("Nhap ho ten: ");
        double diem = NhapDiem("Nhap diem (0-10): ");

        // Thêm sinh viên vào cuối danh sách.
        DanhSach.Add(new Student
        {
            MaSV = ma,
            HoTen = ten,
            Diem = diem
        });

        Console.WriteLine("Them thanh cong.");
    }

    // Cập nhật họ tên hoặc điểm theo mã sinh viên.
    static void CapNhatSinhVien()
    {
        string ma = NhapChuoi("Nhap ma sinh vien: ");
        int viTri = TimViTri(ma);

        if (viTri == -1)
        {
            Console.WriteLine("Khong tim thay sinh vien.");
            return;
        }

        Student sv = DanhSach[viTri];

        Console.WriteLine("1. Sua ho ten");
        Console.WriteLine("2. Sua diem");
        Console.WriteLine("3. Sua ca hai");

        int chon = NhapSoNguyen("Lua chon: ");

        switch (chon)
        {
            case 1:
                sv.HoTen = NhapChuoi("Nhap ho ten moi: ");
                break;
            case 2:
                sv.Diem = NhapDiem("Nhap diem moi (0-10): ");
                break;
            case 3:
                sv.HoTen = NhapChuoi("Nhap ho ten moi: ");
                sv.Diem = NhapDiem("Nhap diem moi (0-10): ");
                break;
            default:
                Console.WriteLine("Lua chon khong hop le.");
                return;
        }

        Console.WriteLine("Cap nhat thanh cong.");
    }

    // Xóa sinh viên theo mã.
    static void XoaSinhVien()
    {
        string ma = NhapChuoi("Nhap ma sinh vien can xoa: ");
        int viTri = TimViTri(ma);

        if (viTri == -1)
        {
            Console.WriteLine("Khong tim thay sinh vien.");
            return;
        }

        // Xóa phần tử; các phần tử phía sau có thể dịch sang trái.
        DanhSach.RemoveAt(viTri);
        Console.WriteLine("Xoa thanh cong.");
    }

    // Tìm sinh viên theo một phần họ tên, không phân biệt hoa thường.
    static void TimSinhVien()
    {
        string tuKhoa = NhapChuoi("Nhap ten can tim: ");
        bool timThay = false;

        // Duyệt từng sinh viên, không dùng LINQ.
        foreach (Student sv in DanhSach)
        {
            if (sv.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
            {
                InSinhVien(sv);
                timThay = true;
            }
        }

        if (!timThay)
            Console.WriteLine("Khong tim thay sinh vien.");
    }

    // Hiển thị toàn bộ danh sách.
    static void HienThiDanhSach()
    {
        if (DanhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong.");
            return;
        }

        Console.WriteLine("{0,-10} {1,-25} {2,8}", "Ma SV", "Ho ten", "Diem");

        foreach (Student sv in DanhSach)
            InSinhVien(sv);
    }

    // Tính điểm trung bình và đếm sinh viên đạt từ 5 điểm.
    static void ThongKe()
    {
        if (DanhSach.Count == 0)
        {
            Console.WriteLine("Danh sach rong, khong tinh duoc diem trung binh.");
            Console.WriteLine("So sinh vien dat: 0");
            return;
        }

        double tongDiem = 0;
        int soSinhVienDat = 0;

        // Duyệt một lần để tính tổng điểm và đếm sinh viên đạt.
        foreach (Student sv in DanhSach)
        {
            tongDiem += sv.Diem;

            if (sv.Diem >= 5)
                soSinhVienDat++;
        }

        Console.WriteLine($"Diem trung binh: {tongDiem / DanhSach.Count:F2}");
        Console.WriteLine($"So sinh vien dat: {soSinhVienDat}");
    }

    // Tìm vị trí theo mã; trả về -1 nếu không tìm thấy.
    static int TimViTri(string ma)
    {
        for (int i = 0; i < DanhSach.Count; i++)
        {
            if (string.Equals(DanhSach[i].MaSV, ma,
                StringComparison.OrdinalIgnoreCase))
                return i;
        }

        return -1;
    }

    // Nhập chuỗi không được để trống.
    static string NhapChuoi(string loiNhac)
    {
        while (true)
        {
            Console.Write(loiNhac);
            string? duLieu = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(duLieu))
                return duLieu;

            Console.WriteLine("Khong duoc de trong.");
        }
    }

    // Nhập số nguyên hợp lệ.
    static int NhapSoNguyen(string loiNhac)
    {
        while (true)
        {
            Console.Write(loiNhac);

            if (int.TryParse(Console.ReadLine(), out int so))
                return so;

            Console.WriteLine("Vui long nhap so nguyen.");
        }
    }

    // Nhập điểm trong khoảng từ 0 đến 10.
    // Nhập điểm từ 0 đến 10.
    static double NhapDiem(string loiNhac)
    {
        while (true)
        {
            Console.Write(loiNhac);

            // Kiểm tra dữ liệu nhập có phải số hợp lệ không.
            if (double.TryParse(Console.ReadLine(), out double diem)
                && double.IsFinite(diem)
                && diem >= 0 && diem <= 10)
            {
                return diem;
            }

            Console.WriteLine("Diem phai tu 0 den 10.");
        }
    }

    // In thông tin một sinh viên theo dạng bảng.
    static void InSinhVien(Student sv)
    {
        Console.WriteLine("{0,-10} {1,-25} {2,8:F2}",
            sv.MaSV, sv.HoTen, sv.Diem);
    }
}
