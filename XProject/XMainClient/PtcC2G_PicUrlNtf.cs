using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013E2 RID: 5090
	internal class PtcC2G_PicUrlNtf : Protocol
	{
		// Token: 0x0600E486 RID: 58502 RVA: 0x0033BD84 File Offset: 0x00339F84
		public override uint GetProtoType()
		{
			return 30863U;
		}

		// Token: 0x0600E487 RID: 58503 RVA: 0x0033BD9B File Offset: 0x00339F9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PicUrlInfo>(stream, this.Data);
		}

		// Token: 0x0600E488 RID: 58504 RVA: 0x0033BDAB File Offset: 0x00339FAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PicUrlInfo>(stream);
		}

		// Token: 0x0600E489 RID: 58505 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006423 RID: 25635
		public PicUrlInfo Data = new PicUrlInfo();
	}
}
