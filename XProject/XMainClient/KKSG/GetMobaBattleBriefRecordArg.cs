using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMobaBattleBriefRecordArg")]
	[Serializable]
	public class GetMobaBattleBriefRecordArg : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
