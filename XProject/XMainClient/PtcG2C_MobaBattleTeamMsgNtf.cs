using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001539 RID: 5433
	internal class PtcG2C_MobaBattleTeamMsgNtf : Protocol
	{
		// Token: 0x0600E9FD RID: 59901 RVA: 0x00343838 File Offset: 0x00341A38
		public override uint GetProtoType()
		{
			return 14987U;
		}

		// Token: 0x0600E9FE RID: 59902 RVA: 0x0034384F File Offset: 0x00341A4F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaBattleTeamMsg>(stream, this.Data);
		}

		// Token: 0x0600E9FF RID: 59903 RVA: 0x0034385F File Offset: 0x00341A5F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaBattleTeamMsg>(stream);
		}

		// Token: 0x0600EA00 RID: 59904 RVA: 0x0034386E File Offset: 0x00341A6E
		public override void Process()
		{
			Process_PtcG2C_MobaBattleTeamMsgNtf.Process(this);
		}

		// Token: 0x0400652C RID: 25900
		public MobaBattleTeamMsg Data = new MobaBattleTeamMsg();
	}
}
