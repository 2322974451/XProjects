using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015DB RID: 5595
	internal class RpcC2G_TransformOp : Rpc
	{
		// Token: 0x0600EC94 RID: 60564 RVA: 0x00347408 File Offset: 0x00345608
		public override uint GetRpcType()
		{
			return 7373U;
		}

		// Token: 0x0600EC95 RID: 60565 RVA: 0x0034741F File Offset: 0x0034561F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TransformOpArg>(stream, this.oArg);
		}

		// Token: 0x0600EC96 RID: 60566 RVA: 0x0034742F File Offset: 0x0034562F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TransformOpRes>(stream);
		}

		// Token: 0x0600EC97 RID: 60567 RVA: 0x0034743E File Offset: 0x0034563E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TransformOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC98 RID: 60568 RVA: 0x0034745A File Offset: 0x0034565A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TransformOp.OnTimeout(this.oArg);
		}

		// Token: 0x040065B1 RID: 26033
		public TransformOpArg oArg = new TransformOpArg();

		// Token: 0x040065B2 RID: 26034
		public TransformOpRes oRes = null;
	}
}
