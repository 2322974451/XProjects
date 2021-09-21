using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013AE RID: 5038
	internal class RpcC2M_FetchPlatNotice : Rpc
	{
		// Token: 0x0600E3B5 RID: 58293 RVA: 0x0033AACC File Offset: 0x00338CCC
		public override uint GetRpcType()
		{
			return 60271U;
		}

		// Token: 0x0600E3B6 RID: 58294 RVA: 0x0033AAE3 File Offset: 0x00338CE3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchPlatNoticeArg>(stream, this.oArg);
		}

		// Token: 0x0600E3B7 RID: 58295 RVA: 0x0033AAF3 File Offset: 0x00338CF3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchPlatNoticeRes>(stream);
		}

		// Token: 0x0600E3B8 RID: 58296 RVA: 0x0033AB02 File Offset: 0x00338D02
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchPlatNotice.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E3B9 RID: 58297 RVA: 0x0033AB1E File Offset: 0x00338D1E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchPlatNotice.OnTimeout(this.oArg);
		}

		// Token: 0x040063FC RID: 25596
		public FetchPlatNoticeArg oArg = new FetchPlatNoticeArg();

		// Token: 0x040063FD RID: 25597
		public FetchPlatNoticeRes oRes = null;
	}
}
