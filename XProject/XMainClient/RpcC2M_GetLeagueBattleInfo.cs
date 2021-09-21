using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001460 RID: 5216
	internal class RpcC2M_GetLeagueBattleInfo : Rpc
	{
		// Token: 0x0600E685 RID: 59013 RVA: 0x0033EA64 File Offset: 0x0033CC64
		public override uint GetRpcType()
		{
			return 29101U;
		}

		// Token: 0x0600E686 RID: 59014 RVA: 0x0033EA7B File Offset: 0x0033CC7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueBattleInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E687 RID: 59015 RVA: 0x0033EA8B File Offset: 0x0033CC8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueBattleInfoRes>(stream);
		}

		// Token: 0x0600E688 RID: 59016 RVA: 0x0033EA9A File Offset: 0x0033CC9A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueBattleInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E689 RID: 59017 RVA: 0x0033EAB6 File Offset: 0x0033CCB6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueBattleInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006482 RID: 25730
		public GetLeagueBattleInfoArg oArg = new GetLeagueBattleInfoArg();

		// Token: 0x04006483 RID: 25731
		public GetLeagueBattleInfoRes oRes = null;
	}
}
