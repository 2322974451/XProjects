using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200106C RID: 4204
	internal class PtcG2C_FashoinChangedNtf : Protocol
	{
		// Token: 0x0600D668 RID: 54888 RVA: 0x003260A0 File Offset: 0x003242A0
		public override uint GetProtoType()
		{
			return 12350U;
		}

		// Token: 0x0600D669 RID: 54889 RVA: 0x003260B7 File Offset: 0x003242B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FashionChangedData>(stream, this.Data);
		}

		// Token: 0x0600D66A RID: 54890 RVA: 0x003260C7 File Offset: 0x003242C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FashionChangedData>(stream);
		}

		// Token: 0x0600D66B RID: 54891 RVA: 0x003260D6 File Offset: 0x003242D6
		public override void Process()
		{
			Process_PtcG2C_FashoinChangedNtf.Process(this);
		}

		// Token: 0x04006176 RID: 24950
		public FashionChangedData Data = new FashionChangedData();
	}
}
