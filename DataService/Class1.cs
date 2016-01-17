using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDataService
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ExampleDataContext
    {
        public IQueryable<Person> People
        {
            get
            {
                return new List<Person>()
                    {
                        new Person() { ID = 1, Name = "Steve"},
                        new Person() { ID = 2, Name = "Dave"}
                    }
                .AsQueryable();
            }
        }
    }

    public class DatamineDataService : DataService<ExampleDataContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
             config.SetEntitySetAccessRule("*", EntitySetRights.All);
            
             config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }

    
}
