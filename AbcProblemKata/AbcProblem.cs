namespace Katas.AbcProblemKata;

public static class AbcProblem
{
    public static bool Check(string word, IEnumerable<(char first, char second)> buildingBlocks)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return false;
        }

        var uppercaseWord = word.ToUpperInvariant();
        var blocksLeft = new List<(char first, char second)>(buildingBlocks);

        foreach (var letter in uppercaseWord)
        {
            var matchingBlock = GetMatchingBlock(letter, blocksLeft);
            if (NoMatchFound(matchingBlock))
            {
                return false;
            }

            blocksLeft.Remove(matchingBlock);
        }

        return true;
    }

    private static bool NoMatchFound((char first, char second) matchingBlock)
    {
        return matchingBlock is (char.MinValue,char.MinValue);
    }

    private static (char first, char second) GetMatchingBlock(char letter, IEnumerable<(char first, char second)> blocks)
    {
        return blocks.FirstOrDefault(block => block.first == letter || block.second == letter);
    }
}