using Kafedra.Application.DTOs;
using Kafedra.Application.Utilities.Enums;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Concretes.Services;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;


namespace Kafedra.Infrastructure.Hubs
{
    public class SearchHub:Hub
    {
        private readonly KafedraContext _context;
        private readonly LayoutServices _settings;

        public SearchHub(KafedraContext context, LayoutServices settings)
        {
            _context = context;
            _settings = settings;
        }

        public async Task SendSearchResults(string query)
        {
            try
            {
                // Perform your search logic here
                // This is a simplified example; replace it with your actual search logic
                var results  = _context.Events.Where(item => item.Title.Contains(query)).ToList();

                Dictionary<string, string> settings = _settings.GetSetting();
                int pageSize = Convert.ToInt32(settings[SettingKeysEnum.Event_PageSize_count.ToString()]);              
                var pagResult= PagenatedListDto<Event>.Save(results.AsQueryable(), 1, pageSize);
                // Send the results to the calling client
                if (query==String.Empty) await Clients.Caller.SendAsync("ReceiveSearchResults", query, pagResult);             
                else  await Clients.Caller.SendAsync("ReceiveSearchResults", query, results);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the search
                // Log the exception for debugging purposes
                Console.Error.WriteLine($"Error in SendSearchResults: {ex.Message}");

                // Send an error message to the calling client
                await Clients.Caller.SendAsync("ReceiveSearchResultsError", "An error occurred during the search.");
            }
        }

        // Replace this method with your actual search logic
       
    }
}
