using MooGame.Extenstions;
using MooGameTests.MockData;


namespace MooGame.Player.Tests
{
    [TestClass()]
	public class PlayerDataTest
	{
		IPlayerData playerData = new MockPlayerData();
		
		[TestMethod()]
		public void SetNameTest()
		{
			playerData.Name = "Super Mario";
			Assert.AreEqual("Super Mario", playerData.Name);
		}

		[TestMethod()]
		public void SetGuessTest()
		{
			playerData.SetGuess("1234");
			Assert.AreEqual("1234", playerData.Guess);
			Assert.AreEqual(5, playerData.GuessTotal);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Assert.AreEqual(4, playerData.GuessTotal);
			playerData.Update(1);
			Assert.AreEqual(5, playerData.GuessTotal);
			Assert.AreEqual(2, playerData.NGames);
		}

		[TestMethod()]
		public void PlayerScoreTest()
		{
			playerData.Update(2);
			Assert.AreEqual(3, playerData.PlayerScore());
		}
	}
}