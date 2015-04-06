using System;

namespace BitMirror
{
	/// <summary>
	/// A chunk contains a portion of the data contained within a file. The data
	/// is hashed to provide change tracking.
	/// </summary>
	public class Chunk
	{
		/// <summary>
		/// Parent File
		/// </summary>
		private File mFile;

		/// <summary>
		/// Construct a chunk as a child of the given parent file
		/// </summary>
		/// <param name="file">Parent File</param>
		public Chunk( File file )
		{
			mFile = file;
		}
	}
}

