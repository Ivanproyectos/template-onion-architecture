using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.autor.Domain.ValueObjects
{
    public class Discount : IEquatable<Discount>
    {
        public decimal Percentage { get; }
        public DateTime ValidFrom { get; }
        public DateTime ValidTo { get; }

        // Constructor que define un descuento con su porcentaje y rango de fechas
        public Discount(decimal percentage, DateTime validFrom, DateTime validTo)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100.");

            if (validFrom >= validTo)
                throw new ArgumentException("ValidFrom must be earlier than ValidTo.");

            Percentage = percentage;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        // Método para aplicar el descuento a un total si está vigente
        public decimal Apply(decimal total)
        {
            if (!IsActive())
                return total;  // Si el descuento no está activo, no se aplica

            return total - (total * (Percentage / 100));
        }

        // Método para verificar si el descuento está activo en función de la fecha actual
        public bool IsActive()
        {
            var currentDate = DateTime.UtcNow;
            return currentDate >= ValidFrom && currentDate <= ValidTo;
        }

        public bool IsValid()
        {
            var now = DateTime.UtcNow;
            return now >= ValidFrom && now <= ValidTo;
        }

        // Implementación de IEquatable para comparar VO basados en sus valores
        public bool Equals(Discount other)
        {
            if (other == null) return false;

            return Percentage == other.Percentage &&
                   ValidFrom == other.ValidFrom &&
                   ValidTo == other.ValidTo;
        }


        // Sobrescribir Equals y GetHashCode para comparar VO por valor
        public override bool Equals(object obj)
        {
            return Equals(obj as Discount);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Percentage, ValidFrom, ValidTo);
        }
    }
}
