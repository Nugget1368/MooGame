namespace MooGame
{
	public interface IPlayerData
	{
		string Name { get; }
		public int NGames { get; }
		bool Equals(object p);
		int GetHashCode();
	}
}