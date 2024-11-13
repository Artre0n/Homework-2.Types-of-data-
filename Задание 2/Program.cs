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
struct Student // Структура для упражнения 6
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Last_name;
    /// <summary>
    /// Имя
    /// </summary>
    public string First_name;
    /// <summary>
    /// Индефикатор
    /// </summary>
    public int Id;
    /// <summary>
    /// Дата Рождения
    /// </summary>
    public DateTime Birth_date;
    /// <summary>
    /// Категория алкоголизма: a, b, c, d
    /// </summary>
    public char Alcoholism_category;
    /// <summary>
    /// Обьём выпитого напитка
    /// </summary>
    public double Volume_drank;
    /// <summary>
    /// Выбранный напиток
    /// </summary>
    public Drinks Chosen_drink;
}
struct Drinks //Структура для упражнения 6
{
    /// <summary>
    /// Наименование напитка
    /// </summary>
    public string Name;
    /// <summary>
    /// Крепость алкоголя
    /// </summary>
    public double Alcohol_percentage;
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

        Console.Write("Введите подстроку: ");
        string sub_string = Console.ReadLine();

        int count = 0;

        if (string.IsNullOrEmpty(main_string) || string.IsNullOrEmpty(sub_string))
        {
            Console.WriteLine("0");
        }
        else
        {
            for (int i = 0; i < main_string.Length - sub_string.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < sub_string.Length; j++)
                {
                    if (main_string[i + j] != sub_string[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    count++;
                }
            }
        }
        Console.WriteLine($"Количество вхождений подстроки '{sub_string}': {count}");
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nУпражнение 5\n");
        //Цель этой задачи - определить, сколько бутылок виски беспошлинной торговли вам
        //нужно будет купить, чтобы экономия по сравнению с обычной средней ценой фактически
        //покрыла расходы на ваш отпуск. Вам будет предоставлена стандартная цена (normPrice),
        //скидка в Duty Free (salePrice) и стоимость отпуска (holidayPrice). Например, если бутылка
        //обычно стоит 10 фунтов стерлингов, а скидка в дьюти фри составляет 10%, вы
        //сэкономите 1 фунт стерлингов на каждой бутылке. Если ваш отпуск стоит 500 фунтов
        //стерлингов, ответ, который вы должны вернуть, будет 500. Все входные данные будут
        //целыми числами. Пожалуйста, верните целое число. Округлить в меньшую сторону.
        Console.WriteLine("Укажите номальную цену, скидку в процентах, стоимость отпуска: ");
        decimal saving = 0;
        decimal bottles = 0;
        decimal normPrice, salePrice, holidayPrice;
        if (decimal.TryParse(Console.ReadLine(), out normPrice) && decimal.TryParse(Console.ReadLine(), out salePrice) && decimal.TryParse(Console.ReadLine(), out holidayPrice))
        {
            saving = normPrice * (salePrice / 100);
            bottles = holidayPrice / saving;
            Console.WriteLine((int)bottles);
        }
        else
        {
            Console.WriteLine("Некорректный ввод!");
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nУпражнение 6\n");
        // Создать структуру студента. У студента есть Фамилия, Имя, его Идентификатор, Дата
        //рождения, Категория алкоголизма(a – студент алкоголик, b – студент любитель
        //выпить, но не алкоголик, c – студент пьет по праздникам, d – студент не пьет), также у
        //студента есть Объем выпитой жидкости конкретного напитка.Создать 5 студентов с
        //различными параметрами. Посчитать общий объем выпитого, общий объем алкоголя
        //(процент спирта) и кто сколько процентов алкоголя и жидкости от общего количества
        //выпил.Предполагается, что студент пьет один вид напитка. Напитки задать в виде
        //структуры: наименование типа напитка и процент спирта.
        Drinks beer = new Drinks()
        {
            Name = "Пиво",
            Alcohol_percentage = 3
        };
        Drinks vodka = new Drinks()
        {
            Name = "Водка",
            Alcohol_percentage = 40
        };
        Drinks cognac = new Drinks()
        {
            Name = "Коньяк",
            Alcohol_percentage = 42
        };
        Drinks wine = new Drinks()
        {
            Name = "Вино",
            Alcohol_percentage = 14
        };
        Drinks champagne = new Drinks()
        {
            Name = "Шампанское",
            Alcohol_percentage = 10
        };

        Student[] students = new Student[5];

        students[0] = new Student()
        {
            Last_name = "Сидоров",
            First_name = "Антон",
            Id = 100,
            Birth_date = new DateTime(2001, 4, 16),
            Alcoholism_category = 'a',
            Volume_drank = 0.7,
            Chosen_drink = vodka
        };
        students[1] = new Student()
        {
            Last_name = "Литвиенко",
            First_name = "Майкл",
            Id = 70,
            Birth_date = new DateTime(2003, 12, 28),
            Alcoholism_category = 'b',
            Volume_drank = 1.5,
            Chosen_drink = champagne
        };
        students[2] = new Student()
        {
            Last_name = "Симакова",
            First_name = "Александра",
            Id = 999,
            Birth_date = new DateTime(2006, 9, 27),
            Alcoholism_category = 'b',
            Volume_drank = 2,
            Chosen_drink = wine
        };
        students[3] = new Student()
        {
            Last_name = "Климин",
            First_name = "Виталий",
            Id = 60,
            Birth_date = new DateTime(2005, 1, 21),
            Alcoholism_category = 'с',
            Volume_drank = 0.7,
            Chosen_drink = cognac
        };
        students[4] = new Student()
        {
            Last_name = "Евкин",
            First_name = "Адам",
            Id = 200,
            Birth_date = new DateTime(2006, 6, 6),
            Alcoholism_category = 'd',
            Volume_drank = 0.0,
            Chosen_drink = beer
        };
        double total_volume = 0;
        double total_alcohol_volume = 0;

        foreach (var student in students)
        {
            total_volume += student.Volume_drank;
            total_alcohol_volume += student.Volume_drank * (student.Chosen_drink.Alcohol_percentage / 100);
        }

        Console.WriteLine($"Общий объем выпитого: {total_volume} литров");
        Console.WriteLine($"Общий объем алкоголя: {total_alcohol_volume} литров");

        foreach (var student in students)
        {
            double percentage_of_total_volume = (student.Volume_drank / total_volume) * 100;
            double alcohol_percentage_of_total = (((student.Volume_drank * (student.Chosen_drink.Alcohol_percentage / 100)) / total_alcohol_volume) * 100);

            Console.WriteLine($"{student.Last_name} {student.First_name}: " +
               $"{percentage_of_total_volume:F2}% от общего объема выпитого, " +
               $"{alcohol_percentage_of_total:F2}% от общего алкоголя");
        }






























    }

}