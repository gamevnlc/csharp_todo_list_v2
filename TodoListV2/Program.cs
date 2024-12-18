Console.WriteLine("Hello");
List<string> todoList = new List<string>();
bool isExit = false;
do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    var userChoice = Console.ReadLine();
    string[] validOptions = new[] { "s", "a", "r", "e" };
    string lowerChoice = userChoice.ToLower();
    if (!validOptions.Contains(lowerChoice))
    {
        Console.WriteLine("Invalid choice");
        continue;
    }

    switch (lowerChoice)
    {
        case "s":
            SeeAllTodo();
            break;
        case "a":
            AddTodo();
            break;
        case "r":
            RemoveTodo();
            break;
        case "e":
            isExit = true;
            break;
    }
} while (!isExit);

void RemoveTodo()
{
    if (!todoList.Any())
    {
        Console.WriteLine("There is no todo");
        return;
    }

    bool isValid = false;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        ListAllTodo();
        var userInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Selected index cannot be empty");
            continue;
        }

        if (int.TryParse(userInput, out int todoIndex))
        {
            if (todoIndex > todoList.Count || todoIndex <= 0)
            {
                Console.WriteLine("The given index is not valid");
                continue;
            }

            string todo = todoList[todoIndex - 1];
            todoList.Remove(todo);
            Console.WriteLine("TODO removed: " + todo);
            isValid = true;
        }
        else
        {
            Console.WriteLine("Selected index is not a number");
        }
    } while (!isValid);
}

void SeeAllTodo()
{
    if (!todoList.Any())
    {
        Console.WriteLine("There is no todo");
        return;
    }

    ListAllTodo();
}

void ListAllTodo()
{
    for (int i = 0; i < todoList.Count; i++)
    {
        int countIndex = i + 1;
        Console.WriteLine(countIndex + ". " + todoList[i]);
    }
}

void AddTodo()
{
    bool isValid = false;
    do
    {
        Console.WriteLine("Enter the TODO description");
        var description = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("The description cannot be empty");
            continue;
        }

        if (todoList.Contains(description))
        {
            Console.WriteLine("The description must be unique");
            continue;
        }

        todoList.Add(description);
        Console.WriteLine("TODO successfully added: " + description);
        isValid = true;
    } while (!isValid);
}