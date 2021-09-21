using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001211 RID: 4625
	internal class RpcC2G_FirstPassInfoReq : Rpc
	{
		// Token: 0x0600DD0C RID: 56588 RVA: 0x0033125C File Offset: 0x0032F45C
		public override uint GetRpcType()
		{
			return 4147U;
		}

		// Token: 0x0600DD0D RID: 56589 RVA: 0x00331273 File Offset: 0x0032F473
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FirstPassInfoReqArg>(stream, this.oArg);
		}

		// Token: 0x0600DD0E RID: 56590 RVA: 0x00331283 File Offset: 0x0032F483
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FirstPassInfoReqRes>(stream);
		}

		// Token: 0x0600DD0F RID: 56591 RVA: 0x00331292 File Offset: 0x0032F492
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FirstPassInfoReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD10 RID: 56592 RVA: 0x003312AE File Offset: 0x0032F4AE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FirstPassInfoReq.OnTimeout(this.oArg);
		}

		// Token: 0x040062AF RID: 25263
		public FirstPassInfoReqArg oArg = new FirstPassInfoReqArg();

		// Token: 0x040062B0 RID: 25264
		public FirstPassInfoReqRes oRes = new FirstPassInfoReqRes();
	}
}
