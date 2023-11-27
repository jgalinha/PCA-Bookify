using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Dapper;

namespace Bookify.Application.Bookings.GetBooking;

public sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse> {
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory) {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken) {
        using var sqlConnection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                           SELECT
                               id AS Id,
                               apartments_id AS ApartmentsId,
                               users_id AS UsersId,
                               status AS Status,
                               price_for_period_amount AS PriceAmout,
                               price_for_period_currency AS PriceCurrency,
                               cleaning_fee_amount AS CleaningFeeAmount,
                               cleaning_fee_currency AS CleaningFeeCurrency,
                               amenities_up_charges_amount AS AmenitiesUpChargesAmount,
                               amenities_up_charges_currency AS AmenitiesUpChargesCurrency,
                               total_price_amount AS TotalPriceAmount,
                               total_price_currency AS TotalPriceCurrency,
                               duration_start AS DurationStart,
                               duration_end AS DurationEnd,
                               created_on_utc AS CreatedOnUtc,
                           FROM bookings
                           WHERE id = @BookingId
                           """;
        var booking = await sqlConnection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql,
            new {
                request.BookingId
            });

        return booking;
    }
}