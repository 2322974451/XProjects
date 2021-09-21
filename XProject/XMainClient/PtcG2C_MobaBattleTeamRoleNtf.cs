using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001533 RID: 5427
	internal class PtcG2C_MobaBattleTeamRoleNtf : Protocol
	{
		// Token: 0x0600E9E8 RID: 59880 RVA: 0x003436C0 File Offset: 0x003418C0
		public override uint GetProtoType()
		{
			return 44930U;
		}

		// Token: 0x0600E9E9 RID: 59881 RVA: 0x003436D7 File Offset: 0x003418D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaBattleTeamRoleData>(stream, this.Data);
		}

		// Token: 0x0600E9EA RID: 59882 RVA: 0x003436E7 File Offset: 0x003418E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaBattleTeamRoleData>(stream);
		}

		// Token: 0x0600E9EB RID: 59883 RVA: 0x003436F6 File Offset: 0x003418F6
		public override void Process()
		{
			Process_PtcG2C_MobaBattleTeamRoleNtf.Process(this);
		}

		// Token: 0x04006529 RID: 25897
		public MobaBattleTeamRoleData Data = new MobaBattleTeamRoleData();
	}
}
