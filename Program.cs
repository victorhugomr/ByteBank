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

		private static Random random = new Random();

		public static string RandomString(int length){
			const string chars = "0123456789";
			return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
		}
		
		public static int GetIndex(List<Accounts> listOfAccounts, string? CPF){
			//Busca o index da lista de contas.
			return listOfAccounts.FindIndex(a => a.CPF == CPF);
   		}
		
		public static string? GetCPF(){
			//Lê um CPF válido.
			string? CPF = Console.ReadLine();

			if(CPF is not null){
				if(CPF.Length == 11){
					return CPF;
				}
				else{
					Console.Clear();
					Console.WriteLine("CPF inválido. Insira novamente o CPF desejado. ");
					return GetCPF();
				}
			}
			else{
				return GetCPF();
			}
   		}

		public static bool AccountExists(List<Accounts> listOfAccounts, string account){
			//Checa se o número da conta existe.
			foreach(Accounts item in listOfAccounts){
				if(account == item.Account){
					return true;
				}
			}
			return false;
   		}

		public static bool CPFExists(List<Accounts> listOfAccounts, string? CPF){
			//Checa se o CPF existe.
			foreach(Accounts item in listOfAccounts){
				if(CPF == item.CPF){
					return true;
				}
			}
			return false;
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

			string? optionTmp = (Console.ReadLine());
			int option = 0;
			if(int.TryParse(optionTmp, out option)){
			}
			
			switch(option){
					case 1:
						InsertUser(listOfAccounts);
						break;

					case 2:
						DeleteUser(listOfAccounts);
						break;

					case 3:
						ListAccounts(listOfAccounts);
						break;

					case 4:
						AccountDetails(listOfAccounts);
						break;

					case 5:
						ShowBalance(listOfAccounts);
						break;

					case 6:
						Transactions(listOfAccounts);
						break;

					case 0:
						Exit();
						break;
				}

			return option;
   		}

		public static int MenuTransactions(List<Accounts> listOfAccounts){
			//Menu de transações.
			Console.Clear();
			Console.WriteLine("Escolha uma opção: ");
			Console.WriteLine("1. Depositar");
			Console.WriteLine("2. Sacar");
			Console.WriteLine("3. Transferir");
			Console.WriteLine("4. Voltar");

			string? optionTmp = (Console.ReadLine());
			int option = 0;
			if(int.TryParse(optionTmp, out option)){
			}

			switch(option){
					case 1:
						Deposit(listOfAccounts);
						break;

					case 2:
						Withdraw(listOfAccounts);
						break;

					case 3:
						Transfer(listOfAccounts);
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
			account.Account = RandomString(8);
			while(AccountExists(listOfAccounts, account.Account)){
				account.Account = RandomString(8);
			}
			account.Agency = "001";

			Console.Clear();
			Console.WriteLine("Para inserir um novo usuário, digite o nome do usuário. ");
			account.Name = Console.ReadLine();

			Console.Clear();
			Console.WriteLine("Digite o CPF do usuário. ");
			account.CPF = GetCPF();
			while(CPFExists(listOfAccounts, account.CPF)){
				Console.Clear();
				Console.WriteLine("CPF já existe. Digite um CPF válido. ");
				account.CPF = GetCPF();
			}

			listOfAccounts.Add(account);
			Console.Clear();
			Console.WriteLine("Usuário inserido com sucesso. \n\nPressione ENTER para continuar. ");
			Console.ReadLine();
   		}

		public static void DeleteUser(List<Accounts> listOfAccounts){
			//Deletar um usuário.
			Console.Clear();
			Console.WriteLine("Para deletar um usuário, digite o CPF do usuário. ");
			string? CPF = GetCPF();
			int index = GetIndex(listOfAccounts, CPF);
			listOfAccounts.RemoveAt(index);
   		}

		public static void ListAccounts(List<Accounts> listOfAccounts){
			//Listar todas as contas registradas.
			Console.Clear();
			foreach(Accounts item in listOfAccounts){
				Console.WriteLine(item.Account);
			}
			Console.WriteLine("\nPressione ENTER para continuar. ");
			Console.ReadLine();
   		}

		public static void AccountDetails(List<Accounts> listOfAccounts){
			//Detalhes de um usuário.
			Console.Clear();
			Console.WriteLine("Digite o CPF do usuário. ");
			string? CPF = GetCPF();
			int index = GetIndex(listOfAccounts, CPF);

			Console.Clear();
			Console.WriteLine("Nome: {0}", listOfAccounts[index].Name);
			Console.WriteLine("CPF: {0}", listOfAccounts[index].CPF);
			Console.WriteLine("Conta: {0}", listOfAccounts[index].Account);
			Console.WriteLine("Agência: {0}", listOfAccounts[index].Agency);
			Console.WriteLine("\nPressione ENTER para continuar. ");
			Console.ReadLine();
   		}

		public static void ShowBalance(List<Accounts> listOfAccounts){
			//Total armazenado na conta.
			Console.Clear();
			Console.WriteLine("Digite o CPF do usuário. ");
			string? CPF = GetCPF();
			int index = GetIndex(listOfAccounts, CPF);
			
			Console.Clear();
			Console.WriteLine("Saldo na conta: R${0:0.00}. \n\nPressione ENTER para continuar", listOfAccounts[index].Balance);
			Console.ReadLine();
   		}

		public static void Transactions(List<Accounts> listOfAccounts){
			//Manipular conta.
			int optionTransactions = 4;

			Console.Clear();
			do{
				optionTransactions = MenuTransactions(listOfAccounts);

			}while(optionTransactions != 4);
   		}

		public static void Deposit(List<Accounts> listOfAccounts){
			//Depositar valor na conta.
			Console.Clear();
			Console.WriteLine("Digite o CPF do usuário que deseja depositar. ");
			string? CPF = GetCPF();
			int index = GetIndex(listOfAccounts, CPF);

			Console.Clear();
			Console.WriteLine("Digite o valor que deseja depositar. ");
			string? valueTmp = (Console.ReadLine());
			double value = 0;
			if(Double.TryParse(valueTmp, out value)){
			}

			if(value > 0){
				listOfAccounts[index].Balance += value;
				Console.Clear();
				Console.WriteLine("Você depositou R${0:0.00}. \n\nPressione ENTER para continuar. ", value);
				Console.ReadLine();
			}
			else{
				Console.Clear();
				Console.WriteLine("OPERAÇÃO NEGADA! O valor informado é um valor inválido. \n\nPressione ENTER para continuar. ");
				Console.ReadLine();
			}
   		}

		public static void Withdraw(List<Accounts> listOfAccounts){
			//Sacar valor da conta.
			Console.Clear();
			Console.WriteLine("Digite o CPF do usuário que deseja sacar. ");
			string? CPF = GetCPF();
			int index = GetIndex(listOfAccounts, CPF);
			
			Console.Clear();
			Console.WriteLine("Digite o valor que deseja sacar. ");
			string? valueTmp = (Console.ReadLine());
			double value = 0;
			if(Double.TryParse(valueTmp, out value)){
			}
			if(listOfAccounts[index].Balance >= value){
				listOfAccounts[index].Balance -= value;
				Console.Clear();
				Console.WriteLine("Você sacou R${0:0.00}. \n\nPressione ENTER para continuar. ", value);
				Console.ReadLine();
			}
			else{
				Console.Clear();
				Console.WriteLine("OPERAÇÃO NEGADA! O valor informado é maior que o saldo em conta. \n\nPressione ENTER para continuar. ");
				Console.ReadLine();
			}
   		}

		public static void Transfer(List<Accounts> listOfAccounts){
			//Transferir valor para outra conta.
			Console.Clear();
			Console.WriteLine("Digite o seu CPF. ");
			string? CPFFrom = GetCPF();
			int indexFrom = GetIndex(listOfAccounts, CPFFrom);

			Console.Clear();
			Console.WriteLine("Digite o CPF do usuário para quem deseja transferir. ");
			string? CPFTo = GetCPF();
			int indexTo = GetIndex(listOfAccounts, CPFTo);
			
			Console.Clear();
			Console.WriteLine("Digite o valor que deseja transferir. ");
			string? valueTmp = (Console.ReadLine());
			double value = 0;
			if(Double.TryParse(valueTmp, out value)){
			}

			if(listOfAccounts[indexFrom].Balance >= value){
				listOfAccounts[indexFrom].Balance -= value;
				listOfAccounts[indexTo].Balance += value;
				Console.Clear();
				Console.WriteLine("Você transferiu R${0:0.00} para {1}. \n\nPressione ENTER para continuar. ", value, listOfAccounts[indexTo].Name);
				Console.ReadLine();
			}
			else{
				Console.Clear();
				Console.WriteLine("OPERAÇÃO NEGADA! O valor informado é maior que o saldo em conta. \n\nPressione ENTER para continuar. ");
				Console.ReadLine();
			}
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