using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001504 RID: 5380
	internal class RpcC2G_AbsEnterScene : Rpc
	{
		// Token: 0x0600E926 RID: 59686 RVA: 0x0034240C File Offset: 0x0034060C
		public override uint GetRpcType()
		{
			return 23463U;
		}

		// Token: 0x0600E927 RID: 59687 RVA: 0x00342423 File Offset: 0x00340623
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AbsEnterSceneArg>(stream, this.oArg);
		}

		// Token: 0x0600E928 RID: 59688 RVA: 0x00342433 File Offset: 0x00340633
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AbsEnterSceneRes>(stream);
		}

		// Token: 0x0600E929 RID: 59689 RVA: 0x00342442 File Offset: 0x00340642
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AbsEnterScene.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E92A RID: 59690 RVA: 0x0034245E File Offset: 0x0034065E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AbsEnterScene.OnTimeout(this.oArg);
		}

		// Token: 0x04006503 RID: 25859
		public AbsEnterSceneArg oArg = new AbsEnterSceneArg();

		// Token: 0x04006504 RID: 25860
		public AbsEnterSceneRes oRes = null;
	}
}
