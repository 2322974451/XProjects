using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001068 RID: 4200
	internal class PtcT2C_ChatNotify : Protocol
	{
		// Token: 0x0600D658 RID: 54872 RVA: 0x00325F44 File Offset: 0x00324144
		public override uint GetProtoType()
		{
			return 4256U;
		}

		// Token: 0x0600D659 RID: 54873 RVA: 0x00325F5B File Offset: 0x0032415B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChatNotify>(stream, this.Data);
		}

		// Token: 0x0600D65A RID: 54874 RVA: 0x00325F6B File Offset: 0x0032416B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChatNotify>(stream);
		}

		// Token: 0x0600D65B RID: 54875 RVA: 0x00325F7A File Offset: 0x0032417A
		public override void Process()
		{
			Process_PtcT2C_ChatNotify.Process(this);
		}

		// Token: 0x04006173 RID: 24947
		public ChatNotify Data = new ChatNotify();
	}
}
