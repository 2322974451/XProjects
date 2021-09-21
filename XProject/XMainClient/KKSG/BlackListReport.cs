using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200007E RID: 126
	[ProtoContract(Name = "BlackListReport")]
	[Serializable]
	public class BlackListReport : IExtensible
	{
		// Token: 0x06000832 RID: 2098 RVA: 0x00012360 File Offset: 0x00010560
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400021A RID: 538
		private IExtension extensionObject;
	}
}
