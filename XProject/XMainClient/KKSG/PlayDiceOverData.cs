using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlayDiceOverData")]
	[Serializable]
	public class PlayDiceOverData : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
