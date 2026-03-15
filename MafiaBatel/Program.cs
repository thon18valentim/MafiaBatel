
class Pessoa
{
	public int Id { get; set; }
	public string NomeReal { get; set; }
	public string NomeFantasia { get; set; }
	public string Personagem { get; set; } = "None";
}

class Voto
{
	public int IdPessoa { get; set; }
	public int IdPessoaAlvo { get; set; }
	public int Rodada { get; set; }
	public DateTime DateTime { get; set; }
}

class Program
{
	static List<Pessoa> pessoas = [];
	static List<Voto> votos = [];
	static string caminhoArquivo = "pessoas.csv";
	static string caminhoArquivoVotos = "votos.csv";
	static int rodada = 1;
	static int idCount = 1;

	static void Main()
	{
		CarregarCSV();
		CarregarVotosCSV();
		MenuPrincipal();
	}

	static void MenuPrincipal()
	{
		while (true)
		{
			Console.WriteLine("\n---- MAFIA BATEL ----");
			Console.WriteLine($"Rodada #{rodada}");
			Console.WriteLine("\n1.	Cadastrar pessoa");
			Console.WriteLine("2.	Cadastrar pessoas genéricas");
			Console.WriteLine("3.	Listar pessoas");
			Console.WriteLine("4.	Listar votos");
			Console.WriteLine("5.	Excluir pessoa");
			Console.WriteLine("6.	Sortear personagens (Modelo A)");
			Console.WriteLine("7.	Sortear personagens (Modelo B)");
			Console.WriteLine("8.	Registrar voto");
			Console.WriteLine("9.	Relatório de votos");
			Console.WriteLine("10.	Avançar rodada");
			Console.WriteLine("11.	Salvar");
			Console.WriteLine("0.	Sair");
			Console.WriteLine("-1.	Excluir base de dados");
			Console.Write("Escolha uma opção: ");
			string opcao = Console.ReadLine();

			switch (opcao)
			{
				case "1":
					CadastrarPessoa();
					break;
				case "2":
					CadastrarPessoasGenericas();
					break;
				case "3":
					ListarPessoas();
					break;
				case "4":
					ListarVotos();
					break;
				case "5":
					ExcluirPessoa();
					break;
				case "6":
					SortearPersonagensPorModelo("A");
					break;
				case "7":
					SortearPersonagensPorModelo("B");
					break;
				case "8":
					// registrar voto
					RegistrarVoto();
					break;
				case "9":
					// retornar relatório de votos
					RelatorioDeVotos();
					break;
				case "10":
					// avançar rodada
					AvancarRodada();
					break;
				case "11":
					SalvarCSV();
					break;
				case "-1":
					ExcluirBaseDeDados();
					break;
				case "0":
					return;
				default:
					Console.WriteLine("Opção inválida.");
					break;
			}
		}
	}

	static void CadastrarPessoa()
	{
		Console.Write("Nome real: ");
		string nomeReal = Console.ReadLine();

		Console.Write("Nome fantasia: ");
		string nomeFantasia = Console.ReadLine();

		Console.Write("Personagem: ");
		string personagem = Console.ReadLine();

		pessoas.Add(new Pessoa
		{
			Id = idCount,
			NomeReal = nomeReal,
			NomeFantasia = nomeFantasia,
			Personagem = personagem
		});

		idCount++;

		Console.WriteLine("Cadastro realizado com sucesso!");
	}

	static void ListarPessoas()
	{
		Console.WriteLine($"\n--- {pessoas.Count} Pessoas Cadastradas ---");

		var count = 1;
		foreach (var p in pessoas)
		{
			Console.WriteLine($"({count}) Id: {p.Id}, Real: {p.NomeReal}, Fantasia: {p.NomeFantasia}, Personagem: {p.Personagem}");
			count++;
		}
	}

	static void SortearPersonagensPorModelo(string modelo)
	{
		int minimoPessoas = modelo == "A" ? 15 : 20;
		if (pessoas.Count < minimoPessoas)
		{
			Console.WriteLine($"Sorteio do modelo {modelo} requer no mínimo {minimoPessoas} pessoas cadastradas.");
			return;
		}

		Dictionary<string, int> distribuicao = modelo == "A"
			? new Dictionary<string, int>
			{
			{ "Mafioso", 3 }, { "Policial", 3 }, { "Detetive", 1 },
			{ "Anjo", 1 }, { "Cidadão Justiceiro", 1 }
			}
			: new Dictionary<string, int>
			{
			{ "Mafioso", 4 }, { "Policial", 4 }, { "Detetive", 1 },
			{ "Anjo", 1 }, { "Cidadão Justiceiro", 1 }
			};

		List<Pessoa> semPersonagem = new List<Pessoa>(pessoas); // Inclui todas as pessoas no sorteio
		Random rnd = new Random();

		foreach (var entry in distribuicao)
		{
			for (int i = 0; i < entry.Value; i++)
			{
				if (semPersonagem.Count == 0) break;
				int indice = rnd.Next(semPersonagem.Count);
				semPersonagem[indice].Personagem = entry.Key;
				semPersonagem.RemoveAt(indice);
			}
		}

		foreach (var p in semPersonagem) p.Personagem = "Cidadão";

		Console.WriteLine($"Sorteio do modelo {modelo} concluído!");
	}

