﻿using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using Microsoft.Extensions.Logging;


namespace maintenance_calibration_system.Application.Equipments.Commands.UpdateActuador
{
    public class UpdateActuadorCommandHandler(
        IEquipmentRepository<Actuador> equipmentRepository,
        IUnitOfWork unitOfWork, ILogger logger) : ICommandHandler<UpdateActuadorCommand, bool>
    {
        private readonly IEquipmentRepository<Actuador> _equipmentRepository = equipmentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger _logger = logger;

        public Task<bool> Handle(UpdateActuadorCommand request, CancellationToken cancellationToken)
        {
            // Buscar el sensor existente
            var existingActuador = _equipmentRepository.GetById(request.Id);

            if (existingActuador == null)
            {
                _logger.LogWarning("Actuador with ID {ActuadorId} not found.", request.Id);
                return Task.FromResult(false); // Devuelve false si no se encuentra el sensor
            }

            // Crear un nuevo objeto Sensor con los valores actualizados usando el constructor
            var updatedActuador = new Actuador(
                existingActuador.Id, // Mantener el mismo ID
                request.AlphanumericCode,
                request.Magnitude,
                request.Manufacturer,
                request.CodeControl,
                request.SignalControl); // Asegúrate de que esta propiedad esté presente


            // Actualizar el sensor en el repositorio
            _equipmentRepository.Update(updatedActuador);
            _unitOfWork.SaveChanges();

            _logger.LogInformation("Actuador with ID {ActuadorId} updated successfully.", request.Id);
            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}
