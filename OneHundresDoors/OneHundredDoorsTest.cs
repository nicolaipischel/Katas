using FluentAssertions;

namespace Katas;

public class OneHundredDoorsTest
{
    private readonly OneHundredDoors _sut = new();

    private readonly IEnumerable<Door> _untoggledDoors = Enumerable.Range(1, 100).Select(_ => new Door());

    /*
     * 100 doors in a row are all initially closed. You make 100 passes by the doors.
     * The first time through, you visit every door and toggle the door (if the door is closed, you open it; if it is open, you close it).
     * The second time you only visit every 2nd door (door #2, #4, #6, ...).
     * The third time, every 3rd door (door #3, #6, #9, ...), etc, until you only visit the 100th door.
     * Question: What state are the doors in after the last pass? Which are open, which are closed?
     * [Source http://rosettacode.org]
     */

    // 1. Open Door
    // 2. Close Door
    // 3. Iterate through all doors
    // 4. First Visit toogle every door
    // 5. Second visit (every 2nd door)
    // 6. Third visit (every 3rd door)
    // 7. Count Open and Closed Doors

    [Fact]
    public void OpensDoor_Given_ItIsClosed()
    {
        // Arrange.
        var door = new Door();

        // Act.
        var toggledDoor = _sut.Toggle(door);

        // Assert.
        toggledDoor.IsOpen.Should().BeTrue();
    }

    [Fact]
    public void ClosesDoor_Given_ItIsOpend()
    {
        // Arrange.
        var door = new Door { IsOpen = true };

        // Act.
        var toggledDoor = _sut.Toggle(door);

        // Assert.
        toggledDoor.IsOpen.Should().BeFalse();
    }

    [Fact]
    public void TogglesEveryDoor_Given_ItsTheFirstVisit()
    {
        // Act.
        var toggledDoors = _sut.Visit(_untoggledDoors);

        // Assert.
        toggledDoors.All(d => d.IsOpen).Should().BeTrue();
    }

    [Fact]
    public void TogglesEverySecondDoor_Given_SecondVisit()
    {
        // Arrange.
        var visitCount = 2;
        var sut = new OneHundredDoors(visitCount);

        // Act.
        var doorsAfterThirdVisit = sut.Visit(_untoggledDoors);

        // Assert.
        AssertOnlyEveryNthDoorIsToggled(doorsAfterThirdVisit, visitCount, _untoggledDoors);
    }

    [Fact]
    public void TogglesEveryThirdDoor_Given_ThirdVisit()
    {
        // Arrange.
        var visitCount = 3;
        var sut = new OneHundredDoors(visitCount);

        // Act.
        var doorsAfterThirdVisit = sut.Visit(_untoggledDoors);

        // Assert.
        AssertOnlyEveryNthDoorIsToggled(doorsAfterThirdVisit, visitCount, _untoggledDoors);
    }

    [Fact]
    public void AllDoorsShouldBeOpen_Given_ThirdVisitIsFinished()
    {
        // Act.
        var doorsAfterFirstVisit = _sut.Visit(_untoggledDoors);
        var doorsAfterSecondVisit = _sut.Visit(doorsAfterFirstVisit);
        var doorsAfterThirdVisit = _sut.Visit(doorsAfterSecondVisit).ToArray();

        // Assert.
        doorsAfterThirdVisit.All(door => door.IsOpen).Should().BeTrue();
    }

    private static void AssertOnlyEveryNthDoorIsToggled(IEnumerable<Door> toggledDoors, int iterator, IEnumerable<Door> untoggledDoors)
    {
        var toggledDoorArray = toggledDoors.ToArray();
        var untoggledDoorArray = untoggledDoors.ToArray();
        for (var i = 0; i < toggledDoorArray.Length; i++)
        {
            if (i % iterator == 0)
            {
                toggledDoorArray[i].IsOpen.Should().NotBe(untoggledDoorArray[i].IsOpen);
            }
            else
            {
                toggledDoorArray[i].IsOpen.Should().Be(untoggledDoorArray[i].IsOpen);
            }
        }
    }
}

public record Door
{
    public bool IsOpen { get; init; }
}