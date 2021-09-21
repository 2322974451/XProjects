using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001659 RID: 5721
	internal class RpcC2G_ActivatePreShow : Rpc
	{
		// Token: 0x0600EEB1 RID: 61105 RVA: 0x0034A264 File Offset: 0x00348464
		public override uint GetRpcType()
		{
			return 22466U;
		}

		// Token: 0x0600EEB2 RID: 61106 RVA: 0x0034A27B File Offset: 0x0034847B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivatePreShowArg>(stream, this.oArg);
		}

		// Token: 0x0600EEB3 RID: 61107 RVA: 0x0034A28B File Offset: 0x0034848B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivatePreShowRes>(stream);
		}

		// Token: 0x0600EEB4 RID: 61108 RVA: 0x0034A29A File Offset: 0x0034849A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivatePreShow.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EEB5 RID: 61109 RVA: 0x0034A2B6 File Offset: 0x003484B6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivatePreShow.OnTimeout(this.oArg);
		}

		// Token: 0x04006621 RID: 26145
		public ActivatePreShowArg oArg = new ActivatePreShowArg();

		// Token: 0x04006622 RID: 26146
		public ActivatePreShowRes oRes = null;
	}
}
