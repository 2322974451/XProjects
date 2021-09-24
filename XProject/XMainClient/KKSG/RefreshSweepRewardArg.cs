using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RefreshSweepRewardArg")]
	[Serializable]
	public class RefreshSweepRewardArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
