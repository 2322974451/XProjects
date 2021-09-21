using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C2 RID: 962
	[ProtoContract(Name = "GetBackFlowSpActTimeArg")]
	[Serializable]
	public class GetBackFlowSpActTimeArg : IExtensible
	{
		// Token: 0x06003362 RID: 13154 RVA: 0x00062AF4 File Offset: 0x00060CF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CC6 RID: 3270
		private IExtension extensionObject;
	}
}
