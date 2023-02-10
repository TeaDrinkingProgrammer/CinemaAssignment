using System;

namespace Domain.Tests;

public class CalculatePriceTest
{
    [Fact]
    public void OrderPriceShouldContainDiscountWhenOrderHasStudentTicket()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, new StudentPriceCalculator(false), 1, 1);
        MovieTicket ticket2 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 2);

        Order order = new Order(1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        
        decimal sut = order.CalculatePrice();
        Assert.Equal(10.00m, sut);
    }

    [Fact]
    public void OrderPriceShouldContainDiscountWhenOrderIsNotInWeekend()
    {
        Movie movie = new Movie("Testmovie");
        MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 03-01-2023"),10.00m);
        MovieTicket ticket1 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 1);
        MovieTicket ticket2 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 2);

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
        MovieTicket ticket1 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 1);
        MovieTicket ticket2 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 2);
        MovieTicket ticket3 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 3);
        MovieTicket ticket4 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 4);
        MovieTicket ticket5 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 5);
        MovieTicket ticket6 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 6);

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
        MovieTicket ticket1 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 1);
        MovieTicket ticket2 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 2);
        MovieTicket ticket3 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 3);
        MovieTicket ticket4 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 4);
        MovieTicket ticket5 = new MovieTicket(screening, new NormalPriceCalculator(false), 1, 5);

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
        MovieTicket ticket1 = new MovieTicket(screening, new StudentPriceCalculator(true), 1, 1);

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
        MovieTicket ticket1 = new MovieTicket(screening, new NormalPriceCalculator(true), 1, 1);

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
        MovieTicket ticket1 = new MovieTicket(screening, new StudentPriceCalculator(true), 1, 1);
        MovieTicket ticket2 = new MovieTicket(screening, new NormalPriceCalculator(true), 1, 1);
        
        Order order = new Order(1);
        order.AddSeatReservation(ticket1);

        decimal sut = order.CalculatePrice();
        
        Assert.Equal(12.00m, sut);
    }
}