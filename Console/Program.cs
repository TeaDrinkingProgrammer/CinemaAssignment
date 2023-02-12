using System.Globalization;
using Domain;

Movie movie = new Movie("Testmovie");
MovieScreening screening = new MovieScreening(movie, DateTime.Parse("13:00 01-01-2023"),10.00m);
MovieTicket ticket1 = new MovieTicket(screening, new StudentPriceCalculator(true), 1, 1);
MovieTicket ticket2 = new MovieTicket(screening, new NormalPriceCalculator(true), 1, 1);

Order order = new Order(1);
order.AddSeatReservation(ticket1);
order.Export(new JsonExport());