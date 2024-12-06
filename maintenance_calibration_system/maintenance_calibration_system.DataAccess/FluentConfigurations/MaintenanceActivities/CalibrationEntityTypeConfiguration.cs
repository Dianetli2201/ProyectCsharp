﻿using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using maintenance_calibration_system.Domain.Datos_de_Configuracion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Datos_de_Configuración;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.MaintenanceActivities
{
    public class CalibrationEntityTypeConfiguration
       : IEntityTypeConfiguration<Calibration>
    {
        public void Configure(EntityTypeBuilder<Calibration> builder)
        {
            builder.ToTable("Calibraciones");
            builder.HasBaseType(typeof(MaintenanceActivity));
            builder.Property(x => x.NameCertificateAuthority).IsRequired();
            
            // Configurar relación muchos a muchos entre Calibration y Sensor
            builder.HasMany(x => x.CalibratedSensors) 
                .WithMany() 
                .UsingEntity<Dictionary<string, object>>( 
                "CalibrationSensors",
             j => j.HasOne<Sensor>().WithMany().HasForeignKey("SensorId"),
             j => j.HasOne<Calibration>().WithMany().HasForeignKey("CalibrationId"),
             j => { j.HasKey("CalibrationId", "SensorId"); });
        }
    }
}
