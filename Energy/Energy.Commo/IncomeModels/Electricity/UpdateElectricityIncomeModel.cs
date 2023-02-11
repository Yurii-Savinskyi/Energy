using System;

namespace Energy.Common.IncomeModels.Electricity
{
    public class UpdateElectricityIncomeModel
    {
        public Guid Id { get; set; }

        public double Hour { get; set; }

        public double Power { get; set; }
    }
}