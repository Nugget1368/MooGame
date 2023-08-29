﻿namespace MooGame
{
	public interface IFileHandler<T>
	{
		void SaveResult(string savedText, string filename);
		List<T> showTopList(string filename);
	}
}