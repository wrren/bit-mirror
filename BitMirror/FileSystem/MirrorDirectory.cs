using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitMirror
{
	/// <summary>
	/// Defines a directory that is mirrored on one or more remote devices.
	/// </summary>
	public class MirrorDirectory
	{
		/// <summary>
		/// Get the path that this mirror directory is monitoring and mirroring
		/// </summary>
		/// <value>The path monitored and mirrored by the MirrorDirectory</value>
		public string Path 
		{
			get { return mWatcher.Path; }
		}

		/// <summary>
		/// Monitored Files
		/// </summary>
		private Dictionary<string, File> mFiles;

		/// <summary>
		/// File System Watcher. Monitors the mirror directory for
		/// file changes.
		/// </summary>
		private FileSystemWatcher mWatcher;

		/// <summary>
		/// Enable, disable or check the status of the mirror directory
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		public bool Enabled
		{
			get { return mWatcher.EnableRaisingEvents; }
			set 
			{
				mWatcher.EnableRaisingEvents = value;
			}
		}

		/// <summary>
		/// Construct a mirror directory at the specified path
		/// </summary>
		public MirrorDirectory( string path )
		{
			mWatcher 		= new FileSystemWatcher( path );

			mWatcher.Changed 	+= new FileSystemEventHandler( OnFileChanged );
			mWatcher.Renamed 	+= new RenamedEventHandler( OnFileMoved );
			mWatcher.Deleted 	+= new FileSystemEventHandler( OnFileDeleted );
		}

		/// <summary>
		/// Perform a full scan of the mirror directory. Unlike actively monitoring for changes, this
		/// process will evaluate all files and their contents, generating diffs as appropriate. Call
		/// this function after enabling a mirror directory if there is reason to believe that the
		/// file system was changes while the mirror directory was disabled.
		/// </summary>
		public void FullScan()
		{
			FullScan( Path, mFiles );
		}

		/// <summary>
		/// Given a target path and a dictionary of paths to File objects, recursively traverse the file
		/// system starting at <c>path</c> and update File entries in the given dictionary. If new files
		/// are encountered, new File objects will be constructed and added to the files dictionary.
		/// </summary>
		/// <param name="path">Path to scan</param>
		/// <param name="files">Dictionary of paths to scanned File objects</param>
		public static void FullScan( string path, Dictionary<string, File> files )
		{
			var fileList 		= Directory.GetFiles( path );
			var directoryList 	= Directory.GetDirectories( path );

			Task[] tasks = new Task[directoryList.Length];

			for( int i = 0; i < directoryList.Length; i++ ) 
			{
				tasks[i] = new Task( () => FullScan( directoryList[i], files ) );
			}

			foreach( string file in fileList )
			{
				if( !files.ContainsKey( file ) ) 
				{
					files[file] = new File( file );
				}

				files[file].Scan();
			}

			Task.WaitAll( tasks );
		}

		private void OnFileChanged( object src, FileSystemEventArgs e )
		{

		}

		private void OnFileMoved( object src, RenamedEventArgs e )
		{

		}

		private void OnFileDeleted( object src, FileSystemEventArgs e )
		{

		}

		private void OnFileCreated( object src, FileSystemEventArgs e )
		{

		}
	}
}

