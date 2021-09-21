using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001006 RID: 4102
	internal class PtcG2C_SkillResult : Protocol
	{
		// Token: 0x0600D4C2 RID: 54466 RVA: 0x00321E6C File Offset: 0x0032006C
		public override uint GetProtoType()
		{
			return 1054U;
		}

		// Token: 0x0600D4C3 RID: 54467 RVA: 0x00321E83 File Offset: 0x00320083
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillReplyDataUnit>(stream, this.Data);
		}

		// Token: 0x0600D4C4 RID: 54468 RVA: 0x00321E93 File Offset: 0x00320093
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillReplyDataUnit>(stream);
		}

		// Token: 0x0600D4C5 RID: 54469 RVA: 0x00321EA2 File Offset: 0x003200A2
		public override void Process()
		{
			Process_PtcG2C_SkillResult.Process(this);
		}

		// Token: 0x04006101 RID: 24833
		public SkillReplyDataUnit Data = new SkillReplyDataUnit();
	}
}
