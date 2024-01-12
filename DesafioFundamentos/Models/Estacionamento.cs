// Uso de Regular Expressions para validar o formato de entrada da placa dos veiculos
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models

{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            // Pede para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            // Uso da Função toUpper para armazenar as placas comm letras maiusculas, melhorando a apresentação do programa e futuras comparações entre strings
            string placa = Console.ReadLine().ToUpper();

            // Validação com RegExp para certificação de que uma placa de veiculo está sendo inserida no formato adequado
            if (Regex.Match(placa, "^[A-z]{3}[0 -9]{1}[A -z]{1}[0 -9]{2}$").Success)
            {
                veiculos.Add(placa);
                Console.WriteLine($"\nO veículo {placa} foi cadastrado com sucesso.");

            }
            else
            {
                Console.WriteLine("Digite um formato de placa válido, Exemplo: AAA9999 ou AAA9A99.");
            }

        }

        public void RemoverVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pede para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine().ToUpper();

            if (Regex.Match(placa, "^[A-z]{3}[0 -9]{1}[A -z]{1}[0 -9]{2}$").Success)
            {

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.Equals(placa)))
                {
                    Console.WriteLine("\nDigite a quantidade de horas que o veículo permaneceu estacionado:");

                    // Pede para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado e realiza o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    int horas = int.Parse(Console.ReadLine());
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    // Remove a placa digitada da lista de veículos
                    veiculos.Remove(placa);


                    Console.WriteLine($"\nO veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}.");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else
            {
                Console.WriteLine("Digite um formato de placa válido, Exemplo: AAA9999 ou AAA9A99.");
            }

        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Realiza um laço de repetição, exibindo os veículos estacionados
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
