using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200158A RID: 5514
	internal class PtcM2C_GroupChatDismiss : Protocol
	{
		// Token: 0x0600EB4A RID: 60234 RVA: 0x00345874 File Offset: 0x00343A74
		public override uint GetProtoType()
		{
			return 18973U;
		}

		// Token: 0x0600EB4B RID: 60235 RVA: 0x0034588B File Offset: 0x00343A8B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatDismissPtc>(stream, this.Data);
		}

		// Token: 0x0600EB4C RID: 60236 RVA: 0x0034589B File Offset: 0x00343A9B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatDismissPtc>(stream);
		}

		// Token: 0x0600EB4D RID: 60237 RVA: 0x003458AA File Offset: 0x00343AAA
		public override void Process()
		{
			Process_PtcM2C_GroupChatDismiss.Process(this);
		}

		// Token: 0x04006574 RID: 25972
		public GroupChatDismissPtc Data = new GroupChatDismissPtc();
	}
}
