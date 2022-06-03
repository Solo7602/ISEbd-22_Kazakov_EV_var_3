﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructFactoryContracts.ViewModels
{
   public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; }
        [DisplayName("Электронная почта")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
