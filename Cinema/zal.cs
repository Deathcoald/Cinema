using System.Collections.Generic;
using System;

public class Zal
{
    public bool[,] MediumHall { get; private set; }
    public static int Rows { get; private set; }
    public static int Cols { get; private set; }

    public Zal()
    {
        Rows = 13;
        Cols = 13;
        MediumHall = new bool[Rows, Cols];
    }
    public void UpdateOccupiedSeats(List<Ticket> tickets)
    {
        Array.Clear(MediumHall, 0, MediumHall.Length);

        foreach (var ticket in tickets)
        {
            MediumHall[ticket.Row, ticket.Col] = true;
        }
    }
    public bool IsSeatOccupied(int row, int col)
    {
        return MediumHall[row, col];
    }
}
