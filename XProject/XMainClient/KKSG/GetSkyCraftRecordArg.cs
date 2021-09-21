using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E2 RID: 994
	[ProtoContract(Name = "GetSkyCraftRecordArg")]
	[Serializable]
	public class GetSkyCraftRecordArg : IExtensible
	{
		// Token: 0x060034EB RID: 13547 RVA: 0x00065724 File Offset: 0x00063924
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D23 RID: 3363
		private IExtension extensionObject;
	}
}
