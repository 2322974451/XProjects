using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010D4 RID: 4308
	internal class PtcG2C_TeleportNotice : Protocol
	{
		// Token: 0x0600D809 RID: 55305 RVA: 0x00328F78 File Offset: 0x00327178
		public override uint GetProtoType()
		{
			return 27305U;
		}

		// Token: 0x0600D80A RID: 55306 RVA: 0x00328F8F File Offset: 0x0032718F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeleportNoticeState>(stream, this.Data);
		}

		// Token: 0x0600D80B RID: 55307 RVA: 0x00328F9F File Offset: 0x0032719F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeleportNoticeState>(stream);
		}

		// Token: 0x0600D80C RID: 55308 RVA: 0x00328FAE File Offset: 0x003271AE
		public override void Process()
		{
			Process_PtcG2C_TeleportNotice.Process(this);
		}

		// Token: 0x040061C0 RID: 25024
		public TeleportNoticeState Data = new TeleportNoticeState();
	}
}
