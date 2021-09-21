using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000112 RID: 274
	[ProtoContract(Name = "GetAchieveBrifInfoReq")]
	[Serializable]
	public class GetAchieveBrifInfoReq : IExtensible
	{
		// Token: 0x06001149 RID: 4425 RVA: 0x000234B4 File Offset: 0x000216B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000453 RID: 1107
		private IExtension extensionObject;
	}
}
