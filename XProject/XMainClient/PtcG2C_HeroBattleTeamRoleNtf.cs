using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001427 RID: 5159
	internal class PtcG2C_HeroBattleTeamRoleNtf : Protocol
	{
		// Token: 0x0600E5A2 RID: 58786 RVA: 0x0033D390 File Offset: 0x0033B590
		public override uint GetProtoType()
		{
			return 25720U;
		}

		// Token: 0x0600E5A3 RID: 58787 RVA: 0x0033D3A7 File Offset: 0x0033B5A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleTeamRoleData>(stream, this.Data);
		}

		// Token: 0x0600E5A4 RID: 58788 RVA: 0x0033D3B7 File Offset: 0x0033B5B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleTeamRoleData>(stream);
		}

		// Token: 0x0600E5A5 RID: 58789 RVA: 0x0033D3C6 File Offset: 0x0033B5C6
		public override void Process()
		{
			Process_PtcG2C_HeroBattleTeamRoleNtf.Process(this);
		}

		// Token: 0x04006459 RID: 25689
		public HeroBattleTeamRoleData Data = new HeroBattleTeamRoleData();
	}
}
