using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001444 RID: 5188
	internal class RpcC2G_GetGuildBonusLeft : Rpc
	{
		// Token: 0x0600E619 RID: 58905 RVA: 0x0033DDF4 File Offset: 0x0033BFF4
		public override uint GetRpcType()
		{
			return 9967U;
		}

		// Token: 0x0600E61A RID: 58906 RVA: 0x0033DE0B File Offset: 0x0033C00B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildBonusLeftArg>(stream, this.oArg);
		}

		// Token: 0x0600E61B RID: 58907 RVA: 0x0033DE1B File Offset: 0x0033C01B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildBonusLeftRes>(stream);
		}

		// Token: 0x0600E61C RID: 58908 RVA: 0x0033DE2A File Offset: 0x0033C02A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildBonusLeft.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E61D RID: 58909 RVA: 0x0033DE46 File Offset: 0x0033C046
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildBonusLeft.OnTimeout(this.oArg);
		}

		// Token: 0x04006470 RID: 25712
		public GetGuildBonusLeftArg oArg = new GetGuildBonusLeftArg();

		// Token: 0x04006471 RID: 25713
		public GetGuildBonusLeftRes oRes = null;
	}
}
