using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001669 RID: 5737
	internal class RpcC2G_EnterLeisureScene : Rpc
	{
		// Token: 0x0600EEEF RID: 61167 RVA: 0x0034A768 File Offset: 0x00348968
		public override uint GetRpcType()
		{
			return 62361U;
		}

		// Token: 0x0600EEF0 RID: 61168 RVA: 0x0034A77F File Offset: 0x0034897F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterLeisureSceneArg>(stream, this.oArg);
		}

		// Token: 0x0600EEF1 RID: 61169 RVA: 0x0034A78F File Offset: 0x0034898F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterLeisureSceneRes>(stream);
		}

		// Token: 0x0600EEF2 RID: 61170 RVA: 0x0034A79E File Offset: 0x0034899E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnterLeisureScene.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EEF3 RID: 61171 RVA: 0x0034A7BA File Offset: 0x003489BA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnterLeisureScene.OnTimeout(this.oArg);
		}

		// Token: 0x0400662C RID: 26156
		public EnterLeisureSceneArg oArg = new EnterLeisureSceneArg();

		// Token: 0x0400662D RID: 26157
		public EnterLeisureSceneRes oRes = null;
	}
}
