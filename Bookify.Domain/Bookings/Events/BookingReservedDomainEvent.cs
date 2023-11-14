using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;