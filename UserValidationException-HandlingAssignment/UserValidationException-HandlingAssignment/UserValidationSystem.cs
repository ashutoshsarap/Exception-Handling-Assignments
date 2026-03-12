using System;

public class UserValdationSystem
{

    public string Name { get; private set; }
    public int Age { get; private set; }
    public decimal Salary { get; private set; }

    public void TakeInputFromUser()
    {
        Console.WriteLine("Enter User name : ");
        Name = Console.ReadLine();

    //while (Age == 0)
    //{
    //    Console.WriteLine("Enter Age : ");
    //    bool validAge = int.TryParse(Console.ReadLine(), out int age);
    //    if (validAge) Age = age;
    //    else
    //    {
    //        throw new InvalidAgeException();
    //        Console.WriteLine("Invalid input Try again"); 
    //    }
    //}

    Label:
        Console.WriteLine("Enter Age : ");
        bool validAge = int.TryParse(Console.ReadLine(), out int age);
        if (!validAge)
        {
            Console.WriteLine("Invalid format, Try again");
            goto Label;
        }
        try
        {
            if (age < 0 | age < 18 | age > 60) throw new InvalidAgeException("Invalid age, Age must be between 18 to 60");
            else Age = age;
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine("Try again");
            goto Label;
        }

    Label1:
        Console.WriteLine("Enter Salary : ");
        bool validSalary = decimal.TryParse(Console.ReadLine(), out decimal salary);
        if (!validSalary)
        {
            Console.WriteLine("Invalid format, try again");
            goto Label1;
        }
        try
        {
            if (salary <= 0) throw new InvalidSalaryException("Salary cannot be <=0");
            else Salary = salary;
        }
        catch (InvalidSalaryException ex)
        {
            Console.WriteLine("Try again");
            goto Label1;
        }


        Console.WriteLine("Input taken \n");
    }

    public void DisplayInput()
    {
        Console.WriteLine($"Name : {Name} \nAge : {Age} \nSalary : {Salary}");
    }

}


class InvalidAgeException : Exception
{
    public InvalidAgeException() { }

    public InvalidAgeException(string message) : base(message) { Console.WriteLine(message); }

    public InvalidAgeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

class InvalidSalaryException : Exception
{
    public InvalidSalaryException() { }

    public InvalidSalaryException(string message) : base(message) { Console.WriteLine(message); }

    public InvalidSalaryException(string message, Exception innerException) : base(message, innerException)
    {
    }
}