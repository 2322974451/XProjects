using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001037 RID: 4151
	internal class RpcC2G_JadeCompose : Rpc
	{
		// Token: 0x0600D589 RID: 54665 RVA: 0x0032444C File Offset: 0x0032264C
		public override uint GetRpcType()
		{
			return 35616U;
		}

		// Token: 0x0600D58A RID: 54666 RVA: 0x00324463 File Offset: 0x00322663
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeComposeArg>(stream, this.oArg);
		}

		// Token: 0x0600D58B RID: 54667 RVA: 0x00324473 File Offset: 0x00322673
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeComposeRes>(stream);
		}

		// Token: 0x0600D58C RID: 54668 RVA: 0x00324482 File Offset: 0x00322682
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeCompose.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D58D RID: 54669 RVA: 0x0032449E File Offset: 0x0032269E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeCompose.OnTimeout(this.oArg);
		}

		// Token: 0x04006127 RID: 24871
		public JadeComposeArg oArg = new JadeComposeArg();

		// Token: 0x04006128 RID: 24872
		public JadeComposeRes oRes = new JadeComposeRes();
	}
}
