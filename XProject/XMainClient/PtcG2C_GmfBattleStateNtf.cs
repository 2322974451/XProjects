using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001317 RID: 4887
	internal class PtcG2C_GmfBattleStateNtf : Protocol
	{
		// Token: 0x0600E14C RID: 57676 RVA: 0x0033754C File Offset: 0x0033574C
		public override uint GetProtoType()
		{
			return 21747U;
		}

		// Token: 0x0600E14D RID: 57677 RVA: 0x00337563 File Offset: 0x00335763
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfBatlleStatePara>(stream, this.Data);
		}

		// Token: 0x0600E14E RID: 57678 RVA: 0x00337573 File Offset: 0x00335773
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfBatlleStatePara>(stream);
		}

		// Token: 0x0600E14F RID: 57679 RVA: 0x00337582 File Offset: 0x00335782
		public override void Process()
		{
			Process_PtcG2C_GmfBattleStateNtf.Process(this);
		}

		// Token: 0x04006385 RID: 25477
		public GmfBatlleStatePara Data = new GmfBatlleStatePara();
	}
}
