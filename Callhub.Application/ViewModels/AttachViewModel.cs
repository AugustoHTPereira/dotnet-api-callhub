using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Application.ViewModels
{
    public class AttachViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string FullPath { get; set; }
        public string RelativePath { get; set; }
        public string TableName { get; set; }
        public Guid TableRegisterId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
