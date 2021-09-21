using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011B5 RID: 4533
	internal class PtcG2C_OnTransferWall : Protocol
	{
		// Token: 0x0600DB9D RID: 56221 RVA: 0x0032F4A8 File Offset: 0x0032D6A8
		public override uint GetProtoType()
		{
			return 37585U;
		}

		// Token: 0x0600DB9E RID: 56222 RVA: 0x0032F4BF File Offset: 0x0032D6BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyTransferWall>(stream, this.Data);
		}

		// Token: 0x0600DB9F RID: 56223 RVA: 0x0032F4CF File Offset: 0x0032D6CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyTransferWall>(stream);
		}

		// Token: 0x0600DBA0 RID: 56224 RVA: 0x0032F4DE File Offset: 0x0032D6DE
		public override void Process()
		{
			Process_PtcG2C_OnTransferWall.Process(this);
		}

		// Token: 0x0400626C RID: 25196
		public NotifyTransferWall Data = new NotifyTransferWall();
	}
}
