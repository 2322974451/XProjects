using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A6 RID: 678
	[ProtoContract(Name = "GetGuildBonusSendListArg")]
	[Serializable]
	public class GetGuildBonusSendListArg : IExtensible
	{
		// Token: 0x060025DF RID: 9695 RVA: 0x00049BC4 File Offset: 0x00047DC4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000962 RID: 2402
		private IExtension extensionObject;
	}
}
