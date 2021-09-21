using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001005 RID: 4101
	internal class PtcC2G_CastSkill : Protocol
	{
		// Token: 0x0600D4BD RID: 54461 RVA: 0x00321E20 File Offset: 0x00320020
		public override uint GetProtoType()
		{
			return 49584U;
		}

		// Token: 0x0600D4BE RID: 54462 RVA: 0x00321E37 File Offset: 0x00320037
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillDataUnit>(stream, this.Data);
		}

		// Token: 0x0600D4BF RID: 54463 RVA: 0x00321E47 File Offset: 0x00320047
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillDataUnit>(stream);
		}

		// Token: 0x0600D4C0 RID: 54464 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006100 RID: 24832
		public SkillDataUnit Data = new SkillDataUnit();
	}
}
