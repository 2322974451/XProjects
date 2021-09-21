using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014D5 RID: 5333
	internal class PtcM2C_NotifySkyTeamCreate : Protocol
	{
		// Token: 0x0600E860 RID: 59488 RVA: 0x00341424 File Offset: 0x0033F624
		public override uint GetProtoType()
		{
			return 21688U;
		}

		// Token: 0x0600E861 RID: 59489 RVA: 0x0034143B File Offset: 0x0033F63B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifySkyTeamCreate>(stream, this.Data);
		}

		// Token: 0x0600E862 RID: 59490 RVA: 0x0034144B File Offset: 0x0033F64B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifySkyTeamCreate>(stream);
		}

		// Token: 0x0600E863 RID: 59491 RVA: 0x0034145A File Offset: 0x0033F65A
		public override void Process()
		{
			Process_PtcM2C_NotifySkyTeamCreate.Process(this);
		}

		// Token: 0x040064DB RID: 25819
		public NotifySkyTeamCreate Data = new NotifySkyTeamCreate();
	}
}
