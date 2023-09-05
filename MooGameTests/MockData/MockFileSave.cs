using MooGame.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTests.MockData
{
	internal class MockFileSave
	{
		public string FileName { get; set; }
		public string SavedText { get; set; }

		public MockFileSave(IPlayer mockPlayer, string filename)
		{
			this.FileName = filename;
			SavedText = mockPlayer.Name + "#&#" + mockPlayer.NumOfGuesses;
		}
		[TestMethod]
		public List<IPlayer> MockSave()
		{
			List<IPlayer> mockPlayers = new List<IPlayer>();
			List<string> names = new List<string> { "Lisa", "Link", "Carro", "Harry Potter", "Nugget", "Johnny Bravo" };
			for (int x = 0; x < names.Count; x++)
			{
				mockPlayers.Add(new MockPlayerData(names[x], x + 2));
			}
			for(int x = 0; x < mockPlayers.Count; x++)
			{
				Assert.AreEqual(names[x], mockPlayers[x].Name);
			}
			return mockPlayers;
		}
	}
}
