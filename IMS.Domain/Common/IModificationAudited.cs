using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetDocs.Domain.Common
{
    public interface IModificationAudited : IHasModificationTime
    {
        string? ModifiedBy { get; set; }
    }
}
