using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C9 RID: 201
	[ProtoContract(Name = "GetNextDayRewardArg")]
	[Serializable]
	public class GetNextDayRewardArg : IExtensible
	{
		// Token: 0x06000D33 RID: 3379 RVA: 0x0001BA30 File Offset: 0x00019C30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400034F RID: 847
		private IExtension extensionObject;
	}
}
