using System;

namespace Energy.Common.ViewModels.Base
{
    public class NewlyCreatedObjectViewModel
    {
        public Guid Id { get; set; }

        public NewlyCreatedObjectViewModel(Guid id)
        {
            Id = id;
        }
    }
}
