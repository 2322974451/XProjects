using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlayDiceOverArg")]
	[Serializable]
	public class PlayDiceOverArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
