using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001DB RID: 475
	[ProtoContract(Name = "TitleLevelUpArg")]
	[Serializable]
	public class TitleLevelUpArg : IExtensible
	{
		// Token: 0x06001B78 RID: 7032 RVA: 0x00036448 File Offset: 0x00034648
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006D7 RID: 1751
		private IExtension extensionObject;
	}
}
