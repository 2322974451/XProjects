using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildDonateInfoArg")]
	[Serializable]
	public class GetGuildDonateInfoArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
