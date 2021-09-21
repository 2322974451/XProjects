using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011DC RID: 4572
	internal class PtcM2C_TeamChangeM2CNtf : Protocol
	{
		// Token: 0x0600DC3A RID: 56378 RVA: 0x003300D4 File Offset: 0x0032E2D4
		public override uint GetProtoType()
		{
			return 53586U;
		}

		// Token: 0x0600DC3B RID: 56379 RVA: 0x003300EB File Offset: 0x0032E2EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamChanged>(stream, this.Data);
		}

		// Token: 0x0600DC3C RID: 56380 RVA: 0x003300FB File Offset: 0x0032E2FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamChanged>(stream);
		}

		// Token: 0x0600DC3D RID: 56381 RVA: 0x0033010A File Offset: 0x0032E30A
		public override void Process()
		{
			Process_PtcM2C_TeamChangeM2CNtf.Process(this);
		}

		// Token: 0x04006289 RID: 25225
		public TeamChanged Data = new TeamChanged();
	}
}
