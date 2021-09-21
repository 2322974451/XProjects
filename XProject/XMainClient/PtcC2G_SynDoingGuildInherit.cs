using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013A3 RID: 5027
	internal class PtcC2G_SynDoingGuildInherit : Protocol
	{
		// Token: 0x0600E389 RID: 58249 RVA: 0x0033A804 File Offset: 0x00338A04
		public override uint GetProtoType()
		{
			return 51759U;
		}

		// Token: 0x0600E38A RID: 58250 RVA: 0x0033A81B File Offset: 0x00338A1B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynDoingGuildInherit>(stream, this.Data);
		}

		// Token: 0x0600E38B RID: 58251 RVA: 0x0033A82B File Offset: 0x00338A2B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynDoingGuildInherit>(stream);
		}

		// Token: 0x0600E38C RID: 58252 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040063F4 RID: 25588
		public SynDoingGuildInherit Data = new SynDoingGuildInherit();
	}
}
