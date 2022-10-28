using Doughnut.Domain.DomainModels.DoughnutSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doughnut.Domain.DomainModels.Referential
{
    public class RefSelectionProcess
    {
        public Guid Id { get; set; }
        public byte Code { get; set; }
        public byte? ParentCode { get; set; }
        public string Text { get; set; }
        public string? Action { get; set; }
        

        private readonly List<RefSelectionProcess> _next = new();
        public IReadOnlyList<RefSelectionProcess> NextSelection => _next;


        public RefSelectionProcess(byte code, string text, string? action = null)
        {
            Code = code;
            Text = text;
            Action = action;
        }

        public RefSelectionProcess(byte code, byte parentCode, string text, string? action = null)
        {
            Code = code;
            ParentCode = parentCode;
            Text = text;
            Action = action;
        }

        public void AddNextSelection(RefSelectionProcess obj)
        {
            _next.Add(obj);
        }
    }
}
