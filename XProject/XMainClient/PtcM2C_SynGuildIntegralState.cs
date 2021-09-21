using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001379 RID: 4985
	internal class PtcM2C_SynGuildIntegralState : Protocol
	{
		// Token: 0x0600E2DB RID: 58075 RVA: 0x00339A68 File Offset: 0x00337C68
		public override uint GetProtoType()
		{
			return 4104U;
		}

		// Token: 0x0600E2DC RID: 58076 RVA: 0x00339A7F File Offset: 0x00337C7F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildIntegralState>(stream, this.Data);
		}

		// Token: 0x0600E2DD RID: 58077 RVA: 0x00339A8F File Offset: 0x00337C8F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildIntegralState>(stream);
		}

		// Token: 0x0600E2DE RID: 58078 RVA: 0x00339A9E File Offset: 0x00337C9E
		public override void Process()
		{
			Process_PtcM2C_SynGuildIntegralState.Process(this);
		}

		// Token: 0x040063D2 RID: 25554
		public SynGuildIntegralState Data = new SynGuildIntegralState();
	}
}
