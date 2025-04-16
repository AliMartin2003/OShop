using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Interfaces
{
    public interface ICart
    {
        bool CreateCart(Cart cart);
        bool UpdateCart(Cart cart);
        IEnumerable<Cart> GetCarts();
        Cart GetCart(int cartId);
        bool DeleteCart(int cartId);
    }
}
