using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012BB RID: 4795
	internal class PtcM2C_GmfJoinBattleM2CReq : Protocol
	{
		// Token: 0x0600DFCD RID: 57293 RVA: 0x00335258 File Offset: 0x00333458
		public override uint GetProtoType()
		{
			return 63969U;
		}

		// Token: 0x0600DFCE RID: 57294 RVA: 0x0033526F File Offset: 0x0033346F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfJoinBattleArg>(stream, this.Data);
		}

		// Token: 0x0600DFCF RID: 57295 RVA: 0x0033527F File Offset: 0x0033347F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfJoinBattleArg>(stream);
		}

		// Token: 0x0600DFD0 RID: 57296 RVA: 0x0033528E File Offset: 0x0033348E
		public override void Process()
		{
			Process_PtcM2C_GmfJoinBattleM2CReq.Process(this);
		}

		// Token: 0x0400633A RID: 25402
		public GmfJoinBattleArg Data = new GmfJoinBattleArg();
	}
}
