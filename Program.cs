using ChainOfResponsibilityDesignPattern;

SeniorManager seniorManager = new();
VicePresident vicePresident = new();
seniorManager.SetSupervisor(vicePresident);

ChiefOperatingOfficer coo = new();
vicePresident.SetSupervisor(coo);


seniorManager.ApproveRequest(new("Mouse and keyboard", 100));

Console.WriteLine("--------------------------------------------");
Console.WriteLine();


seniorManager.ApproveRequest(new("Laptop", 999));

Console.WriteLine("--------------------------------------------");
Console.WriteLine();


seniorManager.ApproveRequest(new("Desk", 3000));

/////////////////////////////////////////////////////////////////////////////////////

// Expense reports show how much money is being spent within the whole company, a department or on a project
record class ExpenseReport(string Name, int Amount);

interface IManager
{
    void SetSupervisor(IManager manager);
    void ApproveRequest(ExpenseReport expenseReport);
}

class SeniorManager : IManager
{
    private IManager _manager;
    public void ApproveRequest(ExpenseReport expenseReport)
    {
        if (expenseReport.Amount < 500) Console.WriteLine($"Approved By {this}");
        else
        {
            Console.WriteLine($"I couldn't accept this {expenseReport}, I'm going to refer it to my manager");
            _manager.ApproveRequest(expenseReport);
        }
    }
    public void SetSupervisor(IManager manager) => _manager = manager;
}

class VicePresident : IManager
{
    private IManager _manager;
    public void ApproveRequest(ExpenseReport expenseReport)
    {
        if (expenseReport.Amount < 1000) Console.WriteLine($"Approved By {this}");
        else
        {
            Console.WriteLine($"I couldn't accept this {expenseReport}, I'm going to refer it to my manager");
            _manager.ApproveRequest(expenseReport);
        }
    }

    public void SetSupervisor(IManager manager) => _manager = manager;
}

class ChiefOperatingOfficer : IManager
{
    private IManager _manager;
    public void ApproveRequest(ExpenseReport expenseReport)
    {
        if (expenseReport.Amount < 5000) Console.WriteLine($"Approved By {this}");
        else Console.WriteLine("Inapplicable");
    }

    public void SetSupervisor(IManager manager) => _manager = manager;
}
