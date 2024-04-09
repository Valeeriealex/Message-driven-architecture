using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_driven_architecture
{
    public class ReservationManager
    {
        private readonly List<Table> _tables;
        private readonly ILogger _logger;

        public ReservationManager(List<Table> tables, ILogger logger)
        {
            _tables = tables;
            _logger = logger;
        }

        public void ReserveTable(int tableNumber)
        {
            var table = _tables.Find(t => t.Number == tableNumber);
            if (table == null)
            {
                throw new ArgumentException($"Table {tableNumber} not found.");
            }

            table.Reserve();
            _logger.LogInformation($"Table {tableNumber} reserved.");
        }

        public async Task CancelReservationsAsync()
        {
            while (true)
            {
                foreach (var table in _tables)
                {
                    if (table.IsReserved)
                    {
                        table.CancelReservation();
                        _logger.LogDebug($"Table {table.Number} reservation cancelled.");
                    }
                }

                int cancelReservation = 20;
                await Task.Delay(TimeSpan.FromSeconds(cancelReservation));
            }
        }
    }
}
