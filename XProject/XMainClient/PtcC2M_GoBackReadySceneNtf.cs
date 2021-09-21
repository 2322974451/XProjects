using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015E4 RID: 5604
	internal class PtcC2M_GoBackReadySceneNtf : Protocol
	{
		// Token: 0x0600ECBB RID: 60603 RVA: 0x00347720 File Offset: 0x00345920
		public override uint GetProtoType()
		{
			return 10491U;
		}

		// Token: 0x0600ECBC RID: 60604 RVA: 0x00347737 File Offset: 0x00345937
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoBackReadyScene>(stream, this.Data);
		}

		// Token: 0x0600ECBD RID: 60605 RVA: 0x00347747 File Offset: 0x00345947
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GoBackReadyScene>(stream);
		}

		// Token: 0x0600ECBE RID: 60606 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040065B9 RID: 26041
		public GoBackReadyScene Data = new GoBackReadyScene();
	}
}
