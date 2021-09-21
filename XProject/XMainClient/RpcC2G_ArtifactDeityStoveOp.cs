using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015CA RID: 5578
	internal class RpcC2G_ArtifactDeityStoveOp : Rpc
	{
		// Token: 0x0600EC51 RID: 60497 RVA: 0x00346E34 File Offset: 0x00345034
		public override uint GetRpcType()
		{
			return 35155U;
		}

		// Token: 0x0600EC52 RID: 60498 RVA: 0x00346E4B File Offset: 0x0034504B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ArtifactDeityStoveOpArg>(stream, this.oArg);
		}

		// Token: 0x0600EC53 RID: 60499 RVA: 0x00346E5B File Offset: 0x0034505B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ArtifactDeityStoveOpRes>(stream);
		}

		// Token: 0x0600EC54 RID: 60500 RVA: 0x00346E6A File Offset: 0x0034506A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ArtifactDeityStoveOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC55 RID: 60501 RVA: 0x00346E86 File Offset: 0x00345086
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ArtifactDeityStoveOp.OnTimeout(this.oArg);
		}

		// Token: 0x040065A5 RID: 26021
		public ArtifactDeityStoveOpArg oArg = new ArtifactDeityStoveOpArg();

		// Token: 0x040065A6 RID: 26022
		public ArtifactDeityStoveOpRes oRes = null;
	}
}
