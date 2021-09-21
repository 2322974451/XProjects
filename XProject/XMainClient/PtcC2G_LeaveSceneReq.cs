using System;
using System.IO;

namespace XMainClient
{
	// Token: 0x02000FFB RID: 4091
	internal class PtcC2G_LeaveSceneReq : Protocol
	{
		// Token: 0x0600D492 RID: 54418 RVA: 0x00321980 File Offset: 0x0031FB80
		public override uint GetProtoType()
		{
			return 27927U;
		}

		// Token: 0x0600D493 RID: 54419 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Serialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D494 RID: 54420 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void DeSerialize(MemoryStream stream)
		{
		}

		// Token: 0x0600D495 RID: 54421 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}
	}
}
