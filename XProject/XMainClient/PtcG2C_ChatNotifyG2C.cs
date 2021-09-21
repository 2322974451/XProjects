using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001551 RID: 5457
	internal class PtcG2C_ChatNotifyG2C : Protocol
	{
		// Token: 0x0600EA5F RID: 59999 RVA: 0x003441BC File Offset: 0x003423BC
		public override uint GetProtoType()
		{
			return 48111U;
		}

		// Token: 0x0600EA60 RID: 60000 RVA: 0x003441D3 File Offset: 0x003423D3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChatNotify>(stream, this.Data);
		}

		// Token: 0x0600EA61 RID: 60001 RVA: 0x003441E3 File Offset: 0x003423E3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChatNotify>(stream);
		}

		// Token: 0x0600EA62 RID: 60002 RVA: 0x003441F2 File Offset: 0x003423F2
		public override void Process()
		{
			Process_PtcG2C_ChatNotifyG2C.Process(this);
		}

		// Token: 0x0400653F RID: 25919
		public ChatNotify Data = new ChatNotify();
	}
}
