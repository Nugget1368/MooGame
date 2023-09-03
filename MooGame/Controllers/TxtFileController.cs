using MooGame.Player;

namespace MooGame.Controllers;
public class TxtFileController : IFileController
{
	public IPlayerData GetSinglePlayer(StreamReader input, int id)
	{
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
		return results[id];
	}
	public List<IPlayerData> GetAllPlayers(StreamReader input)
    {
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
        return results;
    }

	public void SavePlayer(string savedText, string filename)
	{
		StreamWriter output = new StreamWriter(filename, append: true);
		output.WriteLine(savedText);
		output.Close();
	}
}
