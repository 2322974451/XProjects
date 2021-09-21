using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001558 RID: 5464
	internal class RpcC2M_EnterBMReadyScene : Rpc
	{
		// Token: 0x0600EA79 RID: 60025 RVA: 0x00344548 File Offset: 0x00342748
		public override uint GetRpcType()
		{
			return 24371U;
		}

		// Token: 0x0600EA7A RID: 60026 RVA: 0x0034455F File Offset: 0x0034275F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterBMReadySceneArg>(stream, this.oArg);
		}

		// Token: 0x0600EA7B RID: 60027 RVA: 0x0034456F File Offset: 0x0034276F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterBMReadySceneRes>(stream);
		}

		// Token: 0x0600EA7C RID: 60028 RVA: 0x0034457E File Offset: 0x0034277E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_EnterBMReadyScene.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA7D RID: 60029 RVA: 0x0034459A File Offset: 0x0034279A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_EnterBMReadyScene.OnTimeout(this.oArg);
		}

		// Token: 0x0400654A RID: 25930
		public EnterBMReadySceneArg oArg = new EnterBMReadySceneArg();

		// Token: 0x0400654B RID: 25931
		public EnterBMReadySceneRes oRes = null;
	}
}
