using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001152 RID: 4434
	internal class RpcC2G_OpenGuildQAReq : Rpc
	{
		// Token: 0x0600DA10 RID: 55824 RVA: 0x0032C970 File Offset: 0x0032AB70
		public override uint GetRpcType()
		{
			return 62840U;
		}

		// Token: 0x0600DA11 RID: 55825 RVA: 0x0032C987 File Offset: 0x0032AB87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenGuildQAReq>(stream, this.oArg);
		}

		// Token: 0x0600DA12 RID: 55826 RVA: 0x0032C997 File Offset: 0x0032AB97
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<OpenGuildQARes>(stream);
		}

		// Token: 0x0600DA13 RID: 55827 RVA: 0x0032C9A6 File Offset: 0x0032ABA6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_OpenGuildQAReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA14 RID: 55828 RVA: 0x0032C9C2 File Offset: 0x0032ABC2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_OpenGuildQAReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006223 RID: 25123
		public OpenGuildQAReq oArg = new OpenGuildQAReq();

		// Token: 0x04006224 RID: 25124
		public OpenGuildQARes oRes = new OpenGuildQARes();
	}
}
