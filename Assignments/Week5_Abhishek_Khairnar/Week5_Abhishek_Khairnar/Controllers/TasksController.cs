using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using Week5_Abhishek_Khairnar.DTO;
using Week5_Abhishek_Khairnar.Model;

namespace Week5_Abhishek_Khairnar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public string URI = "https://localhost:8081";
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DataBaseName = "TaskDB";
        public string ContainerName = "Tasks";

        [HttpPost]
        public async Task<IActionResult> AddTask(Tasks_DTO task)
        {

            try
            {
                // Database Connection
                CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
                Database database = cosmosClient.GetDatabase(DataBaseName);
                Container container = database.GetContainer(ContainerName);

                TasksEntity tasksEntity = new TasksEntity();
                tasksEntity.Id = Guid.NewGuid().ToString();

                tasksEntity.TaskId = tasksEntity.Id;
                tasksEntity.Name = task.Name;
                tasksEntity.Description = task.Description;
                tasksEntity.isActive = true;
                tasksEntity.CreatedAt = DateTime.UtcNow;
                tasksEntity.Version = 1;
                tasksEntity.Archieved = false;

                TasksEntity response = await container.CreateItemAsync(tasksEntity);
                task.Name = response.Name;
                task.Description = response.Description;

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest("Add task failed!" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskById(string id)
        {
            try
            {
                // Database Connection
                CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
                Database database = cosmosClient.GetDatabase(DataBaseName);
                Container container = database.GetContainer(ContainerName);

                TasksEntity response = container.GetItemLinqQueryable<TasksEntity>(true).Where(b => b.Id == id).AsEnumerable().FirstOrDefault();
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest("get task by id failed!"+ex.Message);
            }
        }



        [HttpPost]
        [Route("/GetAllTasks")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Database Connection
                CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
                Database database = cosmosClient.GetDatabase(DataBaseName);
                Container container = database.GetContainer(ContainerName);
                var taskList = container.GetItemLinqQueryable<TasksEntity>(true).AsEnumerable().ToList();
                return Ok(taskList);
            }
            catch (Exception e)
            {
                return BadRequest("Error");
            }
        }

        [HttpPut]
        [Route("/UpdateTask")]
        public async Task<IActionResult> UpdateTask(string id,Tasks_DTO entity)
        {
            try
            {
                // Database Connection
                CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
                Database database = cosmosClient.GetDatabase(DataBaseName);
                Container container = database.GetContainer(ContainerName);

                var item = container.GetItemLinqQueryable<TasksEntity>(true).Where(p => p.Id == id).AsEnumerable().FirstOrDefault();
                TasksEntity task = new TasksEntity();
                task.Id = Guid.NewGuid().ToString();
                task.Name = entity.Name;
                task.Description = entity.Description;
                task.isActive = true;
                task.LastUpdated = DateTime.UtcNow;
                task.Archieved = false;
                task.Version = item.Version + 1;
                task.TaskId = item.Id;
                task.CreatedAt = item.CreatedAt;

                item.Archieved = true;
                item.isActive = false;

                var response = await container.ReplaceItemAsync(task, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Update task failed");
            }
        }

        [HttpDelete]
        [Route("/DeleteTask")]
        public async Task<IActionResult> DeleteTask(string id)
        {
            try
            {
                // Database Connection
                CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
                Database database = cosmosClient.GetDatabase(DataBaseName);
                Container container = database.GetContainer(ContainerName);
                var response = container.GetItemLinqQueryable<TasksEntity>(true).Where(b => b.Id == id).AsEnumerable().FirstOrDefault();
                if(response == null)
                {
                    return BadRequest("no item found with id");
                }
                var result = await container.DeleteItemStreamAsync(id, new PartitionKey(id));
                return Ok("Deleted Successfully!");
            }catch(Exception ex)
            {
                return BadRequest("Delete task failed");
            }
        }

    }
}
