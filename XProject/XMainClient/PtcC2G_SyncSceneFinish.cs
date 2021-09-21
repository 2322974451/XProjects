using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x020010FF RID: 4351
	internal class PtcC2G_SyncSceneFinish : Protocol
	{
		// Token: 0x0600D8B9 RID: 55481 RVA: 0x00329F58 File Offset: 0x00328158
		public override uint GetProtoType()
		{
			return 559U;
		}

		// Token: 0x0600D8BA RID: 55482 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D8BB RID: 55483 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D8BC RID: 55484 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}
	}
}
