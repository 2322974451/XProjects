using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000450 RID: 1104
	[ProtoContract(Name = "GroupChatLeaderReviewListC2S")]
	[Serializable]
	public class GroupChatLeaderReviewListC2S : IExtensible
	{
		// Token: 0x06003A39 RID: 14905 RVA: 0x0006F5F8 File Offset: 0x0006D7F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E71 RID: 3697
		private IExtension extensionObject;
	}
}
