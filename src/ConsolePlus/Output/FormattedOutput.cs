using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using ConsolePlus.Core;

namespace ConsolePlus.Output;

public static class FormattedOutput
{
    private static readonly ConsoleColor JsonKeyColor = ConsoleColor.Blue;
    private static readonly ConsoleColor JsonStringColor = ConsoleColor.Green;
    private static readonly ConsoleColor JsonNumberColor = ConsoleColor.Yellow;
    private static readonly ConsoleColor JsonBoolColor = ConsoleColor.Magenta;
    private static readonly ConsoleColor JsonNullColor = ConsoleColor.Red;

    private static readonly ConsoleColor XmlTagColor = ConsoleColor.Blue;
    private static readonly ConsoleColor XmlAttributeColor = ConsoleColor.Yellow;
    private static readonly ConsoleColor XmlValueColor = ConsoleColor.Green;
    private static readonly ConsoleColor XmlCommentColor = ConsoleColor.DarkGray;

    public static void WriteJson(string json, bool indent = true)
    {
        try
        {
            var options = new JsonSerializerOptions 
            { 
                WriteIndented = indent 
            };
            
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            
            if (indent)
            {
                json = JsonSerializer.Serialize(element, options);
            }
            
            RenderJson(json);
        }
        catch
        {
            ColoredOutput.Error("Invalid JSON format");
        }
    }

    private static void RenderJson(string json)
    {
        var lines = json.Split('\n');
        
        foreach (var line in lines)
        {
            RenderJsonLine(line);
            Console.WriteLine();
        }
    }

    private static void RenderJsonLine(string line)
    {
        var regex = new Regex(@"^(\s*)(""?[\w]+""?)\s*:\s*(.+)$");
        var match = regex.Match(line);
        
        if (match.Success)
        {
            var indent = match.Groups[1].Value;
            var key = match.Groups[2].Value;
            var value = match.Groups[3].Value;
            
            Console.Write(indent);
            ColoredOutput.Write(key + ": ", JsonKeyColor);
            RenderJsonValue(value.TrimEnd(','));
        }
        else
        {
            RenderJsonValue(line);
        }
    }

    private static void RenderJsonValue(string value)
    {
        if (value.StartsWith("\""))
        {
            ColoredOutput.Write(value, JsonStringColor);
        }
        else if (value == "true" || value == "false")
        {
            ColoredOutput.Write(value, JsonBoolColor);
        }
        else if (value == "null")
        {
            ColoredOutput.Write(value, JsonNullColor);
        }
        else if (double.TryParse(value.TrimEnd(','), out _))
        {
            ColoredOutput.Write(value, JsonNumberColor);
        }
        else
        {
            Console.Write(value);
        }
    }

    public static void WriteXml(string xml, bool indent = true)
    {
        try
        {
            if (indent)
            {
                xml = FormatXml(xml);
            }
            
            RenderXml(xml);
        }
        catch
        {
            ColoredOutput.Error("Invalid XML format");
        }
    }

    private static string FormatXml(string xml)
    {
        return xml;
    }

    private static void RenderXml(string xml)
    {
        var lines = xml.Split('\n');
        
        foreach (var line in lines)
        {
            RenderXmlLine(line.TrimEnd());
            Console.WriteLine();
        }
    }

    private static void RenderXmlLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return;
        
        if (line.StartsWith("<!--") && line.EndsWith("-->"))
        {
            ColoredOutput.Write(line, XmlCommentColor);
            return;
        }
        
        var regex = new Regex(@"(<[^>]+>)([^<]*)");
        var matches = regex.Matches(line);
        
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                var tag = match.Groups[1].Value;
                var text = match.Groups[2].Value;
                
