 using System.Collections.Generic;
using System.Linq;
using Energy.Common.IncomeModels.Base;
using Energy.Common.ViewModels.Base;
using Energy.Common.IncomeModels.Electricity;
using Energy.Common.ViewModels.Electricity;
using Energy.DataAccess.EntityModels;
using Energy.DataAccess.Repositories.Interfaces;
using Energy.Services.Interfaces;

namespace Energy.Services.Implementations
{
    public class ElectricityService : IElectricityService
    {
        private readonly IBaseRepository<Electricity> _electricityRepository;

        public ElectricityService(IBaseRepository<Electricity> electricityRepository)
        {
            _electricityRepository = electricityRepository;
        }

        public NewlyCreatedObjectViewModel Create(CreateElectricityIncomeModel model)
        {
            var dbElectricity = new Electricity
            {
                Hour = model.Hour,
                Power = model.Power
            };

            _electricityRepository.Add(dbElectricity);

            return new NewlyCreatedObjectViewModel(dbElectricity.Id);
        }

        public List<GetElectricityViewModel> GetList()
        {
            var dbElectricities = _electricityRepository.GetAll().ToList();
            var electricitiesList = dbElectricities.Select(p => new GetElectricityViewModel
            {
                Id = p.Id,
                Hour = p.Hour,
                Power = p.Power
            }).ToList();

            return electricitiesList;
        }

        public void Update(UpdateElectricityIncomeModel model)
        {
            var dbElectricity = _electricityRepository.Get(model.Id);

            dbElectricity.Hour = model.Hour;
            dbElectricity.Power = model.Power;

            _electricityRepository.Update(dbElectricity);
        }

        public void Delete(DeleteObjectIncomeModel model)
        {
            var dbElectricity = _electricityRepository.Get(model.Id);

            _electricityRepository.Delete(dbElectricity);
        }
    }
}