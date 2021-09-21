using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001CD RID: 461
	[ProtoContract(Name = "PayFirstAwardArg")]
	[Serializable]
	public class PayFirstAwardArg : IExtensible
	{
		// Token: 0x06001AF4 RID: 6900 RVA: 0x00035538 File Offset: 0x00033738
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006B3 RID: 1715
		private IExtension extensionObject;
	}
}
