using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001439 RID: 5177
	internal class PtcM2C_NoticeGuildTerrall : Protocol
	{
		// Token: 0x0600E5ED RID: 58861 RVA: 0x0033DA0C File Offset: 0x0033BC0C
		public override uint GetProtoType()
		{
			return 7704U;
		}

		// Token: 0x0600E5EE RID: 58862 RVA: 0x0033DA23 File Offset: 0x0033BC23
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrall>(stream, this.Data);
		}

		// Token: 0x0600E5EF RID: 58863 RVA: 0x0033DA33 File Offset: 0x0033BC33
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrall>(stream);
		}

		// Token: 0x0600E5F0 RID: 58864 RVA: 0x0033DA42 File Offset: 0x0033BC42
		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrall.Process(this);
		}

		// Token: 0x04006468 RID: 25704
		public NoticeGuildTerrall Data = new NoticeGuildTerrall();
	}
}
