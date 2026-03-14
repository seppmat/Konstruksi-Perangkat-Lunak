using System;

class DoorMachine
{
    enum State
    {
        Terkunci,
        Terbuka
    }

    private State stateSaatIni;

    public DoorMachine()
    {
        stateSaatIni = State.Terkunci;
        Console.WriteLine("Pintu terkunci");
    }

    public void Buka()
    {
        if (stateSaatIni == State.Terkunci)
        {
            stateSaatIni = State.Terbuka;
            Console.WriteLine("Pintu terbuka");
        }
        else
        {
            Console.WriteLine("Pintu sudah terbuka");
        }
    }

    public void Kunci()
    {
        if (stateSaatIni == State.Terbuka)
        {
            stateSaatIni = State.Terkunci;
            Console.WriteLine("Pintu terkunci");
        }
        else
        {
            Console.WriteLine("Pintu sudah terkunci");
        }
    }
}