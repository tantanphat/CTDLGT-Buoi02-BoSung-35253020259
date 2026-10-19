
using System;

class Bai2
{
    // Chèn value vào index, count là số phần tử hợp lệ.
    public static void Insert(int[] data, ref int count, int index, int value)
    {
        // Khi chèn, index hợp lệ từ 0 đến count.
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException(nameof(index), "Chi so khong hop le");

        // Không chèn nếu mảng đã đầy.
        if (count >= data.Length)
            throw new InvalidOperationException("Mang da day");

        // Dịch phần tử sang phải để tạo chỗ trống.
        for (int i = count; i > index; i--)
            data[i] = data[i - 1];

        // Đặt giá trị mới vào vị trí cần chèn.
        data[index] = value;

        // Tăng số phần tử hợp lệ sau khi chèn.
        count++;
    }

    // Xóa phần tử tại index.
    public static void RemoveAt(int[] data, ref int count, int index)
    {
        // Khi xóa, index hợp lệ từ 0 đến count - 1.
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index), "Chi so khong hop le");

        // Dịch các phần tử phía sau sang trái để lấp chỗ trống.
        for (int i = index; i < count - 1; i++)
            data[i] = data[i + 1];

        // Giảm số phần tử hợp lệ sau khi xóa.
        count--;
    }

    // In các phần tử hợp lệ trong mảng.
    public static void PrintArray(int[] data, int count)
    {
        for (int i = 0; i < count; i++)
            Console.Write(data[i] + " ");

        Console.WriteLine();
    }

    // Kiểm thử chỉ số sai và trường hợp mảng đầy.
    static void TestTruongKhac()
    {
        // Tạo mảng có 3 phần tử hợp lệ và 2 ô trống.
        int[] data = { 4, 7, 2, 0, 0 };
        int count = 3;

        Console.Write("Mang kiem thu: ");
        PrintArray(data, count);

        // Kiểm tra chèn với chỉ số âm.
        try
        {
            Insert(data, ref count, -1, 99);
            Console.WriteLine("Chen index am: KHONG DAT");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Chen index am: DAT");
        }

        // Kiểm tra xóa tại index bằng count.
        try
        {
            RemoveAt(data, ref count, count);
            Console.WriteLine("Xoa index = count: KHONG DAT");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Xoa index = count: DAT");
        }

        // Chèn đến khi mảng đầy.
        Insert(data, ref count, count, 9);
        Insert(data, ref count, count, 8);

        Console.Write("Mang sau khi chen day: ");
        PrintArray(data, count);

        // Chèn khi mảng đầy phải phát sinh ngoại lệ.
        try
        {
            Insert(data, ref count, count, 99);
            Console.WriteLine("Chen khi day: KHONG DAT");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Chen khi day: DAT");
        }
    }

    static void Main()
    {
        // Cấp phát 10 ô nhưng ban đầu chỉ có 5 phần tử hợp lệ.
        int[] data = new int[10];
        int[] banDau = { 4, 7, 2, 9, 5 };
        int count = banDau.Length;

        // Chép dữ liệu ban đầu vào mảng có vùng trống.
        for (int i = 0; i < count; i++)
            data[i] = banDau[i];

        Console.Write("Ban dau: ");
        PrintArray(data, count);

        // Chèn 99 vào vị trí thứ 2.
        Insert(data, ref count, 2, 99);
        Console.Write("Sau khi chen 99 tai index 2: ");
        PrintArray(data, count);

        // Xóa phần tử tại vị trí thứ 1.
        RemoveAt(data, ref count, 1);
        Console.Write("Sau khi xoa tai index 1: ");
        PrintArray(data, count);

        // Kiểm tra chèn vào đầu mảng.
        Insert(data, ref count, 0, 88);
        Console.Write("Sau khi chen tai dau: ");
        PrintArray(data, count);

        // Chèn vào cuối vùng dữ liệu hợp lệ.
        Insert(data, ref count, count, 77);
        Console.Write("Sau khi chen tai cuoi: ");
        PrintArray(data, count);

        // Kiểm tra xóa phần tử đầu.
        RemoveAt(data, ref count, 0);
        Console.Write("Sau khi xoa tai dau: ");
        PrintArray(data, count);

        // Kiểm tra xóa phần tử cuối.
        RemoveAt(data, ref count, count - 1);
        Console.Write("Sau khi xoa tai cuoi: ");
        PrintArray(data, count);

        // Kiểm tra các trường hợp biên.
        TestTruongKhac();
    }
}
