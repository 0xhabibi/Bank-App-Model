using Banking;
using System.Transactions;

string customerName = " ";
int balance = 0;
int minimumBalance = 10000;
long phoneNumber = 0;

Console.WriteLine("Welcome to Mega Bank\n");
Console.WriteLine("To create an account supply the following details");
Console.WriteLine("Enter your Name");
customerName = Console.ReadLine();
Console.WriteLine("Enter your Phone number");
phoneNumber = Convert.ToInt32(Console.ReadLine());

var newCustomer = new BankAccount(customerName, balance);

Console.Clear();
Console.WriteLine("Thank you for opening an account with us");
Console.WriteLine("Please select an option below\n");
Console.WriteLine("press 1 to deposit");
Console.WriteLine("press 2 withdraw");
Console.WriteLine("press 3 for transaction history");
Console.WriteLine("press 4 to exit");



bool customerValid;
while (true)
{
    int selection = Convert.ToInt32(Console.ReadLine());
    switch (selection)
    {
        case 1:
            Deposit();
            Console.WriteLine("Press 0 to continue");
            break;

        case 2:
            Withdraw();
            Console.WriteLine("Press 0 to continue");
            break;


        case 3:
            DisplayTransactionHistory();
            Console.WriteLine("Press 0 to continue");
            break;

        case 4:
            Console.WriteLine("Thank You  For Banking With Us");
            Environment.Exit(4);
            break;

        default:
            Console.Clear();
            Console.WriteLine("Thank you for opening an account with us");
            Console.WriteLine("Please select an option below\n");
            Console.WriteLine("press 1 to deposit");
            Console.WriteLine("press 2 withdraw");
            Console.WriteLine("press 3 for transaction history");
            Console.WriteLine("press 4 to exit");
            break;









    }


}




void Deposit()
{
    Console.WriteLine("How much do you want to deposit?\n");
    int depositAmount = Convert.ToInt32(Console.ReadLine());
    string depositDescription = "Self";
    newCustomer.MakeDeposit(depositAmount, DateTime.Now, depositDescription);
    Console.WriteLine("Deposit successful");
    return;
  
}

void Withdraw()
{
    Console.WriteLine("How much would you like to withdraw?\n");
    int withdrawAmount = Convert.ToInt32(Console.ReadLine());

    // Check if the withdrawal amount is valid
    if (withdrawAmount <= 0)
    {
        Console.WriteLine("Invalid withdrawal amount. Please enter a valid amount.");
        return;
    }

    // Check if the withdrawal amount exceeds the account balance
    if (withdrawAmount > newCustomer.Balance)
    {
        Console.WriteLine("Insufficient balance to make the withdrawal.");
        return;
    }

    // Check if the withdrawal amount goes below the minimum balance
    if (newCustomer.Balance - withdrawAmount < minimumBalance)
    {
        Console.WriteLine("Withdrawal would go below the minimum balance. Please enter a valid amount.");
        return;
    }

    string withdrawalDescription = "Withdrawal";
    newCustomer.MakeWithdrawal(withdrawAmount, DateTime.Now, withdrawalDescription);
    Console.WriteLine("Withdrawal successful");
    return;
}


void DisplayTransactionHistory()
{
    var transactions = newCustomer.GetAccountHistory();

    Console.WriteLine($"{transactions}:\n");

    
}


