using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "applyguildarenaarg")]
	[Serializable]
	public class applyguildarenaarg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
