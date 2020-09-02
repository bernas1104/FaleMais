using System.Collections.Generic;
using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Exceptions;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services {
  public class AreaCodeServices : IAreaCodeServices {
    private readonly IAreaCodesRepository statesRepository;
    private readonly IMapper mapper;

    public AreaCodeServices(IAreaCodesRepository statesRepository, IMapper mapper) {
      this.statesRepository = statesRepository;
      this.mapper = mapper;
    }

    public IEnumerable<AreaCodeViewModel> ListAllAreaCodes() {
      var states = statesRepository.FindAll();

      return mapper.Map<IEnumerable<AreaCodeViewModel>>(states);
    }
  }
}
