using System;

namespace Energy.Common.ViewModels.Electricity
{
    public class GetElectricityViewModel
    {
        public Guid Id { get; set; }

        public double Hour { get; set; }

        public double Power { get; set; }
    }
}