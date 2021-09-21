using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010DA RID: 4314
	internal class PtcG2C_TeamFullDataNtf : Protocol
	{
		// Token: 0x0600D820 RID: 55328 RVA: 0x00329138 File Offset: 0x00327338
		public override uint GetProtoType()
		{
			return 48618U;
		}

		// Token: 0x0600D821 RID: 55329 RVA: 0x0032914F File Offset: 0x0032734F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamFullDataNtf>(stream, this.Data);
		}

		// Token: 0x0600D822 RID: 55330 RVA: 0x0032915F File Offset: 0x0032735F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamFullDataNtf>(stream);
		}

		// Token: 0x0600D823 RID: 55331 RVA: 0x0032916E File Offset: 0x0032736E
		public override void Process()
		{
			Process_PtcG2C_TeamFullDataNtf.Process(this);
		}

		// Token: 0x040061C4 RID: 25028
		public TeamFullDataNtf Data = new TeamFullDataNtf();
	}
}
