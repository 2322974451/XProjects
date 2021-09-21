using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000504 RID: 1284
	[ProtoContract(Name = "EmptyData")]
	[Serializable]
	public class EmptyData : IExtensible
	{
		// Token: 0x06004251 RID: 16977 RVA: 0x0007E404 File Offset: 0x0007C604
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001089 RID: 4233
		private IExtension extensionObject;
	}
}
