using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001275 RID: 4725
	internal class PtcM2C_SynGuildArenaRoleOnlineNew : Protocol
	{
		// Token: 0x0600DEAD RID: 57005 RVA: 0x003338D8 File Offset: 0x00331AD8
		public override uint GetProtoType()
		{
			return 26598U;
		}

		// Token: 0x0600DEAE RID: 57006 RVA: 0x003338EF File Offset: 0x00331AEF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildArenaRoleOnline>(stream, this.Data);
		}

		// Token: 0x0600DEAF RID: 57007 RVA: 0x003338FF File Offset: 0x00331AFF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildArenaRoleOnline>(stream);
		}

		// Token: 0x0600DEB0 RID: 57008 RVA: 0x0033390E File Offset: 0x00331B0E
		public override void Process()
		{
			Process_PtcM2C_SynGuildArenaRoleOnlineNew.Process(this);
		}

		// Token: 0x04006302 RID: 25346
		public SynGuildArenaRoleOnline Data = new SynGuildArenaRoleOnline();
	}
}
