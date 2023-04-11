using System.Threading.Tasks;

namespace AdvBoxCRM.Data;

public interface IAdvBoxCRMDbSchemaMigrator
{
    Task MigrateAsync();
}
