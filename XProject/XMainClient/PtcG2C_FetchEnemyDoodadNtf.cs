using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010AE RID: 4270
	internal class PtcG2C_FetchEnemyDoodadNtf : Protocol
	{
		// Token: 0x0600D774 RID: 55156 RVA: 0x00327F08 File Offset: 0x00326108
		public override uint GetProtoType()
		{
			return 50480U;
		}

		// Token: 0x0600D775 RID: 55157 RVA: 0x00327F1F File Offset: 0x0032611F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OtherFetchDoodadRes>(stream, this.Data);
		}

		// Token: 0x0600D776 RID: 55158 RVA: 0x00327F2F File Offset: 0x0032612F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OtherFetchDoodadRes>(stream);
		}

		// Token: 0x0600D777 RID: 55159 RVA: 0x00327F3E File Offset: 0x0032613E
		public override void Process()
		{
			Process_PtcG2C_FetchEnemyDoodadNtf.Process(this);
		}

		// Token: 0x040061A8 RID: 25000
		public OtherFetchDoodadRes Data = new OtherFetchDoodadRes();
	}
}
