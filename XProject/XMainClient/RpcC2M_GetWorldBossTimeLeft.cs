using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011C6 RID: 4550
	internal class RpcC2M_GetWorldBossTimeLeft : Rpc
	{
		// Token: 0x0600DBDE RID: 56286 RVA: 0x0032F97C File Offset: 0x0032DB7C
		public override uint GetRpcType()
		{
			return 23195U;
		}

		// Token: 0x0600DBDF RID: 56287 RVA: 0x0032F993 File Offset: 0x0032DB93
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWorldBossTimeLeftArg>(stream, this.oArg);
		}

		// Token: 0x0600DBE0 RID: 56288 RVA: 0x0032F9A3 File Offset: 0x0032DBA3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWorldBossTimeLeftRes>(stream);
		}

		// Token: 0x0600DBE1 RID: 56289 RVA: 0x0032F9B2 File Offset: 0x0032DBB2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetWorldBossTimeLeft.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DBE2 RID: 56290 RVA: 0x0032F9CE File Offset: 0x0032DBCE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetWorldBossTimeLeft.OnTimeout(this.oArg);
		}

		// Token: 0x04006277 RID: 25207
		public GetWorldBossTimeLeftArg oArg = new GetWorldBossTimeLeftArg();

		// Token: 0x04006278 RID: 25208
		public GetWorldBossTimeLeftRes oRes = null;
	}
}
