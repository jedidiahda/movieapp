using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class PaymentAdapter
    {
        public static Payment GetPayment(PaymentDTO paymentDTO)
        {
            var payment = new Payment();
            payment.PaymentType = paymentDTO.PaymentType;
            payment.Amount = paymentDTO.Amount;
            payment.BillingAddress = paymentDTO.BillingAddress;
            payment.PaymentDate = paymentDTO.PaymentDate;

            return payment;
        }

        public static PaymentDTO GetPaymentDTO(Payment payment)
        {
            PaymentDTO paymentDTO = new PaymentDTO();
            paymentDTO.PaymentType = payment.PaymentType;
            paymentDTO.Amount = payment.Amount;
            paymentDTO.PaymentDate = payment.PaymentDate;

            return paymentDTO;
        }
    }
}
