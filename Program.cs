using System;
using System.Collections.Generic;

namespace GerenciamentoFuncionarios
{
    class Program
    {
        static List<Funcionario> listaFuncionarios = new List<Funcionario>();
        static int id = 0;
        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("=== Sistema de Gerenciamento de Funcionários ===");
                Console.WriteLine("1 - Adicionar funcionário");
                Console.WriteLine("2 - Listar funcionários");
                Console.WriteLine("3 - Editar funcionário ");
                Console.WriteLine("4 - Deletar funcionário");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        AdicionarFuncionario();
                        break;
                    case "2":
                        Console.Clear();
                        ListarFuncionarios();
                        break;
                    case "3":
                        Console.Clear();
                        EditarFuncionario();
                        break;
                    case "4":
                        Console.Clear();
                        DeletarFuncionario();
                        break;
                    case "0":
                        Console.Clear();
                        sair = true;
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AdicionarFuncionario()
        {
            Console.WriteLine("=== Adicionar funcionário ===");
            Console.Write("Nome: ");
            string? nome = Console.ReadLine();
            Console.Write("Cargo: ");
            string? cargo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cargo))
            {
                Console.WriteLine("=== Informações Inválidas ===");
                return;
            }

            if (listaFuncionarios.Count != 0)
            {
                id = listaFuncionarios.Last().Id + 1;
            }

            Funcionario novoFuncionario = new Funcionario(nome.ToUpper(), cargo.ToUpper(), id);
            listaFuncionarios.Add(novoFuncionario);

            Console.WriteLine("Funcionário adicionado com sucesso!");
        }

        static void ListarFuncionarios()
        {
            Console.WriteLine("\n=== Lista de Funcionários ===");

            if (listaFuncionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
            }
            else
            {
                foreach (var funcionario in listaFuncionarios)
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine($"Id: {funcionario.Id}\nNome: {funcionario.Nome}\nCargo: {funcionario.Cargo}\n");
                }
            }
        }

        static void EditarFuncionario(){
            
            int index = BuscarFuncionario();

            if(index == -1){
                return;
            }   

            Console.WriteLine("Caso nada seja preenchido o dado não será alterado!\n");

            Console.WriteLine($"Nome antigo: {listaFuncionarios[index].Nome}");
            Console.Write("Nome novo: ");
            string? nome = Console.ReadLine();
            Console.WriteLine($"Cargo antigo: {listaFuncionarios[index].Cargo}");
            Console.Write("Cargo novo: ");
            string? cargo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome)) nome = listaFuncionarios[index].Nome;
            if (string.IsNullOrWhiteSpace(cargo)) cargo = listaFuncionarios[index].Cargo;

            listaFuncionarios[index].Nome = nome.ToUpper();
            listaFuncionarios[index].Cargo = cargo.ToUpper();

        }

        static void DeletarFuncionario(){

            int index = BuscarFuncionario();

            if(index != -1){
                listaFuncionarios.RemoveAt(index);
                Console.WriteLine("Funcionário deletado com sucesso");
            }

        }

        static int BuscarFuncionario(){

            if (listaFuncionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return -1;
            }

            ListarFuncionarios();

            Console.WriteLine("=== Informe o Id ===");
            int intId;
            bool idSelecionado = int.TryParse(Console.ReadLine(), out intId);
            
            if(!idSelecionado){
                Console.WriteLine("Id inválido");
                return -1;
            }

            return listaFuncionarios.FindIndex(funcionario => funcionario.Id == intId);

        }

    }

    class Funcionario
    {
        public int Id {get; set;}
        public string Nome { get; set; }
        public string Cargo { get; set; }

        public Funcionario(string nome, string cargo, int id)
        {
            Id = id; 
            Nome = nome;
            Cargo = cargo;
        }
    }
}
