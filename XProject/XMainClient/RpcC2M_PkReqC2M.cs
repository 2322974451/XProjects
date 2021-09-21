using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200121F RID: 4639
	internal class RpcC2M_PkReqC2M : Rpc
	{
		// Token: 0x0600DD47 RID: 56647 RVA: 0x00331960 File Offset: 0x0032FB60
		public override uint GetRpcType()
		{
			return 41221U;
		}

		// Token: 0x0600DD48 RID: 56648 RVA: 0x00331977 File Offset: 0x0032FB77
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkReqArg>(stream, this.oArg);
		}

		// Token: 0x0600DD49 RID: 56649 RVA: 0x00331987 File Offset: 0x0032FB87
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PkReqRes>(stream);
		}

		// Token: 0x0600DD4A RID: 56650 RVA: 0x00331996 File Offset: 0x0032FB96
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_PkReqC2M.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD4B RID: 56651 RVA: 0x003319B2 File Offset: 0x0032FBB2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_PkReqC2M.OnTimeout(this.oArg);
		}

		// Token: 0x040062BB RID: 25275
		public PkReqArg oArg = new PkReqArg();

		// Token: 0x040062BC RID: 25276
		public PkReqRes oRes = null;
	}
}
