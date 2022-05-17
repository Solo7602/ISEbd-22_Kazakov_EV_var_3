﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _AbstractFactoryListImplement.Models;



namespace _AbstractFactoryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Details> Details { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Engines> Engines { get; set; }
        public List<Clients> Clients { get; set; }
        private DataListSingleton()
        {
            Details = new List<Details>();
            Orders = new List<Orders>();
            Engines = new List<Engines>();
            Clients = new List<Clients>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
        }
}
