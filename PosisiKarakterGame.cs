using System;
using System.Collections.Generic;
using System.Text;

class PosisiKarakterGame
{
    public enum State
    {
        Berdiri,
        Jongkok,
        Tengkurap,
        Terbang
    }

    private State state;

    public PosisiKarakterGame()
    {
        state = State.Berdiri;
        Console.WriteLine("State awal: Berdiri");
    }

    public void UbahState(State newState)
    {
        if (state == State.Terbang && newState == State.Jongkok)
        {
            Console.WriteLine("[posisi landing]");
        }
        else if (state == State.Berdiri && newState == State.Terbang)
        {
            Console.WriteLine("[posisi take off]");
        }

        state = newState;
        Console.WriteLine("State sekarang: " + state);
    }
}