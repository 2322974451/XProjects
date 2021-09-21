using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013D0 RID: 5072
	internal class RpcC2M_GetMyMentorInfo : Rpc
	{
		// Token: 0x0600E439 RID: 58425 RVA: 0x0033B630 File Offset: 0x00339830
		public override uint GetRpcType()
		{
			return 8287U;
		}

		// Token: 0x0600E43A RID: 58426 RVA: 0x0033B647 File Offset: 0x00339847
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyMentorInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E43B RID: 58427 RVA: 0x0033B657 File Offset: 0x00339857
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyMentorInfoRes>(stream);
		}

		// Token: 0x0600E43C RID: 58428 RVA: 0x0033B666 File Offset: 0x00339866
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMyMentorInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E43D RID: 58429 RVA: 0x0033B682 File Offset: 0x00339882
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMyMentorInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006413 RID: 25619
		public GetMyMentorInfoArg oArg = new GetMyMentorInfoArg();

		// Token: 0x04006414 RID: 25620
		public GetMyMentorInfoRes oRes = null;
	}
}
