using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013FE RID: 5118
	internal class RpcC2G_PhotographEffect : Rpc
	{
		// Token: 0x0600E4FB RID: 58619 RVA: 0x0033C5D8 File Offset: 0x0033A7D8
		public override uint GetRpcType()
		{
			return 14666U;
		}

		// Token: 0x0600E4FC RID: 58620 RVA: 0x0033C5EF File Offset: 0x0033A7EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PhotographEffectArg>(stream, this.oArg);
		}

		// Token: 0x0600E4FD RID: 58621 RVA: 0x0033C5FF File Offset: 0x0033A7FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PhotographEffect>(stream);
		}

		// Token: 0x0600E4FE RID: 58622 RVA: 0x0033C60E File Offset: 0x0033A80E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PhotographEffect.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E4FF RID: 58623 RVA: 0x0033C62A File Offset: 0x0033A82A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PhotographEffect.OnTimeout(this.oArg);
		}

		// Token: 0x0400643A RID: 25658
		public PhotographEffectArg oArg = new PhotographEffectArg();

		// Token: 0x0400643B RID: 25659
		public PhotographEffect oRes = null;
	}
}
