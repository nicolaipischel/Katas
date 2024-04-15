using FluentAssertions;

namespace Katas.AbcProblemKata;

public sealed class AbcProblemTests
{
    /*
     * You are given a collection of ABC blocks (maybe like the ones you had when you were a kid).
     * There are twenty blocks with two letters on each block.
     * A complete alphabet is guaranteed amongst all sides of the blocks.

     The sample collection of blocks:

      (B O)
      (X K)
      (D Q)
      (C P)
      (N A)
      (G T)
      (R E)
      (T G)
      (Q D)
      (F S)
      (J W)
      (H U)
      (V I)
      (A N)
      (O B)
      (E R)
      (F S)
      (L Y)
      (P C)
      (Z M)

     Task
     Write a function that takes a string (word) and determines whether the word can be spelled with the given collection of blocks.
     The rules are simple:
     1. Once a letter on a block is used that block cannot be used again
     2. The function should be case-insensitive
     3. Show the output on this page for the following 7 words in the following

     Example

     >>> can_make_word("A")
        True
     >>> can_make_word("BARK")
        True
     >>> can_make_word("BOOK")
        False
     >>> can_make_word("TREAT")
        True
     >>> can_make_word("COMMON")
        False
     >>> can_make_word("SQUAD")
        True
     >>> can_make_word("CONFUSE")
        True
    */

    // x Check single letter word (since the whole alphabet is given) - true
    // x Check word with two repeating letters. - BOOK - false
    // x Check word with four unique lowercase letters - bark - true
    // x Check word with same letter at start and end - TREAT - true
    // x Check word with two repeating letter pairs - COMMON - false
    // x Check word with four unique uppercase letters - SQUAD - true
    // x Check word with six uppercase unique letters - CONFUSE - true

    private static List<(char first, char second)> _buildingBlocks = new()
    {
        ('B', 'O'),
        ('X', 'K'),
        ('D', 'Q'),
        ('C', 'P'),
        ('N', 'A'),
        ('G', 'T'),
        ('R', 'E'),
        ('T', 'G'),
        ('Q', 'D'),
        ('F', 'S'),
        ('J', 'W'),
        ('H', 'U'),
        ('V', 'I'),
        ('A', 'N'),
        ('O', 'B'),
        ('E', 'R'),
        ('F', 'S'),
        ('L', 'Y'),
        ('P', 'C'),
        ('Z', 'M'),
    };

    [Theory]
    [InlineData("A", true)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData("BOOK", false)]
    [InlineData("bark", true)]
    [InlineData("TREAT", true)]
    [InlineData("COMMON", false)]
    [InlineData("SQUAD", true)]
    [InlineData("CONFUSE", true)]
    public void Returns_ExpectedResult_Given_WordAndBuildingBlocks(string word, bool expectedResult)
    {
        // Act.
        var result = AbcProblem.Check(word, _buildingBlocks);

        // Assert.
        result.Should().Be(expectedResult);
    }
}