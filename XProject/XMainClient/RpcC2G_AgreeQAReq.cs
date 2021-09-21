using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001127 RID: 4391
	internal class RpcC2G_AgreeQAReq : Rpc
	{
		// Token: 0x0600D95C RID: 55644 RVA: 0x0032AF50 File Offset: 0x00329150
		public override uint GetRpcType()
		{
			return 43200U;
		}

		// Token: 0x0600D95D RID: 55645 RVA: 0x0032AF67 File Offset: 0x00329167
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AgreeQAReq>(stream, this.oArg);
		}

		// Token: 0x0600D95E RID: 55646 RVA: 0x0032AF77 File Offset: 0x00329177
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AgreeQARes>(stream);
		}

		// Token: 0x0600D95F RID: 55647 RVA: 0x0032AF86 File Offset: 0x00329186
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AgreeQAReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D960 RID: 55648 RVA: 0x0032AFA2 File Offset: 0x003291A2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AgreeQAReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006200 RID: 25088
		public AgreeQAReq oArg = new AgreeQAReq();

		// Token: 0x04006201 RID: 25089
		public AgreeQARes oRes = new AgreeQARes();
	}
}
