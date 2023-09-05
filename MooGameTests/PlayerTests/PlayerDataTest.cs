using MooGame.Extenstions;
using MooGameTests.MockData;


namespace MooGame.Player.Tests
{
    [TestClass()]
	public class PlayerDataTest
	{
		IPlayer playerData = new MockPlayerData();
		
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
			Assert.AreEqual(5, playerData.NumOfGuesses);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Assert.AreEqual(4, playerData.NumOfGuesses);
			playerData.Update(1);
			Assert.AreEqual(5, playerData.NumOfGuesses);
			Assert.AreEqual(2, playerData.NumOfGames);
		}

		[TestMethod()]
		public void PlayerScoreTest()
		{
			playerData.Update(2);
			Assert.AreEqual(3, playerData.PlayerScore());
		}
	}
}