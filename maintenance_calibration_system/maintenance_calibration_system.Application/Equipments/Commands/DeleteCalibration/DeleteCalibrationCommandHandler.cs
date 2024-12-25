﻿using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Calibrations.Commands.CreateCalibration;
using maintenance_calibration_system.Application.Equipments.Commands.DeleteActuador;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_Historicos; // Asegúrate de que este espacio de nombres sea correcto


namespace maintenance_calibration_system.Application.Calibrations.Commands.DeleteCalibration
{
    public class DeleteCalibrationCommandHandler(
        ICalibrationRepository<Calibration> calibrationRepository,
        IUnitOfWork unitOfWork) : ICommandHandler<DeleteCalibrationCommand, bool>
    {
        private readonly ICalibrationRepository<Calibration> _calibrationRepository = calibrationRepository; // Repositorio para manejar calibraciones
        private readonly IUnitOfWork _unitOfWork = unitOfWork; // Unidad de trabajo para manejar transacciones

        public Task<bool> Handle(DeleteCalibrationCommand request, CancellationToken cancellationToken)
        {
            bool result = true;

            try
            {
                object value =_calibrationRepository.Delete(request.Id); // Eliminar la calibración por ID
                _unitOfWork.SaveChanges(); // Guardar cambios en la unidad de trabajo
            }
            catch (Exception)
            {
                // Manejo de excepciones (opcional)
                result = false; // Si ocurre un error, se establece result a false
                // Aquí puedes registrar el error o manejarlo según sea necesario
            }

            return Task.FromResult(result); // Retornar el resultado de la operación
        }
    }
}