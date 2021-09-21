using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010A4 RID: 4260
	internal class RpcC2G_FetchEnemyDoodadReq : Rpc
	{
		// Token: 0x0600D74F RID: 55119 RVA: 0x00327B9C File Offset: 0x00325D9C
		public override uint GetRpcType()
		{
			return 56348U;
		}

		// Token: 0x0600D750 RID: 55120 RVA: 0x00327BB3 File Offset: 0x00325DB3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnemyDoodadInfo>(stream, this.oArg);
		}

		// Token: 0x0600D751 RID: 55121 RVA: 0x00327BC3 File Offset: 0x00325DC3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RollInfoRes>(stream);
		}

		// Token: 0x0600D752 RID: 55122 RVA: 0x00327BD2 File Offset: 0x00325DD2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FetchEnemyDoodadReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D753 RID: 55123 RVA: 0x00327BEE File Offset: 0x00325DEE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FetchEnemyDoodadReq.OnTimeout(this.oArg);
		}

		// Token: 0x040061A2 RID: 24994
		public EnemyDoodadInfo oArg = new EnemyDoodadInfo();

		// Token: 0x040061A3 RID: 24995
		public RollInfoRes oRes = new RollInfoRes();
	}
}
