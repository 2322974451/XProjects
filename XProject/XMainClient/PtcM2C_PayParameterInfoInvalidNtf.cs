using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x02001425 RID: 5157
	internal class PtcM2C_PayParameterInfoInvalidNtf : Protocol
	{
		// Token: 0x0600E59B RID: 58779 RVA: 0x0033D334 File Offset: 0x0033B534
		public override uint GetProtoType()
		{
			return 64504U;
		}

		// Token: 0x0600E59C RID: 58780 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600E59D RID: 58781 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600E59E RID: 58782 RVA: 0x0033D34B File Offset: 0x0033B54B
		public override void Process()
		{
			Process_PtcM2C_PayParameterInfoInvalidNtf.Process(this);
		}
	}
}
