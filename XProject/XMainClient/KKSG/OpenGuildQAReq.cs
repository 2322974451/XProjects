using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200016C RID: 364
	[ProtoContract(Name = "OpenGuildQAReq")]
	[Serializable]
	public class OpenGuildQAReq : IExtensible
	{
		// Token: 0x060015F8 RID: 5624 RVA: 0x0002C114 File Offset: 0x0002A314
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000575 RID: 1397
		private IExtension extensionObject;
	}
}
