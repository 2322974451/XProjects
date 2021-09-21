using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001611 RID: 5649
	internal class RpcC2M_GetDailyTaskRefreshInfo : Rpc
	{
		// Token: 0x0600ED7A RID: 60794 RVA: 0x00348640 File Offset: 0x00346840
		public override uint GetRpcType()
		{
			return 42385U;
		}

		// Token: 0x0600ED7B RID: 60795 RVA: 0x00348657 File Offset: 0x00346857
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskRefreshInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600ED7C RID: 60796 RVA: 0x00348667 File Offset: 0x00346867
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskRefreshInfoRes>(stream);
		}

		// Token: 0x0600ED7D RID: 60797 RVA: 0x00348676 File Offset: 0x00346876
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDailyTaskRefreshInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED7E RID: 60798 RVA: 0x00348692 File Offset: 0x00346892
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDailyTaskRefreshInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040065E0 RID: 26080
		public GetDailyTaskRefreshInfoArg oArg = new GetDailyTaskRefreshInfoArg();

		// Token: 0x040065E1 RID: 26081
		public GetDailyTaskRefreshInfoRes oRes = null;
	}
}
