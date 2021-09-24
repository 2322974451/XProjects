using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DailyTaskGiveUpArg")]
	[Serializable]
	public class DailyTaskGiveUpArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
