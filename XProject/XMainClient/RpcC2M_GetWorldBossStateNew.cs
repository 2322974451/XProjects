using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011C2 RID: 4546
	internal class RpcC2M_GetWorldBossStateNew : Rpc
	{
		// Token: 0x0600DBCE RID: 56270 RVA: 0x0032F820 File Offset: 0x0032DA20
		public override uint GetRpcType()
		{
			return 17093U;
		}

		// Token: 0x0600DBCF RID: 56271 RVA: 0x0032F837 File Offset: 0x0032DA37
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWorldBossStateArg>(stream, this.oArg);
		}

		// Token: 0x0600DBD0 RID: 56272 RVA: 0x0032F847 File Offset: 0x0032DA47
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWorldBossStateRes>(stream);
		}

		// Token: 0x0600DBD1 RID: 56273 RVA: 0x0032F856 File Offset: 0x0032DA56
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetWorldBossStateNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DBD2 RID: 56274 RVA: 0x0032F872 File Offset: 0x0032DA72
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetWorldBossStateNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006274 RID: 25204
		public GetWorldBossStateArg oArg = new GetWorldBossStateArg();

		// Token: 0x04006275 RID: 25205
		public GetWorldBossStateRes oRes = null;
	}
}
