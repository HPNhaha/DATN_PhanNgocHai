using DoAnTotNghiep.Models.BaseEntities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace DoAnTotNghiep.Data
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context == null) return result;

            var user = _httpContextAccessor.HttpContext?.User.FindFirst("userName")?.Value;// lay username da tao trong claim
            
            Console.WriteLine($" AuditInterceptor Running - User: {user}"); // Debug log
            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.createdBy = user;
                    entry.Entity.createdAt = DateTime.Now;
                    entry.Entity.updatedBy = user;
                    entry.Entity.updatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.updatedBy = user;
                    entry.Entity.updatedAt = DateTime.Now;
                }
            }
            return await base.SavingChangesAsync(eventData, result,cancellationToken);
        }
    }
}
