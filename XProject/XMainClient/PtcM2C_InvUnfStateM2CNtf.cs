using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001327 RID: 4903
	internal class PtcM2C_InvUnfStateM2CNtf : Protocol
	{
		// Token: 0x0600E18C RID: 57740 RVA: 0x00337C10 File Offset: 0x00335E10
		public override uint GetProtoType()
		{
			return 2693U;
		}

		// Token: 0x0600E18D RID: 57741 RVA: 0x00337C27 File Offset: 0x00335E27
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvUnfState>(stream, this.Data);
		}

		// Token: 0x0600E18E RID: 57742 RVA: 0x00337C37 File Offset: 0x00335E37
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvUnfState>(stream);
		}

		// Token: 0x0600E18F RID: 57743 RVA: 0x00337C46 File Offset: 0x00335E46
		public override void Process()
		{
			Process_PtcM2C_InvUnfStateM2CNtf.Process(this);
		}

		// Token: 0x04006391 RID: 25489
		public InvUnfState Data = new InvUnfState();
	}
}
