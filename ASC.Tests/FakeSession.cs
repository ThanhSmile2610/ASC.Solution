using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ASC.Tests
{
    public class FakeSession : ISession
    {
        private readonly Dictionary<string, byte[]> _sessionStorage = new Dictionary<string, byte[]>();

        public bool IsAvailable => true; // Giả lập session luôn khả dụng
        public string Id => Guid.NewGuid().ToString(); // Sinh ID session giả lập
        public IEnumerable<string> Keys => _sessionStorage.Keys; // Lấy danh sách key trong session

        public void Set(string key, byte[] value) => _sessionStorage[key] = value; // Lưu dữ liệu vào session

        public bool TryGetValue(string key, out byte[] value) => _sessionStorage.TryGetValue(key, out value); // Lấy giá trị từ session

        public void Remove(string key) => _sessionStorage.Remove(key); // Xóa một key trong session

        public void Clear() => _sessionStorage.Clear(); // Xóa toàn bộ session

        public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask; // Không cần thực hiện gì

        public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask; // Không cần thực hiện gì
    }
}
