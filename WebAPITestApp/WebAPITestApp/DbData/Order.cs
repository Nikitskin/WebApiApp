﻿
using System;

namespace WebAPITestApp.DbData
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }                   
        public double Value { get; set; }
        public string OrderedDate { get; set; }
    }
}
