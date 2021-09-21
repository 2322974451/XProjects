using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010CD RID: 4301
	internal class RpcC2G_UseSupplement : Rpc
	{
		// Token: 0x0600D7EB RID: 55275 RVA: 0x00328CFC File Offset: 0x00326EFC
		public override uint GetRpcType()
		{
			return 20068U;
		}

		// Token: 0x0600D7EC RID: 55276 RVA: 0x00328D13 File Offset: 0x00326F13
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UseSupplementReq>(stream, this.oArg);
		}

		// Token: 0x0600D7ED RID: 55277 RVA: 0x00328D23 File Offset: 0x00326F23
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UseSupplementRes>(stream);
		}

		// Token: 0x0600D7EE RID: 55278 RVA: 0x00328D32 File Offset: 0x00326F32
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_UseSupplement.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D7EF RID: 55279 RVA: 0x00328D4E File Offset: 0x00326F4E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_UseSupplement.OnTimeout(this.oArg);
		}

		// Token: 0x040061BA RID: 25018
		public UseSupplementReq oArg = new UseSupplementReq();

		// Token: 0x040061BB RID: 25019
		public UseSupplementRes oRes = new UseSupplementRes();
	}
}
