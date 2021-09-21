using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015B3 RID: 5555
	internal class RpcC2G_TactEnterScene : Rpc
	{
		// Token: 0x0600EBF1 RID: 60401 RVA: 0x00346660 File Offset: 0x00344860
		public override uint GetRpcType()
		{
			return 27599U;
		}

		// Token: 0x0600EBF2 RID: 60402 RVA: 0x00346677 File Offset: 0x00344877
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TactEnterSceneArg>(stream, this.oArg);
		}

		// Token: 0x0600EBF3 RID: 60403 RVA: 0x00346687 File Offset: 0x00344887
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TactEnterSceneRes>(stream);
		}

		// Token: 0x0600EBF4 RID: 60404 RVA: 0x00346696 File Offset: 0x00344896
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TactEnterScene.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EBF5 RID: 60405 RVA: 0x003466B2 File Offset: 0x003448B2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TactEnterScene.OnTimeout(this.oArg);
		}

		// Token: 0x04006592 RID: 26002
		public TactEnterSceneArg oArg = new TactEnterSceneArg();

		// Token: 0x04006593 RID: 26003
		public TactEnterSceneRes oRes = null;
	}
}
