using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetHeroBattleWeekRewardArg")]
	[Serializable]
	public class GetHeroBattleWeekRewardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
