using System;

Console.WriteLine("Hello!");

var todoList = new List<string>();
bool exitLoop = false;

do
{
    PrintOptions();

    var userInput = Console.ReadLine();

    switch (userInput.ToUpper())

    {
        case "S":
            PrintList(todoList);
            break;
        case "A":
            AddItemToList(todoList);
            break;
        case "R":
            RemoveFromList(todoList);
            break;
        case "E":
            Console.WriteLine("Bye bye !");
            exitLoop = true;
            break;
        default:
            Console.WriteLine("Invalid Choice !");
            Console.WriteLine();
            break;
    }
} while (!exitLoop);

Console.ReadKey();

void PrintList(List<string> todoList)
{
    Console.Clear();

    if (todoList.Count == 0)
    {
        Console.WriteLine("List is empty !");
        return;
    }

    Console.WriteLine("Imprimindo a lista !");
    Console.WriteLine("=======================");

    for (int i = 0; i < todoList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoList[i]}");
    }
    Console.WriteLine("======================");

}
void RemoveFromList(List<string> todoList)
{
    if (todoList.Count == 0)
    {
        Console.WriteLine("List is empty ! There is nothing to remove !");
        return;
    }
    PrintList(todoList);

    int index;
    do
    {
        Console.WriteLine("Insert valid index number to remove !");
    } while (!ValidateIndex(out index));

    var correctIndex = index - 1;
    var removedItem = todoList[correctIndex];
    todoList.RemoveAt(index - 1);

    Console.WriteLine($"{removedItem} was removed from the list !");

}
void AddItemToList(List<string> todoList)
{
    string userInput;

    do
    {
        Console.WriteLine("Enter the TODO description");
        userInput = Console.ReadLine();
    } while (!ValidateDescriptionInput(userInput));

    todoList.Add(userInput);

}
void PrintOptions()
{
    Console.WriteLine("What do you want to do ?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}
bool ValidateDescriptionInput(string userInput)
{

    if (todoList.Contains(userInput))
    {
        Console.WriteLine("Description must be unique !");
        return false;
    }
    if (userInput == "")
    {
        Console.WriteLine("Description cannot be empty !");
        return false;
    }

    return true;
}
bool ValidateIndex(out int index)
{
    var output = Console.ReadLine();

    if (
                int.TryParse(output, out index) &&
                index <= todoList.Count
                && index > 0)
    {
        Console.WriteLine("Index is valid !");
        return true;
    }


    Console.WriteLine("Index is invalid !");
    return false;
}