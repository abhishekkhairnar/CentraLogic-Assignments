using System.Diagnostics;

List<string> TaskList = new List<string>();
while (true)
{
    Console.Write("======Task Application=======\n" +
                      "1. Create Task\n"+
                      "2. Read Task\n"+
                      "3. Update Task\n" + 
                      "4. Delete Task\n"+
                      "5. Exit\n"+
                      "Enter your choice : ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("===========Create Task============");
            Console.Write("Enter title of the task : ");
            string task = Console.ReadLine();
            TaskList.Add(task);
            Console.WriteLine("Task added successfully!");
            break;
        case "2":
            Console.WriteLine("===========Read Task============");
            int i = 1;
            foreach(string t in TaskList)
            {   
                Console.Write("Task "+i+" -> ");
                Console.WriteLine(t);
                i++;
            }
            break;
        case "3":
            Console.WriteLine("===========Update Task============");
            if (TaskList.Count == 0)
            {
                Console.WriteLine("There is no task to update!!");
                break;
            }
            Console.Write("Enter the task title to update: ");
            string titleToUpdate = Console.ReadLine();

            for(i=0;i<TaskList.Count;i++)
            {
                if (TaskList[i] == titleToUpdate)
                {
                    Console.Write("Enter new task : ");
                    TaskList[i] = Console.ReadLine();
                    break;
                }
            }
            Console.WriteLine("Task not found");
            break;
        case "4":
            Console.WriteLine("===========Delete Task============");
            Console.Write("Enter the task title to delete: ");
            string titleToDelete = Console.ReadLine();
            if (TaskList.Remove(titleToDelete))
            {
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
            break;
        case "5":
            Console.WriteLine("Program Exit successfully!");
            Environment.Exit(0);
            break;
        case "6":
            Console.WriteLine("Please enter valid choice!!");
            break;
    }

}
