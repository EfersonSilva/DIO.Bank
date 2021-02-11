using System;
using System.Collections.Generic;
using System.Text;
using DIO.Bank.Enum;

namespace DIO.Bank.Class
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
            TipoConta = tipoConta;
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            Saldo -= valorSaque;
            Console.WriteLine($"Saldo Atual da conta {Nome} é: {Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            Console.WriteLine($"Saldo Atual da conta {Nome} é: {Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return $"TipoConta: {TipoConta} \n" +
                $" Nome: {Nome} \n" +
                $" Saldo: {Saldo} \n" +
                $" Credito: {Credito}";
        }
    }
}
