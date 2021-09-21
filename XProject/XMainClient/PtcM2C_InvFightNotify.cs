using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013F6 RID: 5110
	internal class PtcM2C_InvFightNotify : Protocol
	{
		// Token: 0x0600E4DD RID: 58589 RVA: 0x0033C390 File Offset: 0x0033A590
		public override uint GetProtoType()
		{
			return 38172U;
		}

		// Token: 0x0600E4DE RID: 58590 RVA: 0x0033C3A7 File Offset: 0x0033A5A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightPara>(stream, this.Data);
		}

		// Token: 0x0600E4DF RID: 58591 RVA: 0x0033C3B7 File Offset: 0x0033A5B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvFightPara>(stream);
		}

		// Token: 0x0600E4E0 RID: 58592 RVA: 0x0033C3C6 File Offset: 0x0033A5C6
		public override void Process()
		{
			Process_PtcM2C_InvFightNotify.Process(this);
		}

		// Token: 0x04006435 RID: 25653
		public InvFightPara Data = new InvFightPara();
	}
}
