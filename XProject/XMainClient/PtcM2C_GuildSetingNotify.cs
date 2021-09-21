using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001299 RID: 4761
	internal class PtcM2C_GuildSetingNotify : Protocol
	{
		// Token: 0x0600DF46 RID: 57158 RVA: 0x00334550 File Offset: 0x00332750
		public override uint GetProtoType()
		{
			return 21944U;
		}

		// Token: 0x0600DF47 RID: 57159 RVA: 0x00334567 File Offset: 0x00332767
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSettingChanged>(stream, this.Data);
		}

		// Token: 0x0600DF48 RID: 57160 RVA: 0x00334577 File Offset: 0x00332777
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildSettingChanged>(stream);
		}

		// Token: 0x0600DF49 RID: 57161 RVA: 0x00334586 File Offset: 0x00332786
		public override void Process()
		{
			Process_PtcM2C_GuildSetingNotify.Process(this);
		}

		// Token: 0x04006321 RID: 25377
		public GuildSettingChanged Data = new GuildSettingChanged();
	}
}
