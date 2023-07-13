using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

string[] input = Console.ReadLine().Split(',');

Dictionary<int, double> accounts = new Dictionary<int, double>();

foreach (string line in input)
{
    string[] info = line.Split("-");
    int account = int.Parse(info[0]);
    double balace = double.Parse(info[1]);
    accounts.Add(account, balace);
}
string commandInfo = string.Empty;


while ((commandInfo = Console.ReadLine()) != "End")
{
	string[] tokens = commandInfo.Split(" ");
	string command = tokens[0];
	int account = int.Parse(tokens[1]);
	double balance = double.Parse(tokens[2]);
	try
	{
		switch (command)
		{
			case "Deposit":
				if (!accounts.ContainsKey(account))
				{
					throw new ArgumentException("Invalid account!");
				}
				accounts[account] += balance;
                Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}");
                break;

			case "Withdraw":
				if (accounts[account] < balance)
				{
                    throw new ArgumentException("Insufficient balance!");
                }
				accounts[account] -= balance;
                Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}");
                break;
			default:
				throw new ArgumentException("Invalid command!");
		}
	}
	catch (ArgumentException ex)
	{
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("Enter another command");
}