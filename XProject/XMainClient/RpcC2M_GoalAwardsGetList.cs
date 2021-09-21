using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015E5 RID: 5605
	internal class RpcC2M_GoalAwardsGetList : Rpc
	{
		// Token: 0x0600ECC0 RID: 60608 RVA: 0x00347774 File Offset: 0x00345974
		public override uint GetRpcType()
		{
			return 36694U;
		}

		// Token: 0x0600ECC1 RID: 60609 RVA: 0x0034778B File Offset: 0x0034598B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoalAwardsGetList_C2M>(stream, this.oArg);
		}

		// Token: 0x0600ECC2 RID: 60610 RVA: 0x0034779B File Offset: 0x0034599B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GoalAwardsGetList_M2C>(stream);
		}

		// Token: 0x0600ECC3 RID: 60611 RVA: 0x003477AA File Offset: 0x003459AA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GoalAwardsGetList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ECC4 RID: 60612 RVA: 0x003477C6 File Offset: 0x003459C6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GoalAwardsGetList.OnTimeout(this.oArg);
		}

		// Token: 0x040065BA RID: 26042
		public GoalAwardsGetList_C2M oArg = new GoalAwardsGetList_C2M();

		// Token: 0x040065BB RID: 26043
		public GoalAwardsGetList_M2C oRes = null;
	}
}
