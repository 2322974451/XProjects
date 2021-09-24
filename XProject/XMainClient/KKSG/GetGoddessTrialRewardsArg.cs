using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGoddessTrialRewardsArg")]
	[Serializable]
	public class GetGoddessTrialRewardsArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
