using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011A8 RID: 4520
	internal class RpcC2M_RemoveBlackListNew : Rpc
	{
		// Token: 0x0600DB68 RID: 56168 RVA: 0x0032EFF4 File Offset: 0x0032D1F4
		public override uint GetRpcType()
		{
			return 38702U;
		}

		// Token: 0x0600DB69 RID: 56169 RVA: 0x0032F00B File Offset: 0x0032D20B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RemoveBlackListArg>(stream, this.oArg);
		}

		// Token: 0x0600DB6A RID: 56170 RVA: 0x0032F01B File Offset: 0x0032D21B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RemoveBlackListRes>(stream);
		}

		// Token: 0x0600DB6B RID: 56171 RVA: 0x0032F02A File Offset: 0x0032D22A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RemoveBlackListNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DB6C RID: 56172 RVA: 0x0032F046 File Offset: 0x0032D246
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RemoveBlackListNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006262 RID: 25186
		public RemoveBlackListArg oArg = new RemoveBlackListArg();

		// Token: 0x04006263 RID: 25187
		public RemoveBlackListRes oRes = null;
	}
}
