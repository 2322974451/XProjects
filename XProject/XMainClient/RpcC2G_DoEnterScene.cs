using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001166 RID: 4454
	internal class RpcC2G_DoEnterScene : Rpc
	{
		// Token: 0x0600DA6A RID: 55914 RVA: 0x0032D484 File Offset: 0x0032B684
		public override uint GetRpcType()
		{
			return 45201U;
		}

		// Token: 0x0600DA6B RID: 55915 RVA: 0x0032D49B File Offset: 0x0032B69B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoEnterSceneArg>(stream, this.oArg);
		}

		// Token: 0x0600DA6C RID: 55916 RVA: 0x0032D4AB File Offset: 0x0032B6AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DoEnterSceneRes>(stream);
		}

		// Token: 0x0600DA6D RID: 55917 RVA: 0x0032D4BA File Offset: 0x0032B6BA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DoEnterScene.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA6E RID: 55918 RVA: 0x0032D4D6 File Offset: 0x0032B6D6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DoEnterScene.OnTimeout(this.oArg);
		}

		// Token: 0x04006237 RID: 25143
		public DoEnterSceneArg oArg = new DoEnterSceneArg();

		// Token: 0x04006238 RID: 25144
		public DoEnterSceneRes oRes = new DoEnterSceneRes();
	}
}
