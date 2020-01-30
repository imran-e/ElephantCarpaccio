using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElephantCarpaccio.Models;

namespace ElephantCarpaccio.Service
{
    public interface ICarpaccioService { CarpaccioResult PriceCalculator(ICarpaccioModel input); }
    public class CarpaccioService : ICarpaccioService
    {
        public CarpaccioResult PriceCalculator(ICarpaccioModel model)
        {
            var productPrice = Convert.ToDecimal(model.ProductPrice);
            var quantity = int.Parse(model.Quantity);
            var state = model.SelectedState.ToString().ToUpper();
            var total = productPrice * quantity;

            var stateCode = HelperFunctions.GetStateCode()[state.ToUpper()];
            var stateTax = HelperFunctions.GetStateTax()[stateCode];
            var discountRate = HelperFunctions.GetDiscountRate(total);

            var totalPriceWithDiscount = total - (total * discountRate / 100);

            var totalPriceAfterTax = totalPriceWithDiscount - (totalPriceWithDiscount * stateTax / 100);

            var result = new CarpaccioResult()
            {
                Total = Math.Round(totalPriceAfterTax, 2),
                AppliedPercentage = discountRate
            };

            return result;
        }
    }
}
