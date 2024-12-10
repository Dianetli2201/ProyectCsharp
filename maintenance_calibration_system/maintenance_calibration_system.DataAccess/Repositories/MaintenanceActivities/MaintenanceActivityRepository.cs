using System; // Para tipos básicos como Guid y DateTime.
using System.Collections.Generic; // Para usar colecciones genéricas como IEnumerable.
using System.Linq; // Para utilizar métodos LINQ como ToList().
using maintenance_calibration_system.Domain.Common; // Para la clase Entity.
using maintenance_calibration_system.Domain.Datos_Historicos; // Para MaintenanceActivity.
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Respositories.Common; // Para ApplicationContext.

namespace maintenance_calibration_system.DataAccess.Respositories.MaintenanceActivities
{
    public abstract class MaintenanceActivityRepository<T> : RepositoryBase<T>  where T : MaintenanceActivity 
    {

        /// <summary>Constructor</summary>
        protected MaintenanceActivityRepository(ApplicationContext context) : base(context)
        {
        }


    }
}