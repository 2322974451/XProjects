using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001582 RID: 5506
	internal class PtcG2C_NotifyStartUpTypeToClient : Protocol
	{
		// Token: 0x0600EB2C RID: 60204 RVA: 0x003455E8 File Offset: 0x003437E8
		public override uint GetProtoType()
		{
			return 64412U;
		}

		// Token: 0x0600EB2D RID: 60205 RVA: 0x003455FF File Offset: 0x003437FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyStartUpTypeToClient>(stream, this.Data);
		}

		// Token: 0x0600EB2E RID: 60206 RVA: 0x0034560F File Offset: 0x0034380F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyStartUpTypeToClient>(stream);
		}

		// Token: 0x0600EB2F RID: 60207 RVA: 0x0034561E File Offset: 0x0034381E
		public override void Process()
		{
			Process_PtcG2C_NotifyStartUpTypeToClient.Process(this);
		}

		// Token: 0x0400656F RID: 25967
		public NotifyStartUpTypeToClient Data = new NotifyStartUpTypeToClient();
	}
}
