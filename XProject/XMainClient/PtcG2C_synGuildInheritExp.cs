using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200139D RID: 5021
	internal class PtcG2C_synGuildInheritExp : Protocol
	{
		// Token: 0x0600E370 RID: 58224 RVA: 0x0033A610 File Offset: 0x00338810
		public override uint GetProtoType()
		{
			return 15872U;
		}

		// Token: 0x0600E371 RID: 58225 RVA: 0x0033A627 File Offset: 0x00338827
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<synGuildInheritExp>(stream, this.Data);
		}

		// Token: 0x0600E372 RID: 58226 RVA: 0x0033A637 File Offset: 0x00338837
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<synGuildInheritExp>(stream);
		}

		// Token: 0x0600E373 RID: 58227 RVA: 0x0033A646 File Offset: 0x00338846
		public override void Process()
		{
			Process_PtcG2C_synGuildInheritExp.Process(this);
		}

		// Token: 0x040063EF RID: 25583
		public synGuildInheritExp Data = new synGuildInheritExp();
	}
}
