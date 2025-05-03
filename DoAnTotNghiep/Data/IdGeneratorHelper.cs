using DoAnTotNghiep.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Data
{
    public static class IdGeneratorHelper
    {
        public static async Task<string> GenerateNextIdAsync<TEntity>(
            DbContext context,
            string prefix,
            int padding = 3)
         where TEntity : BaseEntity
        {
            var dbSet = context.Set<TEntity>();
            string dateId = DateTime.Now.ToString("yyyyddMM");
            string fullPrefix = $"{prefix}{dateId}";

            var lastId = await dbSet
                .Where(e => e.id.StartsWith(fullPrefix))  
                .OrderByDescending(e => e.id)
                .Select(e => e.id)
                .FirstOrDefaultAsync();

            int lastNumber = 0;
            if (!string.IsNullOrEmpty(lastId))
            {
                // Trích xuất phần số từ id và chuyển đổi sang số
                if (int.TryParse(lastId.Substring(fullPrefix.Length), out lastNumber))
                {
                    lastNumber++;  // Tăng số lên một
                }
            }
            else
            {
                lastNumber = 1;  // Nếu không có ID nào thì bắt đầu từ 1
            }

            return $"{fullPrefix}{lastNumber.ToString($"D{padding}")}";  // Trả về ID với số được padding
        }
    }
}
