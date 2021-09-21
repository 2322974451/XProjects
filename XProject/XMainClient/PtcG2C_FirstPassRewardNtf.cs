using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001213 RID: 4627
	internal class PtcG2C_FirstPassRewardNtf : Protocol
	{
		// Token: 0x0600DD15 RID: 56597 RVA: 0x003312E4 File Offset: 0x0032F4E4
		public override uint GetProtoType()
		{
			return 19007U;
		}

		// Token: 0x0600DD16 RID: 56598 RVA: 0x003312FB File Offset: 0x0032F4FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FirstPassRewardNtfData>(stream, this.Data);
		}

		// Token: 0x0600DD17 RID: 56599 RVA: 0x0033130B File Offset: 0x0032F50B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FirstPassRewardNtfData>(stream);
		}

		// Token: 0x0600DD18 RID: 56600 RVA: 0x0033131A File Offset: 0x0032F51A
		public override void Process()
		{
			Process_PtcG2C_FirstPassRewardNtf.Process(this);
		}

		// Token: 0x040062B1 RID: 25265
		public FirstPassRewardNtfData Data = new FirstPassRewardNtfData();
	}
}
