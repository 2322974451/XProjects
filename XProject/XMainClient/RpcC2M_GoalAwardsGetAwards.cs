using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015E7 RID: 5607
	internal class RpcC2M_GoalAwardsGetAwards : Rpc
	{
		// Token: 0x0600ECC9 RID: 60617 RVA: 0x00347848 File Offset: 0x00345A48
		public override uint GetRpcType()
		{
			return 4985U;
		}

		// Token: 0x0600ECCA RID: 60618 RVA: 0x0034785F File Offset: 0x00345A5F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoalAwardsGetAwards_C2M>(stream, this.oArg);
		}

		// Token: 0x0600ECCB RID: 60619 RVA: 0x0034786F File Offset: 0x00345A6F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GoalAwardsGetAwards_M2C>(stream);
		}

		// Token: 0x0600ECCC RID: 60620 RVA: 0x0034787E File Offset: 0x00345A7E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GoalAwardsGetAwards.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ECCD RID: 60621 RVA: 0x0034789A File Offset: 0x00345A9A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GoalAwardsGetAwards.OnTimeout(this.oArg);
		}

		// Token: 0x040065BC RID: 26044
		public GoalAwardsGetAwards_C2M oArg = new GoalAwardsGetAwards_C2M();

		// Token: 0x040065BD RID: 26045
		public GoalAwardsGetAwards_M2C oRes = null;
	}
}
