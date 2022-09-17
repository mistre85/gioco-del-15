// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System.Xml.Linq;

int[] campo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0,15 };


//MescolaCampo(campo);

while (!vittoria(campo)){

    StampaCampo(campo);

    int numeroDaSpostare = Convert.ToInt32(Console.ReadLine());

    if (!SpostaNumero(campo, numeroDaSpostare))
    {
        Console.WriteLine("Non si può spostare il numero selezionato!");
    }

};









bool SpostaNumero(int[]campo ,int numeroDaSpostare) { 

    int numeroTrovato = 0;
    bool spostabile = false;
    //devo cercare il numero ma come se fosse una griglia
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            numeroTrovato = LeggiArray(i, j, campo);

            if(numeroTrovato == numeroDaSpostare)
            {
                int numeroSopra = LeggiArray(i - 1, j, campo);
                int numeroSotto = LeggiArray(i +1, j, campo);
                int numeroDestra = LeggiArray(i, j+1, campo);
                int numeroSinistra = LeggiArray(i , j-1, campo);

                if(numeroSopra == 0)
                {
                    ScriviArray(i - 1, j, campo, numeroTrovato);
                    spostabile = true;
                }
                else
                if(numeroSotto == 0)
                {
                    ScriviArray(i + 1, j, campo, numeroTrovato);
                    spostabile = true;
                }
                else
                if(numeroDestra == 0)
                {
                    ScriviArray(i , j+1, campo, numeroTrovato);
                    spostabile = true;
                }
                else
                if (numeroSinistra == 0)
                {
                    ScriviArray(i, j - 1, campo, numeroTrovato);
                    spostabile = true;
                }

                if (spostabile)
                {
                    ScriviArray(i, j, campo, 0);
                    return true;
                }
            }

        }

       
    }

    return spostabile;
}

bool vittoria(int[] campo)
{

    int minore = 0;

    for(int i = 0; i < campo.Length-1; i++)
    {
        if(minore > campo[i])
        {
            return false;
        }
        else
        {
            minore = campo[i];
        }
    }

    return true;
}

void MescolaCampo(int[] campo)
{

    int mescolaPer = new Random().Next(100, 10000);

    for (int i = 0; i < mescolaPer; i++)
    {
        int pos1 = new Random().Next(0, campo.Length);
        int pos2 = new Random().Next(0, campo.Length);

        int temp = campo[pos1];
        campo[pos1] = campo[pos2];
        campo[pos2] = temp;
    }
}

int IndiceArray(int rigaV, int colonnaV, int[] array)
{
    int colonna = colonnaV % 4;
    int riga = rigaV * 4;

    int posizione = colonna + riga;

    return posizione;
}
int LeggiArray(int rigaV, int colonnaV, int[] array)
{
    if (rigaV < 0 || rigaV>=4 || colonnaV<0|| colonnaV>4)
    {
        return -1;
    }

    return array[IndiceArray(rigaV,colonnaV,array)];
}

void ScriviArray(int rigaV, int colonnaV, int[] array,int valore)
{
    if (rigaV < 0 || rigaV >= 4 || colonnaV < 0 || colonnaV > 4)
    {
        return;
    }

    array[IndiceArray(rigaV, colonnaV, array)] = valore;
}


void StampaCampo(int[] campo)
{
    Console.WriteLine();
    for (int i = 0; i < 4; i++)
    {
        Console.WriteLine();
        for (int j = 0; j < 4; j++)
        {
            int elemento = LeggiArray(i, j, campo);
            Console.Write("\t{0}", elemento);
        }

        Console.WriteLine();

    }
    Console.WriteLine();
}
