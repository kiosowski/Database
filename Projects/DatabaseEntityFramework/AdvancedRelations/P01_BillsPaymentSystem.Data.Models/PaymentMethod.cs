using P01_BillsPaymentSystem.Data.Models.Atributes;
using P01_BillsPaymentSystem.Data.Models.Enum;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Xor(nameof(BankAccountId))]
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

    }
}