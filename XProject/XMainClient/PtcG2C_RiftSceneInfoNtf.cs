using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200167E RID: 5758
	internal class PtcG2C_RiftSceneInfoNtf : Protocol
	{
		// Token: 0x0600EF48 RID: 61256 RVA: 0x0034B114 File Offset: 0x00349314
		public override uint GetProtoType()
		{
			return 17975U;
		}

		// Token: 0x0600EF49 RID: 61257 RVA: 0x0034B12B File Offset: 0x0034932B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiftSceneInfoNtfData>(stream, this.Data);
		}

		// Token: 0x0600EF4A RID: 61258 RVA: 0x0034B13B File Offset: 0x0034933B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RiftSceneInfoNtfData>(stream);
		}

		// Token: 0x0600EF4B RID: 61259 RVA: 0x0034B14A File Offset: 0x0034934A
		public override void Process()
		{
			Process_PtcG2C_RiftSceneInfoNtf.Process(this);
		}

		// Token: 0x04006645 RID: 26181
		public RiftSceneInfoNtfData Data = new RiftSceneInfoNtfData();
	}
}