                RenderXmlTag(tag);
                if (!string.IsNullOrEmpty(text))
                {
                    Console.Write(text);
                }
            }
        }
        else
        {
            Console.Write(line);
        }
    }

    private static void RenderXmlTag(string tag)
    {
        if (tag.StartsWith("</"))
        {
            ColoredOutput.Write(tag, XmlTagColor);
            return;
        }
        
        var attrRegex = new Regex(@"(\S+)=(""[^""]*"")");
        var matches = attrRegex.Matches(tag);
        
        if (matches.Count == 0)
        {
            ColoredOutput.Write(tag, XmlTagColor);
            return;
        }
        
        var lastIndex = 0;
        foreach (Match match in matches)
        {
            var attrName = match.Groups[1].Value;
            var attrValue = match.Groups[2].Value;
            
            var beforeAttr = tag.Substring(lastIndex, match.Index - lastIndex);
            ColoredOutput.Write(beforeAttr, XmlTagColor);
            ColoredOutput.Write(attrName, XmlAttributeColor);
            Console.Write("=");
            ColoredOutput.Write(attrValue, XmlValueColor);
            
            lastIndex = match.Index + match.Length;
        }
        
        var remaining = tag.Substring(lastIndex);
        ColoredOutput.Write(remaining, XmlTagColor);
    }

    public static void WriteTree(string text, ConsoleColor? branchColor = null, ConsoleColor? leafColor = null)
    {
        branchColor ??= ConsoleColor.Cyan;
        leafColor ??= ConsoleColor.Gray;
        
        var lines = text.Split('\n');
        var sb = new StringBuilder();
        
        foreach (var line in lines)
        {
            var trimmed = line.TrimStart();
            var spaces = line.Length - trimmed.Length;
            
            sb.Append(new string(' ', spaces));
            
            if (trimmed.StartsWith("├──") || trimmed.StartsWith("└──") || trimmed.StartsWith("│"))
            {
                ColoredOutput.Write(trimmed.Substring(0, 2), branchColor.Value);
                if (trimmed.Length > 2)
                {
                    ColoredOutput.Write(trimmed.Substring(2), leafColor.Value);
                }
            }
            else if (trimmed.StartsWith("├──") || trimmed.StartsWith("└──"))
            {
                ColoredOutput.Write(trimmed.Substring(0, 2), branchColor.Value);
                if (trimmed.Length > 2)
                {
                    ColoredOutput.Write(trimmed.Substring(2), leafColor.Value);
                }
            }
            else
            {
                Console.Write(trimmed);
            }
            
            Console.WriteLine();
        }
    }

    private static readonly ConsoleColor MdHeadingColor = ConsoleColor.Cyan;
    private static readonly ConsoleColor MdBoldColor = ConsoleColor.White;
    private static readonly ConsoleColor MdItalicColor = ConsoleColor.Gray;
    private static readonly ConsoleColor MdCodeColor = ConsoleColor.Green;
    private static readonly ConsoleColor MdLinkColor = ConsoleColor.Blue;
    private static readonly ConsoleColor MdListColor = ConsoleColor.Yellow;
    private static readonly ConsoleColor MdBlockquoteColor = ConsoleColor.DarkGray;
    private static readonly ConsoleColor MdHrColor = ConsoleColor.DarkGray;

    public static void WriteMarkdown(string markdown)
    {
        var lines = markdown.Split('\n');
        
        foreach (var line in lines)
        {
            RenderMarkdownLine(line);
            Console.WriteLine();
        }
    }

    private static void RenderMarkdownLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine();
            return;
        }

        if (line.StartsWith("### "))
        {
            ColoredOutput.WriteLine(line.Substring(4), MdHeadingColor);
            return;
        }
        
        if (line.StartsWith("## "))
        {
            StyledOutput.Bold(line.Substring(3), MdHeadingColor);
            return;
        }
        
        if (line.StartsWith("# "))
        {
            StyledOutput.Bold(line.Substring(2), MdHeadingColor);
            return;
        }

        if (line.StartsWith("```"))
        {
            ColoredOutput.Write(line, MdCodeColor);
            return;
        }

        if (line.StartsWith("> "))
        {
            var content = line.Substring(2);
            Console.Write("│ ");
            ColoredOutput.Write(content, MdBlockquoteColor);
            return;
        }

        if (line.StartsWith("- ") || line.StartsWith("* "))
        {
            Console.Write("● ");
            RenderMarkdownInline(line.Substring(2));
            return;
        }

        if (Regex.IsMatch(line, @"^\d+\. "))
        {
            var match = Regex.Match(line, @"^(\d+\. )(.*)$");
            ColoredOutput.Write(match.Groups[1].Value, MdListColor);
            RenderMarkdownInline(match.Groups[2].Value);
            return;
        }

        if (line.Trim() == "---" || line.Trim() == "***" || line.Trim() == "___")
        {
            ColoredOutput.Write(new string('─', Console.WindowWidth - 1), MdHrColor);
            return;
        }

        RenderMarkdownInline(line);
    }

    private static void RenderMarkdownInline(string text)
    {
        var boldItalicRegex = new Regex(@"\*\*\*(.+?)\*\*\*");
        var boldRegex = new Regex(@"\*\*(.+?)\*\*");
        var italicRegex = new Regex(@"\*(.+?)\*");
        var codeRegex = new Regex(@"`([^`]+)`");
        var linkRegex = new Regex(@"\[([^\]]+)\]\(([^)]+)\)");

        var processed = text;
        var segments = new List<(int start, int length, string content, string type)>();
        
        foreach (Match match in boldItalicRegex.Matches(processed))
        {
            segments.Add((match.Index, match.Length, match.Groups[1].Value, "bolditalic"));
        }
        foreach (Match match in boldRegex.Matches(processed))
        {
            if (!segments.Any(s => s.start == match.Index))
                segments.Add((match.Index, match.Length, match.Groups[1].Value, "bold"));
        }
        foreach (Match match in italicRegex.Matches(processed))
        {
            if (!segments.Any(s => s.start == match.Index))
                segments.Add((match.Index, match.Length, match.Groups[1].Value, "italic"));
        }
        
        if (segments.Count == 0)
        {
            processed = linkRegex.Replace(processed, m => m.Groups[1].Value);
            processed = codeRegex.Replace(processed, m => m.Groups[1].Value);
            Console.Write(processed);
            return;
        }
        
        segments.Sort((a, b) => a.start.CompareTo(b.start));
        
        var lastIndex = 0;
        foreach (var seg in segments)
        {
            if (seg.start > lastIndex)
            {
                var before = processed.Substring(lastIndex, seg.start - lastIndex);
                before = linkRegex.Replace(before, m => m.Groups[1].Value);
                before = codeRegex.Replace(before, m => m.Groups[1].Value);
                Console.Write(before);
            }
            
            var content = seg.content;
            content = linkRegex.Replace(content, m => m.Groups[1].Value);
            
            switch (seg.type)
            {
                case "bolditalic":
                    Console.Write(AnsiEscapeCodes.Bold);
                    Console.Write(AnsiEscapeCodes.Italic);
                    ColoredOutput.Write(content, MdBoldColor);
                    Console.Write(AnsiEscapeCodes.ItalicOff);
                    Console.Write(AnsiEscapeCodes.BoldOff);
                    break;
                case "bold":
                    Console.Write(AnsiEscapeCodes.Bold);
                    ColoredOutput.Write(content, MdBoldColor);
                    Console.Write(AnsiEscapeCodes.BoldOff);
                    break;
                case "italic":
                    Console.Write(AnsiEscapeCodes.Italic);
                    ColoredOutput.Write(content, MdItalicColor);
                    Console.Write(AnsiEscapeCodes.ItalicOff);
                    break;
            }
            
            lastIndex = seg.start + seg.length;
        }
        
        if (lastIndex < processed.Length)
        {
            var remaining = processed.Substring(lastIndex);
            remaining = linkRegex.Replace(remaining, m => m.Groups[1].Value);
            remaining = codeRegex.Replace(remaining, m => m.Groups[1].Value);
            Console.Write(remaining);
        }
    }
}
