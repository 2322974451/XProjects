using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200114A RID: 4426
	internal class PtcG2C_ReceiveFlowerNtf : Protocol
	{
		// Token: 0x0600D9F2 RID: 55794 RVA: 0x0032C720 File Offset: 0x0032A920
		public override uint GetProtoType()
		{
			return 43606U;
		}

		// Token: 0x0600D9F3 RID: 55795 RVA: 0x0032C737 File Offset: 0x0032A937
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReceiveFlowerData>(stream, this.Data);
		}

		// Token: 0x0600D9F4 RID: 55796 RVA: 0x0032C747 File Offset: 0x0032A947
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReceiveFlowerData>(stream);
		}

		// Token: 0x0600D9F5 RID: 55797 RVA: 0x0032C756 File Offset: 0x0032A956
		public override void Process()
		{
			Process_PtcG2C_ReceiveFlowerNtf.Process(this);
		}

		// Token: 0x0400621E RID: 25118
		public ReceiveFlowerData Data = new ReceiveFlowerData();
	}
}
