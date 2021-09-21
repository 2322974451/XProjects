using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012C6 RID: 4806
	internal class RpcC2M_GuildArenaSimpleDeployNew : Rpc
	{
		// Token: 0x0600DFFD RID: 57341 RVA: 0x003356B8 File Offset: 0x003338B8
		public override uint GetRpcType()
		{
			return 42310U;
		}

		// Token: 0x0600DFFE RID: 57342 RVA: 0x003356CF File Offset: 0x003338CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildArenaSimpleDeployArg>(stream, this.oArg);
		}

		// Token: 0x0600DFFF RID: 57343 RVA: 0x003356DF File Offset: 0x003338DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildArenaSimpleDeployRes>(stream);
		}

		// Token: 0x0600E000 RID: 57344 RVA: 0x003356EE File Offset: 0x003338EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildArenaSimpleDeployNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E001 RID: 57345 RVA: 0x0033570A File Offset: 0x0033390A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildArenaSimpleDeployNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006344 RID: 25412
		public GuildArenaSimpleDeployArg oArg = new GuildArenaSimpleDeployArg();

		// Token: 0x04006345 RID: 25413
		public GuildArenaSimpleDeployRes oRes = null;
	}
}
