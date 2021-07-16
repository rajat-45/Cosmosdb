using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using FunctionApp1.Data;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Cosmos;

namespace FunctionApp1

{
    //public  async Task QueryItemsAsync()
    //{
    //    var sqlQueryText = "SELECT * FROM c WHERE c.LastName = 'Andersen'";

    //    Console.WriteLine("Running query: {0}\n", sqlQueryText);

    //    QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
    //    FeedIterator<Employee> queryResultSetIterator = this.container.GetItemQueryIterator<Employee>(queryDefinition);

    //    List<Employee> families = new List<Employee>();

    //    while (queryResultSetIterator.HasMoreResults)
    //    {
    //        FeedResponse<Employee> currentResultSet = await queryResultSetIterator.ReadNextAsync();
    //        foreach (Employee employee in currentResultSet)
    //        {
    //            families.Add(family);
    //            Console.WriteLine("\tRead {0}\n", family);
    //        }
    //    }
    //}
    public static class GetSingle
    {
        [FunctionName("GetSingle")]
        public static async Task<Employee> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Get/{id}")] HttpRequest req, TraceWriter log, string id)
        {

            log.Info("C# HTTP trigger function to get all data from Cosmos DB");

            IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();
            var empdetails = await Respository.GetItemsAsync("Employee");
            var empdetails1 = empdetails.Where(e => e.Id == id);
            //Employee employee = new Employee();
            //foreach (var emp in empdetails)
            //{
            //    if (emp.Id == id)
            //    {
            //        employee.Name = emp.Name;
            //        employee.Cityname = emp.Cityname;
            //        return employee;
            //    }

            //}
            return empdetails1.FirstOrDefault<Employee>();


        }
    }
    //public static class CreateOrUpdate
    //{
    //    [FunctionName("CreateOrUpdate")]
    //    public static async Task<bool> Run([HttpTrigger(AuthorizationLevel.Function, "post", "put", Route = "CreateOrUpdate")] HttpRequest req, TraceWriter log)
    //    {
    //        log.Info("C# HTTP trigger function to create a record into Cosmos DB");
    //        try
    //        {
    //            IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();
    //            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    //            var employee = JsonConvert.DeserializeObject<Employee>(requestBody);
    //            if (req.Method == "POST")
    //            {
    //                employee.Id = null;
    //                await Respository.CreateItemAsync(employee, "Employee");
    //            }
    //            else
    //            {
    //                await Respository.UpdateItemAsync(employee.Id, employee, "Employee");
    //            }
    //            return true;
    //        }
    //        catch
    //        {
    //            log.Info("Error occured while creating a record into Cosmos DB");
    //            return false;
    //        }

    //    }
    //}
    //public static class GetSingle
    //{
    //    [FunctionName("GetSingle")]
    //    public static async Task<Employee> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Get/{id}")] HttpRequest req, TraceWriter log, string id)
    //    {
    //        log.Info("C# HTTP trigger function to get a single data from Cosmos DB");

    //        IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();

    //        //IDocumentDBRepository<Employee> Respository = new DocumentDBReposito90ry<Employee>();
    //        var Employeedetails=  Respository.GetItemsAsync("Employee");
    //        //var employees = await Respository.GetItemsAsync(d => d.Id == "12345");
    //        var employees = await Respository.GetItemsAsync(d => d.Id == id, "Employeedetails");

    //        Employee employee = new Employee();
    //        foreach (var emp in employees)
    //        {
    //            employee = emp;
    //            break;
    //        }
    //        return employee;
    //    }
    //}

    //public static class Function1
    //{

    //   [FunctionName("Function1")]
    //    public static async Task<IActionResult> Run(
    //        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
    //        ILogger log)
    //    {
    //        log.LogInformation("C# HTTP trigger function processed a request.");

    //        string name = req.Query["name"];

    //        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    //        dynamic data = JsonConvert.DeserializeObject(requestBody);
    //        name = name ?? data?.name;

    //        string responseMessage = string.IsNullOrEmpty(name)
    //            ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
    //            : $"Hello, {name}. This HTTP triggered function executed successfully.";

    //        return new OkObjectResult(responseMessage);
    //    }

    //}
    //public static class CreateOrUpdate
    //{
    //    [FunctionName("CreateOrUpdate")]
    //    public static async Task<bool> Run([HttpTrigger(AuthorizationLevel.Function, "post", "put", Route = "CreateOrUpdate")] HttpRequest req, TraceWriter log)
    //    {
    //        log.Info("C# HTTP trigger function to create a record into Cosmos DB");
    //        try
    //        {
    //            IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();
    //            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    //            var employee = JsonConvert.DeserializeObject<Employee>(requestBody);
    //            if (req.Method == "POST")
    //            {
    //                employee.Id = null;
    //                await Respository.CreateItemAsync(employee, "Employee");
    //            }
    //            else
    //            {
    //                await Respository.UpdateItemAsync(employee.Id, employee, "Employee");
    //            }
    //            return true;
    //        }
    //        catch
    //        {
    //            log.Info("Error occured while creating a record into Cosmos DB");
    //            return false;
    //        }

    //    }
    //}

    //public static class Delete
    //{
    //    [FunctionName("Delete")]
    //    public static async Task<bool> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Delete/{id}/{cityName}")] HttpRequest req, TraceWriter log, string id, string cityName)
    //    {
    //        log.Info("C# HTTP trigger function to delete a record from Cosmos DB");

    //        IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();
    //        try
    //        {
    //            await Respository.DeleteItemAsync(id, "Employee", cityName);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //}
    //public static class GetAll
    //{
    //    [FunctionName("GetAll")]
    //    public static async Task<IEnumerable<Employee>> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Get")] HttpRequest req, TraceWriter log)
    //    {
    //        log.Info("C# HTTP trigger function to get all data from Cosmos DB");

    //        IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();
    //        return await Respository.GetItemsAsync("Employee");
    //    }
    //}


}


