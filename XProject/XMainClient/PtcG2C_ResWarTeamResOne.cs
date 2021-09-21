using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001356 RID: 4950
	internal class PtcG2C_ResWarTeamResOne : Protocol
	{
		// Token: 0x0600E24A RID: 57930 RVA: 0x00338D3C File Offset: 0x00336F3C
		public override uint GetProtoType()
		{
			return 8869U;
		}

		// Token: 0x0600E24B RID: 57931 RVA: 0x00338D53 File Offset: 0x00336F53
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarAllTeamBaseInfo>(stream, this.Data);
		}

		// Token: 0x0600E24C RID: 57932 RVA: 0x00338D63 File Offset: 0x00336F63
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarAllTeamBaseInfo>(stream);
		}

		// Token: 0x0600E24D RID: 57933 RVA: 0x00338D72 File Offset: 0x00336F72
		public override void Process()
		{
			Process_PtcG2C_ResWarTeamResOne.Process(this);
		}

		// Token: 0x040063B5 RID: 25525
		public ResWarAllTeamBaseInfo Data = new ResWarAllTeamBaseInfo();
	}
}
