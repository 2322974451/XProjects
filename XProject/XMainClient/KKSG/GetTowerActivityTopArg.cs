using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetTowerActivityTopArg")]
	[Serializable]
	public class GetTowerActivityTopArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
