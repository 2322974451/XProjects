using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011EF RID: 4591
	internal class PtcM2C_MSReceiveFlowerNtf : Protocol
	{
		// Token: 0x0600DC84 RID: 56452 RVA: 0x003307E8 File Offset: 0x0032E9E8
		public override uint GetProtoType()
		{
			return 16969U;
		}

		// Token: 0x0600DC85 RID: 56453 RVA: 0x003307FF File Offset: 0x0032E9FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReceiveFlowerData>(stream, this.Data);
		}

		// Token: 0x0600DC86 RID: 56454 RVA: 0x0033080F File Offset: 0x0032EA0F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReceiveFlowerData>(stream);
		}

		// Token: 0x0600DC87 RID: 56455 RVA: 0x0033081E File Offset: 0x0032EA1E
		public override void Process()
		{
			Process_PtcM2C_MSReceiveFlowerNtf.Process(this);
		}

		// Token: 0x04006296 RID: 25238
		public ReceiveFlowerData Data = new ReceiveFlowerData();
	}
}
