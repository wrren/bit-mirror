using System;
using System.Collections.Generic;

namespace BitMirror
{
	/// <summary>
	/// Represents a mirrored file stored in a MirrorDirectory. A File object keeps an
	/// up-to-date digest of its contents and will re-evaluate this digest on-demand, 
	/// generating a diff for transmission to its mirrored counterparts.
	/// </summary>
	public class File
	{
		/// <summary>
		/// Path to this file
		/// </summary>
		private string mPath;

		/// <summary>
		/// File Chunks
		/// </summary>
		private List<Chunk> mChunks = new List<Chunk>();

		/// <summary>
		/// Construct a File instance that points to the file at the specified path
		/// in the file system.
		/// </summary>
		/// <param name="path">Path.</param>
		public File( string path )
		{
			mPath = path;
		}

		/// <summary>
		/// Scan the File's current contents for changes.
		/// </summary>
		public void Scan()
		{

		}
	}
}

