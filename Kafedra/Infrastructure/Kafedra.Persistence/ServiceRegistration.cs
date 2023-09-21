

using Kafedra.Domain.Identities;
using Kafedra.Persistence.Configurations;
using Kafedra.Persistence.Contexts;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Kafedra.Persistence.Repositories.Implementations;
using Kafedra.Persistence.Repositories.Interfaces;


namespace Kafedra.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<KafedraContext>(opt =>
            {
                opt.UseSqlServer(ServiceConfiguration.ConnectionString());
            }).AddIdentity<AppUser, IdentityRole>(x =>
            {
                x.Password.RequiredLength = 5;
              //  x.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
                x.SignIn.RequireConfirmedEmail = true;
                x.User.RequireUniqueEmail = true;
                //todo we will change here or add somethings
            }).
            AddEntityFrameworkStores<KafedraContext>().AddDefaultTokenProviders();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();





        }
    }
}
