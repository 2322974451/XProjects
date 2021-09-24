using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskForCheckInBonusArg")]
	[Serializable]
	public class AskForCheckInBonusArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
