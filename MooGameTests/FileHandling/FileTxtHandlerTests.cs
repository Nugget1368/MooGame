using MooGame.Extenstions;
using MooGame.Factories;
using MooGame.FileHandling;
using MooGame.Player;
using MooGameTests.MockData;
using System.Numerics;


namespace FileTxtHandler.Tests
{
    [TestClass()]
	public class FileTxtHandlerTests
	{
		MockFileSave saveFile = new MockFileSave(new MockPlayerData(), "TestResults.txt");
		[TestMethod()]
		public void SaveResultTest()
		{
			//Save 1 result
			StreamWriter output = new StreamWriter(saveFile.FileName, append: true);
			output.WriteLine(saveFile.SavedText);
			output.Close();
		}

		[TestMethod]
		public void SaveMockResults()
		{
			//Save some mock data to the testfile to see that everything works as it should later on
			StreamWriter output = new StreamWriter(saveFile.FileName, append: false);
			var mockList = saveFile.MockSave();
			foreach(var data in mockList)
			{
				output.WriteLine($"{data.Name}#&#{data.GuessTotal}");
			}
			Assert.AreEqual("Lisa", mockList[0].Name);
			Assert.AreEqual("Link", mockList[1].Name);
			Assert.AreEqual("Carro", mockList[2].Name);
			output.Close();
		}

		[TestMethod()]
		public void showTopListTest()
		{
			//Show Top Results
			StreamReader input = new StreamReader(saveFile.FileName);

			List<IPlayerData> results = ReadAllPlayers(input);

			input.Close();
			results = SortSaveFile(results);
			foreach (MockPlayerData playerData in results)
			{
				Console.WriteLine($"{string.Format("{0,-9}{1,5:D}{2,9:F2}", playerData.Name, playerData.NGames, playerData.PlayerScore(playerData.GuessTotal, playerData.NGames))}");
			}

			Assert.AreEqual("Lisa", results[0].Name);
			Assert.AreEqual("Link", results[1].Name);
			Assert.AreEqual("Carro", results[2].Name);
			Assert.AreEqual("TestObject", results[3].Name);
			Assert.AreEqual("Harry Potter", results[4].Name);
			Assert.AreEqual("Nugget", results[5].Name);
			Assert.AreEqual("Johnny Bravo", results[6].Name);


		}
		private List<IPlayerData> SortSaveFile(List<IPlayerData> results)
		{
			results.Sort((p1, p2) => p1.PlayerScore().CompareTo(p2.PlayerScore()));
			return results;
		}

		private List<IPlayerData> ReadAllPlayers(StreamReader input)
		{
			List<IPlayerData> results = new List<IPlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				IPlayerData playerData = new MockPlayerData(nameAndScore[0], Convert.ToInt32(nameAndScore[1]));
				int pos = results.IndexOf(playerData);
				if (pos < 0)
				{
					results.Add(playerData);
				}
				else
				{
					results[pos].Update(playerData.GuessTotal);
				}
			}
			return results;
		}
	}
}