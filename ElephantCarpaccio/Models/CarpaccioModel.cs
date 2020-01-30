using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElephantCarpaccio.Models
{
    public interface ICarpaccioModel
    {
        string Quantity { get; set; }
        string ProductPrice { get; set; }
        States SelectedState { get; set; }
    }

    public class CarpaccioModel : ICarpaccioModel
    {
        public string Quantity { get; set; }
        public string ProductPrice { get; set; }
        public States SelectedState { get; set; }
    }

    public enum States
    {
        Utah,
        Nevada,
        Texas,
        Alabama,
        California
    }
}
