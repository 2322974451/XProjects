using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelSealOverExpArg")]
	[Serializable]
	public class LevelSealOverExpArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