	static void SalvarCSV()
	{
		using (var sw = new StreamWriter(caminhoArquivo))
		{
			foreach (var p in pessoas)
			{
				sw.WriteLine($"{p.Id},{p.NomeReal},{p.NomeFantasia},{p.Personagem}");
			}
		}
		Console.WriteLine("Dados salvos com sucesso!");
	}

	static void SalvarVotosCSV()
	{
		using (var sw = new StreamWriter(caminhoArquivoVotos))
		{
			foreach (var v in votos)
			{
				sw.WriteLine($"{v.IdPessoa},{v.IdPessoaAlvo},{v.Rodada},{v.DateTime}");
			}
		}
		Console.WriteLine("Dados salvos com sucesso!");
	}

	static void CarregarCSV()
	{
		if (!File.Exists(caminhoArquivo)) return;

		var linhas = File.ReadAllLines(caminhoArquivo);
		foreach (var linha in linhas)
		{
			var partes = linha.Split(',');
			if (partes.Length == 4)
			{
				pessoas.Add(new Pessoa
				{
					Id = int.Parse(partes[0]),
					NomeReal = partes[1],
					NomeFantasia = partes[2],
					Personagem = partes[3]
				});
			}
		}

		idCount = pessoas.Count + 1;

		Console.WriteLine("Dados das pessoas carregados.");
	}

	static void CarregarVotosCSV()
	{
		if (!File.Exists(caminhoArquivoVotos)) return;

		var linhas = File.ReadAllLines(caminhoArquivoVotos);
		foreach (var linha in linhas)
		{
			var partes = linha.Split(',');
			if (partes.Length == 4)
			{
				votos.Add(new Voto
				{
					IdPessoa = int.Parse(partes[0]),
					IdPessoaAlvo = int.Parse(partes[1]),
					Rodada = int.Parse(partes[2]),
					DateTime = DateTime.Parse(partes[3])
				});
			}
		}

		idCount = pessoas.Count + 1;
		rodada = votos.Max(vt => vt.Rodada);

		Console.WriteLine("Dados dos votos carregados.");
	}

	static void ExcluirPessoa()
	{
		Console.Write("Digite o id da pessoa que deseja excluir: ");
		var id = Console.ReadLine();

		var pessoaParaRemover = pessoas.Find(p => p.Id == int.Parse(id));

		if (pessoaParaRemover != null)
		{
			pessoas.Remove(pessoaParaRemover);
			Console.WriteLine("Pessoa removida com sucesso!");
		}
		else
		{
			Console.WriteLine("Pessoa não encontrada.");
		}
	}

	static void CadastrarPessoasGenericas()
	{
		Console.Write("Quantas pessoas genéricas deseja cadastrar? ");
		if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
		{
			Console.WriteLine("Por favor, insira um número válido maior que zero.");
			return;
		}

		for (int i = 1; i <= quantidade; i++)
		{
			string nomeReal = $"Pessoa{i}";
			string nomeFantasia = $"Fantasia{i}";

			pessoas.Add(new Pessoa
			{
				Id = idCount,
				NomeReal = nomeReal,
				NomeFantasia = nomeFantasia
			});

			idCount++;
		}

		Console.WriteLine($"{quantidade} pessoas genéricas cadastradas com sucesso!");
	}

	static void ExcluirBaseDeDados()
	{
		if (File.Exists(caminhoArquivo))
		{
			File.Delete(caminhoArquivo);
			pessoas.Clear();
			idCount = 1;
			Console.WriteLine("Base de dados excluída com sucesso!");
		}
		else
		{
			Console.WriteLine("Nenhum arquivo de base de dados encontrado.");
		}
	}

	static void RegistrarVoto()
	{
		ListarPessoas();

		Console.WriteLine($"\n--- Registrar voto na rodada {rodada} ---");
		Console.Write("Digite o id da pessoa que irá votar: ");
		var id = Console.ReadLine();

		var pessoaParaVotar = pessoas.Find(p => p.Id == int.Parse(id));
		if (pessoaParaVotar != null)
		{
			var votoExistente = votos.FirstOrDefault(vt => vt.Rodada == rodada && vt.IdPessoa == pessoaParaVotar.Id);

			Console.WriteLine("Digite o id da pessoal alvo do voto: ");

			var idPessoaAlvo = Console.ReadLine();
			var pessoaAlvo = pessoas.Find(p => p.Id == int.Parse(id));
			if (pessoaAlvo == null)
			{
				Console.WriteLine("Pessoa não encontrada.");
				return;
			}

			var voto = new Voto
			{
				IdPessoa = int.Parse(id),
				IdPessoaAlvo = int.Parse(idPessoaAlvo),
				Rodada = rodada,
				DateTime = DateTime.Now
			};

			if (votoExistente != null)
			{
				votoExistente = voto;
			} // substituir voto
			else
			{
				votos.Add(voto);
			} // novo voto

			SalvarVotosCSV();
			Console.WriteLine("Voto registrado com sucesso");
		}
		else
		{
			Console.WriteLine("Pessoa não encontrada.");
		}
	}

