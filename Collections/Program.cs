internal class Program
{
    private class ListTask
    {
        private readonly List<string> _list = new();

        public void TaskLoop()
        {
            Console.WriteLine("Введите элементы списка (через Enter). Для завершения введите '-exit':");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "-exit") break;
                _list.Add(input);
            }

            Console.Write("Введите новую строку для добавления в список: ");
            string newItem = Console.ReadLine();
            _list.Add(newItem);

            Console.WriteLine("Список после добавления:");
            Console.WriteLine(string.Join(", ", _list));

            Console.Write("Введите строку для добавления в середину списка: ");
            string middleItem = Console.ReadLine();
            _list.Insert(_list.Count / 2, middleItem);

            Console.WriteLine("Список после вставки в середину:");
            Console.WriteLine(string.Join(", ", _list));
        }
    }

    private class DictionaryTask
    {
        private readonly Dictionary<string, int> _students = new();

        public void TaskLoop()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            int grade;
            do
            {
                Console.Write("Введите оценку (от 2 до 5): ");
            } while (!int.TryParse(Console.ReadLine(), out grade) || grade < 2 || grade > 5);

            _students[name] = grade;
            Console.Write("Введите имя студента для поиска: ");
            string searchName = Console.ReadLine();

            if (_students.TryGetValue(searchName, out int foundGrade))
            {
                Console.WriteLine($"Оценка студента {searchName}: {foundGrade}");
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }
    }

    private class DoublyLinkedListTask
    {
        private class Node
        {
            public string Data;
            public Node Next;
            public Node Prev;

            public Node(string data)
            {
                Data = data;
            }
        }

        private Node _head;
        private Node _tail;

        public void TaskLoop()
        {
            Console.WriteLine("Введите от 3 до 6 элементов списка:");
            for (int i = 0; i < 6; i++)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;
                Add(input);
            }

            Console.WriteLine("Прямой порядок:");
            PrintForward();
            Console.WriteLine("Обратный порядок:");
            PrintBackward();
        }

        private void Add(string data)
        {
            Node newNode = new(data);
            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
        }

        private void PrintForward()
        {
            for (Node current = _head; current != null; current = current.Next)
            {
                Console.Write(current.Data + " ");
            }
            Console.WriteLine();
        }

        private void PrintBackward()
        {
            for (Node current = _tail; current != null; current = current.Prev)
            {
                Console.Write(current.Data + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите задание (1, 2, 3) или введите '-exit' для выхода: ");
            string input = Console.ReadLine();
            if (input == "-exit") break;

            switch (input)
            {
                case "1":
                    new ListTask().TaskLoop();
                    break;
                case "2":
                    new DictionaryTask().TaskLoop();
                    break;
                case "3":
                    new DoublyLinkedListTask().TaskLoop();
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        }
    }
}


