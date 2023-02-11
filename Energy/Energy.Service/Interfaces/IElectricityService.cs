using System.Collections.Generic;
using Energy.Common.IncomeModels.Base;
using Energy.Common.IncomeModels.Electricity;
using Energy.Common.ViewModels.Base;
using Energy.Common.ViewModels.Electricity;

namespace Energy.Services.Interfaces
{
    public interface IElectricityService
    {
        NewlyCreatedObjectViewModel Create(CreateElectricityIncomeModel model);

        List<GetElectricityViewModel> GetList();

        void Update(UpdateElectricityIncomeModel model);

        void Delete(DeleteObjectIncomeModel model);
    }
}