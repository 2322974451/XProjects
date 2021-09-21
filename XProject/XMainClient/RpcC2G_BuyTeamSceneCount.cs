using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010E0 RID: 4320
	internal class RpcC2G_BuyTeamSceneCount : Rpc
	{
		// Token: 0x0600D837 RID: 55351 RVA: 0x003293F4 File Offset: 0x003275F4
		public override uint GetRpcType()
		{
			return 9226U;
		}

		// Token: 0x0600D838 RID: 55352 RVA: 0x0032940B File Offset: 0x0032760B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyTeamSceneCountP>(stream, this.oArg);
		}

		// Token: 0x0600D839 RID: 55353 RVA: 0x0032941B File Offset: 0x0032761B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyTeamSceneCountRet>(stream);
		}

		// Token: 0x0600D83A RID: 55354 RVA: 0x0032942A File Offset: 0x0032762A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyTeamSceneCount.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D83B RID: 55355 RVA: 0x00329446 File Offset: 0x00327646
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyTeamSceneCount.OnTimeout(this.oArg);
		}

		// Token: 0x040061C8 RID: 25032
		public BuyTeamSceneCountP oArg = new BuyTeamSceneCountP();

		// Token: 0x040061C9 RID: 25033
		public BuyTeamSceneCountRet oRes = new BuyTeamSceneCountRet();
	}
}
