using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Conversor.Entity.Entity
{
    public class EMoneda
    {[Key]
        public int Id { get; set; }
        public string PaisOrigen { get; set; }
        public string PaisDestino { get; set; }
        public string TipoCambio { get; set; }
      
    }
}
