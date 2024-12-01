using Api.autor.Domain.Entities;
using Api.autor.Domain.ValueObjects;

namespace Api.autor.Domain.Aggregates
{
    public class OrderAggregate
    {
        public Guid Id { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public decimal Total { get; private set; }
        public Discount Discount { get; private set; }

        public OrderAggregate(List<OrderItem> items, Discount discount = null)
        {
            Id = Guid.NewGuid();
            Items = items ?? throw new ArgumentNullException(nameof(items));
            Discount = discount;

            CalculateTotal();
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
            CalculateTotal();
        }

        public void ApplyDiscount(Discount discount)
        {
            if (discount.IsValid())
            {
                Discount = discount;
                CalculateTotal();
            }
            else
            {
                throw new InvalidOperationException("Discount is not valid.");
            }
        }

        private void CalculateTotal()
        {
            Total = Items.Sum(item => item.GetTotalPrice());

            if (Discount != null && Discount.IsValid())
            {
                Total = Discount.Apply(Total);
            }
        }
    }
}
