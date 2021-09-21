using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200110A RID: 4362
	internal class RpcC2G_ReqGetLoginReward : Rpc
	{
		// Token: 0x0600D8E7 RID: 55527 RVA: 0x0032A38C File Offset: 0x0032858C
		public override uint GetRpcType()
		{
			return 44079U;
		}

		// Token: 0x0600D8E8 RID: 55528 RVA: 0x0032A3A3 File Offset: 0x003285A3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginRewardGetReq>(stream, this.oArg);
		}

		// Token: 0x0600D8E9 RID: 55529 RVA: 0x0032A3B3 File Offset: 0x003285B3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LoginRewardGetRet>(stream);
		}

		// Token: 0x0600D8EA RID: 55530 RVA: 0x0032A3C2 File Offset: 0x003285C2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReqGetLoginReward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D8EB RID: 55531 RVA: 0x0032A3DE File Offset: 0x003285DE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReqGetLoginReward.OnTimeout(this.oArg);
		}

		// Token: 0x040061EA RID: 25066
		public LoginRewardGetReq oArg = new LoginRewardGetReq();

		// Token: 0x040061EB RID: 25067
		public LoginRewardGetRet oRes = new LoginRewardGetRet();
	}
}
