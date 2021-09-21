using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010C0 RID: 4288
	internal class PtcG2C_ItemCircleDrawResult : Protocol
	{
		// Token: 0x0600D7BB RID: 55227 RVA: 0x003288F4 File Offset: 0x00326AF4
		public override uint GetProtoType()
		{
			return 34574U;
		}

		// Token: 0x0600D7BC RID: 55228 RVA: 0x0032890B File Offset: 0x00326B0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CircleDrawGive>(stream, this.Data);
		}

		// Token: 0x0600D7BD RID: 55229 RVA: 0x0032891B File Offset: 0x00326B1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CircleDrawGive>(stream);
		}

		// Token: 0x0600D7BE RID: 55230 RVA: 0x0032892A File Offset: 0x00326B2A
		public override void Process()
		{
			Process_PtcG2C_ItemCircleDrawResult.Process(this);
		}

		// Token: 0x040061B4 RID: 25012
		public CircleDrawGive Data = new CircleDrawGive();
	}
}
