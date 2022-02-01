using System;

namespace vendaQuitanda
{ 
    class Program
 
    {
		static QuitandaRepositorio repositorio = new QuitandaRepositorio();

		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarAlimentos();
						break;
					case "2":
						InserirAlimento();
						break;
					case "3":
						AtualizarAlimento();
						break;
					case "4":
						ExcluirAlimento();
						break;
					case "5":
						VisualizarAlimento();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						Console.WriteLine("Opção inválida!");
						break;
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void ListarAlimentos()
		{
			Console.WriteLine("Lista de alimentos:");
			Console.WriteLine();

			var lista = repositorio.Listar();

			bool possuiItensValidos = false;
			foreach (var alimento in lista) 
			{
				if (!alimento.isExcluido()) {
					Console.WriteLine("#ID {0}: {1}", alimento.retornaId(), alimento.retornaNome());
					possuiItensValidos = true;
				}
			}

			if (!possuiItensValidos) {
				Console.WriteLine("Nenhum alimento cadastrado.");
			}
		}

		private static void InserirAlimento()
		{
			Console.WriteLine("Inserir novo Alimento:");
			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(TipoAlimento)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoAlimento), i));
			}

			Console.WriteLine();
			Console.Write("Digite o tipo de alimento entre as opções acima: ");
			int entradaTipoAlimento = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do alimento: ");
			string entradaNome = Console.ReadLine();
			Console.Write("Digite as calorias do alimento: ");
			int entradaCaloria = int.Parse(Console.ReadLine());

			Console.Write("Digite o preço do alimento: ");
            double entradaPreco = Double.Parse(Console.ReadLine());

			Console.Write("Digite a unidade de medida do alimento: ");
			string entradaUnidadeMedida = Console.ReadLine();


			Alimento novoAlimento = new Alimento(id: repositorio.ProximoId(),
										tipoAlimento: (TipoAlimento)entradaTipoAlimento,
										nome: entradaNome,
										caloria: entradaCaloria,
										unidadeMedida: entradaUnidadeMedida,
										preco: entradaPreco);

			repositorio.Inserir(novoAlimento);

			Console.WriteLine();
			Console.WriteLine("Alimento incluído com sucesso!");
		}

		private static void AtualizarAlimento()
		{
			Console.Write("Digite o id do alimento: ");
			int indiceAlimento = int.Parse(Console.ReadLine());
			Console.WriteLine();

			var alimento = repositorio.RetornarPorId(indiceAlimento);
			
            if (isAlimentoValido(alimento)) 
			{ 
				Console.WriteLine("Detalhes do Alimento:");
				Console.WriteLine();
				Console.WriteLine(alimento);
				Console.WriteLine();

				Console.WriteLine("Atualizar Alimento:");
				Console.WriteLine();

				foreach (int i in Enum.GetValues(typeof(TipoAlimento)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoAlimento), i));
				}

				Console.WriteLine();
				Console.Write("Digite o tipo do alimento entre as opções acima: ");
				int entradaTipoAlimento = int.Parse(Console.ReadLine());

				Console.Write("Digite o nome do alimento: ");
				string nomeAlimento = Console.ReadLine();

				Console.Write("Digite as calorias do alimento: ");
				int entradaCaloria = int.Parse(Console.ReadLine());

				Console.Write("Digite o preço do alimento: ");
				double entradaPreco = double.Parse(Console.ReadLine());

				Console.Write("Digite a unidade de medida do alimento: ");
				string entradaUnidadeMedida = Console.ReadLine();

				Alimento atualizaSerie = new Alimento(id: indiceAlimento,
											tipoAlimento: (TipoAlimento)entradaTipoAlimento,
											nome: nomeAlimento,
											caloria: entradaCaloria,
											unidadeMedida: entradaUnidadeMedida,
											preco: entradaPreco);

				repositorio.Atualizar(indiceAlimento, atualizaSerie);

			}

		}

		private static void ExcluirAlimento()
		{
			Console.Write("Digite o id do Alimento: ");
			int indiceAlimento = int.Parse(Console.ReadLine());
			Console.WriteLine();

			Alimento alimento = repositorio.RetornarPorId(indiceAlimento);

			if (isAlimentoValido(alimento))
			{
				Console.Write("Deseja excluir o alimento {0}? (s/n): ", alimento.retornaNome());
				string confirmacao = Console.ReadLine();

				if (confirmacao.ToUpper() == "S")
				{
					repositorio.Excluir(indiceAlimento);
					Console.WriteLine();
					Console.WriteLine("Alimento Excluído com sucesso!");
				}
				else if (confirmacao.ToUpper() != "N") 
				{
					Console.WriteLine();
					Console.WriteLine("Opção inválida");
				}

			}

		}

		private static void VisualizarAlimento()
		{
			Console.Write("Digite o id do alimento: ");
			int indiceAlimento = int.Parse(Console.ReadLine());
			Console.WriteLine();

			var alimento = repositorio.RetornarPorId(indiceAlimento);

			if (isAlimentoValido(alimento)) 
			{ 
				Console.WriteLine(alimento);
			}
			
		}

		private static bool isAlimentoValido(Alimento alimento) {
			bool retorno = true;

			if(alimento == null)
            {
				retorno = false;
            }
			else if (alimento.isExcluido())
			{
				Console.WriteLine();
				Console.WriteLine("O alimento foi excluído da base");
				retorno = false;
            }
            
			return retorno;
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("VendaQuitanda. A seu dispor!!");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();
			Console.WriteLine("1- Listar alimentos");
			Console.WriteLine("2- Inserir novo alimento");
			Console.WriteLine("3- Atualizar alimento");
			Console.WriteLine("4- Excluir alimento");
			Console.WriteLine("5- Visualizar alimento");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}


