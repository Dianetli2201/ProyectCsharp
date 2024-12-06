﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using maintenance_calibration_system.DataAccess.Contexts;

#nullable disable

namespace maintenance_calibration_system.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241206045050_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("MaintenanceActuator", b =>
                {
                    b.Property<Guid>("MaintenanceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ActuatorId")
                        .HasColumnType("TEXT");

                    b.HasKey("MaintenanceId", "ActuatorId");

                    b.HasIndex("ActuatorId");

                    b.ToTable("MaintenanceActuator");
                });

            modelBuilder.Entity("SensorCalibration", b =>
                {
                    b.Property<Guid>("SensorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CalibrationId")
                        .HasColumnType("TEXT");

                    b.HasKey("SensorId", "CalibrationId");

                    b.HasIndex("CalibrationId");

                    b.ToTable("SensorCalibration");
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_Historicos.MaintenanceActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateActivity")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameTechnician")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MaintenanceActivities", (string)null);

                    b.HasDiscriminator<string>("ActivityType").HasValue("MaintenanceActivity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_de_Configuracion.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AlphanumericCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Equipments", (string)null);

                    b.HasDiscriminator<string>("EquipmentType").HasValue("Equipment");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_de_Planificación.Planning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentElement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Planes", (string)null);
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_Historicos.Calibration", b =>
                {
                    b.HasBaseType("maintenance_calibration_system.Domain.Datos_Historicos.MaintenanceActivity");

                    b.Property<string>("NameCertificateAuthority")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PlanningId")
                        .HasColumnType("TEXT");

                    b.HasIndex("PlanningId");

                    b.ToTable("MaintenanceActivities", null, t =>
                        {
                            t.Property("PlanningId")
                                .HasColumnName("Calibration_PlanningId");
                        });

                    b.HasDiscriminator().HasValue("Calibration");
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_Historicos.Maintenance", b =>
                {
                    b.HasBaseType("maintenance_calibration_system.Domain.Datos_Historicos.MaintenanceActivity");

                    b.Property<Guid?>("PlanningId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeMaintenance")
                        .HasColumnType("INTEGER");

                    b.HasIndex("PlanningId");

                    b.ToTable("MaintenanceActivities", (string)null);

                    b.HasDiscriminator().HasValue("Maintenance");
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_de_Configuración.Actuador", b =>
                {
                    b.HasBaseType("maintenance_calibration_system.Domain.Datos_de_Configuracion.Equipment");

                    b.Property<string>("CodeControl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Maintenance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SignalControl")
                        .HasColumnType("INTEGER");

                    b.ToTable("Equipments", (string)null);

                    b.HasDiscriminator().HasValue("Actuator");
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_de_Configuración.Sensor", b =>
                {
                    b.HasBaseType("maintenance_calibration_system.Domain.Datos_de_Configuracion.Equipment");

                    b.Property<bool>("Calibrated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrincipleOperation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Protocol")
                        .HasColumnType("INTEGER");

                    b.ToTable("Equipments", (string)null);

                    b.HasDiscriminator().HasValue("Sensor");
                });

            modelBuilder.Entity("MaintenanceActuator", b =>
                {
                    b.HasOne("maintenance_calibration_system.Domain.Datos_de_Configuración.Actuador", null)
                        .WithMany()
                        .HasForeignKey("ActuatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("maintenance_calibration_system.Domain.Datos_Historicos.Maintenance", null)
                        .WithMany()
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SensorCalibration", b =>
                {
                    b.HasOne("maintenance_calibration_system.Domain.Datos_Historicos.Calibration", null)
                        .WithMany()
                        .HasForeignKey("CalibrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("maintenance_calibration_system.Domain.Datos_de_Configuración.Sensor", null)
                        .WithMany()
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_de_Configuracion.Equipment", b =>
                {
                    b.OwnsOne("maintenance_calibration_system.Domain.ValueObjects.PhysicalMagnitude", "Magnitude", b1 =>
                        {
                            b1.Property<Guid>("EquipmentId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("UnitofMagnitude")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("EquipmentId");

                            b1.ToTable("Equipments");

                            b1.WithOwner()
                                .HasForeignKey("EquipmentId");
                        });

                    b.Navigation("Magnitude")
                        .IsRequired();
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_Historicos.Calibration", b =>
                {
                    b.HasOne("maintenance_calibration_system.Domain.Datos_de_Planificación.Planning", null)
                        .WithMany()
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("maintenance_calibration_system.Domain.Datos_Historicos.Maintenance", b =>
                {
                    b.HasOne("maintenance_calibration_system.Domain.Datos_de_Planificación.Planning", null)
                        .WithMany()
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
