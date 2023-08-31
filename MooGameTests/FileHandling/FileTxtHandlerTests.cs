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
			foreach(var data in saveFile.MockSave())
			{
				output.WriteLine($"{data.Name}#&#{data.GuessTotal}");
			}
			output.Close();
		}

		[TestMethod()]
		public void showTopListTest()
		{
			//Show Top Results
			StreamReader input = new StreamReader(saveFile.FileName);

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

			input.Close();
			results = SortSaveFile(results);
			foreach (MockPlayerData playerData in results)
			{
				Console.WriteLine($"{string.Format("{0,-9}{1,5:D}{2,9:F2}", playerData.Name, playerData.NGames, playerData.PlayerScore(playerData.GuessTotal, playerData.NGames))}");		}
			}
		private List<IPlayerData> SortSaveFile(List<IPlayerData> results)
		{
			results.Sort((p1, p2) => p1.PlayerScore(p1.GuessTotal, p1.NGames).CompareTo(p2.PlayerScore(p2.GuessTotal, p2.NGames)));
			return results;
		}
	}
}