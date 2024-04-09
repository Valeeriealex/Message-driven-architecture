using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_driven_architecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tables = new List<Table>
            {
                new Table(1),
                new Table(2),
                new Table(3),
            };

            var logger = new ConsoleLogger();
            var reservationManager = new ReservationManager(tables, logger);

            while (true)
            {
                Console.Write("Enter table number to reserve or 'cancel' to cancel: ");
                var input = Console.ReadLine();

                if (input.ToLower() == "cancel")
                {
                    reservationManager.CancelReservationsAsync().GetAwaiter().GetResult();
                }
                else
                {
                    if (int.TryParse(input, out int tableNumber))
                    {
                        try
                        {
                            reservationManager.ReserveTable(tableNumber);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
