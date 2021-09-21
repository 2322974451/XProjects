using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012D6 RID: 4822
	internal class PtcG2C_SkyCityTeamRes : Protocol
	{
		// Token: 0x0600E03B RID: 57403 RVA: 0x00335B64 File Offset: 0x00333D64
		public override uint GetProtoType()
		{
			return 49519U;
		}

		// Token: 0x0600E03C RID: 57404 RVA: 0x00335B7B File Offset: 0x00333D7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityAllTeamBaseInfo>(stream, this.Data);
		}

		// Token: 0x0600E03D RID: 57405 RVA: 0x00335B8B File Offset: 0x00333D8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityAllTeamBaseInfo>(stream);
		}

		// Token: 0x0600E03E RID: 57406 RVA: 0x00335B9A File Offset: 0x00333D9A
		public override void Process()
		{
			Process_PtcG2C_SkyCityTeamRes.Process(this);
		}

		// Token: 0x0400634F RID: 25423
		public SkyCityAllTeamBaseInfo Data = new SkyCityAllTeamBaseInfo();
	}
}
