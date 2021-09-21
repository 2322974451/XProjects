using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000508 RID: 1288
	[ProtoContract(Name = "QueryBoxsArg")]
	[Serializable]
	public class QueryBoxsArg : IExtensible
	{
		// Token: 0x06004273 RID: 17011 RVA: 0x0007E7C8 File Offset: 0x0007C9C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001092 RID: 4242
		private IExtension extensionObject;
	}
}
