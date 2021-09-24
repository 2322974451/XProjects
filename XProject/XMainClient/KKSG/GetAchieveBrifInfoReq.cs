using System;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetAchieveBrifInfoReq")]
	[Serializable]
	public class GetAchieveBrifInfoReq : IExtensible
	{

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IExtension extensionObject;
	}
}
