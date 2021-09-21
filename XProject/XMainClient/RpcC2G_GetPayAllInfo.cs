using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011D0 RID: 4560
	internal class RpcC2G_GetPayAllInfo : Rpc
	{
		// Token: 0x0600DC06 RID: 56326 RVA: 0x0032FC54 File Offset: 0x0032DE54
		public override uint GetRpcType()
		{
			return 41260U;
		}

		// Token: 0x0600DC07 RID: 56327 RVA: 0x0032FC6B File Offset: 0x0032DE6B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPayAllInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DC08 RID: 56328 RVA: 0x0032FC7B File Offset: 0x0032DE7B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPayAllInfoRes>(stream);
		}

		// Token: 0x0600DC09 RID: 56329 RVA: 0x0032FC8A File Offset: 0x0032DE8A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetPayAllInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC0A RID: 56330 RVA: 0x0032FCA6 File Offset: 0x0032DEA6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetPayAllInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400627E RID: 25214
		public GetPayAllInfoArg oArg = new GetPayAllInfoArg();

		// Token: 0x0400627F RID: 25215
		public GetPayAllInfoRes oRes = new GetPayAllInfoRes();
	}
}
