using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000148 RID: 328
	[ProtoContract(Name = "GetFlowerRewardArg")]
	[Serializable]
	public class GetFlowerRewardArg : IExtensible
	{
		// Token: 0x06001428 RID: 5160 RVA: 0x00028AD8 File Offset: 0x00026CD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000504 RID: 1284
		private IExtension extensionObject;
	}
}
