using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "JoinLeagueEleBattleArg")]
	[Serializable]
	public class JoinLeagueEleBattleArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
