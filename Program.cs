using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a suíte
Suite standartd = new Suite(tipoSuite: "Standatd", capacidade: 1, valorDiaria: 30);
// Cria a suíte
Suite premium = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 40);
// Cria a suíte
Suite ultra = new Suite(tipoSuite: "Ultra", capacidade: 5, valorDiaria: 60);

List<Pessoa> hospedes = new List<Pessoa>();
int opcao = 0, numerohospedes = 0, opcaosuite;
do
{
    Console.Clear();
    Console.WriteLine("==================================================================");
    Console.WriteLine("Bem Vindo ao Hotel");
    Console.WriteLine("1 - Cadastrar Hóspede");
    Console.WriteLine("2 - Reservar Suíte");
    Console.WriteLine("3 - Listar Hóspedes");
    Console.WriteLine("0 - Sair");
     Console.WriteLine("Digite a opção desejada:");
    opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Digite o numero de hóspedes que deseja cadastrar(Capacidade Maxima 5))"); 
            try
            {
                numerohospedes = Convert.ToInt32(Console.ReadLine());
                if (numerohospedes > 5 || numerohospedes < 0)
                {
                    throw new Exception("Numero de hóspedes inválido");
                }
                else
                {
                    for(int i = 0; i < numerohospedes; i++)
                    {
                        Console.Clear();
                        Console.WriteLine($"Digite o nome do hóspede numero {i + 1}:");
                        string nome = Console.ReadLine();
                        Console.WriteLine($"Digite o sobrenome do hóspede numero {i + 1}:");
                        string sobrenome = Console.ReadLine();
                        Pessoa pessoa = new Pessoa(nome, sobrenome);
                        hospedes.Add(pessoa);
                       
                    }
                    if (numerohospedes == 1)
                    {
                        Console.WriteLine($"Cadastrado com sucesso, Suit recomendada {standartd.TipoSuite}, com a capacidade para:{numerohospedes} hóspede");
                    }
                    else if (numerohospedes == 2)
                    {
                        Console.WriteLine($"Cadastrado com sucesso, Suit recomendada  {premium.TipoSuite}, com a capacidade para: {numerohospedes} hóspedes");
                    }else
                    {
                        Console.WriteLine($"Cadastrado com sucesso, Suit recomendada {ultra.TipoSuite}, com a capacidade para: {numerohospedes} hóspedes");
                    }

                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    opcao = 2;
                }

                    
            }
            catch (System.Exception)
            {
                
                throw new Exception("Digite um número válido");
            }
       
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.WriteLine("1-Standartd    2-Premium   3-Ultra");
            Console.Write("Digite a opção para a suit desejada:");
            opcaosuite = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("==================================================================");
            Console.Write("Digite o número de dias que pretende ficar hospedado: ");
            Reserva reserva = new Reserva( Convert.ToInt32(Console.ReadLine()));
            switch (opcaosuite)
            {
                case 1:
                    reserva.CadastrarSuite(standartd);
                    break;
                case 2:
                    reserva.CadastrarSuite(premium);
                    break;
                case 3:
                    reserva.CadastrarSuite(ultra);
                    break;
                default:
                    Console.WriteLine("Opção inválida, por favor, digite novamente.");
                    break;
            }

                if (hospedes.Count == 0)
                {
                    throw new Exception("Não há hospedes cadastrados");
                }
                else
                {
                    Console.Clear();
                    reserva.CadastrarHospedes(hospedes);
                    Console.WriteLine($"Reserva da Suite {reserva.Suite.TipoSuite} realizada com sucesso. São " +
                                      $"{reserva.DiasReservados} dias, por {reserva.CalcularValorDiaria():C}");
                    Console.WriteLine("Hóspedes cadastrados:");
                    foreach (var hospede in hospedes)
                    {
                        Console.WriteLine(hospede.NomeCompleto);
                    }

                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();

                }
            break;

        case 3:
                Console.Clear();
                if (hospedes.Count == 0)
                {
                    Console.WriteLine("Não há hospedes cadastrados");
                } else
                {
                    Console.WriteLine($"{hospedes.Count} Hospede(s) cadastrado(s): ");
                    foreach (var hospede in hospedes)
                    {
                        Console.WriteLine($"{hospedes.Count} - {hospede.NomeCompleto}");
                    }
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            break;

        case 0:
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();

            break;

        default:
            Console.WriteLine("Opção inválida, por favor, digite novamente.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;

    }

} while (opcao != 0);
