using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200102D RID: 4141
	internal class RpcC2G_GMCommand : Rpc
	{
		// Token: 0x0600D560 RID: 54624 RVA: 0x00323F2C File Offset: 0x0032212C
		public override uint GetRpcType()
		{
			return 3248U;
		}

		// Token: 0x0600D561 RID: 54625 RVA: 0x00323F43 File Offset: 0x00322143
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GMCmdArg>(stream, this.oArg);
		}

		// Token: 0x0600D562 RID: 54626 RVA: 0x00323F53 File Offset: 0x00322153
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GMCmdRes>(stream);
		}

		// Token: 0x0600D563 RID: 54627 RVA: 0x00323F62 File Offset: 0x00322162
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GMCommand.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D564 RID: 54628 RVA: 0x00323F7E File Offset: 0x0032217E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GMCommand.OnTimeout(this.oArg);
		}

		// Token: 0x0400611F RID: 24863
		public GMCmdArg oArg = new GMCmdArg();

		// Token: 0x04006120 RID: 24864
		public GMCmdRes oRes = new GMCmdRes();
	}
}
