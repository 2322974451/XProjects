using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200121B RID: 4635
	internal class RpcC2M_ClientQueryRankListNtf : Rpc
	{
		// Token: 0x0600DD37 RID: 56631 RVA: 0x00331510 File Offset: 0x0032F710
		public override uint GetRpcType()
		{
			return 39913U;
		}

		// Token: 0x0600DD38 RID: 56632 RVA: 0x00331527 File Offset: 0x0032F727
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClientQueryRankListArg>(stream, this.oArg);
		}

		// Token: 0x0600DD39 RID: 56633 RVA: 0x00331537 File Offset: 0x0032F737
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClientQueryRankListRes>(stream);
		}

		// Token: 0x0600DD3A RID: 56634 RVA: 0x00331546 File Offset: 0x0032F746
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClientQueryRankListNtf.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD3B RID: 56635 RVA: 0x00331562 File Offset: 0x0032F762
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClientQueryRankListNtf.OnTimeout(this.oArg);
		}

		// Token: 0x040062B8 RID: 25272
		public ClientQueryRankListArg oArg = new ClientQueryRankListArg();

		// Token: 0x040062B9 RID: 25273
		public ClientQueryRankListRes oRes;
	}
}
