using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010BE RID: 4286
	internal class PtcG2C_GuildGoblinKillNtf : Protocol
	{
		// Token: 0x0600D7B4 RID: 55220 RVA: 0x00328870 File Offset: 0x00326A70
		public override uint GetProtoType()
		{
			return 9436U;
		}

		// Token: 0x0600D7B5 RID: 55221 RVA: 0x00328887 File Offset: 0x00326A87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildGoblinSceneInfo>(stream, this.Data);
		}

		// Token: 0x0600D7B6 RID: 55222 RVA: 0x00328897 File Offset: 0x00326A97
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildGoblinSceneInfo>(stream);
		}

		// Token: 0x0600D7B7 RID: 55223 RVA: 0x003288A6 File Offset: 0x00326AA6
		public override void Process()
		{
			Process_PtcG2C_GuildGoblinKillNtf.Process(this);
		}

		// Token: 0x040061B3 RID: 25011
		public GuildGoblinSceneInfo Data = new GuildGoblinSceneInfo();
	}
}
