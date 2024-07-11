﻿using _0_Framwork.Application;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        public string Name { get; set; }
        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]
        public int DiscountRate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; }
    }
}
