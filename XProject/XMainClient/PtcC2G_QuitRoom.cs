using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011CB RID: 4555
	internal class PtcC2G_QuitRoom : Protocol
	{
		// Token: 0x0600DBF3 RID: 56307 RVA: 0x0032FAF8 File Offset: 0x0032DCF8
		public override uint GetProtoType()
		{
			return 44925U;
		}

		// Token: 0x0600DBF4 RID: 56308 RVA: 0x0032FB0F File Offset: 0x0032DD0F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QuitRoom>(stream, this.Data);
		}

		// Token: 0x0600DBF5 RID: 56309 RVA: 0x0032FB1F File Offset: 0x0032DD1F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QuitRoom>(stream);
		}

		// Token: 0x0600DBF6 RID: 56310 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400627B RID: 25211
		public QuitRoom Data = new QuitRoom();
	}
}
