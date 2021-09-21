using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010C6 RID: 4294
	internal class PtcG2C_SceneDamageRankNtf : Protocol
	{
		// Token: 0x0600D7D1 RID: 55249 RVA: 0x00328B10 File Offset: 0x00326D10
		public override uint GetProtoType()
		{
			return 26864U;
		}

		// Token: 0x0600D7D2 RID: 55250 RVA: 0x00328B27 File Offset: 0x00326D27
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneDamageRankNtf>(stream, this.Data);
		}

		// Token: 0x0600D7D3 RID: 55251 RVA: 0x00328B37 File Offset: 0x00326D37
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneDamageRankNtf>(stream);
		}

		// Token: 0x0600D7D4 RID: 55252 RVA: 0x00328B46 File Offset: 0x00326D46
		public override void Process()
		{
			Process_PtcG2C_SceneDamageRankNtf.Process(this);
		}

		// Token: 0x040061B6 RID: 25014
		public SceneDamageRankNtf Data = new SceneDamageRankNtf();
	}
}
