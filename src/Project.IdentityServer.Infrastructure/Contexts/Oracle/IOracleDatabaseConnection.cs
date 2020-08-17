
using Oracle.ManagedDataAccess.Client;

namespace Project.identityserver.Infrastructure.Contexts
{
    public interface IOracleDatabaseConnection
    {
        OracleConnection GetConnection();
    }
}