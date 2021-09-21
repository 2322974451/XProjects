using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200117E RID: 4478
	internal class PtcG2C_GuildBossTimeOut : Protocol
	{
		// Token: 0x0600DACA RID: 56010 RVA: 0x0032E20C File Offset: 0x0032C40C
		public override uint GetProtoType()
		{
			return 56816U;
		}

		// Token: 0x0600DACB RID: 56011 RVA: 0x0032E223 File Offset: 0x0032C423
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBossTimeOut>(stream, this.Data);
		}

		// Token: 0x0600DACC RID: 56012 RVA: 0x0032E233 File Offset: 0x0032C433
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBossTimeOut>(stream);
		}

		// Token: 0x0600DACD RID: 56013 RVA: 0x0032E242 File Offset: 0x0032C442
		public override void Process()
		{
			Process_PtcG2C_GuildBossTimeOut.Process(this);
		}

		// Token: 0x04006249 RID: 25161
		public GuildBossTimeOut Data = new GuildBossTimeOut();
	}
}
