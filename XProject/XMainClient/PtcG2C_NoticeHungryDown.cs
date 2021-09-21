using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200120D RID: 4621
	internal class PtcG2C_NoticeHungryDown : Protocol
	{
		// Token: 0x0600DCFC RID: 56572 RVA: 0x00331130 File Offset: 0x0032F330
		public override uint GetProtoType()
		{
			return 36895U;
		}

		// Token: 0x0600DCFD RID: 56573 RVA: 0x00331147 File Offset: 0x0032F347
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeHungryDown>(stream, this.Data);
		}

		// Token: 0x0600DCFE RID: 56574 RVA: 0x00331157 File Offset: 0x0032F357
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeHungryDown>(stream);
		}

		// Token: 0x0600DCFF RID: 56575 RVA: 0x00331166 File Offset: 0x0032F366
		public override void Process()
		{
			Process_PtcG2C_NoticeHungryDown.Process(this);
		}

		// Token: 0x040062AC RID: 25260
		public NoticeHungryDown Data = new NoticeHungryDown();
	}
}
