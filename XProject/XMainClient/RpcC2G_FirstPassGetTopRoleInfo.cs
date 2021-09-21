using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001219 RID: 4633
	internal class RpcC2G_FirstPassGetTopRoleInfo : Rpc
	{
		// Token: 0x0600DD2E RID: 56622 RVA: 0x00331488 File Offset: 0x0032F688
		public override uint GetRpcType()
		{
			return 37076U;
		}

		// Token: 0x0600DD2F RID: 56623 RVA: 0x0033149F File Offset: 0x0032F69F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FirstPassGetTopRoleInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DD30 RID: 56624 RVA: 0x003314AF File Offset: 0x0032F6AF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FirstPassGetTopRoleInfoRes>(stream);
		}

		// Token: 0x0600DD31 RID: 56625 RVA: 0x003314BE File Offset: 0x0032F6BE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FirstPassGetTopRoleInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD32 RID: 56626 RVA: 0x003314DA File Offset: 0x0032F6DA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FirstPassGetTopRoleInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040062B6 RID: 25270
		public FirstPassGetTopRoleInfoArg oArg = new FirstPassGetTopRoleInfoArg();

		// Token: 0x040062B7 RID: 25271
		public FirstPassGetTopRoleInfoRes oRes = new FirstPassGetTopRoleInfoRes();
	}
}
