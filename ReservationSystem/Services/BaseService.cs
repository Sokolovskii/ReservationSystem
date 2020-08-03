using System;
using Microsoft.Extensions.Logging;
using ReservationSystem.Exceptions;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services
{
    /// <summary>
    /// Базовый класс для сервисов
    /// </summary>
    public class BaseService
    {
        protected readonly ILogger _logger;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="logger">Логгер</param>
        protected BaseService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Try-catch оболочка для возвращающего метода с отловом ошибки NotFound 
        /// </summary>
        protected ServiceResponse<T> Execute<T>(Func<ServiceResponse<T>> function)
        {
            try
            {
                return function();
            }
            catch (ObjectNotFoundException exception)
            {
                _logger.LogWarning(exception.Message);
                return ServiceResponse<T>.Warning(exception.Message);
            }
            catch(Exception exception)
            {
                _logger.LogError($"Произошло исключение {exception.Message}");
                return ServiceResponse<T>.Fail(exception.Message);
            }
        }

        /// <summary>
        /// Try-catch оболочка для невозвращающего метода
        /// принимающего 1 тип аргументов
        /// с отловом ошибки NotFound
        /// </summary>
        protected ServiceResponse.NonGeneric.ServiceResponse Execute(Func<ServiceResponse.NonGeneric.ServiceResponse> function)
        {
            try
            {
                return function();
            }
            catch (ObjectNotFoundException exception)
            {
                _logger.LogWarning(exception.Message);
                return ServiceResponse.NonGeneric.ServiceResponse.Warning(exception.Message);
            }
            catch(Exception exception)
            {
                _logger.LogError($"Произошло исключение {exception.Message}");
                return ServiceResponse.NonGeneric.ServiceResponse.Fail(exception.Message);
            }
        }
    }
}