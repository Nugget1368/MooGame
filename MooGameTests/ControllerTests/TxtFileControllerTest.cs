using MooGame.Player;
using MooGameTests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTests.ControllerTests
{
	[TestClass]
	public class TxtFileControllerTest
	{
		MockFileSave mockFile = new MockFileSave(new MooPlayer("Bowser", 5), "TestResults.txt");
		List<IPlayer> mockList = new List<IPlayer>();
		[TestMethod]
		public void GetSinglePlayer()
		{
			StreamReader input = new StreamReader(mockFile.FileName);
			int id = 0;

			List<IPlayer> results = new List<IPlayer>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				IPlayer playerData = new MooPlayer(nameAndScore[0], Convert.ToInt32(nameAndScore[1]));
				int pos = results.IndexOf(playerData);
				if (pos < 0)
				{
					results.Add(playerData);
				}
				else
				{
					results[pos].Update(playerData.NumOfGuesses);
				}
			}
			//return results[id];
			//Top 3 på MockListan
			Assert.AreEqual("Lisa", results[id].Name);
			Assert.AreEqual("Link", results[1].Name);
			Assert.AreEqual("Carro", results[2].Name);
		}
	}
}
