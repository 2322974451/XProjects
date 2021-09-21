using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016A5 RID: 5797
	internal class RpcC2G_JadeComposeNew : Rpc
	{
		// Token: 0x0600EFEA RID: 61418 RVA: 0x0034C0E4 File Offset: 0x0034A2E4
		public override uint GetRpcType()
		{
			return 46652U;
		}

		// Token: 0x0600EFEB RID: 61419 RVA: 0x0034C0FB File Offset: 0x0034A2FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeComposeNewArg>(stream, this.oArg);
		}

		// Token: 0x0600EFEC RID: 61420 RVA: 0x0034C10B File Offset: 0x0034A30B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeComposeNewRes>(stream);
		}

		// Token: 0x0600EFED RID: 61421 RVA: 0x0034C11A File Offset: 0x0034A31A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeComposeNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EFEE RID: 61422 RVA: 0x0034C136 File Offset: 0x0034A336
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeComposeNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006665 RID: 26213
		public JadeComposeNewArg oArg = new JadeComposeNewArg();

		// Token: 0x04006666 RID: 26214
		public JadeComposeNewRes oRes = null;
	}
}
