using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core
{
    public interface IWithId
    {
        int Id { get; set; }
    }
}
