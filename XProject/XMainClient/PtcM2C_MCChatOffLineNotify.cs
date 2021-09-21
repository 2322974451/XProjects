using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200119C RID: 4508
	internal class PtcM2C_MCChatOffLineNotify : Protocol
	{
		// Token: 0x0600DB35 RID: 56117 RVA: 0x0032EBBC File Offset: 0x0032CDBC
		public override uint GetProtoType()
		{
			return 35008U;
		}

		// Token: 0x0600DB36 RID: 56118 RVA: 0x0032EBD3 File Offset: 0x0032CDD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChatOfflineNotify>(stream, this.Data);
		}

		// Token: 0x0600DB37 RID: 56119 RVA: 0x0032EBE3 File Offset: 0x0032CDE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChatOfflineNotify>(stream);
		}

		// Token: 0x0600DB38 RID: 56120 RVA: 0x0032EBF2 File Offset: 0x0032CDF2
		public override void Process()
		{
			Process_PtcM2C_MCChatOffLineNotify.Process(this);
		}

		// Token: 0x04006258 RID: 25176
		public ChatOfflineNotify Data = new ChatOfflineNotify();
	}
}
