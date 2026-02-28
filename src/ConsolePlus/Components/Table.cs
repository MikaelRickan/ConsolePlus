namespace ConsolePlus.Components;

public class Table
{
    private readonly List<string[]> _rows = new();
    private string[]? _headers;
    private readonly List<int> _columnWidths = new();
    private ConsoleColor _headerColor = ConsoleColor.Cyan;
    private ConsoleColor _borderColor = ConsoleColor.Gray;
    private ConsoleColor _alternateRowColor = ConsoleColor.Gray;
    private TableBorderStyle _borderStyle = TableBorderStyle.Simple;
    private bool _alternateRowColors;
    private List<ConsoleColor>? _columnColors;

    public Table() { }

    public Table AddHeader(params string[] headers)
    {
        _headers = headers;
        UpdateColumnWidths(headers);
        return this;
    }

    public Table AddRow(params string[] row)
    {
        _rows.Add(row);
        UpdateColumnWidths(row);
        return this;
    }

    public Table WithHeaderColor(ConsoleColor color)
    {
        _headerColor = color;
        return this;
    }

    public Table WithBorderColor(ConsoleColor color)
    {
        _borderColor = color;
        return this;
    }

    public Table WithAlternateRowColors(bool enable = true)
    {
        _alternateRowColors = enable;
        return this;
    }

    public Table WithAlternateRowColor(ConsoleColor color)
    {
        _alternateRowColor = color;
        return this;
    }

    public Table WithBorderStyle(TableBorderStyle style)
    {
        _borderStyle = style;
        return this;
    }

    public Table WithColumnColors(params ConsoleColor[] colors)
    {
        _columnColors = colors.ToList();
        return this;
    }

    private void UpdateColumnWidths(string[] data)
    {
        while (_columnWidths.Count < data.Length)
            _columnWidths.Add(0);

        for (int i = 0; i < data.Length; i++)
        {
            _columnWidths[i] = Math.Max(_columnWidths[i], data[i].Length);
        }
    }

    public void Render()
    {
        if (_headers == null && _rows.Count == 0)
            return;

        var borders = GetBorderCharacters();
        
        WriteBorderLine(borders.Top, borders.TopLeft, borders.TopRight, borders.TopMid, borders.Mid);

        if (_headers != null)
        {
            WriteRow(_headers, _headerColor, borders);
            WriteBorderLine(borders.Mid, borders.MidLeft, borders.MidRight, borders.MidMid, borders.Mid);
        }

        for (int i = 0; i < _rows.Count; i++)
        {
            var rowColor = _alternateRowColors && i % 2 == 1 ? _alternateRowColor : ConsoleColor.Gray;
            WriteRow(_rows[i], rowColor, borders);
        }

        WriteBorderLine(borders.Bottom, borders.BottomLeft, borders.BottomRight, borders.BottomMid, borders.Mid);
    }

    private void WriteRow(string[] row, ConsoleColor color, (string Top, string Bottom, string Mid, string TopLeft, string TopRight, string BottomLeft, string BottomRight, string MidLeft, string MidRight, string TopMid, string BottomMid, string MidMid) borders)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = _borderColor;
        Console.Write(borders.MidLeft);

        for (int i = 0; i < row.Length; i++)
        {
            var cellColor = _columnColors?.Count > i ? _columnColors[i] : color;
            Console.ForegroundColor = cellColor;
            
            var cell = row[i].PadRight(_columnWidths[i]);
            Console.Write($" {cell} ");

            Console.ForegroundColor = _borderColor;
            Console.Write(i < row.Length - 1 ? borders.MidMid : "");
        }

        Console.ForegroundColor = _borderColor;
        Console.WriteLine(borders.MidRight);
        Console.ForegroundColor = originalColor;
    }

    private void WriteBorderLine(string fill, string left, string right, string mid, string midFill)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = _borderColor;

        Console.Write(left);
        for (int i = 0; i < _columnWidths.Count; i++)
        {
            var width = _columnWidths[i] + 2;
            Console.Write(new string(fill[0], width));
            Console.Write(i < _columnWidths.Count - 1 ? mid : "");
        }
        Console.WriteLine(right);

        Console.ForegroundColor = originalColor;
    }

    private (string Top, string Bottom, string Mid, string TopLeft, string TopRight, string BottomLeft, string BottomRight, string MidLeft, string MidRight, string TopMid, string BottomMid, string MidMid) GetBorderCharacters()
    {
        return _borderStyle switch
        {
            TableBorderStyle.Simple => ("─", "─", "─", "┌", "┐", "└", "┘", "│", "│", "┬", "┴", "┼"),
            TableBorderStyle.Double => ("═", "═", "═", "╔", "╗", "╚", "╝", "║", "║", "╦", "╩", "╬"),
            TableBorderStyle.Rounded => ("─", "─", "─", "╭", "╮", "╰", "╯", "│", "│", "┬", "┴", "┼"),
            TableBorderStyle.Compact => (" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "),
            _ => ("─", "─", "─", "┌", "┐", "└", "┘", "│", "│", "┬", "┴", "┼")
        };
    }
}

public enum TableBorderStyle
{
    Simple,
    Double,
    Rounded,
    Compact
}
