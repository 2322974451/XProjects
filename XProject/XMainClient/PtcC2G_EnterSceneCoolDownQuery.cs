using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001065 RID: 4197
	internal class PtcC2G_EnterSceneCoolDownQuery : Protocol
	{
		// Token: 0x0600D64C RID: 54860 RVA: 0x00325E74 File Offset: 0x00324074
		public override uint GetProtoType()
		{
			return 40442U;
		}

		// Token: 0x0600D64D RID: 54861 RVA: 0x00325E8B File Offset: 0x0032408B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterSceneCoolDownQuery>(stream, this.Data);
		}

		// Token: 0x0600D64E RID: 54862 RVA: 0x00325E9B File Offset: 0x0032409B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<EnterSceneCoolDownQuery>(stream);
		}

		// Token: 0x0600D64F RID: 54863 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006171 RID: 24945
		public EnterSceneCoolDownQuery Data = new EnterSceneCoolDownQuery();
	}
}
