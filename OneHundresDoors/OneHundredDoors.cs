namespace Katas;

public class OneHundredDoors
{
    private int _visitCount;

    public OneHundredDoors(int visitCount = 1)
    {
        _visitCount = visitCount;
    }
    internal Door Toggle(Door door)
    {
        _visitCount++;
        return door with { IsOpen = !door.IsOpen };
    }

    private IEnumerable<Door> ToogleEveryNth(IEnumerable<Door> doors, int iterator)
    {
        var doorArray = doors.ToArray();
        _visitCount++;
        for (var i = 0; i < doorArray.Length; i++)
        {
            yield return i % iterator == 0
                ? Toggle(doorArray[i])
                : doorArray[i];
        }
    }

    public IEnumerable<Door> Visit(IEnumerable<Door> doors) =>
        ToogleEveryNth(doors, _visitCount);
}