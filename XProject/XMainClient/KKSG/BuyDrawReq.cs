using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F4 RID: 1268
	[ProtoContract(Name = "BuyDrawReq")]
	[Serializable]
	public class BuyDrawReq : IExtensible
	{
		// Token: 0x06004196 RID: 16790 RVA: 0x0007CE04 File Offset: 0x0007B004
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400105B RID: 4187
		private IExtension extensionObject;
	}
}
