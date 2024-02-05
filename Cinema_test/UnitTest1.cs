namespace Cinema_test
{
    public class UnitTest1
    {
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
    }
}