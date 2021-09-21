using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010B1 RID: 4273
	internal class PtcG2C_PkPrepareNtf : Protocol
	{
		// Token: 0x0600D780 RID: 55168 RVA: 0x003281A8 File Offset: 0x003263A8
		public override uint GetProtoType()
		{
			return 41409U;
		}

		// Token: 0x0600D781 RID: 55169 RVA: 0x003281BF File Offset: 0x003263BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkPrepareNtf>(stream, this.Data);
		}

		// Token: 0x0600D782 RID: 55170 RVA: 0x003281CF File Offset: 0x003263CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PkPrepareNtf>(stream);
		}

		// Token: 0x0600D783 RID: 55171 RVA: 0x003281DE File Offset: 0x003263DE
		public override void Process()
		{
			Process_PtcG2C_PkPrepareNtf.Process(this);
		}

		// Token: 0x040061AA RID: 25002
		public PkPrepareNtf Data = new PkPrepareNtf();
	}
}
