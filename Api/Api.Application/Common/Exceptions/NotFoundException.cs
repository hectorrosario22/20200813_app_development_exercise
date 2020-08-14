using System;

namespace Api.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }

        public NotFoundException(string entityName, object entityKey) : base($"La entidad {entityName} con el identificador {entityKey} no existe o fue eliminada")
        { }
    }
}
