using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_driven_architecture
{
    public class Table
    {
        public int Number { get; }
        public bool IsReserved { get; private set; }

        public Table(int number)
        {
            Number = number;
            IsReserved = false;
        }

        public void Reserve()
        {
            if (IsReserved)
            {
                throw new InvalidOperationException("Table is already reserved.");
            }

            IsReserved = true;
            Console.WriteLine($"Table {Number} has been reserved.");
            Audit("Table reserved.");
        }

        public void CancelReservation()
        {
            if (!IsReserved)
            {
                throw new InvalidOperationException("Table is not reserved.");
            }

            IsReserved = false;
            Console.WriteLine($"Table {Number} reservation has been cancelled.");
            Audit("Table reservation cancelled.");
        }

        private void Audit(string message)
        {
            Console.WriteLine($"[Audit] {message}");
        }
    }
}
