using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001190 RID: 4496
	internal class PtcG2C_NotifyGuildBossAddAttr : Protocol
	{
		// Token: 0x0600DB09 RID: 56073 RVA: 0x0032E660 File Offset: 0x0032C860
		public override uint GetProtoType()
		{
			return 42027U;
		}

		// Token: 0x0600DB0A RID: 56074 RVA: 0x0032E677 File Offset: 0x0032C877
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddAttrCount>(stream, this.Data);
		}

		// Token: 0x0600DB0B RID: 56075 RVA: 0x0032E687 File Offset: 0x0032C887
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AddAttrCount>(stream);
		}

		// Token: 0x0600DB0C RID: 56076 RVA: 0x0032E696 File Offset: 0x0032C896
		public override void Process()
		{
			Process_PtcG2C_NotifyGuildBossAddAttr.Process(this);
		}

		// Token: 0x04006251 RID: 25169
		public AddAttrCount Data = new AddAttrCount();
	}
}
