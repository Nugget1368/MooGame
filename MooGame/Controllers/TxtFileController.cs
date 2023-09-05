using MooGame.Player;

namespace MooGame.Controllers;
public class TxtFileController : IFileController
{
	public IPlayer GetSinglePlayer(StreamReader input, int id)
	{
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
		return results[id];
	}
	public List<IPlayer> GetAllPlayers(StreamReader input)
    {
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
        return results;
    }

	public void SavePlayer(string savedText, string filename)
	{
		StreamWriter output = new StreamWriter(filename, append: true);
		output.WriteLine(savedText);
		output.Close();
	}
}
