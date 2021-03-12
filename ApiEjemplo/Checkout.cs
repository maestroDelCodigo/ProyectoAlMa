namespace ApiEjemplo
{
    public class Checkout
    {
        private readonly ICheckout _checkout;

        public Checkout(ICheckout checkout)
        {
            _checkout = checkout;
        }
    }
}
