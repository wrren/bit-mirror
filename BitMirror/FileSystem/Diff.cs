using System;

namespace BitMirror
{
	/// <summary>
	/// Class representing the difference between two versions of the same file. May
	/// also represent the full content of a newly added file, changes in attributes
	/// or a deletion event.
	/// </summary>
	public class Diff
	{
		/// <summary>
		/// File Current/Previous Path
		/// </summary>
		private string mPath;

		/// <summary>
		/// New File Path. Will only be different from <c>mPath</c> if the file
		/// was moved.
		/// </summary>
		private string mNewPath;



		public Diff()
		{
		}
	}
}

