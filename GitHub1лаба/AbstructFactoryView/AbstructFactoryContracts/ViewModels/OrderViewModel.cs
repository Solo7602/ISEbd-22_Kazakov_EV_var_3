using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AbstructFactoryContracts.Enums;



namespace AbstructFactoryContracts.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Изделие")]
        public string Engine { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
