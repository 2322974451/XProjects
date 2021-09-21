using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D8 RID: 984
	[ProtoContract(Name = "LeaveSkyTeamArg")]
	[Serializable]
	public class LeaveSkyTeamArg : IExtensible
	{
		// Token: 0x06003464 RID: 13412 RVA: 0x000647F0 File Offset: 0x000629F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D03 RID: 3331
		private IExtension extensionObject;
	}
}
