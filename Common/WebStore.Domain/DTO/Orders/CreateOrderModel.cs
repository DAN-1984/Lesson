using System;
using System.Collections.Generic;
using System.Text;
using WebStore.ViewModels.Orders;

namespace WebStore.Domain.DTO.Orders
{
    /// <summary>Структура оформляемого заказа</summary>
    public class CreateOrderModel
    {
        /// <summary>Информация о заказе</summary>
        public OrderViewModel OrderViewModel { get; set; }

        /// <summary>Пункты заказа</summary>
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
