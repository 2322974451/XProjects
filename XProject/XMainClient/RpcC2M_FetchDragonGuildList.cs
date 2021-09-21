using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001638 RID: 5688
	internal class RpcC2M_FetchDragonGuildList : Rpc
	{
		// Token: 0x0600EE20 RID: 60960 RVA: 0x0034951C File Offset: 0x0034771C
		public override uint GetRpcType()
		{
			return 23518U;
		}

		// Token: 0x0600EE21 RID: 60961 RVA: 0x00349533 File Offset: 0x00347733
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchDragonGuildListArg>(stream, this.oArg);
		}

		// Token: 0x0600EE22 RID: 60962 RVA: 0x00349543 File Offset: 0x00347743
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchDragonGuildRes>(stream);
		}

		// Token: 0x0600EE23 RID: 60963 RVA: 0x00349552 File Offset: 0x00347752
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchDragonGuildList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE24 RID: 60964 RVA: 0x0034956E File Offset: 0x0034776E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchDragonGuildList.OnTimeout(this.oArg);
		}

		// Token: 0x04006602 RID: 26114
		public FetchDragonGuildListArg oArg = new FetchDragonGuildListArg();

		// Token: 0x04006603 RID: 26115
		public FetchDragonGuildRes oRes = null;
	}
}
