using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013BB RID: 5051
	internal class PtcM2C_ResWarTimeNtf : Protocol
	{
		// Token: 0x0600E3EA RID: 58346 RVA: 0x0033B02C File Offset: 0x0033922C
		public override uint GetProtoType()
		{
			return 36825U;
		}

		// Token: 0x0600E3EB RID: 58347 RVA: 0x0033B043 File Offset: 0x00339243
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarTime>(stream, this.Data);
		}

		// Token: 0x0600E3EC RID: 58348 RVA: 0x0033B053 File Offset: 0x00339253
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarTime>(stream);
		}

		// Token: 0x0600E3ED RID: 58349 RVA: 0x0033B062 File Offset: 0x00339262
		public override void Process()
		{
			Process_PtcM2C_ResWarTimeNtf.Process(this);
		}

		// Token: 0x04006406 RID: 25606
		public ResWarTime Data = new ResWarTime();
	}
}
