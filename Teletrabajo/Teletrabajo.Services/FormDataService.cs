using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teletrabajo.Models;
using Teletrabajo.Models.Enums;

namespace Teletrabajo.Services
{
    public class FormDataService : IFormDataService
    {
        public readonly TeletrabajoBaseDeDatosContext _context;

        public FormDataService(TeletrabajoBaseDeDatosContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Hace el insert de los datos del formulario
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>

        public async Task<FormData> Post(FormData formData,EstadoTramite estado)
        {
            formData.Id = Guid.NewGuid();
            formData.FechaCreacion = DateTime.Now;
            formData.EstadoTramiteId = (int)estado;

            _context.FormData.Add(formData);
            await _context.SaveChangesAsync();

            return formData;
        }
    }
}
