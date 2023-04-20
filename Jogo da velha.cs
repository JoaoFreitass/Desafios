using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] tabuleiro = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = ' ';
                }
            }

            while (true)
            {
                Console.WriteLine("\nJOGO DA VELHA:");
                Console.WriteLine(" ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("  ");
                    for (int j = 0; j < 3; j++)
                    {
                        if ((i == 0 && j == 2) || (i == 1 && j == 2) || (i == 2 && j == 2))
                        {
                            Console.Write(tabuleiro[i, j] + "  ");
                        }
                        else
                        {
                            Console.Write(tabuleiro[i, j] + " | ");
                        }

                    }
                    if (i == 0 || i == 1)
                        Console.WriteLine("\n-------------");
                    else
                    {
                        Console.WriteLine();
                    }
                }


                Console.Write("\n \nInforme qual a linha que deseja selecionar (0 a 2):\n");
                int linha = int.Parse(Console.ReadLine());
                Console.Write("Informe qual a coluna que deseja selecionar (0 a 2):\n");
                int coluna = int.Parse(Console.ReadLine());


                if (tabuleiro[linha, coluna] != ' ')
                {
                    Console.WriteLine("\n A posição já está preenchida, selecione outra!");
                    continue;
                }

                Console.Write("Vez de qual jogador?: X ou O \n");
                char jogador = char.Parse(Console.ReadLine());
                char resultado = res(jogador, tabuleiro, linha, coluna);
                if (resultado != 'A')
                {
                    if (resultado == 'E')

                    {
                        Console.WriteLine($"Empate");
                        Console.WriteLine();
                        break;

                    }
                    else
                    {
                        Console.WriteLine($"Jogador {jogador} ganhou");
                        Console.WriteLine();

                        break;
                    }
                }
            }

            Console.Write("Deseja executar o jogo novamente? (S/N): ");
            string resp = Console.ReadLine();
            if (resp.ToUpper() == "S")
            {
                Main(args);
            }











            static char res(char jogador, char[,] tabuleiro, int linha, int coluna)
            {

                tabuleiro[linha, coluna] = jogador;

                if ((tabuleiro[0, 0] == jogador && tabuleiro[0, 1] == jogador && tabuleiro[0, 2] == jogador) ||      // primeira linha
                               (tabuleiro[1, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[1, 2] == jogador) ||      // segunda linha
                               (tabuleiro[2, 0] == jogador && tabuleiro[2, 1] == jogador && tabuleiro[2, 2] == jogador) ||      // terceira linha
                               (tabuleiro[0, 0] == jogador && tabuleiro[1, 0] == jogador && tabuleiro[2, 0] == jogador) ||      // primeira coluna
                               (tabuleiro[0, 1] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 1] == jogador) ||      // segunda coluna
                               (tabuleiro[0, 2] == jogador && tabuleiro[1, 2] == jogador && tabuleiro[2, 2] == jogador) ||      // terceira coluna
                               (tabuleiro[0, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 2] == jogador) ||      // diagonla principal
                               (tabuleiro[0, 2] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 0] == jogador))        // diagonal secundária
                {

                    return jogador;

                }
                else if (!Espaco(tabuleiro))
                {
                    return 'E';
                }
                else
                {
                    return 'A';
                }
            }

            static bool Espaco(char[,] tabuleiro)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabuleiro[i, j] == ' ')
                        {
                            return true;
                        }
                    }
                }
                return false;
            }


        }

    }
}