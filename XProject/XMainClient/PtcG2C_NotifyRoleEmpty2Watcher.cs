using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x0200118A RID: 4490
	internal class PtcG2C_NotifyRoleEmpty2Watcher : Protocol
	{
		// Token: 0x0600DAF4 RID: 56052 RVA: 0x0032E4AC File Offset: 0x0032C6AC
		public override uint GetProtoType()
		{
			return 1540U;
		}

		// Token: 0x0600DAF5 RID: 56053 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600DAF6 RID: 56054 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600DAF7 RID: 56055 RVA: 0x0032E4C3 File Offset: 0x0032C6C3
		public override void Process()
		{
			Process_PtcG2C_NotifyRoleEmpty2Watcher.Process(this);
		}
	}
}
