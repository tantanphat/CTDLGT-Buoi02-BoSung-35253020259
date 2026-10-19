  Thông tin sinh viên
- Họ và tên: Nguyễn Tấn Phát
- Mã số sinh viên: 35253020259
- Học phần: 26C1INF50900706

  Cách chạy chương trình
Mỗi bài được đặt trong một project hoặc thư mục riêng: Bai1, Bai2,
Bai3, Bai4.
1. Cài đặt .NET SDK phù hợp với phiên bản C# đang sử dụng.
2. Mở terminal tại thư mục của bài cần chạy.
3. Đưa mã nguồn của bài vào project.
4. Chạy chương trình bằng dotnet run.


   Bài 1: Thống kê và đảo mảng
Mô tả thuật toán
- Nhập n và các phần tử của mảng.
- Khởi tạo tổng, giá trị nhỏ nhất và lớn nhất từ phần tử đầu tiên.
- Duyệt mảng một lần để tính tổng, min, max, trung bình và đếm số phần
  tử âm, dương, bằng 0.
- Dùng hai chỉ số trái và phải để hoán đổi phần tử từ hai đầu vào
  giữa, đảo mảng tại chỗ.
Độ phức tạp
- Thống kê: thời gian Θ(n), bộ nhớ phụ Θ(1).
- Đảo mảng: thời gian Θ(n), bộ nhớ phụ Θ(1).
- Tổng thể sau khi nhập mảng: thời gian Θ(n).
Các ca kiểm thử
1. Mảng 3 7 2 9 5: kiểm tra min, max và mảng sau khi đảo.
2. Mảng -5 0 5 0: kiểm tra đếm số âm, dương và bằng 0.
3. Mảng 8: kiểm tra trường hợp chỉ có một phần tử.
4. Mảng -4 -2 -9: kiểm tra mảng toàn số âm và trung bình âm.
   
Bài 2: Chèn và xóa trên mảng
Mô tả thuật toán
- Dùng count để xác định số phần tử hợp lệ và data.Length để xác
  định sức chứa.
- Insert: kiểm tra chỉ số và sức chứa; dịch phần tử từ phải sang
  trái, ghi giá trị mới rồi tăng count.
- RemoveAt: kiểm tra chỉ số; dịch phần tử phía sau sang trái rồi
  giảm count.
- Chỉ số không hợp lệ phát sinh ArgumentOutOfRangeException; chèn
  khi mảng đầy phát sinh InvalidOperationException.
Độ phức tạp
- Insert tại index: thời gian Θ(count - index + 1), xấu nhất
  O(n), bộ nhớ phụ Θ(1).
- RemoveAt tại index: thời gian Θ(count - index), xấu nhất
  O(n), bộ nhớ phụ Θ(1).
Các ca kiểm thử
1. Ban đầu [4, 7, 2, 9, 5], chèn 99 tại chỉ số 2, sau đó xóa tại
   chỉ số 1.
2. Chèn ở đầu và cuối phần dữ liệu.
3. Xóa ở đầu và xóa phần tử cuối.
4. Chèn với chỉ số âm.
5. Xóa tại index == count.
6. Chèn khi mảng đã đầy.
   
Bài 3: Quản lý sinh viên bằng List<Student>
Mô tả thuật toán
- Tạo lớp Student gồm mã sinh viên, họ tên và điểm.
- Xây dựng menu để thêm, cập nhật, xóa, tìm kiếm, hiển thị và thống kê
  sinh viên.
- Kiểm tra mã trùng trước khi thêm và chỉ chấp nhận điểm từ 0 đến
  10.
- Tìm kiếm theo một phần họ tên, không phân biệt chữ hoa và chữ
  thường.
- Tính điểm trung bình và đếm sinh viên có điểm từ 5 trở lên; xử lý
  riêng khi danh sách rỗng.
Độ phức tạp
- Thêm có kiểm tra mã trùng: O(n).
- Tìm theo mã hoặc họ tên: trường hợp xấu O(n).
- Xóa theo mã: O(n) do tìm kiếm và có thể dịch phần tử.
- Thống kê: Θ(n), bộ nhớ phụ Θ(1).
Các ca kiểm thử
1. Chuẩn bị ít nhất năm sinh viên.
2. Thêm sinh viên hợp lệ.
3. Từ chối mã sinh viên bị trùng.
4. Từ chối điểm nhỏ hơn 0 hoặc lớn hơn 10.
5. Cập nhật họ tên hoặc điểm.
6. Tìm kiếm có kết quả và không có kết quả.
7. Xóa sinh viên tồn tại và thử xóa mã không tồn tại.
8. Thống kê khi danh sách rỗng.
Bài 4: Mảng động và Capacity
Mô tả thuật toán
- Xây dựng lớp DynamicArray<T> dùng mảng T[] làm vùng lưu trữ nội
  bộ.
- Count lưu số phần tử hợp lệ; Capacity trả về sức chứa của mảng.
- Khi thêm mà mảng đã đầy, tạo mảng mới có dung lượng gấp đôi, sao
  chép đúng Count phần tử rồi chuyển sang mảng mới.
- Dùng indexer để đọc và cập nhật phần tử; chỉ chấp nhận chỉ số từ 0
  đến Count - 1.
Độ phức tạp
- Indexer đọc/ghi: O(1).
- Add khi còn chỗ: O(1).
- Add khi phải mở rộng: O(n).
- Add khấu hao qua nhiều lần thêm: O(1).
- Thêm n phần tử từ mảng rỗng: O(n) tổng thời gian; bộ nhớ lưu trữ
  O(n).
Các ca kiểm thử
1. Thêm lần lượt số từ 1 đến 10, in Count và Capacity sau mỗi
   lần thêm.
2. Đọc và cập nhật phần tử bằng indexer.
3. Kiểm tra chỉ số âm và chỉ số bằng Count; cả hai phải phát sinh
   ArgumentOutOfRangeException.
4. Theo dõi dung lượng tăng từ 4 lên 8 và xác nhận thứ tự dữ liệu
   cũ được giữ nguyên.
5. Ghi số phần tử được sao chép mỗi lần mở rộng: 4 phần tử khi tăng
   4 → 8, và 8 phần tử khi tăng 8 → 16.

   Khai báo sử dụng AI
Tôi đã sử dụng ChatGPT để hỗ trợ giải thích yêu cầu, gợi ý cách làm, xây
dựng ca kiểm thử và hướng dẫn soạn README. Tôi đã chạy thử chương trình, kiểm tra
kết quả và chịu trách nhiệm về mã nguồn cùng nội dung nộp bài.
