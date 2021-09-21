using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013A8 RID: 5032
	internal class PtcM2C_ResWarMineDataNtf : Protocol
	{
		// Token: 0x0600E39C RID: 58268 RVA: 0x0033A924 File Offset: 0x00338B24
		public override uint GetProtoType()
		{
			return 57215U;
		}

		// Token: 0x0600E39D RID: 58269 RVA: 0x0033A93B File Offset: 0x00338B3B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarMineData>(stream, this.Data);
		}

		// Token: 0x0600E39E RID: 58270 RVA: 0x0033A94B File Offset: 0x00338B4B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarMineData>(stream);
		}

		// Token: 0x0600E39F RID: 58271 RVA: 0x0033A95A File Offset: 0x00338B5A
		public override void Process()
		{
			Process_PtcM2C_ResWarMineDataNtf.Process(this);
		}

		// Token: 0x040063F7 RID: 25591
		public ResWarMineData Data = new ResWarMineData();
	}
}
