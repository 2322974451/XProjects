using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200141A RID: 5146
	internal class PtcG2C_HeroBattleTeamMsgNtf : Protocol
	{
		// Token: 0x0600E571 RID: 58737 RVA: 0x0033D048 File Offset: 0x0033B248
		public override uint GetProtoType()
		{
			return 1414U;
		}

		// Token: 0x0600E572 RID: 58738 RVA: 0x0033D05F File Offset: 0x0033B25F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleTeamMsg>(stream, this.Data);
		}

		// Token: 0x0600E573 RID: 58739 RVA: 0x0033D06F File Offset: 0x0033B26F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleTeamMsg>(stream);
		}

		// Token: 0x0600E574 RID: 58740 RVA: 0x0033D07E File Offset: 0x0033B27E
		public override void Process()
		{
			Process_PtcG2C_HeroBattleTeamMsgNtf.Process(this);
		}

		// Token: 0x04006452 RID: 25682
		public HeroBattleTeamMsg Data = new HeroBattleTeamMsg();
	}
}
