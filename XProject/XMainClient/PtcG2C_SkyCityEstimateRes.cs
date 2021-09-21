using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012CE RID: 4814
	internal class PtcG2C_SkyCityEstimateRes : Protocol
	{
		// Token: 0x0600E01B RID: 57371 RVA: 0x003358D8 File Offset: 0x00333AD8
		public override uint GetProtoType()
		{
			return 36139U;
		}

		// Token: 0x0600E01C RID: 57372 RVA: 0x003358EF File Offset: 0x00333AEF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityEstimateInfo>(stream, this.Data);
		}

		// Token: 0x0600E01D RID: 57373 RVA: 0x003358FF File Offset: 0x00333AFF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityEstimateInfo>(stream);
		}

		// Token: 0x0600E01E RID: 57374 RVA: 0x0033590E File Offset: 0x00333B0E
		public override void Process()
		{
			Process_PtcG2C_SkyCityEstimateRes.Process(this);
		}

		// Token: 0x04006349 RID: 25417
		public SkyCityEstimateInfo Data = new SkyCityEstimateInfo();
	}
}
