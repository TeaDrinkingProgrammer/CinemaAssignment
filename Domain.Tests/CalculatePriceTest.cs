using System;

namespace Domain.Tests;

public class CalculatePriceTest
{
    [Fact]
    public void OrderPriceShouldContainDiscountWhenOrderHasStudentTicket()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1, true);
        MovieTicket ticket2 = new MovieTicket(screening, false, 1, 2, false);

        Order order = new Order(1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);

        Assert.Equal(10.00m, order.CalculatePrice());
    }

    [Fact]
    public void OrderPriceShouldContainDiscountWhenOrderIsNotInWeekend()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 03-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1, false);
        MovieTicket ticket2 = new MovieTicket(screening, false, 1, 2, false);

        Order order = new Order(1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);

        decimal sut = order.CalculatePrice();

        Assert.Equal(10.00m, sut);
    }

        [Fact]
    public void OrderPriceShouldContainGroupDiscountWhenOrderIsLargerThanOrEqualTo6Tickets()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1, false);
        MovieTicket ticket2 = new MovieTicket(screening, false, 1, 2, false);
        MovieTicket ticket3 = new MovieTicket(screening, false, 1, 3, false);
        MovieTicket ticket4 = new MovieTicket(screening, false, 1, 4, false);
        MovieTicket ticket5 = new MovieTicket(screening, false, 1, 5, false);
        MovieTicket ticket6 = new MovieTicket(screening, false, 1, 6, false);

        Order order = new Order(1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        order.AddSeatReservation(ticket3);
        order.AddSeatReservation(ticket4);
        order.AddSeatReservation(ticket5);
        order.AddSeatReservation(ticket6);

        decimal sut = order.CalculatePrice();
        
        Assert.Equal(54.00m, sut);
    }

    [Fact]
    public void OrderPriceShouldNotContainGroupDiscountWhenOrderIsLessThan6Tickets()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1, false);
        MovieTicket ticket2 = new MovieTicket(screening, false, 1, 2, false);
        MovieTicket ticket3 = new MovieTicket(screening, false, 1, 3, false);
        MovieTicket ticket4 = new MovieTicket(screening, false, 1, 4, false);
        MovieTicket ticket5 = new MovieTicket(screening, false, 1, 5, false);

        Order order = new Order(1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        order.AddSeatReservation(ticket3);
        order.AddSeatReservation(ticket4);
        order.AddSeatReservation(ticket5);

        decimal sut = order.CalculatePrice();
        
        Assert.Equal(50.00m, sut);
    }

    [Fact]
    public void OrderPriceShouldHave2EuroPremiumForPremiumSeatsWhenTicketHasStudentDiscount()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, true, 1, 1, true);

        Order order = new Order(1);
        order.AddSeatReservation(ticket1);

        decimal sut = order.CalculatePrice();
        
        Assert.Equal(12.00m, sut);
    }

    [Fact]
    public void OrderPriceShouldHave3EuroPremiumForPremiumSeatsWhenTicketDoesNotHaveStudentDiscount()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, true, 1, 1, false);

        Order order = new Order(1);
        order.AddSeatReservation(ticket1);

        decimal sut = order.CalculatePrice();
        
        Assert.Equal(13.00m, sut);
    }

    [Fact]
    public void OrderPriceShouldCost0EurosForPremiumSeatWhenTicketIsFree()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, true, 1, 1, true);
        MovieTicket ticket2 = new MovieTicket(screening, true, 1, 1, false);
        
        Order order = new Order(1);
        order.AddSeatReservation(ticket1);

        decimal sut = order.CalculatePrice();
        
        Assert.Equal(12.00m, sut);
    }
}