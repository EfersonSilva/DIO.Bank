using System;
using System.Collections.Generic;
using DIO.Bank.Class;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

          
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;

                    case "5":
                       Depositar();
                        break;

                    case "c":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por ultilizar nossos serviços!");
            Console.WriteLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valor, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o Numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double saque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(saque);
        }

        private static void Sacar()
        {
            Console.Write("Digite o Numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double saque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(saque);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserindo uma nova conta: ");
            Console.Write("Digite 1 para conta fisica e 2 para Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da conta: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome, saldo,credito, (TipoConta)tipoConta);
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            if (listContas.Count < 0)
            {
                Console.WriteLine("Nenhuma conta foi cadastrada!");
            }
            else
            {
                foreach (var conta in listContas)
                {
                    Console.WriteLine(conta.ToString());
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine($"DIO Bank a seu dispor: \n" +
               $"Informe a Opção desejada: \n \n" +
               $"1 - Listar contas: \n" +
               $"2 - Inserir nova conta: \n" +
               $"3 - Transferir: \n" +
               $"4 - Sacar: \n" +
               $"5 - Depositar: \n" +
               $"C - Limpar: \n" +
               $"X - Sair \n");

            string opcaoUsuario = Console.ReadLine().ToUpper();

            return opcaoUsuario;
        }
    }
}
