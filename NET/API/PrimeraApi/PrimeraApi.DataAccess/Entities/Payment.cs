﻿using System;
using System.Collections.Generic;

namespace PrimeraApi.DataAccess.Entities
{
    public partial class Payment
    {
        public int CustomerNumber { get; set; }
        public string CheckNumber { get; set; } = null!;
        public DateOnly PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public virtual Customer CustomerNumberNavigation { get; set; } = null!;
    }
}
