using ValueOf;

namespace PartyTracker.Api.Domain.Common;

public class EventId : ValueOf<Guid, EventId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Event Id cannot be empty", nameof(EventId));
        }
    }
}
