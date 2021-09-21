using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B46 RID: 2886
	internal class RpcC2M_AskGuildWageInfo : Rpc
	{
		// Token: 0x0600A888 RID: 43144 RVA: 0x001E0BCC File Offset: 0x001DEDCC
		public override uint GetRpcType()
		{
			return 17779U;
		}

		// Token: 0x0600A889 RID: 43145 RVA: 0x001E0BE3 File Offset: 0x001DEDE3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildWageInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600A88A RID: 43146 RVA: 0x001E0BF3 File Offset: 0x001DEDF3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildWageInfoRes>(stream);
		}

		// Token: 0x0600A88B RID: 43147 RVA: 0x001E0C02 File Offset: 0x001DEE02
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildWageInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A88C RID: 43148 RVA: 0x001E0C1E File Offset: 0x001DEE1E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildWageInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04003E75 RID: 15989
		public AskGuildWageInfoArg oArg = new AskGuildWageInfoArg();

		// Token: 0x04003E76 RID: 15990
		public AskGuildWageInfoRes oRes = null;
	}
}
