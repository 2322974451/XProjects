using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BlackListReport")]
	[Serializable]
	public class BlackListReport : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
