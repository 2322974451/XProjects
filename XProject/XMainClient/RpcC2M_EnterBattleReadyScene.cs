using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015E2 RID: 5602
	internal class RpcC2M_EnterBattleReadyScene : Rpc
	{
		// Token: 0x0600ECB2 RID: 60594 RVA: 0x00347624 File Offset: 0x00345824
		public override uint GetRpcType()
		{
			return 55233U;
		}

		// Token: 0x0600ECB3 RID: 60595 RVA: 0x0034763B File Offset: 0x0034583B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterBattleReadySceneArg>(stream, this.oArg);
		}

		// Token: 0x0600ECB4 RID: 60596 RVA: 0x0034764B File Offset: 0x0034584B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterBattleReadySceneRes>(stream);
		}

		// Token: 0x0600ECB5 RID: 60597 RVA: 0x0034765A File Offset: 0x0034585A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_EnterBattleReadyScene.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ECB6 RID: 60598 RVA: 0x00347676 File Offset: 0x00345876
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_EnterBattleReadyScene.OnTimeout(this.oArg);
		}

		// Token: 0x040065B7 RID: 26039
		public EnterBattleReadySceneArg oArg = new EnterBattleReadySceneArg();

		// Token: 0x040065B8 RID: 26040
		public EnterBattleReadySceneRes oRes = null;
	}
}
