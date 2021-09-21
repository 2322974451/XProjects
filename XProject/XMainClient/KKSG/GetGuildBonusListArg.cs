using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B8 RID: 184
	[ProtoContract(Name = "GetGuildBonusListArg")]
	[Serializable]
	public class GetGuildBonusListArg : IExtensible
	{
		// Token: 0x06000C6A RID: 3178 RVA: 0x0001A31C File Offset: 0x0001851C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000317 RID: 791
		private IExtension extensionObject;
	}
}
