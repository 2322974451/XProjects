using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001508 RID: 5384
	internal class RpcC2G_ReplyPartyExchangeItemOpt : Rpc
	{
		// Token: 0x0600E936 RID: 59702 RVA: 0x003425B8 File Offset: 0x003407B8
		public override uint GetRpcType()
		{
			return 13740U;
		}

		// Token: 0x0600E937 RID: 59703 RVA: 0x003425CF File Offset: 0x003407CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReplyPartyExchangeItemOptArg>(stream, this.oArg);
		}

		// Token: 0x0600E938 RID: 59704 RVA: 0x003425DF File Offset: 0x003407DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReplyPartyExchangeItemOptRes>(stream);
		}

		// Token: 0x0600E939 RID: 59705 RVA: 0x003425EE File Offset: 0x003407EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReplyPartyExchangeItemOpt.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E93A RID: 59706 RVA: 0x0034260A File Offset: 0x0034080A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReplyPartyExchangeItemOpt.OnTimeout(this.oArg);
		}

		// Token: 0x04006506 RID: 25862
		public ReplyPartyExchangeItemOptArg oArg = new ReplyPartyExchangeItemOptArg();

		// Token: 0x04006507 RID: 25863
		public ReplyPartyExchangeItemOptRes oRes = null;
	}
}
