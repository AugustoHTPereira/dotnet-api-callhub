using System;

namespace Callhub.Application.ViewModels
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CompanyViewModel Company { get; set; }
    }
}
