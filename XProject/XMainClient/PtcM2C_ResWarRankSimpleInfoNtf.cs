using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001381 RID: 4993
	internal class PtcM2C_ResWarRankSimpleInfoNtf : Protocol
	{
		// Token: 0x0600E2FB RID: 58107 RVA: 0x00339CA4 File Offset: 0x00337EA4
		public override uint GetProtoType()
		{
			return 29973U;
		}

		// Token: 0x0600E2FC RID: 58108 RVA: 0x00339CBB File Offset: 0x00337EBB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarRankSimpleInfo>(stream, this.Data);
		}

		// Token: 0x0600E2FD RID: 58109 RVA: 0x00339CCB File Offset: 0x00337ECB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarRankSimpleInfo>(stream);
		}

		// Token: 0x0600E2FE RID: 58110 RVA: 0x00339CDA File Offset: 0x00337EDA
		public override void Process()
		{
			Process_PtcM2C_ResWarRankSimpleInfoNtf.Process(this);
		}

		// Token: 0x040063D8 RID: 25560
		public ResWarRankSimpleInfo Data = new ResWarRankSimpleInfo();
	}
}
