using System;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;

struct User_Info // Структура для упражнения 1
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string name;
    /// <summary>
    /// Город
    /// </summary>
    public string city;
    /// <summary>
    /// Возраст
    /// </summary>
    public int age;
    /// <summary>
    /// Пин-код
    /// </summary>
    public int pin_code;
    /// <summary>
    /// Выводит информацию о пользователе
    /// </summary>
    public void PrintInformation()
    {
        Console.WriteLine($"\nИмя пользователя - {name}\nГород пользователя - {city}");
        Console.Write($"Возраст - {age}\nПин-код - {pin_code}\n");
    }
}
public class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Упражнение 1\n");
        //Выведите на экран информацию о каждом типе данных в виде:
        //Тип данных – максимальное значение – минимальное значение
        Console.WriteLine("Тип данных – максимальное значение – минимальное значение");

        Console.WriteLine($"bool  – True – False");
        Console.WriteLine($"byte  – {byte.MaxValue}  – {byte.MinValue}");
        Console.WriteLine($"sbyte – {sbyte.MaxValue} – {sbyte.MinValue}");
        Console.WriteLine($"short – {short.MaxValue} – {short.MinValue}");
        Console.WriteLine($"ushort – {ushort.MaxValue} – {ushort.MinValue}");
        Console.WriteLine($"int   – {int.MaxValue}   – {int.MinValue}");
        Console.WriteLine($"uint  – {uint.MaxValue}  – {uint.MinValue}");
        Console.WriteLine($"long  – {long.MaxValue}  – {long.MinValue}");
        Console.WriteLine($"ulong  – {ulong.MaxValue}  – {ulong.MinValue}");
        Console.WriteLine($"float – {float.MaxValue} – {float.MinValue}");
        Console.WriteLine($"double – {double.MaxValue} – {double.MinValue}");
        Console.WriteLine($"decimal – {decimal.MaxValue} – {decimal.MinValue}");
        Console.WriteLine($"char  – {(int)char.MaxValue}  – {(int)char.MinValue}");
        ///////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nУпражнение 2\n");
        //Напишите программу, в которой принимаются данные пользователя в виде имени,
        //города, возраста и PIN - кода.Далее сохраните все значение в соответствующей
        //переменной, а затем распечатайте всю информацию в правильном формате.

        User_Info user = new User_Info();

        Console.Write("Введите имя: ");
        user.name = Console.ReadLine();

        Console.Write("Введите город: ");
        user.city = Console.ReadLine();

        Console.Write("Введите возраст: ");
        if (int.TryParse(Console.ReadLine(), out user.age) && user.age < 121 && user.age > 0)
        {
            Console.Write("Введите пин-код, состоящий из 4 цифр: ");
            if (int.TryParse(Console.ReadLine(), out user.pin_code) && user.pin_code.ToString().Length == 4)                 
            {
                user.PrintInformation();
            }
            else
            {
                Console.WriteLine("Некорректный ввод пин-кода!");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод возраста!");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nУпражнение 3\n");
        //Преобразуйте входную строку: строчные буквы замените на заглавные, заглавные – на строчные.

        Console.Write("Введите текст: ");
        string scribbles = Console.ReadLine();
        
        for (int i = 0; i < scribbles.Length; i++)
        {
            if (char.IsLower(scribbles[i]))
            {
                Console.Write(char.ToUpper(scribbles[i]));
            }
            else if (char.IsUpper(scribbles[i]))
            {
                Console.Write(char.ToLower(scribbles[i]));
            }
            else
            {
                Console.Write(scribbles[i]);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        
        Console.WriteLine("\nУпражнение 4\n");
        //Введите строку, введите подстроку. Необходимо найти количество вхождений и вывести на экран.

        Console.Write("Введите строку: ");
        string main_string = Console.ReadLine();
        int count = 0;
        int index = 0;
        Console.Write("Введите подстроку: ");
        string sub_string = Console.ReadLine();
        if (string.IsNullOrEmpty(main_string) || string.IsNullOrEmpty(sub_string))
        {
            count = 0;
        }

        while ((index = main_string.IndexOf(sub_string, index)) != -1)
        {
            count++;
            index += sub_string.Length; 
        }
        Console.WriteLine($"Количество вхождений подстроки '{sub_string}': {count}");
    }
}