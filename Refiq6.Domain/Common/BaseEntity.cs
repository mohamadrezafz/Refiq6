

namespace Refiq6.Domain.Common;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;

}
