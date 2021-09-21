using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000296 RID: 662
	[ProtoContract(Name = "NoticeGuildWageReward")]
	[Serializable]
	public class NoticeGuildWageReward : IExtensible
	{
		// Token: 0x0600250E RID: 9486 RVA: 0x000483A8 File Offset: 0x000465A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000928 RID: 2344
		private IExtension extensionObject;
	}
}
