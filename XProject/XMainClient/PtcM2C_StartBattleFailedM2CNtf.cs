using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015D9 RID: 5593
	internal class PtcM2C_StartBattleFailedM2CNtf : Protocol
	{
		// Token: 0x0600EC8D RID: 60557 RVA: 0x00347374 File Offset: 0x00345574
		public override uint GetProtoType()
		{
			return 20444U;
		}

		// Token: 0x0600EC8E RID: 60558 RVA: 0x0034738B File Offset: 0x0034558B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartBattleFailedRes>(stream, this.Data);
		}

		// Token: 0x0600EC8F RID: 60559 RVA: 0x0034739B File Offset: 0x0034559B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<StartBattleFailedRes>(stream);
		}

		// Token: 0x0600EC90 RID: 60560 RVA: 0x003473AA File Offset: 0x003455AA
		public override void Process()
		{
			Process_PtcM2C_StartBattleFailedM2CNtf.Process(this);
		}

		// Token: 0x040065B0 RID: 26032
		public StartBattleFailedRes Data = new StartBattleFailedRes();
	}
}
