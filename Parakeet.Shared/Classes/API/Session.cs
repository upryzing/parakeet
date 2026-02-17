namespace Parakeet.Shared.Classes.API;

/**
<summary>
Session for Parakeet instances.

CONSIDER: permissions for a given session? Could be good for apps you don't trust.
</summary>
*/
public class Session(String sessionID, String sessionName, Ulid sessionUlid) {
	public readonly String ID = sessionID;

	public readonly String Name = sessionName;

	public readonly Ulid AssociatedUlid = sessionUlid;
}