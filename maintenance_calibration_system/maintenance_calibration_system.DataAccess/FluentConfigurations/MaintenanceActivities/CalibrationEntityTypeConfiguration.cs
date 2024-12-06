﻿using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;

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
            
            //Configurando propiedades
            builder.Property(c => c.NameCertificateAuthority).IsRequired();

            // Configuración de la relación muchos a muchos con Sensor
            builder.HasMany(c => c.CalibratedSensors)
                .WithMany() 
                .UsingEntity<Dictionary<string, object>>( 
                    "SensorCalibration", 
                j => j.HasOne<Sensor>().WithMany().HasForeignKey("SensorId"),
                j => j.HasOne<Calibration>().WithMany().HasForeignKey("CalibrationId"),
                j => { j.HasKey("SensorId", "CalibrationId"); 
                });
        }
    }
}
