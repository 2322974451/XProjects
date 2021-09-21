using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011B3 RID: 4531
	internal class PtcG2C_synguildarenadisplace : Protocol
	{
		// Token: 0x0600DB96 RID: 56214 RVA: 0x0032F450 File Offset: 0x0032D650
		public override uint GetProtoType()
		{
			return 21037U;
		}

		// Token: 0x0600DB97 RID: 56215 RVA: 0x0032F467 File Offset: 0x0032D667
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<guildarenadisplace>(stream, this.Data);
		}

		// Token: 0x0600DB98 RID: 56216 RVA: 0x0032F477 File Offset: 0x0032D677
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<guildarenadisplace>(stream);
		}

		// Token: 0x0600DB99 RID: 56217 RVA: 0x0032F486 File Offset: 0x0032D686
		public override void Process()
		{
			Process_PtcG2C_synguildarenadisplace.Process(this);
		}

		// Token: 0x0400626B RID: 25195
		public guildarenadisplace Data = new guildarenadisplace();
	}
}
