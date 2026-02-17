namespace Parakeet.Shared.Classes.API;

public enum FileMetatype : UInt16 {
	File,
	Text,
	Image,
	Audio
}

public class FileMetadata(FileMetatype kind, uint width = 0, uint height = 0) {
	public FileMetatype Type = kind;

	/**
	<summary>
	Width and height of a given image. Unused if Type != FileMetatype.Image
	</summary>
	*/
	public uint Width = width, Height = height;
}