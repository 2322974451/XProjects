using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B5A RID: 2906
	internal class PtcG2C_TajieHelpNotify : Protocol
	{
		// Token: 0x0600A8F6 RID: 43254 RVA: 0x001E1428 File Offset: 0x001DF628
		public override uint GetProtoType()
		{
			return 36521U;
		}

		// Token: 0x0600A8F7 RID: 43255 RVA: 0x001E143F File Offset: 0x001DF63F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TajieHelpData>(stream, this.Data);
		}

		// Token: 0x0600A8F8 RID: 43256 RVA: 0x001E144F File Offset: 0x001DF64F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TajieHelpData>(stream);
		}

		// Token: 0x0600A8F9 RID: 43257 RVA: 0x001E145E File Offset: 0x001DF65E
		public override void Process()
		{
			Process_PtcG2C_TajieHelpNotify.Process(this);
		}

		// Token: 0x04003E93 RID: 16019
		public TajieHelpData Data = new TajieHelpData();
	}
}
