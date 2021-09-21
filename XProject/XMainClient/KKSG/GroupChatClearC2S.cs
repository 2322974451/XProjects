using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200046B RID: 1131
	[ProtoContract(Name = "GroupChatClearC2S")]
	[Serializable]
	public class GroupChatClearC2S : IExtensible
	{
		// Token: 0x06003B3B RID: 15163 RVA: 0x00071360 File Offset: 0x0006F560
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EB6 RID: 3766
		private IExtension extensionObject;
	}
}
