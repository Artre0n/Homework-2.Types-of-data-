using System;

enum Account_type // перечисление для упражнения 3.1
{
    Текущий,
    Сберегательный
}
struct Bank_Account // структура для упражнения 3.2
{
    /// <summary>
    /// Номер счёта
    /// </summary>
    public string account_number;
    /// <summary>
    /// Тип счёта
    /// </summary>
    public string account_type;
    /// <summary>
    /// Баланс счёта
    /// </summary>
    public int account_balance;
    /// <summary>
    /// Выводит информацию о банковском счете – его номер, тип и баланс
    /// </summary>
    public void PrintInformation()
    {
        Console.WriteLine($"Ваш номер счёта: {account_number}\nВаш тип счёта: {account_type}\nВаш баланс: {account_balance}$");
    }
}
enum ВУЗ // Перечисление для домашнего задания 3.1
{
    КГУ,
    КАИ,
    КХТИ
}
struct Работник // Структура для домашнего задания 3.1
{
    public string имя;
    public ВУЗ университет;
}
public class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Упражнение 3.1\n");

        Account_type account_type_0 = Account_type.Текущий;
        Account_type account_type_1 = Account_type.Сберегательный;

        Console.WriteLine(account_type_0);
        Console.WriteLine(account_type_1);

        /////////////////////////////////////////////////////////////

        Console.WriteLine("\nУпражнение 3.2\n");

        Bank_Account accountInformation = new Bank_Account()
        {
            account_number = "40817978600029744678",
            account_type = "Текущий",
            account_balance = 1500

        };
        accountInformation.PrintInformation();

        /////////////////////////////////////////////////////////////

        Console.WriteLine("\nДомашнее задание 3.1\n");

        Работник действующий_работник = new Работник()
        {
            имя = "Лол Пётр Кекович",
            университет = ВУЗ.КАИ
        };

        Console.WriteLine($"Имя: {действующий_работник.имя}, ВУЗ: {действующий_работник.университет}");
    }
}

