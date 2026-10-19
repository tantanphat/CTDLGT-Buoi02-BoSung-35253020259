
using System;

class Bai1
{
    static void Main()
    {
        // Nhập số lượng phần tử của mảng.
        Console.WriteLine("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        // Kiểm tra n phải từ 1 đến 100000.
        if (n < 1 || n > 100000)
        {
            Console.WriteLine("N khong hop le");
            return; // Kết thúc nếu n không hợp lệ.
        }

        // Tạo mảng có n phần tử.
        int[] mang = new int[n];

        // Nhập n số nguyên trên một dòng.
        Console.WriteLine($"Nhap {n} so nguyen");
        string[] duLieu = Console.ReadLine().Split();

        // Chuyển dữ liệu nhập từ chuỗi sang số nguyên.
        for (int i = 0; i < n; i++)
        {
            mang[i] = int.Parse(duLieu[i]);
        }

        // Khởi tạo tổng và các biến thống kê.
        long tong = 0; // Dùng long để hạn chế tràn số khi tính tổng.
        int nhoNhat = mang[0]; // Lấy phần tử đầu làm giá trị nhỏ nhất ban đầu.
        int lonNhat = mang[0]; // Lấy phần tử đầu làm giá trị lớn nhất ban đầu.
        int phanTuAm = 0;
        int phanTuDuong = 0;
        int phanTuBang0 = 0;

        // Duyệt mảng một lần để tính các số liệu thống kê.
        for (int i = 0; i < n; i++)
        {
            tong += mang[i]; // Cộng phần tử hiện tại vào tổng.

            // Cập nhật giá trị nhỏ nhất nếu tìm được số nhỏ hơn.
            if (mang[i] < nhoNhat)
            {
                nhoNhat = mang[i];
            }

            // Cập nhật giá trị lớn nhất nếu tìm được số lớn hơn.
            if (mang[i] > lonNhat)
            {
                lonNhat = mang[i];
            }

            // Đếm số phần tử âm, dương và bằng 0.
            if (mang[i] < 0)
            {
                phanTuAm++;
            }
            else if (mang[i] > 0)
            {
                phanTuDuong++;
            }
            else
            {
                phanTuBang0++;
            }
        }

        // Ép tổng sang double trước khi chia để giữ phần thập phân.
        double trungBinhCong = (double)tong / n;

        // In kết quả thống kê, làm tròn trung bình đến 2 chữ số.
        Console.WriteLine($"Tong: {tong}");
        Console.WriteLine($"Nho nhat: {nhoNhat}");
        Console.WriteLine($"Lon nhat: {lonNhat}");
        Console.WriteLine($"Trung binh: {Math.Round(trungBinhCong, 2):F2}");
        Console.WriteLine($"So phan tu am: {phanTuAm}");
        Console.WriteLine($"So phan tu duong: {phanTuDuong}");
        Console.WriteLine($"So phan tu bang 0: {phanTuBang0}");

        // Đặt hai chỉ số ở đầu và cuối mảng để đảo tại chỗ.
        int trai = 0;
        int phai = n - 1;

        // Tiếp tục đổi chỗ cho đến khi hai chỉ số gặp nhau.
        while (trai < phai)
        {
            // Hoán đổi phần tử đầu và cuối của đoạn đang xét.
            int tam = mang[trai];
            mang[trai] = mang[phai];
            mang[phai] = tam;

            // Thu hẹp đoạn cần đảo về phía giữa mảng.
            trai++;
            phai--;
        }

        // In mảng sau khi đảo ngược thứ tự.
        Console.Write("Mang sau khi dao: ");

        for (int i = 0; i < n; i++)
        {
            Console.Write(mang[i] + " ");
        }

        Console.WriteLine();
    }
}
