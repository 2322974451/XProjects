using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011E2 RID: 4578
	internal class PtcM2C_TeamFullDataM2CNtf : Protocol
	{
		// Token: 0x0600DC51 RID: 56401 RVA: 0x003302C0 File Offset: 0x0032E4C0
		public override uint GetProtoType()
		{
			return 39119U;
		}

		// Token: 0x0600DC52 RID: 56402 RVA: 0x003302D7 File Offset: 0x0032E4D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamFullDataNtf>(stream, this.Data);
		}

		// Token: 0x0600DC53 RID: 56403 RVA: 0x003302E7 File Offset: 0x0032E4E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamFullDataNtf>(stream);
		}

		// Token: 0x0600DC54 RID: 56404 RVA: 0x003302F6 File Offset: 0x0032E4F6
		public override void Process()
		{
			Process_PtcM2C_TeamFullDataM2CNtf.Process(this);
		}

		// Token: 0x0400628D RID: 25229
		public TeamFullDataNtf Data = new TeamFullDataNtf();
	}
}
