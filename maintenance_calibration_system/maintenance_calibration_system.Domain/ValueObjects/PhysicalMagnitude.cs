using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Domain.ValueObjects
{
    /// <summary>
    /// Representa una magnitud física en el sistema.
    /// </summary>
    public class PhysicalMagnitude : ValueObject
    {

        public string? Name { get; set; } 
        public string? UnitofMagnitude { get; set; }

        public PhysicalMagnitude() { }
        
        public PhysicalMagnitude(string? name, string? magnitude)
        { 
            Name = name;
            UnitofMagnitude = magnitude;  
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return UnitofMagnitude;
        }

       
    }
}