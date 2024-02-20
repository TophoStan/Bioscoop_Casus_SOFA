
using Bioscoop_Deel_1_SOFA;

Movie movie = new Movie("The Matrix");
Movie otherMovie = new Movie("John Wick");

// Create a non-weekend movie screening
DateTime wednesdayDateTime = new DateTime(2024, 2, 20, 19, 0, 0); // January 31, 2024 is a Wednesday
MovieScreening movieScreening = new MovieScreening(movie, wednesdayDateTime, 10.0M);

// Create a weekend movie screening
DateTime saturdayDateTime = new DateTime(2024, 2, 3, 19, 0, 0); // February 3, 2024 is a Saturday
MovieScreening weekendMovieScreening = new MovieScreening(movie, saturdayDateTime, 10.0M);

// Add the screenings to the movie
movie.addScreening(movieScreening);
otherMovie.addScreening(weekendMovieScreening);

// Create a non-premium movie ticket
MovieTicket movieTicket = new MovieTicket(movieScreening, 1, 1, false);

// Create a premium movie ticket
MovieTicket premiumMovieTicket = new MovieTicket(movieScreening, 1, 1, true);

// Create a non-student order
Order order = new Order(1, false);
order.AddSeatReservation(premiumMovieTicket);
order.AddSeatReservation(movieTicket); // This ticket should be free because it's the second ticket

order.Submit();
order.Pay();
order.SendTickets();