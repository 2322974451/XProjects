using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001176 RID: 4470
	internal class PtcG2C_GmfOneBattleEndNtf : Protocol
	{
		// Token: 0x0600DAAC RID: 55980 RVA: 0x0032DFB4 File Offset: 0x0032C1B4
		public override uint GetProtoType()
		{
			return 61740U;
		}

		// Token: 0x0600DAAD RID: 55981 RVA: 0x0032DFCB File Offset: 0x0032C1CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfOneBattleEnd>(stream, this.Data);
		}

		// Token: 0x0600DAAE RID: 55982 RVA: 0x0032DFDB File Offset: 0x0032C1DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfOneBattleEnd>(stream);
		}

		// Token: 0x0600DAAF RID: 55983 RVA: 0x0032DFEA File Offset: 0x0032C1EA
		public override void Process()
		{
			Process_PtcG2C_GmfOneBattleEndNtf.Process(this);
		}

		// Token: 0x04006244 RID: 25156
		public GmfOneBattleEnd Data = new GmfOneBattleEnd();
	}
}
