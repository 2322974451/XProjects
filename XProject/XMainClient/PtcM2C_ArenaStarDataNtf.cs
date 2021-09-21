using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014D3 RID: 5331
	internal class PtcM2C_ArenaStarDataNtf : Protocol
	{
		// Token: 0x0600E859 RID: 59481 RVA: 0x003413B8 File Offset: 0x0033F5B8
		public override uint GetProtoType()
		{
			return 11371U;
		}

		// Token: 0x0600E85A RID: 59482 RVA: 0x003413CF File Offset: 0x0033F5CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArenaStarPara>(stream, this.Data);
		}

		// Token: 0x0600E85B RID: 59483 RVA: 0x003413DF File Offset: 0x0033F5DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ArenaStarPara>(stream);
		}

		// Token: 0x0600E85C RID: 59484 RVA: 0x003413EE File Offset: 0x0033F5EE
		public override void Process()
		{
			Process_PtcM2C_ArenaStarDataNtf.Process(this);
		}

		// Token: 0x040064DA RID: 25818
		public ArenaStarPara Data = new ArenaStarPara();
	}
}
