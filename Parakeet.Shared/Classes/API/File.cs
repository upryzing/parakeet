namespace Parakeet.Shared.Classes.API;

public class File(string fileID, string fileTag, string filename, FileMetadata meta, string type, UInt64 size) {
	public readonly string ID = fileID;
	public readonly string Tag = fileTag;

	public readonly string Filename = filename;

	public readonly FileMetadata Metadata = meta;

	/// <summary> MIMETYPE IF YOU'RE A NERD (like meeeee) </summary>
	public readonly string MediaType = type;

	/**
	<summary>
	The file's size in bytes.

	Advice: use *ibibytes, not *byte, when displaying.
	</summary>
	*/
	public readonly UInt64 Size = size;
}