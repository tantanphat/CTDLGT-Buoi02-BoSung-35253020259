
using System;

// Quan ly mang dong bang mang T[].
public class DynamicArray<T>
{
    // Mang luu tru cac phan tu.
    private T[] phanTu;

    // So phan tu dang duoc su dung.
    public int Count { get; private set; }

    // Tong so o da cap phat.
    public int Capacity => phanTu.Length;

    // Tao mang voi suc chua mac dinh la 4.
    public DynamicArray(int sucChua = 4)
    {
        // Khong chap nhan suc chua am.
        if (sucChua < 0)
            throw new ArgumentOutOfRangeException(nameof(sucChua));

        // Cap phat mang ban dau, chua co phan tu nao.
        phanTu = new T[sucChua];
        Count = 0;
    }

    // Them phan tu vao cuoi mang.
    public void Add(T giaTri)
    {
        // Neu mang day thi mo rong truoc khi them.
        DamBaoSucChua();

        // Ghi gia tri vao o trong tiep theo.
        phanTu[Count] = giaTri;

        // Tang so phan tu sau khi ghi du lieu.
        Count++;
    }

    // Mo rong mang khi khong con o trong.
    private void DamBaoSucChua()
    {
        // Neu con cho thi khong can mo rong.
        if (Count < Capacity)
            return;

        // Gap doi suc chua; neu bang 0 thi tang len 4.
        int sucChuaMoi = Capacity == 0 ? 4 : Capacity * 2;

        // Tao mang moi de chua du lieu.
        T[] mangMoi = new T[sucChuaMoi];

        // Sao chep dung cac phan tu dang duoc su dung.
        for (int i = 0; i < Count; i++)
            mangMoi[i] = phanTu[i];

        // Ghi lai so phan tu duoc sao chep khi mo rong.
        Console.WriteLine(
            $"Mo rong: {Capacity} -> {sucChuaMoi}, sao chep {Count} phan tu.");

        // Chuyen sang mang moi va giu nguyen thu tu du lieu.
        phanTu = mangMoi;
    }

    // Cho phep doc va sua phan tu theo chi so.
    public T this[int chiSo]
    {
        get
        {
            // Chi so phai nam trong vung du lieu hop le.
            if (chiSo < 0 || chiSo >= Count)
                throw new ArgumentOutOfRangeException(nameof(chiSo));

            // Tra ve gia tri tai vi tri duoc yeu cau.
            return phanTu[chiSo];
        }
        set
        {
            // Khong cho sua vi tri am hoac vi tri chua co du lieu.
            if (chiSo < 0 || chiSo >= Count)
                throw new ArgumentOutOfRangeException(nameof(chiSo));

            // Cap nhat gia tri ma khong thay doi Count va Capacity.
            phanTu[chiSo] = value;
        }
    }
}

class Bai4
{
    static void Main()
    {
        // Tao mang dong voi suc chua mac dinh bang 4.
        DynamicArray<int> mang = new DynamicArray<int>();

        //Kiem thu bat buoc 1
        // Them cac so tu 1 den 10 va theo doi dung luong.
        for (int i = 1; i <= 10; i++)
        {
            mang.Add(i);
            Console.WriteLine(
                $"Them {i}: Count = {mang.Count}, Capacity = {mang.Capacity}");
        }

        // Kiem thu bat buoc 2
        // Doc phan tu tai chi so 2.
        Console.WriteLine($"Gia tri tai chi so 2: {mang[2]}");

        // Sua phan tu tai chi so 2 roi doc lai de kiem tra.
        mang[2] = 99;
        Console.WriteLine($"Sau khi sua: {mang[2]}");

        // In mang de kiem tra thu tu cac phan tu.
        Console.Write("Mang hien tai: ");
        for (int i = 0; i < mang.Count; i++)
            Console.Write(mang[i] + " ");
        Console.WriteLine();

        // Kiem tra chi so am.
        try
        {
            Console.WriteLine(mang[-1]);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Chi so am: da tu choi.");
        }

        // Kiem tra chi so bang Count.
        try
        {
            Console.WriteLine(mang[mang.Count]);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Chi so bang Count: da tu choi.");
        }


        // Kiem tra truong hop suc chua am.
        try
        {
            DynamicArray<int> mangLoi = new DynamicArray<int>(-1);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Suc chua am: da tu choi.");
        }
    }
}
