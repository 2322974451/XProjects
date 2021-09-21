using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016A2 RID: 5794
	internal class PtcM2C_MarriageLevelValueNtf : Protocol
	{
		// Token: 0x0600EFDE RID: 61406 RVA: 0x0034C014 File Offset: 0x0034A214
		public override uint GetProtoType()
		{
			return 3559U;
		}

		// Token: 0x0600EFDF RID: 61407 RVA: 0x0034C02B File Offset: 0x0034A22B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MarriageLevelValueNtfData>(stream, this.Data);
		}

		// Token: 0x0600EFE0 RID: 61408 RVA: 0x0034C03B File Offset: 0x0034A23B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MarriageLevelValueNtfData>(stream);
		}

		// Token: 0x0600EFE1 RID: 61409 RVA: 0x0034C04A File Offset: 0x0034A24A
		public override void Process()
		{
			Process_PtcM2C_MarriageLevelValueNtf.Process(this);
		}

		// Token: 0x04006663 RID: 26211
		public MarriageLevelValueNtfData Data = new MarriageLevelValueNtfData();
	}
}
