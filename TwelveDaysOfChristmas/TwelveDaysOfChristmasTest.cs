using FluentAssertions;

namespace Katas.TwelveDaysOfChristmas;

public class TwelveDaysOfChristmasTest
{
    /*
     * Write the smallest program that outputs the lyrics of the Xmas carol The Twelve Days of Xmas.
     * You must reproduce the words in the correct order, but case, format, and punctuation are left to your discretion.
     */

    // x First verse header lines
    // x First verse line
    // x Second Verse header lines
    // x Second verse lines
    // x Whole first verse
    // x Whole second verse
    // x Nth verse header
    // x Nth verse specific line
    // x Whole Nth verse
    // x Whole song

    private const string FIRST_VERSE = """
                                       On the first day of Christmas
                                       My true love gave to me:
                                       A partridge in a pear tree.
                                       """;

    private const string SECOND_VERSE = """
                                        On the second day of Christmas
                                        My true love gave to me:
                                        Two turtle doves and
                                        A partridge in a pear tree.
                                        """;

    private const string THIRD_VERSE = """
                                       On the third day of Christmas
                                       My true love gave to me:
                                       Three french hens
                                       Two turtle doves and
                                       A partridge in a pear tree.
                                       """;

    private const string FOURTH_VERSE = """
                                        On the fourth day of Christmas
                                        My true love gave to me:
                                        Four calling birds
                                        Three french hens
                                        Two turtle doves and
                                        A partridge in a pear tree.
                                        """;

    private const string FIFTH_VERSE = """
                                       On the fifth day of Christmas
                                       My true love gave to me:
                                       Five golden rings
                                       Four calling birds
                                       Three french hens
                                       Two turtle doves and
                                       A partridge in a pear tree.
                                       """;

    private const string SIXTH_VERSE = """
                                        On the sixth day of Christmas
                                        My true love gave to me:
                                        Six geese a-laying
                                        Five golden rings
                                        Four calling birds
                                        Three french hens
                                        Two turtle doves and
                                        A partridge in a pear tree.
                                        """;

    private const string SEVENTH_VERSE = """
                                         On the seventh day of Christmas
                                         My true love gave to me:
                                         Seven swans a-swimming
                                         Six geese a-laying
                                         Five golden rings
                                         Four calling birds
                                         Three french hens
                                         Two turtle doves and
                                         A partridge in a pear tree.
                                         """;

    private const string EIGHT_VERSE = """
                                       On the eight day of Christmas
                                       My true love gave to me:
                                       Eight maids a-milking
                                       Seven swans a-swimming
                                       Six geese a-laying
                                       Five golden rings
                                       Four calling birds
                                       Three french hens
                                       Two turtle doves and
                                       A partridge in a pear tree.
                                       """;

    private const string NINTH_VERSE = """
                                 On the ninth day of Christmas
                                 My true love gave to me:
                                 Nine ladies dancing
                                 Eight maids a-milking
                                 Seven swans a-swimming
                                 Six geese a-laying
                                 Five golden rings
                                 Four calling birds
                                 Three french hens
                                 Two turtle doves and
                                 A partridge in a pear tree.
                                 """;

    private const string TENTH_VERSE = """
                                       On the tenth day of Christmas
                                       My true love gave to me:
                                       Ten lords a-leaping
                                       Nine ladies dancing
                                       Eight maids a-milking
                                       Seven swans a-swimming
                                       Six geese a-laying
                                       Five golden rings
                                       Four calling birds
                                       Three french hens
                                       Two turtle doves and
                                       A partridge in a pear tree.
                                       """;

    private const string ELEVENTH_VERSE = """
                                          On the eleventh day of Christmas
                                          My true love gave to me:
                                          Eleven pipers piping
                                          Ten lords a-leaping
                                          Nine ladies dancing
                                          Eight maids a-milking
                                          Seven swans a-swimming
                                          Six geese a-laying
                                          Five golden rings
                                          Four calling birds
                                          Three french hens
                                          Two turtle doves and
                                          A partridge in a pear tree.
                                          """;

    private const string TWELFTH_VERSE = """
                                         On the twelfth day of Christmas
                                         My true love gave to me:
                                         Twelve drummers drumming
                                         Eleven pipers piping
                                         Ten lords a-leaping
                                         Nine ladies dancing
                                         Eight maids a-milking
                                         Seven swans a-swimming
                                         Six geese a-laying
                                         Five golden rings
                                         Four calling birds
                                         Three french hens
                                         Two turtle doves and
                                         A partridge in a pear tree.
                                         """;

