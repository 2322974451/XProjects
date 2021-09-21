using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004FC RID: 1276
	[ProtoContract(Name = "GetDailyTaskRefreshRecordArg")]
	[Serializable]
	public class GetDailyTaskRefreshRecordArg : IExtensible
	{
		// Token: 0x060041F7 RID: 16887 RVA: 0x0007D97C File Offset: 0x0007BB7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001073 RID: 4211
		private IExtension extensionObject;
	}
}
