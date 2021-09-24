using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PokerTournamentEndReFundMsg")]
	[Serializable]
	public class PokerTournamentEndReFundMsg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
