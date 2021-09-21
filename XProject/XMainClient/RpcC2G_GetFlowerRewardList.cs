using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001131 RID: 4401
	internal class RpcC2G_GetFlowerRewardList : Rpc
	{
		// Token: 0x0600D987 RID: 55687 RVA: 0x0032B394 File Offset: 0x00329594
		public override uint GetRpcType()
		{
			return 26656U;
		}

		// Token: 0x0600D988 RID: 55688 RVA: 0x0032B3AB File Offset: 0x003295AB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetFlowerRewardListArg>(stream, this.oArg);
		}

		// Token: 0x0600D989 RID: 55689 RVA: 0x0032B3BB File Offset: 0x003295BB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetFlowerRewardListRes>(stream);
		}

		// Token: 0x0600D98A RID: 55690 RVA: 0x0032B3CA File Offset: 0x003295CA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetFlowerRewardList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D98B RID: 55691 RVA: 0x0032B3E6 File Offset: 0x003295E6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetFlowerRewardList.OnTimeout(this.oArg);
		}

		// Token: 0x04006208 RID: 25096
		public GetFlowerRewardListArg oArg = new GetFlowerRewardListArg();

		// Token: 0x04006209 RID: 25097
		public GetFlowerRewardListRes oRes = new GetFlowerRewardListRes();
	}
}
