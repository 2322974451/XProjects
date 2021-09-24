using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LotteryDrawReq")]
	[Serializable]
	public class LotteryDrawReq : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
