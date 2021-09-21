using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013A6 RID: 5030
	internal class PtcG2C_SynGuildInheritNumInfo : Protocol
	{
		// Token: 0x0600E395 RID: 58261 RVA: 0x0033A8A8 File Offset: 0x00338AA8
		public override uint GetProtoType()
		{
			return 54442U;
		}

		// Token: 0x0600E396 RID: 58262 RVA: 0x0033A8BF File Offset: 0x00338ABF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynGuildInheritNumInfo>(stream, this.Data);
		}

		// Token: 0x0600E397 RID: 58263 RVA: 0x0033A8CF File Offset: 0x00338ACF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynGuildInheritNumInfo>(stream);
		}

		// Token: 0x0600E398 RID: 58264 RVA: 0x0033A8DE File Offset: 0x00338ADE
		public override void Process()
		{
			Process_PtcG2C_SynGuildInheritNumInfo.Process(this);
		}

		// Token: 0x040063F6 RID: 25590
		public SynGuildInheritNumInfo Data = new SynGuildInheritNumInfo();
	}
}
