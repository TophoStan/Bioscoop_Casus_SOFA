namespace Cinema_test
{
    public class UnitTest1
    {
        //1,2,4
        [Fact]
        public void IsAStudentAndHasSecondTicketThatIsNotPremumShouldEqual10()
        {
            Movie movie = new Movie("The matrix");
            MovieScreening movieScreening = new(movie, DateTime.Now, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, false);
            MovieTicket movieTicket2 = new(movieScreening, 1, 2, false);
            Order order = new(1, true);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);


            decimal result = order.calculatePrice();


            Assert.Equal(10, result);
        }
        //1,2,5,6
        [Fact]
        public void IsAStudentAndIsNotSecondTicketThatIsPremiumShouldEqual10()
        {
            Movie movie = new Movie("The matrix");
            MovieScreening movieScreening = new(movie, DateTime.Now, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, false);
            Order order = new(1, true);
            order.addSeatReservation(movieTicket1);
            decimal result = order.calculatePrice();
            Assert.Equal(10, result);
        }
        //1,2,5,7
        [Fact]
        public void IsAStudentAndIsNotSecondTicketThatIsPremiumShouldEqual12()
        {
            Movie movie = new Movie("The matrix");
            MovieScreening movieScreening = new(movie, DateTime.Now, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, true);
            Order order = new(1, true);
            order.addSeatReservation(movieTicket1);
            decimal result = order.calculatePrice();
            Assert.Equal(12, result);
        }

        //1,3,8,11,13
        [Fact]
        public void IsNotAStudentAndWithinTheWeekendThatIsPremiumAndGroupIsNotBiggerThan6ShouldEqual()
        {

            DateTime monday = new DateTime(2024, 2, 5);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, monday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, true);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);
            decimal result = order.calculatePrice();
            Assert.Equal(13, result);
        }

    }

    #if(true && (false || false))
}