using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200053F RID: 1343
	[ProtoContract(Name = "GuildZiCaiGetList_C2M")]
	[Serializable]
	public class GuildZiCaiGetList_C2M : IExtensible
	{
		// Token: 0x060044D2 RID: 17618 RVA: 0x00082E40 File Offset: 0x00081040
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001130 RID: 4400
		private IExtension extensionObject;
	}
}
