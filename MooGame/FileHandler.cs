namespace MooGame
{
	/* ****************************************************************************************
	 * Gör ett uinterface där Filehandlern är anpassad för flera olika spel med andra filnamn, 
	 * andra krav på Append. Andra sätt att skriva sparfilen?
	 ****************************************************************************/
	public class FileTxtHandler
	{
		public void SaveResult(string savedText, string fileName)
		{
			/*playerData.GetName() + "#&#" + playerData.GetGuessTotal()*/
			StreamWriter output = new StreamWriter(fileName, append: true);
			output.WriteLine(savedText);
			output.Close();
		}

		public void showTopList()
		{
			/* FileHandler?*/
			//GetTopList
			StreamReader input = new StreamReader("result.txt");
			
			/* Läs in filen, konvertera till en Lista? */
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				PlayerData playerData = new PlayerData();
				playerData.SetName(nameAndScore[0]);
				playerData.SetGuessTotal(Convert.ToInt32(nameAndScore[1]));
				int pos = results.IndexOf(playerData);
				if (pos < 0)
				{
					results.Add(playerData);
				}
				else
				{
					results[pos].Update(playerData.GetGuessTotal());
				}
			}

			/* Bryt ut? -> FileUpdate?*/
			SortSaveFile(results);
			/**********/
			input.Close();
			/**********/
		}

		private void SortSaveFile(List<PlayerData> results)
		{
			Logic logic = new Logic();

			results.Sort((p1, p2) => logic.Average(p1.GetGuessTotal(), p1.NGames).CompareTo(logic.Average(p2.GetGuessTotal(), p2.NGames)));
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, logic.Average(p.GetGuessTotal(), p.NGames)));
			}
		}
	}
}