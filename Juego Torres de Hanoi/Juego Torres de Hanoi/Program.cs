using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    private Stack<int>[] torres;
    private int numDiscos;

    public TorresDeHanoi(int n)
    {
        numDiscos = n;
        torres = new Stack<int>[3];
        for (int i = 0; i < 3; i++)
            torres[i] = new Stack<int>();

        for (int i = n; i >= 1; i--)
            torres[0].Push(i);
    }

    public void Resolver()
    {
        MostrarTorres();
        MoverDiscos(numDiscos, 0, 2, 1);
    }

    private void MoverDiscos(int n, int origen, int destino, int auxiliar)
    {
        if (n > 0)
        {
            MoverDiscos(n - 1, origen, auxiliar, destino);
            MoverUnDisco(origen, destino);
            MoverDiscos(n - 1, auxiliar, destino, origen);
        }
    }

    private void MoverUnDisco(int origen, int destino)
    {
        int disco = torres[origen].Pop();
        torres[destino].Push(disco);
        Console.WriteLine($"Favor de mover disco {disco} de Torre {origen + 1} a Torre {destino + 1}");
        MostrarTorres();
    }

    private void MostrarTorres()
    {
        Console.WriteLine("Estado actual de las torres:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Torre " + (i + 1) + ": ");
            foreach (var disco in torres[i])
                Console.Write(disco + " ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Favor de ingresar el número de discos: ");
        int numDiscos = int.Parse(Console.ReadLine());
        TorresDeHanoi hanoi = new TorresDeHanoi(numDiscos);
        hanoi.Resolver();
    }
}
