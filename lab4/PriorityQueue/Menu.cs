namespace PriorityQueue;
class Menu
{
    private PriQueue pq = new PriQueue();
    public void Run()
    {
        int opt;
        do
        {
            printMenuOptions();
            Console.Write("Enter an option: ");
            opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 0:
                    Console.WriteLine("Bye");
                    break;
                case 1:
                    AddItem();
                    break;
                case 2:
                    GetMaxItem();
                    break;
                case 3:
                    RemoveMaxItem();
                    break;
                case 4:
                    IsEmpty();
                    break;
                case 5:
                    Print();
                    break;
                default:

                    Console.WriteLine("Invalid option");
                    break;

            }

        } while (opt != 0);

    }
    public void AddItem()
    {
        Console.Write("Enter data: ");
        string data = Console.ReadLine();
        Console.Write("Enter pri: ");
        int pri = int.Parse(Console.ReadLine());
        Item t = new Item(pri, data);
        pq.Add(t);
        Console.WriteLine("Element added!");
    }
    public void Print()
    {
        if (pq.IsEmpty())
        {
            Console.WriteLine("PriQueue is empty!");
        }
        else
        {
            Console.WriteLine(pq);
        }

    }
    public void IsEmpty()
    {
        if (pq.IsEmpty())
        {
            Console.WriteLine("PriQueue is empty!");
        }
        else
        {

            Console.WriteLine("PriQueue is not empty!");
        }
    }

    public void GetMaxItem()
    {
        try
        {

            Item t = pq.GetMax();
            Console.WriteLine(t);
        }
        catch (PriQueue.EmptyPriQueueException)
        {
            Console.WriteLine("Empty PriQueue");

        }

    }
    public void RemoveMaxItem()
    {
        try
        {

            Item t = pq.RemoveMax();
            Console.WriteLine($"{t} is removed!");
        }
        catch (PriQueue.EmptyPriQueueException)
        {
            Console.WriteLine("Empty PriQueue");

        }

    }
    public void printMenuOptions()
    {
        Console.WriteLine("=================");
        Console.WriteLine("0- Exit");
        Console.WriteLine("1- Add an item");
        Console.WriteLine("2- get max");
        Console.WriteLine("3- remove max");
        Console.WriteLine("4- is empty?");
        Console.WriteLine("5- Print");
        Console.WriteLine("=================");
    }
}