    [Theory]
    [InlineData(1, Christmas.FIRST)]
    [InlineData(2, Christmas.SECOND)]
    [InlineData(3, Christmas.THIRD)]
    [InlineData(4, Christmas.FOURTH)]
    [InlineData(5, Christmas.FIFTH)]
    [InlineData(6, Christmas.SIXTH)]
    [InlineData(7, Christmas.SEVENTH)]
    [InlineData(8, Christmas.EIGHT)]
    [InlineData(9, Christmas.NINTH)]
    [InlineData(10, Christmas.TENTH)]
    [InlineData(11, Christmas.ELEVENTH)]
    [InlineData(12, Christmas.TWELFTH)]
    public void Returns_NthVerseHeaderLines_Given_NthVerseNumber( int verseNumber, string numberString)
    {
        // Arrange
        var expected = new[] { $"On the {numberString} day of Christmas", Christmas.HEADER_LINE_TWO };

        // Act.
        var actual = Christmas.CreateVerseHeaderLines(verseNumber);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(1, new[] { Christmas.FIRST_SPECIFIC_LINE })]
    [InlineData(2, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE })]
    [InlineData(3, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE})]
    [InlineData(4, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE})]
    [InlineData(5, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE})]
    [InlineData(6, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE, Christmas.SIXTH_SPECIFIC_LINE})]
    [InlineData(7, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE, Christmas.SIXTH_SPECIFIC_LINE, Christmas.SEVENTH_SPECIFIC_LINE})]
    [InlineData(8, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE, Christmas.SIXTH_SPECIFIC_LINE, Christmas.SEVENTH_SPECIFIC_LINE, Christmas.EIGHT_SPECIFIC_LINE})]
    [InlineData(9, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE, Christmas.SIXTH_SPECIFIC_LINE, Christmas.SEVENTH_SPECIFIC_LINE, Christmas.EIGHT_SPECIFIC_LINE, Christmas.NINTH_SPECIFIC_LINE})]
    [InlineData(10, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE, Christmas.SIXTH_SPECIFIC_LINE, Christmas.SEVENTH_SPECIFIC_LINE, Christmas.EIGHT_SPECIFIC_LINE, Christmas.NINTH_SPECIFIC_LINE, Christmas.TENTH_SPECIFIC_LINE})]
    [InlineData(11, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE, Christmas.SIXTH_SPECIFIC_LINE, Christmas.SEVENTH_SPECIFIC_LINE, Christmas.EIGHT_SPECIFIC_LINE, Christmas.NINTH_SPECIFIC_LINE, Christmas.TENTH_SPECIFIC_LINE, Christmas.ELEVENTH_SPECIFIC_LINE})]
    [InlineData(12, new[] { Christmas.FIRST_SPECIFIC_LINE, Christmas.SECOND_SPECIFIC_LINE , Christmas.THIRD_SPECIFIC_LINE, Christmas.FOURTH_SPECIFIC_LINE, Christmas.FIFTH_SPECIFIC_LINE, Christmas.SIXTH_SPECIFIC_LINE, Christmas.SEVENTH_SPECIFIC_LINE, Christmas.EIGHT_SPECIFIC_LINE, Christmas.NINTH_SPECIFIC_LINE, Christmas.TENTH_SPECIFIC_LINE, Christmas.ELEVENTH_SPECIFIC_LINE, Christmas.TWELFTH_SPECIFIC_LINE})]
    public void Returns_NthVerseLines_Given_NthVerseNumber(int verseNumber, IEnumerable<string> expectedVerseLines)
    {
        // Act.
        var actual = Christmas.CreateVerseLines(verseNumber);

        // Assert
        actual.Should().BeEquivalentTo(expectedVerseLines);
    }

    [Theory]
    [InlineData(1, FIRST_VERSE)]
    [InlineData(2, SECOND_VERSE)]
    [InlineData(3, THIRD_VERSE)]
    [InlineData(4, FOURTH_VERSE)]
    [InlineData(5, FIFTH_VERSE)]
    [InlineData(6, SIXTH_VERSE)]
    [InlineData(7, SEVENTH_VERSE)]
    [InlineData(8, EIGHT_VERSE)]
    [InlineData(9, NINTH_VERSE)]
    [InlineData(10, TENTH_VERSE)]
    [InlineData(11, ELEVENTH_VERSE)]
    [InlineData(12, TWELFTH_VERSE)]
    public void Returns_NthVerse_Given_NthVerseNumber(int verseNumber, string expectedVerse)
    {
        // Act.
        var verse = Christmas.CreateVerse(verseNumber);

        // Assert
        verse.Should().Be(expectedVerse);
    }

    [Fact]
    public void Returns_EmptyHeaderLines_Given_TooLargeVerseNumber()
    {
        // Act.
        var actual = Christmas.CreateVerseHeaderLines(99);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void Returns_EmptyVerseLines_Given_TooLargeVerseNumber()
    {
        // Act.
        var actual = Christmas.CreateVerseLines(99);

        // Assert
        actual.Should().BeEmpty();
    }

    [Fact]
    public void Returns_SongLyrics()
    {
        // Arrange.
        var expected = $"""
                         {FIRST_VERSE}

                         {SECOND_VERSE}

                         {THIRD_VERSE}

                         {FOURTH_VERSE}

                         {FIFTH_VERSE}

                         {SIXTH_VERSE}

                         {SEVENTH_VERSE}

                         {EIGHT_VERSE}

                         {NINTH_VERSE}

                         {TENTH_VERSE}

                         {ELEVENTH_VERSE}

                         {TWELFTH_VERSE}
                         """;

        // Act.
        var verse = Christmas.CreateLyrics();

        // Assert
        verse.Should().Be(expected);
    }
}