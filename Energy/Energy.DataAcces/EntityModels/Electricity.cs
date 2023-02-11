using Energy.DataAccess.EntityModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Energy.DataAccess.EntityModels
{
    public class Electricity : BaseEntity
    {
        [MaxLength(256)]

        public double Hour { get; set; }

        public double Power { get; set; }

    }
}