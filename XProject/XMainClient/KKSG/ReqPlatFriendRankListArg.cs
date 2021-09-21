using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000291 RID: 657
	[ProtoContract(Name = "ReqPlatFriendRankListArg")]
	[Serializable]
	public class ReqPlatFriendRankListArg : IExtensible
	{
		// Token: 0x060024D7 RID: 9431 RVA: 0x00047D7C File Offset: 0x00045F7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400091A RID: 2330
		private IExtension extensionObject;
	}
}
