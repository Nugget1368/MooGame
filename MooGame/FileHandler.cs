namespace MooGame
{
	/* ****************************************************************************************
	 * Gör ett uinterface där Filehandlern är anpassad för flera olika spel med andra filnamn, 
	 * andra krav på Append. Andra sätt att skriva sparfilen?
	 ****************************************************************************/
	public class FileTxtHandler : IFileHandler
	{
		public void SaveResult(string savedText, string filename)
		{
			StreamWriter output = new StreamWriter(filename, append: true);
			output.WriteLine(savedText);
			output.Close();
		}

		public List<IPlayerData> showTopList(string filename)
		{
			/* FileHandler?*/
			//GetTopList
			StreamReader input = new StreamReader(filename);

			/* Läs in filen, konvertera till en Lista? */
			List<IPlayerData> results = new List<IPlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				IPlayerData playerData = new PlayerData(nameAndScore[0], Convert.ToInt32(nameAndScore[1]));
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

			/* Bryt ut? -> FileUpdate?*/
			/**********/
			input.Close();
			/**********/
			return results = SortSaveFile(results);
		}

		private List<IPlayerData> SortSaveFile(List<IPlayerData> results)
		{
			Logic logic = new Logic();
			results.Sort((p1, p2) => logic.Average(p1.GuessTotal, p1.NGames).CompareTo(logic.Average(p2.GuessTotal, p2.NGames)));
			return results;
		}
	}
}