using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016AD RID: 5805
	internal class RpcC2G_GetJadeSealAllInfo : Rpc
	{
		// Token: 0x0600F00E RID: 61454 RVA: 0x0034C2E4 File Offset: 0x0034A4E4
		public override uint GetRpcType()
		{
			return 2424U;
		}

		// Token: 0x0600F00F RID: 61455 RVA: 0x0034C2FB File Offset: 0x0034A4FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetJadeSealAllInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600F010 RID: 61456 RVA: 0x0034C30B File Offset: 0x0034A50B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetJadeSealAllInfoRes>(stream);
		}

		// Token: 0x0600F011 RID: 61457 RVA: 0x0034C31A File Offset: 0x0034A51A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetJadeSealAllInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600F012 RID: 61458 RVA: 0x0034C336 File Offset: 0x0034A536
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetJadeSealAllInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400666D RID: 26221
		public GetJadeSealAllInfoArg oArg = new GetJadeSealAllInfoArg();

		// Token: 0x0400666E RID: 26222
		public GetJadeSealAllInfoRes oRes = null;
	}
}
