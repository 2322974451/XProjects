using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001288 RID: 4744
	internal class RpcC2G_RefreshSweepReward : Rpc
	{
		// Token: 0x0600DEF9 RID: 57081 RVA: 0x00333E30 File Offset: 0x00332030
		public override uint GetRpcType()
		{
			return 38012U;
		}

		// Token: 0x0600DEFA RID: 57082 RVA: 0x00333E47 File Offset: 0x00332047
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RefreshSweepRewardArg>(stream, this.oArg);
		}

		// Token: 0x0600DEFB RID: 57083 RVA: 0x00333E57 File Offset: 0x00332057
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RefreshSweepRewardRes>(stream);
		}

		// Token: 0x0600DEFC RID: 57084 RVA: 0x00333E66 File Offset: 0x00332066
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_RefreshSweepReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DEFD RID: 57085 RVA: 0x00333E82 File Offset: 0x00332082
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_RefreshSweepReward.OnTimeout(this.oArg);
		}

		// Token: 0x04006310 RID: 25360
		public RefreshSweepRewardArg oArg = new RefreshSweepRewardArg();

		// Token: 0x04006311 RID: 25361
		public RefreshSweepRewardRes oRes = new RefreshSweepRewardRes();
	}
}
