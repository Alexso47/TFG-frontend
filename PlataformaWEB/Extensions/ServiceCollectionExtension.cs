using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaWEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaWEB.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IEconomicOperatorService, EconomicOperatorService>();

            services.AddHttpClient<IFacilityService, FacilityService>();
            
            services.AddHttpClient<IMachineService, MachineService>();

            services.AddHttpClient<IRequestService, RequestService>();
            
            services.AddHttpClient<IArrivalService, ArrivalService>();
            
            services.AddHttpClient<IInvoiceService, InvoiceService>();
            
            services.AddHttpClient<IDispatchService, DispatchService>();

            return services;
        }
    }
}
