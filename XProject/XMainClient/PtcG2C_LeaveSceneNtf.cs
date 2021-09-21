using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x02000FFC RID: 4092
	internal class PtcG2C_LeaveSceneNtf : Protocol
	{
		// Token: 0x0600D497 RID: 54423 RVA: 0x00321998 File Offset: 0x0031FB98
		public override uint GetProtoType()
		{
			return 33831U;
		}

		// Token: 0x0600D498 RID: 54424 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D499 RID: 54425 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D49A RID: 54426 RVA: 0x003219AF File Offset: 0x0031FBAF
		public override void Process()
		{
			Process_PtcG2C_LeaveSceneNtf.Process(this);
		}
	}
}
