using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001596 RID: 5526
	internal class RpcC2M_EnterWeddingScene : Rpc
	{
		// Token: 0x0600EB7C RID: 60284 RVA: 0x00345D74 File Offset: 0x00343F74
		public override uint GetRpcType()
		{
			return 30316U;
		}

		// Token: 0x0600EB7D RID: 60285 RVA: 0x00345D8B File Offset: 0x00343F8B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterWeddingSceneArg>(stream, this.oArg);
		}

		// Token: 0x0600EB7E RID: 60286 RVA: 0x00345D9B File Offset: 0x00343F9B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterWeddingSceneRes>(stream);
		}

		// Token: 0x0600EB7F RID: 60287 RVA: 0x00345DAA File Offset: 0x00343FAA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_EnterWeddingScene.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB80 RID: 60288 RVA: 0x00345DC6 File Offset: 0x00343FC6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_EnterWeddingScene.OnTimeout(this.oArg);
		}

		// Token: 0x0400657E RID: 25982
		public EnterWeddingSceneArg oArg = new EnterWeddingSceneArg();

		// Token: 0x0400657F RID: 25983
		public EnterWeddingSceneRes oRes = null;
	}
}
