using Common.Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using SocietyManagementShowcase.Common;
using SocietyManagementShowcase.IRepository;

namespace SocietyManagementShowcase.Repository
{
    public class SeedDatabaseRepo : ISeedDatabaseRepo
    {
        private readonly EfCoreDbContext _efCoreDbContext;
        private readonly ILogger<SeedDatabaseRepo> _logger;


        public SeedDatabaseRepo(EfCoreDbContext efCoreDbContext, ILogger<SeedDatabaseRepo> logger)
        {
            _efCoreDbContext = efCoreDbContext;
            _logger = logger;
        }

        public async Task<Society> SeedDatabaseAsync()
        {
            try
            {

                using (_efCoreDbContext)
                {
                    Flat flat = new Flat()
                    {
                        AreaSqFt = 500,
                        FlatNo = "A101",
                        MaintenanceCharge = 1000,
                        Residents = _efCoreDbContext.Person.Where(x => x.FlatNo == "A101").ToList()
                    };

                    Wing wingA = _efCoreDbContext.Wing
                        .Where(x => x.Name == "Wing A")
                        .Include(x => x.FlatList)
                        .FirstOrDefault();

                    wingA.FlatList.Add(flat);

                    await _efCoreDbContext.SaveChangesAsync();
                }


                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }


        private async void AddSociety()
        {
            using (_efCoreDbContext)
            {
                Engine engine = new Engine()
                {
                    FuelLevel = 100,
                    Health = StatusHealth.OK,
                    LastMaintenanceCheck = DateTime.Now,
                    OilLevel = 100
                };

                ElectricityGenerator BackupGenerator = new ElectricityGenerator()
                {
                    BackupGeneratorEngine = engine,
                    Health = StatusHealth.OK

                };

                Elevator elevator = new Elevator()
                {
                    Health = StatusHealth.OK,
                    Type = ElevatorType.PassengerElevator1,
                };

                Elevator elevator2 = new Elevator()
                {
                    Health = StatusHealth.OK,
                    Type = ElevatorType.PassengerElevator2,
                };

                Elevator elevator3 = new Elevator()
                {
                    Health = StatusHealth.OK,
                    Type = ElevatorType.ServiceElevator,
                };
                List<Elevator> elevators = new List<Elevator>()
                    {
                        elevator, elevator2, elevator3
                    };

                WaterTank tank = new WaterTank()
                {
                    Health = StatusHealth.OK,
                    WaterLevel = 100,
                    LastMaintenanceCheck = DateTime.Now,
                    Type = WaterTankType.Kitchen,
                    Capacity = 1000
                };
                WaterTank tank2 = new WaterTank()
                {
                    Health = StatusHealth.OK,
                    WaterLevel = 100,
                    LastMaintenanceCheck = DateTime.Now,
                    Type = WaterTankType.Bathroom,
                    Capacity = 1000
                };
                WaterTank tank3 = new WaterTank()
                {
                    Health = StatusHealth.OK,
                    WaterLevel = 100,
                    LastMaintenanceCheck = DateTime.Now,
                    Type = WaterTankType.Flush,
                    Capacity = 1000
                };
                Person person1 = new Person()
                {
                    Name = "John Doe",
                    Email = "email@email.com",
                    Contact = 1234567890,
                    FlatNo = "A101",
                    Role = SocietyRoleType.Manager,
                };
                Wing wing = new Wing()
                {
                    Name = "Wing A",
                    BackupGenerator = BackupGenerator,
                    ElectricMeterBill = 0,
                    ElectricMeterReading = 0,
                    Elevators = elevators,
                    WaterTanks = new List<WaterTank>() { tank, tank2, tank3 },
                    NoticeBoard = new List<string>()
                        {
                            "Welcome to Wing A",
                            "Please maintain cleanliness",
                            "Fire drill on Saturday at 10 AM"
                        },
                    SubManager = person1,

                };

                _efCoreDbContext.Wing.Add(wing);
                await _efCoreDbContext.SaveChangesAsync();
            }
        }


    }
}
