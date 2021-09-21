using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001282 RID: 4738
	internal class PtcG2C_RiskRecoverDiceNtf : Protocol
	{
		// Token: 0x0600DEE2 RID: 57058 RVA: 0x00333CA0 File Offset: 0x00331EA0
		public override uint GetProtoType()
		{
			return 45917U;
		}

		// Token: 0x0600DEE3 RID: 57059 RVA: 0x00333CB7 File Offset: 0x00331EB7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiskRecoverDiceData>(stream, this.Data);
		}

		// Token: 0x0600DEE4 RID: 57060 RVA: 0x00333CC7 File Offset: 0x00331EC7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RiskRecoverDiceData>(stream);
		}

		// Token: 0x0600DEE5 RID: 57061 RVA: 0x00333CD6 File Offset: 0x00331ED6
		public override void Process()
		{
			Process_PtcG2C_RiskRecoverDiceNtf.Process(this);
		}

		// Token: 0x0400630C RID: 25356
		public RiskRecoverDiceData Data = new RiskRecoverDiceData();
	}
}
