using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002DD RID: 733
	[ProtoContract(Name = "ReqGuildInheritInfoArg")]
	[Serializable]
	public class ReqGuildInheritInfoArg : IExtensible
	{
		// Token: 0x06002877 RID: 10359 RVA: 0x0004EA38 File Offset: 0x0004CC38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A0F RID: 2575
		private IExtension extensionObject;
	}
}
