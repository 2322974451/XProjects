using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200159C RID: 5532
	internal class RpcC2M_MarriageRelationOp : Rpc
	{
		// Token: 0x0600EB97 RID: 60311 RVA: 0x00346040 File Offset: 0x00344240
		public override uint GetRpcType()
		{
			return 24966U;
		}

		// Token: 0x0600EB98 RID: 60312 RVA: 0x00346057 File Offset: 0x00344257
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MarriageRelationOpArg>(stream, this.oArg);
		}

		// Token: 0x0600EB99 RID: 60313 RVA: 0x00346067 File Offset: 0x00344267
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MarriageRelationOpRes>(stream);
		}

		// Token: 0x0600EB9A RID: 60314 RVA: 0x00346076 File Offset: 0x00344276
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MarriageRelationOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB9B RID: 60315 RVA: 0x00346092 File Offset: 0x00344292
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MarriageRelationOp.OnTimeout(this.oArg);
		}

		// Token: 0x04006584 RID: 25988
		public MarriageRelationOpArg oArg = new MarriageRelationOpArg();

		// Token: 0x04006585 RID: 25989
		public MarriageRelationOpRes oRes = null;
	}
}
