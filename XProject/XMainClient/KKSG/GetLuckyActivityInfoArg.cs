using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F2 RID: 1266
	[ProtoContract(Name = "GetLuckyActivityInfoArg")]
	[Serializable]
	public class GetLuckyActivityInfoArg : IExtensible
	{
		// Token: 0x06004179 RID: 16761 RVA: 0x0007CA88 File Offset: 0x0007AC88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001054 RID: 4180
		private IExtension extensionObject;
	}
}
