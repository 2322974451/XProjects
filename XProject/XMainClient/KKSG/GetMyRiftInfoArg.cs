using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000525 RID: 1317
	[ProtoContract(Name = "GetMyRiftInfoArg")]
	[Serializable]
	public class GetMyRiftInfoArg : IExtensible
	{
		// Token: 0x060043B2 RID: 17330 RVA: 0x00080C7C File Offset: 0x0007EE7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010E0 RID: 4320
		private IExtension extensionObject;
	}
}
