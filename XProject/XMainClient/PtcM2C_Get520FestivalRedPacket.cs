using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016B3 RID: 5811
	internal class PtcM2C_Get520FestivalRedPacket : Protocol
	{
		// Token: 0x0600F027 RID: 61479 RVA: 0x0034C430 File Offset: 0x0034A630
		public override uint GetProtoType()
		{
			return 28202U;
		}

		// Token: 0x0600F028 RID: 61480 RVA: 0x0034C447 File Offset: 0x0034A647
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Get520FestivalRedPacket>(stream, this.Data);
		}

		// Token: 0x0600F029 RID: 61481 RVA: 0x0034C457 File Offset: 0x0034A657
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<Get520FestivalRedPacket>(stream);
		}

		// Token: 0x0600F02A RID: 61482 RVA: 0x0034C466 File Offset: 0x0034A666
		public override void Process()
		{
			Process_PtcM2C_Get520FestivalRedPacket.Process(this);
		}

		// Token: 0x04006672 RID: 26226
		public Get520FestivalRedPacket Data = new Get520FestivalRedPacket();
	}
}
