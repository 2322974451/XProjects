using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001617 RID: 5655
	internal class RpcC2M_DailyTaskRefreshOper : Rpc
	{
		// Token: 0x0600ED95 RID: 60821 RVA: 0x00348970 File Offset: 0x00346B70
		public override uint GetRpcType()
		{
			return 31675U;
		}

		// Token: 0x0600ED96 RID: 60822 RVA: 0x00348987 File Offset: 0x00346B87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskRefreshOperArg>(stream, this.oArg);
		}

		// Token: 0x0600ED97 RID: 60823 RVA: 0x00348997 File Offset: 0x00346B97
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DailyTaskRefreshOperRes>(stream);
		}

		// Token: 0x0600ED98 RID: 60824 RVA: 0x003489A6 File Offset: 0x00346BA6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DailyTaskRefreshOper.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED99 RID: 60825 RVA: 0x003489C2 File Offset: 0x00346BC2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DailyTaskRefreshOper.OnTimeout(this.oArg);
		}

		// Token: 0x040065E6 RID: 26086
		public DailyTaskRefreshOperArg oArg = new DailyTaskRefreshOperArg();

		// Token: 0x040065E7 RID: 26087
		public DailyTaskRefreshOperRes oRes = null;
	}
}
