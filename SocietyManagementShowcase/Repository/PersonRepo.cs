using Common.Models;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;

namespace SocietyManagementShowcase.Repository
{
    public class PersonRepo : IPersonRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<PersonRepo> _logger;

        public PersonRepo(EfCoreDbContext efCoreDbContext, ILogger<PersonRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task<List<Person>> GetAllPersonsAsync(int firstId)
        {
            try
            {
                using (_efCoreDbContext)
                {
                    if (firstId <= 0)
                    {
                        firstId = int.MinValue;
                    }

                    List<Person> persons = await (from person in _efCoreDbContext.Person
                                                  where person.Id >= firstId
                                                  orderby person.Id
                                                  select person)
                                                  .Take(5)
                                                  .AsNoTracking()
                                                  .ToListAsync();
                    return persons;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all persons");
                return new List<Person>();
            }
        }

    }
}
