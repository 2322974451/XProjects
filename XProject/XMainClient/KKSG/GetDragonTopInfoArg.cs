using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000161 RID: 353
	[ProtoContract(Name = "GetDragonTopInfoArg")]
	[Serializable]
	public class GetDragonTopInfoArg : IExtensible
	{
		// Token: 0x06001577 RID: 5495 RVA: 0x0002B234 File Offset: 0x00029434
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000554 RID: 1364
		private IExtension extensionObject;
	}
}
