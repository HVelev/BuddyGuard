using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Models
{
    public class NomenclatureDTO<T>
    {
        public T Value { get; set; }

        public string DisplayName { get; set; }

        public decimal? Price { get; set; }
    }
}
