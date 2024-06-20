using System.Data;

namespace Core.App.Common.Interfaces
{
    public interface IDapperDbContext
    {
        IDbConnection CreateConnection();
    }
}
