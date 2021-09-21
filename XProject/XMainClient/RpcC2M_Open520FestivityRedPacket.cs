using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016B5 RID: 5813
	internal class RpcC2M_Open520FestivityRedPacket : Rpc
	{
		// Token: 0x0600F02E RID: 61486 RVA: 0x0034C48C File Offset: 0x0034A68C
		public override uint GetRpcType()
		{
			return 57488U;
		}

		// Token: 0x0600F02F RID: 61487 RVA: 0x0034C4A3 File Offset: 0x0034A6A3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Open520FestivityRedPacketArg>(stream, this.oArg);
		}

		// Token: 0x0600F030 RID: 61488 RVA: 0x0034C4B3 File Offset: 0x0034A6B3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<Open520FestivityRedPacketRes>(stream);
		}

		// Token: 0x0600F031 RID: 61489 RVA: 0x0034C4C2 File Offset: 0x0034A6C2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_Open520FestivityRedPacket.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600F032 RID: 61490 RVA: 0x0034C4DE File Offset: 0x0034A6DE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_Open520FestivityRedPacket.OnTimeout(this.oArg);
		}

		// Token: 0x04006673 RID: 26227
		public Open520FestivityRedPacketArg oArg = new Open520FestivityRedPacketArg();

		// Token: 0x04006674 RID: 26228
		public Open520FestivityRedPacketRes oRes = null;
	}
}
