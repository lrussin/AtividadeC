﻿using Livraria;
using System.Reflection.Metadata.Ecma335;


int opcao = 0;
List<Livros> biblioteca = new List<Livros>();
List<Usuario> usuarios = new List<Usuario>();
List<Emprestimo> emprestimos = new List<Emprestimo>();


do
{
	Console.WriteLine("O QUE VOCE DESEJA?");

	Console.WriteLine("========CADASTROS========");
	Console.WriteLine("1 - CADASTRAR LIVRO");
	Console.WriteLine("2 - CADASTRAR USUARIO");

	Console.WriteLine("========TRANSAÇÕES=======");
	Console.WriteLine("3 - NOVO EMPRÉSTIMO");
	//não é necessario
	Console.WriteLine("4 - DEVOLVER EMPRÉSTIMO");

	Console.WriteLine("========CONSULTAS========");
	//NECESSÁRIO
	Console.WriteLine("5 - CONSULTAR LIVROS");
	//NECESSÁRIO
	Console.WriteLine("6 - CONSULTAR USUARIO");

	Console.WriteLine("======CONFIGURAÇÕES======");
	Console.WriteLine("7 - SAIR");
	Console.WriteLine("");

	opcao = int.Parse(Console.ReadLine());



	switch (opcao)
	{
		case 1:
			Console.WriteLine("Cadastro de Livro");


			Console.Write("Nome do Livro: ");
			string livro = Console.ReadLine();
			Console.Write("Codigo: ");
			double cod = double.Parse(Console.ReadLine());
			Console.Write("Valor: ");
			decimal valor = decimal.Parse(Console.ReadLine());
			Console.Write("Nº Paginas: ");
			int pg = int.Parse(Console.ReadLine());

			

			Livros novo = new Livros(livro, pg, cod, valor);

			biblioteca.Add(novo);

			Console.Clear();

			break;
		case 2:
			Console.WriteLine("Cadastro de Usuario");
			CadastrarUsuario();
			break;
		case 3:
			Console.WriteLine("Novo Empréstimo");
			NovoEmprestimo();
			break;
		case 4:
			Console.WriteLine("Devolver Empréstimo");
			DevolverEmprestimo();
			break;
		case 5:
			Console.WriteLine("Consultar Livros");
			ConsultarLivro();
			break;
		case 6:
			Console.WriteLine("Consultar Usuário");
			ConsultarUsuario();
			break;
	}

} while (opcao != 7);

void NovoEmprestimo()
{
	Console.Write("Login: ");
	string login = Console.ReadLine();

	Usuario buscado = usuarios.Where(x => x.Login.Equals(login)).FirstOrDefault();

	if (buscado != null)
	{
		Console.WriteLine("Usuario Encontrado...");

		Console.Write("Senha: ");
		string senha = Console.ReadLine();



		if (buscado.Senha == senha)
		{

			Console.WriteLine("Usuario Logado!");
			Console.WriteLine("");
			Console.Write("Qual livro você deseja?, digite o nome: ");
			string nomeLivro = Console.ReadLine();

			List<Livros> buscalivro = biblioteca.Where(x => x.Livro.StartsWith(nomeLivro)).ToList();
			if (buscalivro.Count == 0) Console.WriteLine("Livro não encontrado");
			else if (buscalivro.Count == 1)
			{
				Console.WriteLine($"{buscalivro[0].Livro} encontrado!");

				//ADICIONA "REGISTRO" NA LISTA EMPRESTIMOS

				Emprestimo novoEmprestimo = new Emprestimo(buscalivro[0], buscado);

				emprestimos.Add(novoEmprestimo);

				Console.Clear();

			}
			else
			{

				Console.WriteLine($"{buscalivro.Count} encontrados");
				//INFORMAR QUAIS LIVROS ENCONTRADOS COM O NOME
			}


		}
		else Console.WriteLine("Senha Incorreta");
	}
	else Console.WriteLine("Usuario não Encontrado...");




}

void DevolverEmprestimo()
{
	Console.Write("Login: ");
	string login = Console.ReadLine();

	Usuario buscado = usuarios.FirstOrDefault(x => x.Login.Equals(login));

	if (buscado != null)
	{
		Console.WriteLine("Usuario Encontrado...");

		Console.Write("Senha: ");
		string senha = Console.ReadLine();

		if (buscado.Senha == senha)
		{
			Console.WriteLine("Usuario Logado!");
			Console.WriteLine("");
			Console.WriteLine("Lista de Empréstimos:");

			// Exibir a lista de empréstimos do usuário
			List<Emprestimo> emprestimosUsuario = emprestimos.Where(e => e.Usuario == buscado).ToList();

			if (emprestimosUsuario.Count == 0)
			{
				Console.WriteLine("Você não possui empréstimos pendentes.");
			}
			else
			{
				for (int i = 0; i < emprestimosUsuario.Count; i++)
				{
					Console.WriteLine($"Item {i}");
					Console.WriteLine($"Livro: {emprestimosUsuario[i].Livros.Livro}");
					Console.WriteLine("");
				}

				// Solicitar ao usuário que escolha qual empréstimo deseja devolver
				Console.Write("Digite o número do item para devolver (ou -1 para cancelar): ");
				int opcaoDevolucao = int.Parse(Console.ReadLine());

				if (opcaoDevolucao >= 0 && opcaoDevolucao < emprestimosUsuario.Count)
				{
					// Remover o empréstimo da lista
					emprestimos.Remove(emprestimosUsuario[opcaoDevolucao]);

					Console.WriteLine("Empréstimo devolvido com sucesso!");
				}
				else
				{
					Console.WriteLine("Operação de devolução cancelada.");
				}
			}
		}
		else
		{
			Console.WriteLine("Senha Incorreta");
		}
	}
	else
	{
		Console.WriteLine("Usuario não Encontrado...");
	}
}

void CadastrarUsuario()
{


	Console.Write("Nome do Usuario: ");
	string usuario = Console.ReadLine();
	Console.Write("Login: ");
	string login = Console.ReadLine();
	Console.Write("Senha: ");
	string senha = Console.ReadLine();

	Usuario novoUser = new Usuario(usuario, login, senha);

	usuarios.Add(novoUser);


	Console.WriteLine(novoUser.Id);
}

void ConsultarUsuario()
{
	int i = 0;
	foreach (var user in usuarios)
	{
		Console.WriteLine(" ");

		Console.WriteLine("Item " + i);
		Console.WriteLine("Nome do Usuario: " + user.Nome);
		Console.WriteLine("Login: " + user.Login);

		Console.WriteLine(" ");

		i++;
	}
}

void ConsultarLivro()
{
	int i = 0;
	foreach (var liv in biblioteca)
	{
		Console.WriteLine(" ");

		Console.WriteLine("Item " + i );
		Console.WriteLine("Nome do Livro: " + liv.Livro);
		Console.WriteLine("Codigo: " + liv.Codigo);
		Console.WriteLine("Valor: " + liv.Valor);
		Console.WriteLine("Nº Paginas: " + liv.Paginas);

		Console.WriteLine(" ");

		i++;
	}
}

Console.ReadLine();