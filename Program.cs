namespace ByteBank{

    public class Program{

		public static void Menu(int option){
			//Menu principal.
			Console.WriteLine();
   	}

		public static void MenuTransactions(){
			//Menu de transações.
			Console.WriteLine();
   	}

		public static void InsertUser(){
			//Inserir novo usuário.
   	}

		public static void DeleteUser(){
			//Deletar um usuário.
   	}

		public static void ListAccounts(){
			//Listar todas as contas registradas.
   	}

		public static void AccountDetails(){
			//Detalhes de um usuário.
   	}

		public static void Balance(){
			//Total armazenado no banco.
   	}

		public static void Transactions(){
			//Manipular conta.
			MenuTransactions();
   	}

		public static void Exit(){
			//Sair do programa.
   	}

    	public static void Main(){
			int option = 0;

			do{
				Menu(option);
				option = int.Parse(Console.ReadLine());
			}while(option != 0);
   	}
	}
}