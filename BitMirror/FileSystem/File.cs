using System;
using System.Collections.Generic;
using System.IO;

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
		public List<Chunk> Scan()
		{
			FileStream stream = System.IO.File.OpenRead( mPath );
			
			long offset = 0;

			List<Chunk> changes = new List<Chunk>();

			foreach( Chunk chunk in mChunks )
			{
				if( chunk.GenerateSignature( stream ) == false )
				{
					changes.Add( chunk );
				}

				offset += chunk.Length;
			}
			
			return changes;
		}

		/// <summary>
		/// Apply the given file diff to this file. This may result in the file being moved
		/// to a new location, in which case the returned string will reflect this.
		/// </summary>
		/// <param name="diff">File difference to be applied to this file</param>
		/// <returns>New file path or null if the file was deleted</returns>
		public string Apply( Diff diff )
		{
			return null;
		}
	}
}

