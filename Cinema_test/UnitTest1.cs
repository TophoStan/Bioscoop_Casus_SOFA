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
            decimal result = order.CalculatePrice();
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
            decimal result = order.CalculatePrice();
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
            decimal result = order.CalculatePrice();
            Assert.Equal(12, result);
        }

        //1,3,8,11,12
        [Fact]
        public void IsNotAStudentAndWithinTheWeekendThatIsPremiumAndGroupIsNotBiggerThan6ShouldEqual()
        {
            DateTime monday = new DateTime(2024, 2, 5);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, monday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, true);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);
            decimal result = order.CalculatePrice();
            Assert.Equal(13, result);
        }

        //1,3,8,11,13
        [Fact]
        public void IsNotAStudentAndWithinTheWeekendThatIsPremiumAndGroupIsBiggerThan39ShouldEqual()
        {
            DateTime sunday = new DateTime(2024, 2, 4);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, sunday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, true);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket1);
            decimal result = order.CalculatePrice();
            Assert.Equal(70.2m, result);
        }

        //1,3,9,14,16
        [Fact]
        public void IsNotAStudentAndNotInTheWeekendHasSecondTicketAndIsPremiumTicketThan13ShouldEqual()
        {
            DateTime monday = new DateTime(2024, 2, 5);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, monday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, true);
            MovieTicket movieTicket2 = new(movieScreening, 1, 2, true);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            decimal result = order.CalculatePrice();
            Assert.Equal(13, result);
        }

        //1,3,9,14,17
        [Fact]
        public void IsNotAStudentAndNotInTheWeekendHasSecondTicketAndIsNotPremiumTicketThan10ShouldEqual()
        {
            DateTime monday = new DateTime(2024, 2, 5);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, monday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, false);
            MovieTicket movieTicket2 = new(movieScreening, 1, 2, false);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);
            order.addSeatReservation(movieTicket2);
            decimal result = order.CalculatePrice();
            Assert.Equal(10, result);
        }   

        //1,3,9,15
        [Fact]
        public void IsNotAStudentAndNotInTheWeekendHasNotSecondTicketThan10ShouldEqual()
        {
            DateTime monday = new DateTime(2024, 2, 5);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, monday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, false);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);
            decimal result = order.CalculatePrice();
            Assert.Equal(10, result);
        }


        [Fact]
        public void exportToPlainText()
        {
            DateTime monday = new DateTime(2024, 2, 5);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, monday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, false);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);


            order.Export(TicketExportFormat.PLAINTEXT);

            StreamReader sr = new StreamReader("C:/dev/Order_1.txt");
           string result = sr.ReadToEnd();

            Assert.Contains("Order Number: 1", result);
        }

        [Fact]
        public void exportToJSON()
        {
            DateTime monday = new DateTime(2024, 2, 5);
            Movie movie = new("The matrix");
            MovieScreening movieScreening = new(movie, monday, 10);
            MovieTicket movieTicket1 = new(movieScreening, 1, 2, false);
            Order order = new(1, false);
            order.addSeatReservation(movieTicket1);


            order.Export(TicketExportFormat.JSON);

            StreamReader sr = new StreamReader("C:/dev/Order_1.json");
            string result = sr.ReadToEnd();

            Assert.Contains("\"OrderNr\": 1", result);
        }

        [Fact]
        public void getTitleFromMovie()
        {
            Movie movie = new("The matrix");

            Assert.Equal("The matrix", movie.getTitle());
        }
        [Fact]
        public void toStringFromMovie()
        {
            Movie movie = new("The matrix");

            Assert.Equal("Titlename: The matrix", movie.ToString());
        }


    }
}