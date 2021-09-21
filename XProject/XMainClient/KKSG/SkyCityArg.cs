using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000253 RID: 595
	[ProtoContract(Name = "SkyCityArg")]
	[Serializable]
	public class SkyCityArg : IExtensible
	{
		// Token: 0x06002159 RID: 8537 RVA: 0x000414D8 File Offset: 0x0003F6D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400084A RID: 2122
		private IExtension extensionObject;
	}
}
