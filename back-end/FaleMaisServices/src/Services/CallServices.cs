using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Exceptions;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services {
  public class CallServices : ICallServices {
    private readonly ICallsRepository callsRepository;
    private readonly IMapper mapper;

    public CallServices(
      ICallsRepository callsRepository,
      IMapper mapper
      ) {
      this.callsRepository = callsRepository;
      this.mapper = mapper;
    }

    public CallViewModel UpdateCallPrice(CallViewModel data) {
      var call = callsRepository.FindByFromToAreaCode(
        data.FromAreaCode, data.ToAreaCode
      );

      if (call == null) {
       throw new FaleMaisException(
         "There is no call price registered for these area codes",
         404
        );
      }

      call.PricePerMinute = data.PricePerMinute;
      callsRepository.SaveChanges();

      return mapper.Map<CallViewModel>(call);
    }

    public CallViewModel GetCallPriceFromTo(
      byte fromAreaCode,
      byte toAreaCode
    ) {
      var call = callsRepository.FindByFromToAreaCode(fromAreaCode, toAreaCode);

      if (call == null) {
       throw new FaleMaisException(
         "There is no call price registered for these area codes",
         404
        );
      }

      return mapper.Map<CallViewModel>(call);
    }
  }
}
