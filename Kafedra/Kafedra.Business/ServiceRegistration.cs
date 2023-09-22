using Kafedra.Business.Services.Implementations;
using Kafedra.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business
{
    public  static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<ISettingService, SettingService>();

            //  services.AddFluentValidation(o => o.RegisterValidatorsFromAssembly(typeof(AuthorPostDtoValidator).Assembly));

            //  return services;
        }
    }
}
