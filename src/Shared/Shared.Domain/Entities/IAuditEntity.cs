using System;

namespace Shared.Domain.Entities
{
    public interface IAuditEntity
    {
        DateTime? AddedDate { get; set; }

        DateTime? ModifiedDate { get; set; }

        DateTime? DeletedDate { get; set; }

        string IPAddress { get; set; }
    }
}