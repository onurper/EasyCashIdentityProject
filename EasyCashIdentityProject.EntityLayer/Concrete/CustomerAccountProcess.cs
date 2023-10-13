﻿using System.ComponentModel.DataAnnotations;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        [Key]
        public int CustomerAccountProcessID { get; set; }

        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public CustomerAccount SenderCustomer { get; set; }
        public CustomerAccount ReceiverCustomer { get; set; }
        public string Description { get; set; }
    }
}