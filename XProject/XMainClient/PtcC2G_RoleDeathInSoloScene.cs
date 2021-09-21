using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x0200105E RID: 4190
	internal class PtcC2G_RoleDeathInSoloScene : Protocol
	{
		// Token: 0x0600D630 RID: 54832 RVA: 0x00325C38 File Offset: 0x00323E38
		public override uint GetProtoType()
		{
			return 16659U;
		}

		// Token: 0x0600D631 RID: 54833 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D632 RID: 54834 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D633 RID: 54835 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}
	}
}
