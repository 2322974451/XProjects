using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001000 RID: 4096
	internal class PtcC2G_MoveOperationReq : Protocol
	{
		// Token: 0x0600D4A8 RID: 54440 RVA: 0x00321AAC File Offset: 0x0031FCAC
		public override uint GetProtoType()
		{
			return 30732U;
		}

		// Token: 0x0600D4A9 RID: 54441 RVA: 0x00321AC3 File Offset: 0x0031FCC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MoveInfo>(stream, this.Data);
		}

		// Token: 0x0600D4AA RID: 54442 RVA: 0x00321AD3 File Offset: 0x0031FCD3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MoveInfo>(stream);
		}

		// Token: 0x0600D4AB RID: 54443 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040060F8 RID: 24824
		public MoveInfo Data = new MoveInfo();
	}
}
