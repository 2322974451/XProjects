using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200152F RID: 5423
	internal class RpcC2G_SceneMobaOp : Rpc
	{
		// Token: 0x0600E9D8 RID: 59864 RVA: 0x00343518 File Offset: 0x00341718
		public override uint GetRpcType()
		{
			return 32594U;
		}

		// Token: 0x0600E9D9 RID: 59865 RVA: 0x0034352F File Offset: 0x0034172F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneMobaOpArg>(stream, this.oArg);
		}

		// Token: 0x0600E9DA RID: 59866 RVA: 0x0034353F File Offset: 0x0034173F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SceneMobaOpRes>(stream);
		}

		// Token: 0x0600E9DB RID: 59867 RVA: 0x0034354E File Offset: 0x0034174E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SceneMobaOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E9DC RID: 59868 RVA: 0x0034356A File Offset: 0x0034176A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SceneMobaOp.OnTimeout(this.oArg);
		}

		// Token: 0x04006526 RID: 25894
		public SceneMobaOpArg oArg = new SceneMobaOpArg();

		// Token: 0x04006527 RID: 25895
		public SceneMobaOpRes oRes = null;
	}
}
