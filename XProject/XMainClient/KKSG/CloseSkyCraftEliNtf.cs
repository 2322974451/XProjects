using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CloseSkyCraftEliNtf")]
	[Serializable]
	public class CloseSkyCraftEliNtf : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
