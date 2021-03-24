using System;
using System.Collections.Generic;

namespace dioConta
{
    class Program
    {

        static List<conta> listaContas = new List<conta>();
        static void Main(string[] args)
        {
            CriarConta("ContaTeste", 1, 100, 200);

            string opcao = menu();

            while (!opcao.Equals("X"))
            {
                switch (opcao)
                {

                    case "1":
                        {
                            InserirConta();
                            break;
                        }
                    case "2":
                        {
                            ListarContas();
                            break;
                        }
                    case "3":
                        {
                            Depositar();
                            break;
                        }
                    case "4":
                        {
                            Sacar();
                            break;
                        }
                    case "5":
                        {
                            Transferir();
                            break;
                        }
                    case "C":
                        {
                            Console.Clear();
                            break;
                        }

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine();
                        break;

                }

                opcao = menu();

            }
            Console.WriteLine();
            Console.WriteLine("Obrigado por acessar DIO Bank!");
            Console.WriteLine();

            static string menu()
            {
                Console.WriteLine();
                Console.WriteLine("Bem vindo ao DIO Bank!");
                Console.WriteLine();
                Console.WriteLine("Informe a opcao desejada:");
                Console.WriteLine("[1] PARA INSERIR NOVA CONTA");
                Console.WriteLine("[2] PARA LISTAR TODAS AS CONTAS");
                Console.WriteLine("[3] PARA DEPOSITAR");
                Console.WriteLine("[4] PARA SACAR");
                Console.WriteLine("[5] PARA TRANSFERIR ENTRE CONTAS");
                Console.WriteLine("[C] PARA LIMPAR A TELA");
                Console.WriteLine("[x] PARA ENCERRAR");
                Console.WriteLine();
                string opcao = Console.ReadLine().ToUpper();
                return opcao;
            }
        }

        private static void InserirConta()
        {

            Console.Write("Digite o Nome para conta: ");
            String nome = Console.ReadLine();
            Console.Write("Digite [1] para conta Pessoa física ou [2] para conta Pessoa juridica: ");
            int tipo = int.Parse(Console.ReadLine());
            Console.Write("Digite o crédito inicial: ");
            double credito = double.Parse(Console.ReadLine());
            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());
            Console.Write("");
            CriarConta(nome, tipo, credito, saldo);
            ListarContas();

        }
        private static void Sacar()
        {

            Console.WriteLine("Realizando Saque:");
            Console.WriteLine("Digite o número da conta:");
            int conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser sacado");
            double saque = double.Parse(Console.ReadLine());
            listaContas[conta].sacar(saque);


        }

        private static void Depositar()
        {
            Console.WriteLine("Realizando Depósito:");
            Console.WriteLine("Digite o número da conta:");
            int conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser depositado");
            double deposito = double.Parse(Console.ReadLine());
            listaContas[conta].depositar(deposito);


        }
        private static void Transferir()
        {
            Console.WriteLine("Realizando Transferência:");
            Console.WriteLine("Digite o número da conta de origem:");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número da conta de destino:");
            int contadestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser transferido");
            double transfere = double.Parse(Console.ReadLine());
            listaContas[contaOrigem].transferir(transfere, listaContas[contadestino]);

        }

        private static void CriarConta(string nome, int tipo, double credito, double saldo)
        {
            conta novaConta = new conta(Nome: nome, tipoConta: (tipoContas)tipo, Saldo: saldo, Credito: credito);
            listaContas.Add(novaConta);
        }
        private static void ListarContas()
        {

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            Console.WriteLine("Listando as contas existentes:");

            for (int i = 0; i < listaContas.Count; i++)
            {
                Console.WriteLine("Conta:{0} {1}", i, listaContas[i].ToString());
            }

        }

    }
}
