using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001364 RID: 4964
	internal class PtcM2C_ResWarGuildBriefNtf : Protocol
	{
		// Token: 0x0600E284 RID: 57988 RVA: 0x003392E0 File Offset: 0x003374E0
		public override uint GetProtoType()
		{
			return 35338U;
		}

		// Token: 0x0600E285 RID: 57989 RVA: 0x003392F7 File Offset: 0x003374F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarGuildBrief>(stream, this.Data);
		}

		// Token: 0x0600E286 RID: 57990 RVA: 0x00339307 File Offset: 0x00337507
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarGuildBrief>(stream);
		}

		// Token: 0x0600E287 RID: 57991 RVA: 0x00339316 File Offset: 0x00337516
		public override void Process()
		{
			Process_PtcM2C_ResWarGuildBriefNtf.Process(this);
		}

		// Token: 0x040063C1 RID: 25537
		public ResWarGuildBrief Data = new ResWarGuildBrief();
	}
}
