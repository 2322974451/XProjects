using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A1 RID: 161
	[ProtoContract(Name = "EndGuildCardArg")]
	[Serializable]
	public class EndGuildCardArg : IExtensible
	{
		// Token: 0x06000B21 RID: 2849 RVA: 0x00017DB4 File Offset: 0x00015FB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002CA RID: 714
		private IExtension extensionObject;
	}
}
