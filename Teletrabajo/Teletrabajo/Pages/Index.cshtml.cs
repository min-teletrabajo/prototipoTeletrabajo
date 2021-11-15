using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teletrabajo.Models;
using Teletrabajo.Services;

namespace Teletrabajo.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IFormDataService formDataRepository;
        public List<FormData> FormDatas { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IFormDataService formDataRepository)
        {
            _logger = logger;
            this.formDataRepository = formDataRepository;
        }

        public void OnGet()
        {
            FormDatas = formDataRepository.GetAllFormData();
        }
    }
}
