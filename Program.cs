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