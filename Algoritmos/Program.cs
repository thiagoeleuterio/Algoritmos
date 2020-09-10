using System;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Programa();
        }

        private static void Programa()
        {
            Console.WriteLine();
            Console.WriteLine("Entrada:");
            Console.Write("Tamanho Disco: ");
            int nTamanhoDisco = int.Parse(Console.ReadLine());
            Console.Write("Arquivos: ");
            string sArquivos = Console.ReadLine();

            string[] arrArquivos = sArquivos.Split(',');

            int nQtdeDiscos = RetornarQtdeMinDiscos(nTamanhoDisco, arrArquivos);

            Console.WriteLine();
            Console.WriteLine($@"Saída: {nQtdeDiscos} (discos) ");
            Console.ReadKey();
        }

        private static int RetornarQtdeMinDiscos(int nTamanhoDisco, string[] arrArquivos)
        {
            List<int> maxArq = new List<int>();
            List<int> minArq = new List<int>();

            for (int i = 0; i < arrArquivos.Length; i++)
            {
                if (int.Parse(arrArquivos[i]) >= nTamanhoDisco / 2)
                {
                    maxArq.Add(int.Parse(arrArquivos[i]));
                }
                else
                {
                    minArq.Add(int.Parse(arrArquivos[i]));
                }
            }

            if (minArq.Count == 0)
            {
                return maxArq.Count();
            }

            int nDiscoQtde = 0;
            bool bUnir = false;

            for (int i = 0; i < maxArq.Count; i++)
            {
                int nMaxTamanho = maxArq[i];
                for (int j = 0; j < minArq.Count; j++)
                {
                    int nMinTamanho = minArq[j];
                    if (nMaxTamanho + nMinTamanho <= nTamanhoDisco)
                    {
                        bUnir = true;
                    }

                    if (bUnir)
                    {
                        minArq.Remove(minArq[j]);
                    }
                }

                nDiscoQtde++;
            }

            int nMinElementos = minArq.Count();

            nDiscoQtde = nDiscoQtde + nMinElementos / 2 + nMinElementos % 2;

            return nDiscoQtde;
        }
    }
}
