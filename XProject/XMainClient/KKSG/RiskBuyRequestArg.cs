using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200021C RID: 540
	[ProtoContract(Name = "RiskBuyRequestArg")]
	[Serializable]
	public class RiskBuyRequestArg : IExtensible
	{
		// Token: 0x06001E30 RID: 7728 RVA: 0x0003B4B4 File Offset: 0x000396B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400078E RID: 1934
		private IExtension extensionObject;
	}
}
