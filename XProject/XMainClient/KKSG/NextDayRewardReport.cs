using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000CC RID: 204
	[ProtoContract(Name = "NextDayRewardReport")]
	[Serializable]
	public class NextDayRewardReport : IExtensible
	{
		// Token: 0x06000D3F RID: 3391 RVA: 0x0001BB54 File Offset: 0x00019D54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000353 RID: 851
		private IExtension extensionObject;
	}
}
