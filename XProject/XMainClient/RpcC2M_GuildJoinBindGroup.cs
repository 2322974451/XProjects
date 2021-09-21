using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001311 RID: 4881
	internal class RpcC2M_GuildJoinBindGroup : Rpc
	{
		// Token: 0x0600E131 RID: 57649 RVA: 0x003372C0 File Offset: 0x003354C0
		public override uint GetRpcType()
		{
			return 12928U;
		}

		// Token: 0x0600E132 RID: 57650 RVA: 0x003372D7 File Offset: 0x003354D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildJoinBindGroupReq>(stream, this.oArg);
		}

		// Token: 0x0600E133 RID: 57651 RVA: 0x003372E7 File Offset: 0x003354E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildJoinBindGroupRes>(stream);
		}

		// Token: 0x0600E134 RID: 57652 RVA: 0x003372F6 File Offset: 0x003354F6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildJoinBindGroup.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E135 RID: 57653 RVA: 0x00337312 File Offset: 0x00335512
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildJoinBindGroup.OnTimeout(this.oArg);
		}

		// Token: 0x0400637F RID: 25471
		public GuildJoinBindGroupReq oArg = new GuildJoinBindGroupReq();

		// Token: 0x04006380 RID: 25472
		public GuildJoinBindGroupRes oRes = null;
	}
}
