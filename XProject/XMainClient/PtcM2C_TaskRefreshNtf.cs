using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001661 RID: 5729
	internal class PtcM2C_TaskRefreshNtf : Protocol
	{
		// Token: 0x0600EED1 RID: 61137 RVA: 0x0034A534 File Offset: 0x00348734
		public override uint GetProtoType()
		{
			return 40464U;
		}

		// Token: 0x0600EED2 RID: 61138 RVA: 0x0034A54B File Offset: 0x0034874B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TaskRefreshNtf>(stream, this.Data);
		}

		// Token: 0x0600EED3 RID: 61139 RVA: 0x0034A55B File Offset: 0x0034875B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TaskRefreshNtf>(stream);
		}

		// Token: 0x0600EED4 RID: 61140 RVA: 0x0034A56A File Offset: 0x0034876A
		public override void Process()
		{
			Process_PtcM2C_TaskRefreshNtf.Process(this);
		}

		// Token: 0x04006627 RID: 26151
		public TaskRefreshNtf Data = new TaskRefreshNtf();
	}
}
