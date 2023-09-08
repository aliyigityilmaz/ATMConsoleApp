public class cardHolder
{
    String cardNum;
    int pin;
    String name;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String name, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.name = name;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getCardNum()
    {
           return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getName()
    {
        return name;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    public void SetNum(String newcardNum)
    {
        cardNum = newcardNum;
    }
    public void SetPin(int newpin)
    {
        pin = newpin;
    }
    public void SetName(String newname)
    {
        name = newname;
    }
    public void SetLastName(String newlastName)
    {
        lastName = newlastName;
    }
    public void SetBalance(double newbalance)
    {
        balance = newbalance;
    }

    public static void Main(String[]args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from the following options..");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Please enter the amount you would like to deposit.");
            double depositAmount = Convert.ToDouble(Console.ReadLine());
            currentUser.SetBalance(currentUser.getBalance() + depositAmount);
            Console.WriteLine("Your new balance is: " + currentUser.getBalance());
            Console.WriteLine("Thank you for your deposit.");
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Please enter the amount you would like to withdraw.");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());
            if (withdrawAmount > currentUser.getBalance())
            {
                Console.WriteLine("You do not have enough funds to withdraw that amount.");
            }
            else
            {
                currentUser.SetBalance(currentUser.getBalance() - withdrawAmount);
                Console.WriteLine("Your new balance is: " + currentUser.getBalance());
                Console.WriteLine("Thank you for your withdrawal.");
            }
        }
        void checkBalance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }
        void exit()
        {
            Console.WriteLine("Thank you for using our ATM.");
            Console.WriteLine("Please take your card.");
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456789", 1234, "John", "Doe", 1000));
        cardHolders.Add(new cardHolder("987654321", 4321, "Jane", "Doe", 500));
        cardHolders.Add(new cardHolder("123123123", 1111, "John", "Smith", 2000));
        cardHolders.Add(new cardHolder("321321321", 2222, "Jane", "Smith", 2500));

        Console.WriteLine("Welcome to ATM Console App.");
        Console.WriteLine("Please enter your card number.");
        String cardNum = "";
        cardHolder currentUser = null;

        while (true)
        {
            try
            {
                cardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(x => x.getCardNum() == cardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid card number. Please try again.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid card number. Please try again.");
                throw;
            }
        }
        Console.WriteLine("Please enter your pin.");
        while (true)
        {
            try
            {
                int pin = Convert.ToInt32(Console.ReadLine());
                if (currentUser.getPin() == pin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect pin. Please try again.");
                throw;
            }
        }
        Console.WriteLine("Welcome " + currentUser.getName() + " " + currentUser.getLastName() + ".");
        printOptions();
        while (true)
        {
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    deposit(currentUser);
                    printOptions();
                }
                else if (option == 2)
                {
                    withdraw(currentUser);
                    printOptions();
                }
                else if (option == 3)
                {
                    checkBalance(currentUser);
                    printOptions();
                }
                else if (option == 4)
                {
                    exit();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid option. Please try again.");
                throw;
            }
        }
    }
}