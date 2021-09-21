using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012B7 RID: 4791
	internal class RpcC2M_FetchGuildHistoryNew : Rpc
	{
		// Token: 0x0600DFBB RID: 57275 RVA: 0x00335088 File Offset: 0x00333288
		public override uint GetRpcType()
		{
			return 26284U;
		}

		// Token: 0x0600DFBC RID: 57276 RVA: 0x0033509F File Offset: 0x0033329F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHistoryArg>(stream, this.oArg);
		}

		// Token: 0x0600DFBD RID: 57277 RVA: 0x003350AF File Offset: 0x003332AF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildHistoryRes>(stream);
		}

		// Token: 0x0600DFBE RID: 57278 RVA: 0x003350BE File Offset: 0x003332BE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchGuildHistoryNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DFBF RID: 57279 RVA: 0x003350DA File Offset: 0x003332DA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchGuildHistoryNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006336 RID: 25398
		public GuildHistoryArg oArg = new GuildHistoryArg();

		// Token: 0x04006337 RID: 25399
		public GuildHistoryRes oRes = null;
	}
}
