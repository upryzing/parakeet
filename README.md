# Parakeet: Upryzing's C# Server
Intended to replace the current `Parrot` server software.<br>
As of writing, nonfunctional.

## Compilation
You can compile Parakeet by running `dotnet build` and `dotnet publish` in the root of the repository. These commands will also work in each subproject.

## TODO

- [ ] Core (Parakeet.Core)
	- [ ] Accounts
		- [ ] Feature parity with Parrot, at minimum
	- [ ] Channels
		- [ ] Text
		- [ ] Voice
			- [ ] Custom livekit server
	- [ ] Config
		- [ ] Invite only
			- [ ] Single use
			- [ ] Multiple use
			- [ ] Infinite Use
	- [ ] Stoat compatibility API
	- [ ] Federation (do not do for a while)
- [ ] Bonfire2 (Parakeet.Events)
	- [ ] Reimplement in C#
- [ ] Dove (Parakeet.Proxy)
	- [ ] Reimplement in C#
- [ ] Pigeon (Parakeet.Fileserver)
	- [ ] Reimplement in C#
- [ ] Admin panel
- [ ] Misc
	- [ ] Redo self-hosting guide to mention Parakeet
	- [ ] Adapt CI and API related stuff to Parakeet