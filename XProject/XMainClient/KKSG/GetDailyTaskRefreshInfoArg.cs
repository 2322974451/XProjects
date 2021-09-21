using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F8 RID: 1272
	[ProtoContract(Name = "GetDailyTaskRefreshInfoArg")]
	[Serializable]
	public class GetDailyTaskRefreshInfoArg : IExtensible
	{
		// Token: 0x060041BD RID: 16829 RVA: 0x0007D284 File Offset: 0x0007B484
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001065 RID: 4197
		private IExtension extensionObject;
	}
}
