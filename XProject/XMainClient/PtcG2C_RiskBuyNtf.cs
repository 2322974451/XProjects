using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200127D RID: 4733
	internal class PtcG2C_RiskBuyNtf : Protocol
	{
		// Token: 0x0600DECD RID: 57037 RVA: 0x00333B5C File Offset: 0x00331D5C
		public override uint GetProtoType()
		{
			return 61237U;
		}

		// Token: 0x0600DECE RID: 57038 RVA: 0x00333B73 File Offset: 0x00331D73
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiskBuyData>(stream, this.Data);
		}

		// Token: 0x0600DECF RID: 57039 RVA: 0x00333B83 File Offset: 0x00331D83
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RiskBuyData>(stream);
		}

		// Token: 0x0600DED0 RID: 57040 RVA: 0x00333B92 File Offset: 0x00331D92
		public override void Process()
		{
			Process_PtcG2C_RiskBuyNtf.Process(this);
		}

		// Token: 0x04006308 RID: 25352
		public RiskBuyData Data = new RiskBuyData();
	}
}
