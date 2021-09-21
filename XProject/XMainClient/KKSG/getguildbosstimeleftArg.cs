using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200022B RID: 555
	[ProtoContract(Name = "getguildbosstimeleftArg")]
	[Serializable]
	public class getguildbosstimeleftArg : IExtensible
	{
		// Token: 0x06001F05 RID: 7941 RVA: 0x0003CE00 File Offset: 0x0003B000
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007BE RID: 1982
		private IExtension extensionObject;
	}
}
