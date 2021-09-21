using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200163A RID: 5690
	internal class RpcC2M_GetDragonGuildTaskInfo : Rpc
	{
		// Token: 0x0600EE29 RID: 60969 RVA: 0x00349628 File Offset: 0x00347828
		public override uint GetRpcType()
		{
			return 36879U;
		}

		// Token: 0x0600EE2A RID: 60970 RVA: 0x0034963F File Offset: 0x0034783F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildTaskInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600EE2B RID: 60971 RVA: 0x0034964F File Offset: 0x0034784F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildTaskInfoRes>(stream);
		}

		// Token: 0x0600EE2C RID: 60972 RVA: 0x0034965E File Offset: 0x0034785E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildTaskInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE2D RID: 60973 RVA: 0x0034967A File Offset: 0x0034787A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildTaskInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006604 RID: 26116
		public GetDragonGuildTaskInfoArg oArg = new GetDragonGuildTaskInfoArg();

		// Token: 0x04006605 RID: 26117
		public GetDragonGuildTaskInfoRes oRes = null;
	}
}
