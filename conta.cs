using System;

namespace dioConta
{
    public class conta
    {

        private string Nome { get; set; }
        private tipoContas tipoConta { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }


        public conta(string Nome, tipoContas tipoConta, double Credito, double Saldo)
        {

            this.Nome = Nome;
            this.tipoConta = tipoConta;
            this.Credito = Credito;
            this.Saldo = Saldo;
        }

        public void depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.Write("Saldo atual de  {0} é  {1}", this.Nome, this.Saldo);
            Console.WriteLine();
        }

        public bool sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < this.Credito * -1)
            {
                Console.Write("Saldo insuficiente.");
                Console.WriteLine();
                return false;
            }

            this.Saldo -= valorSaque;
            Console.Write("Saldo atual de  {0} é  {1}", this.Nome, this.Saldo);
            Console.WriteLine();
            return true;
        }

        public void transferir(double valorTransferencia, conta contaDestino)
        {
            if (this.sacar(valorTransferencia)) contaDestino.depositar(valorTransferencia);

        }

        public override string ToString()
        {
            string retorna = " ";
            retorna += "Nome: " + this.Nome + " | ";
            retorna += "Tipo: " + this.tipoConta + " | ";
            retorna += "Saldo: " + this.Saldo + " | ";
            retorna += "Credito: " + this.Credito;
            return retorna;
        }

    }
}