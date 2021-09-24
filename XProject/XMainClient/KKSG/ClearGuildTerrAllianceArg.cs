using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClearGuildTerrAllianceArg")]
	[Serializable]
	public class ClearGuildTerrAllianceArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
