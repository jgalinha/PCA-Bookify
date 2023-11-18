using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings;

public static class BookingErrors {
    public static Error NotFound = new(
        "Booking.NotFound",
        "The Booking with the specified identifier was not found");

    public static Error Overlap = new(
        "Booking.Overlap",
        "The current booking is overlapping with an existing one");

    public static Error NotReserved = new(
        "Booking.NotReserved",
        "the booking is not pending");

    public static Error NotConfirmed = new(
        "Booking.NotReserved",
        "The booking id not confirmed");

    public static Error AlreadyStarted = new(
        "Booking.AlreadyStarted",
        "the booking has already started");
}