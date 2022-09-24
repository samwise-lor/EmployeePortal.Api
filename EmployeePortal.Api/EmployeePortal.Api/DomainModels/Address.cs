﻿using System;

namespace EmployeePortal.Api.DomainModels
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid EmployeeId { get; set; }
    }
}