using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200048C RID: 1164
	[ProtoContract(Name = "GroupChatApplyNtf")]
	[Serializable]
	public class GroupChatApplyNtf : IExtensible
	{
		// Token: 0x06003CD1 RID: 15569 RVA: 0x00074200 File Offset: 0x00072400
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F23 RID: 3875
		private IExtension extensionObject;
	}
}
