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
		/// Possible types of file differences.
		/// </summary>
		public enum Type
		{
			ContentModification,	// Content was modified
			Movement,		// File was moved
			Deletion		// File was deleted
		}

		/// <summary>
		/// File Current/Previous Path
		/// </summary>
		private string mPath;

		/// <summary>
		/// New File Path. Will only be different from <c>mPath</c> if the file
		/// was moved.
		/// </summary>
		private string mNewPath;

		/// <summary>
		/// File Diff Type
		/// </summary>
		private Type mType;

		public Diff()
		{
		}
	}
}

