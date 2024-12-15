using System.Text.Json.Serialization;
using System;

public class Ticket
{
    private int row;
    private int col;

    [JsonPropertyName("FIO")]
    public string FIO { get; set; }

    [JsonPropertyName("Row")]
    public int Row 
    { 
        get { return row; }
        private set 
        { 
            if (value >= Zal.Rows)
                throw new Exception("Bad number of row");
            row = value;
        } 
    }

    [JsonPropertyName("Col")]
    public int Col
    {
        get { return col; }
        private set
        {
            if (value >= Zal.Cols)
                throw new Exception("Bad number of col");
            col = value;
        }
    }

    [JsonPropertyName("DayTime")]
    public DateTime DayTime { get; private set; }

    [JsonConstructor]
    public Ticket(DateTime dayTime, string fio, int row, int col)
    {
        FIO = fio;
        Row = row;
        Col = col;
        DayTime = dayTime;
    }

    public Ticket() { }
}
