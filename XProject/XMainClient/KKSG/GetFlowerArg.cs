using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000146 RID: 326
	[ProtoContract(Name = "GetFlowerArg")]
	[Serializable]
	public class GetFlowerArg : IExtensible
	{
		// Token: 0x06001412 RID: 5138 RVA: 0x0002884C File Offset: 0x00026A4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004FF RID: 1279
		private IExtension extensionObject;
	}
}
