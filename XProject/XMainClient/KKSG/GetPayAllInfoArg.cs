using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C1 RID: 449
	[ProtoContract(Name = "GetPayAllInfoArg")]
	[Serializable]
	public class GetPayAllInfoArg : IExtensible
	{
		// Token: 0x06001A1F RID: 6687 RVA: 0x00033BD0 File Offset: 0x00031DD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400067F RID: 1663
		private IExtension extensionObject;
	}
}
