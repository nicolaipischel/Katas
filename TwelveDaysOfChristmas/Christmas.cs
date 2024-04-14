using System.Text;

namespace Katas.TwelveDaysOfChristmas;

public static class Christmas
{
    internal const string HEADER_LINE_TWO = "My true love gave to me:";

    internal const string FIRST = "first";
    internal const string SECOND = "second";
    internal const string THIRD = "third";
    internal const string FOURTH = "fourth";
    internal const string FIFTH = "fifth";
    internal const string SIXTH = "sixth";
    internal const string SEVENTH = "seventh";
    internal const string EIGHT = "eight";
    internal const string NINTH = "ninth";
    internal const string TENTH = "tenth";
    internal const string ELEVENTH = "eleventh";
    internal const string TWELFTH = "twelfth";

    internal const string FIRST_SPECIFIC_LINE = "A partridge in a pear tree.";
    internal const string SECOND_SPECIFIC_LINE = "Two turtle doves and";
    internal const string THIRD_SPECIFIC_LINE = "Three french hens";
    internal const string FOURTH_SPECIFIC_LINE = "Four calling birds";
    internal const string FIFTH_SPECIFIC_LINE = "Five golden rings";
    internal const string SIXTH_SPECIFIC_LINE = "Six geese a-laying";
    internal const string SEVENTH_SPECIFIC_LINE = "Seven swans a-swimming";
    internal const string EIGHT_SPECIFIC_LINE = "Eight maids a-milking";
    internal const string NINTH_SPECIFIC_LINE = "Nine ladies dancing";
    internal const string TENTH_SPECIFIC_LINE = "Ten lords a-leaping";
    internal const string ELEVENTH_SPECIFIC_LINE = "Eleven pipers piping";
    internal const string TWELFTH_SPECIFIC_LINE = "Twelve drummers drumming";

    private static readonly string[] VerseNumbers =
    {
        FIRST,
        SECOND,
        THIRD,
        FOURTH,
        FIFTH,
        SIXTH,
        SEVENTH,
        EIGHT,
        NINTH,
        TENTH,
        ELEVENTH,
        TWELFTH
    };

    private static readonly string[] VerseLines =
    {
        FIRST_SPECIFIC_LINE,
        SECOND_SPECIFIC_LINE,
        THIRD_SPECIFIC_LINE,
        FOURTH_SPECIFIC_LINE,
        FIFTH_SPECIFIC_LINE,
        SIXTH_SPECIFIC_LINE,
        SEVENTH_SPECIFIC_LINE,
        EIGHT_SPECIFIC_LINE,
        NINTH_SPECIFIC_LINE,
        TENTH_SPECIFIC_LINE,
        ELEVENTH_SPECIFIC_LINE,
        TWELFTH_SPECIFIC_LINE
    };

    public static string CreateLyrics()
    {
        var sb = new StringBuilder();
        for (int i = 1; i <= 12; i++)
        {
            sb.Append(CreateVerse(i));
            if (i < 12)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
            }
        }

        return sb.ToString();
    }

    internal static IEnumerable<string> CreateVerseHeaderLines(int number)
    {
        return number <= VerseNumbers.Length
            ? new[]
            {
                $"On the {VerseNumbers[number - 1]} day of Christmas",
                HEADER_LINE_TWO
            }
            : Enumerable.Empty<string>();
    }

    internal static IEnumerable<string> CreateVerseLines(int number)
    {
        var lines = new List<string>();
        if (number > VerseLines.Length)
        {
            return Enumerable.Empty<string>();
        }

        for (var i = 0; i < number; i++)
        {
            lines.Add(VerseLines[i]);
        }

        return lines;
    }

    public static string CreateVerse(int number)
    {
        var headerLines = CreateVerseHeaderLines(number);
        var verseLines = CreateVerseLines(number);
        var reversedVerseSpecificLines = verseLines.Reverse();

        var wholeVerseLines = headerLines.Concat(reversedVerseSpecificLines);

        return FormatLines(wholeVerseLines);
    }

    private static string FormatLines(IEnumerable<string> wholeVerseLines)
    {
        return string.Join(Environment.NewLine, wholeVerseLines);
    }
}