	static void ListarVotos()
	{
		Console.WriteLine($"\n--- {votos.Count} Votos Cadastradas ---");

		foreach (var v in votos)
		{
			var pessoa = pessoas.FirstOrDefault(ps => ps.Id == v.IdPessoa);
			var pessoaAlvo = pessoas.FirstOrDefault(ps => ps.Id == v.IdPessoa);

			Console.WriteLine($"({v.Rodada}) Votante: {pessoa.NomeFantasia} [{pessoa.Personagem}], Alvo: {pessoaAlvo.NomeFantasia} [{pessoaAlvo.Personagem}]");
		}
	}

	static void RelatorioDeVotos()
	{
		Console.WriteLine($"\n--- Relatório de Votos Prisão ---");

		var contagemDeVotosPrisao = new Dictionary<int, int>();
		foreach (var vt in votos.FindAll(vt => vt.Rodada == rodada))
		{
			var pessoa = pessoas.FirstOrDefault(p => p.Id == vt.IdPessoa);
			if (pessoa.Personagem == "Mafioso" || pessoa.Personagem == "Anjo")
			{
				continue;
			}

			if (contagemDeVotosPrisao.TryGetValue(vt.IdPessoaAlvo, out int valor))
			{
				contagemDeVotosPrisao[vt.IdPessoaAlvo] = valor + 1;
			}
			else
			{
				contagemDeVotosPrisao[vt.IdPessoaAlvo] = 1;
			}
		}

		var count = 1;
		contagemDeVotosPrisao = contagemDeVotosPrisao.OrderByDescending(cdv => cdv.Value).ToDictionary();
		foreach (var vt in contagemDeVotosPrisao)
		{
			var pessoa = pessoas.FirstOrDefault(p => p.Id == vt.Key);
			Console.WriteLine($"(Pos. {count}) {pessoa.NomeFantasia} | Votos: {vt.Value}");

			count++;
		}

		Console.WriteLine($"\n--- Relatório de Votos Sequestro ---");

		var contagemDeVotosSequestro = new Dictionary<int, int>();
		foreach (var vt in votos.FindAll(vt => vt.Rodada == rodada))
		{
			var pessoa = pessoas.FirstOrDefault(p => p.Id == vt.IdPessoa);
			if (pessoa.Personagem != "Mafioso")
			{
				continue;
			}

			if (contagemDeVotosSequestro.TryGetValue(vt.IdPessoaAlvo, out int valor))
			{
				contagemDeVotosSequestro[vt.IdPessoaAlvo] = valor + 1;
			}
			else
			{
				contagemDeVotosSequestro[vt.IdPessoaAlvo] = 1;
			}
		}

		count = 1;
		contagemDeVotosSequestro = contagemDeVotosSequestro.OrderByDescending(cdv => cdv.Value).ToDictionary();
		foreach (var vt in contagemDeVotosSequestro)
		{
			var pessoa = pessoas.FirstOrDefault(p => p.Id == vt.Key);
			Console.WriteLine($"(Pos. {count}) {pessoa.NomeFantasia} | Votos: {vt.Value}");

			count++;
		}

		Console.WriteLine($"\n--- Relatório de Votos Anjos ---");

		var contagemDeVotosAnjos = new Dictionary<int, int>();
		foreach (var vt in votos.FindAll(vt => vt.Rodada == rodada))
		{
			var pessoa = pessoas.FirstOrDefault(p => p.Id == vt.IdPessoa);
			if (pessoa.Personagem != "Anjo")
			{
				continue;
			}

			if (contagemDeVotosAnjos.TryGetValue(vt.IdPessoaAlvo, out int valor))
			{
				contagemDeVotosAnjos[vt.IdPessoaAlvo] = valor + 1;
			}
			else
			{
				contagemDeVotosAnjos[vt.IdPessoaAlvo] = 1;
			}
		}

		count = 1;
		contagemDeVotosAnjos = contagemDeVotosAnjos.OrderByDescending(cdv => cdv.Value).ToDictionary();
		foreach (var vt in contagemDeVotosAnjos)
		{
			var pessoa = pessoas.FirstOrDefault(p => p.Id == vt.Key);
			Console.WriteLine($"(Pos. {count}) {pessoa.NomeFantasia} | Votos: {vt.Value}");

			count++;
		}
	}

	static void AvancarRodada()
	{
		RelatorioDeVotos();

		Console.WriteLine($"\nVotos computados: {votos.FindAll(vt => vt.Rodada == rodada).Count}");
		Console.WriteLine($"Avançar rodada? (1) Sim ou (2) Não");
		var res = Console.ReadLine();

		if (int.Parse(res) == 1)
		{
			rodada++;
			Console.WriteLine("Rodada avançada");
		}
		else
		{
			Console.WriteLine("Cancelada");
		}
	}
}