using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEjemplo.Controllers;
using ApiEjemplo.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
