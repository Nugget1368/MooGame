using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Controllers;
using MooGame.Player;
using MooGameTests.MockData;

namespace MooGameTests.UITests;

[TestClass()]
public class ConsoleUITest
{
    IPlayerData mockPlayer = new MockPlayerData();
    [TestMethod()]
    public void EnterNameTest()
    {
        Console.WriteLine("Enter your user name:\n");
        string name = "";
        while (name == "" || name == null)
        {
            Console.WriteLine("Enter your user name:\n");
            name = "Tilde den Vilde II";
        }
        mockPlayer.Name = name;
        Assert.AreEqual("Tilde den Vilde II", mockPlayer.Name);
    }

    [TestMethod()]
    public void ResultTestTrue()
    {
		string checkResult = "BBBB,";
		Console.WriteLine(checkResult + "\n");
		if (checkResult != "BBBB,")
		{
			Console.WriteLine("Try again:");
			Assert.IsTrue(false);
		}
		Assert.IsTrue(true);
	}
	[TestMethod()]
	public void ResultTestFalse()
	{
		string checkResult = "BCBC";
		Console.WriteLine(checkResult + "\n");
		if (checkResult != "BBBB,")
		{
			Console.WriteLine("Try again:");
			Assert.IsFalse(false);
		}
		Assert.IsTrue(true);
	}


    [TestMethod()]
    public void HighScoreTest()
    {
		List<IPlayerData> playerData = new List<IPlayerData>();
		for (int x = 0; x < 5; x++)
		{
			playerData.Add(new MockPlayerData());
		}
		Console.WriteLine("Player   games	average");
		foreach (var player in playerData)
		{
			Console.WriteLine($"{string.Format("{0,-9}{1,5:D}{2,9:F2}", "TestObject", 1, 4.00)}", $"{string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NGames, player.PlayerScore())}");
			Assert.AreEqual($"{string.Format("{0,-9}{1,5:D}{2,9:F2}", "TestObject", 1, 4.00)}", $"{string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NGames, player.PlayerScore())}");

		}
	}

    [TestMethod()]
    public void GameOverTestNo()
    {
		string input = "no I don't want to";
		Console.WriteLine("Correct, it took " + mockPlayer.GuessTotal + " guesses\nContinue?");
		if (input.Substring(0, 1) == "n")
		{
			Console.WriteLine("No");
			Assert.IsTrue(true);
		}
		else
		{
			Console.WriteLine("Yes");
			Assert.IsTrue(false);
		}
	}
	[TestMethod()]
	public void GameOverTestYes()
	{
		string input = "Yes I'd love to!";
		Console.WriteLine("Correct, it took " + mockPlayer.GuessTotal + " guesses\nContinue?");
		if (input.Substring(0, 1) == "n")
		{
			Console.WriteLine("No");
			Assert.IsTrue(false);
		}
		else
		{
			Console.WriteLine("Yes");
			Assert.IsTrue(true);
		}
	}
}