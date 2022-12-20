using System;
using System.Collections.Generic;

namespace ByteBank{

    public class Program{

		public class Accounts{
			public double? Balance { get; set; }
			public string? Account { get; set; }
			public string? Agency { get; set; }
			public string? Name { get; set; }
			public string? CPF { get; set; }
		}

		public static int Menu(List<Accounts> listOfAccounts){
			//Menu principal.
			Console.Clear();
			Console.WriteLine("Escolha uma opção: ");
			Console.WriteLine("1. Inserir novo usuário");
			Console.WriteLine("2. Deletar um usuário");
			Console.WriteLine("3. Listar contas registradas");
			Console.WriteLine("4. Mostrar detalhes de um usuário");
			Console.WriteLine("5. Mostrar saldo de um usuário");
			Console.WriteLine("6. Realizar uma transação");
			Console.WriteLine("0. Sair");

			int option = int.Parse(Console.ReadLine());

			switch(option){
					case 1:
						InsertUser(listOfAccounts);
						break;

					case 2:
						DeleteUser();
						break;

					case 3:
						ListAccounts(listOfAccounts);
						break;

					case 4:
						AccountDetails();
						break;

					case 5:
						ShowBalance();
						break;

					case 6:
						Transactions();
						break;

					case 0:
						Exit();
						break;
				}

			return option;
   		}

		public static int MenuTransactions(){
			//Menu de transações.
			Console.Clear();
			Console.WriteLine("Escolha uma opção: ");
			Console.WriteLine("1. Depositar");
			Console.WriteLine("2. Sacar");
			Console.WriteLine("3. Transferir");
			Console.WriteLine("4. Voltar");

			int option = int.Parse(Console.ReadLine());

			switch(option){
					case 1:
						Deposit();
						break;

					case 2:
						Withdraw();
						break;

					case 3:
						Transfer();
						break;

					default:
						break;
				}
			
			return option;
   		}

		public static void InsertUser(List<Accounts> listOfAccounts){
			//Inserir novo usuário.
			Accounts account = new Accounts();

			account.Balance = 0;
			account.Account = "gerar string aleatória";
			account.Agency = "123";

			Console.Clear();
			Console.WriteLine("Para inserir um novo usuário, digite o nome do usuário: ");
			account.Name = Console.ReadLine();

			Console.Clear();
			Console.WriteLine("Digite o CPF do usuário: ");
			account.CPF = Console.ReadLine();

			listOfAccounts.Add(account);
   		}

		public static void DeleteUser(){
			//Deletar um usuário.
			Console.Clear();
   		}

		public static void ListAccounts(List<Accounts> listOfAccounts){
			//Listar todas as contas registradas.
			Console.Clear();
			foreach(Accounts item in listOfAccounts){
				Console.WriteLine(item.Account);
			}
			
			Console.WriteLine("Pressione ENTER para continuar. ");
			Console.ReadLine();
   		}

		public static void AccountDetails(){
			//Detalhes de um usuário.
			Console.Clear();
   		}

		public static void ShowBalance(){
			//Total armazenado no banco.
			Console.Clear();
   		}

		public static void Transactions(){
			//Manipular conta.
			int optionTransactions = 4;

			Console.Clear();
			
			do{
				optionTransactions = MenuTransactions();

			}while(optionTransactions != 4);
   		}

		public static void Deposit(){
			//Depositar valor na conta.
			Console.Clear();
   		}

		public static void Withdraw(){
			//Sacar valor da conta.
			Console.Clear();
   		}

		public static void Transfer(){
			//Transferir valor para outra conta.
			Console.Clear();
   		}

		public static void Exit(){
			//Sair do programa.
			Console.Clear();
   		}

    	public static void Main(){
			List<Accounts> listOfAccounts = new List<Accounts>();
			int option = 0;

			do{
				option = Menu(listOfAccounts);

			}while(option != 0);
   		}
	}
}