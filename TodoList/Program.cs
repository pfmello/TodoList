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

void RemoveFromList(List<string> todoList)
{
    PrintList(todoList);
    Console.WriteLine("Which item you want to remove ?");

    bool validNumber = false;
    int index;
    bool validIndex = false;

    do
    {
        Console.WriteLine("Insert valid index number !");
        var output = Console.ReadLine();

        validNumber = int.TryParse(output, out index);

        if (index <= todoList.Count && index > 0)
        {
            Console.WriteLine("Index is valid !");
            todoList.RemoveAt(index - 1);
            validIndex = true;
        }
        else
        {
            Console.WriteLine("Index is invalid !");
        }

    } while (validIndex == false || validNumber == false);

}
void PrintList(List<string> todoList)
{
    Console.Clear();

    if (todoList.Count == 0)
    {
        Console.WriteLine("List is empty !");
    }
    else
    {
        Console.WriteLine("Imprimindo a lista !");
        Console.WriteLine("=======================");

        int index = 1;
        foreach (string item in todoList)
        {
            Console.WriteLine($"{index}. {item}");
            index++;
        }
        Console.WriteLine("======================");
    }
}
void AddItemToList(List<string> todoList)
{
    bool validDescription = false;

    do
    {
        Console.WriteLine("Enter the TODO description");
        var userInput = Console.ReadLine();

        if (todoList.Contains(userInput))
        {
            Console.WriteLine("Description must be unique !");
        }
        else if (userInput == "")
        {
            Console.WriteLine("Description cannot be empty !");
        }
        else
        {
            validDescription = true;
            todoList.Add(userInput);
        }

    } while (!validDescription);
}
static void PrintOptions()
{
    Console.WriteLine("What do you want to do ?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}