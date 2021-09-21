using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012F2 RID: 4850
	internal class PtcM2C_GuildCardMatchNtf : Protocol
	{
		// Token: 0x0600E0B2 RID: 57522 RVA: 0x0033670C File Offset: 0x0033490C
		public override uint GetProtoType()
		{
			return 64513U;
		}

		// Token: 0x0600E0B3 RID: 57523 RVA: 0x00336723 File Offset: 0x00334923
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardMatchNtf>(stream, this.Data);
		}

		// Token: 0x0600E0B4 RID: 57524 RVA: 0x00336733 File Offset: 0x00334933
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardMatchNtf>(stream);
		}

		// Token: 0x0600E0B5 RID: 57525 RVA: 0x00336742 File Offset: 0x00334942
		public override void Process()
		{
			Process_PtcM2C_GuildCardMatchNtf.Process(this);
		}

		// Token: 0x04006367 RID: 25447
		public GuildCardMatchNtf Data = new GuildCardMatchNtf();
	}
}
