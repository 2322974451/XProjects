using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200017B RID: 379
	[ProtoContract(Name = "GetMyWatchRecordArg")]
	[Serializable]
	public class GetMyWatchRecordArg : IExtensible
	{
		// Token: 0x060016FB RID: 5883 RVA: 0x0002DFE4 File Offset: 0x0002C1E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005AE RID: 1454
		private IExtension extensionObject;
	}
}
