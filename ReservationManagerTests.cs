using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Message_driven_architecture
{
    public class ReservationManagerTests
    {
        [Fact]
        public async Task ReserveTable_ReservesTable()
        {
            // Arrange
            var tables = Enumerable.Range(1, 3).Select(i => new Table(i)).ToList();
            var logger = new FakeLogger();
            var reservationManager = new ReservationManager(tables, logger);

            // Act
            reservationManager.ReserveTable(2);

            // Assert
            Assert.True(tables.Single(t => t.Number == 2).IsReserved);
        }
    }
}
