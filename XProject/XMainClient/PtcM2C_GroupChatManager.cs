using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001586 RID: 5510
	internal class PtcM2C_GroupChatManager : Protocol
	{
		// Token: 0x0600EB3C RID: 60220 RVA: 0x00345778 File Offset: 0x00343978
		public override uint GetProtoType()
		{
			return 17710U;
		}

		// Token: 0x0600EB3D RID: 60221 RVA: 0x0034578F File Offset: 0x0034398F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatManagerPtc>(stream, this.Data);
		}

		// Token: 0x0600EB3E RID: 60222 RVA: 0x0034579F File Offset: 0x0034399F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatManagerPtc>(stream);
		}

		// Token: 0x0600EB3F RID: 60223 RVA: 0x003457AE File Offset: 0x003439AE
		public override void Process()
		{
			Process_PtcM2C_GroupChatManager.Process(this);
		}

		// Token: 0x04006572 RID: 25970
		public GroupChatManagerPtc Data = new GroupChatManagerPtc();
	}
}
