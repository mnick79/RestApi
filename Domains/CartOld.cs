﻿using RestApi.Domains.BaseEntity;

namespace RestApi.Domains
{
    public class CartOld: Entity
    {
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public int CustomerNumber { get; set; }


    }
}