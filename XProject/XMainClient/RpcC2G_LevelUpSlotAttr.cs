using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010D6 RID: 4310
	internal class RpcC2G_LevelUpSlotAttr : Rpc
	{
		// Token: 0x0600D810 RID: 55312 RVA: 0x00329034 File Offset: 0x00327234
		public override uint GetRpcType()
		{
			return 62918U;
		}

		// Token: 0x0600D811 RID: 55313 RVA: 0x0032904B File Offset: 0x0032724B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelUpSlotAttrArg>(stream, this.oArg);
		}

		// Token: 0x0600D812 RID: 55314 RVA: 0x0032905B File Offset: 0x0032725B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LevelUpSlotAttrRes>(stream);
		}

		// Token: 0x0600D813 RID: 55315 RVA: 0x0032906A File Offset: 0x0032726A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LevelUpSlotAttr.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D814 RID: 55316 RVA: 0x00329086 File Offset: 0x00327286
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LevelUpSlotAttr.OnTimeout(this.oArg);
		}

		// Token: 0x040061C1 RID: 25025
		public LevelUpSlotAttrArg oArg = new LevelUpSlotAttrArg();

		// Token: 0x040061C2 RID: 25026
		public LevelUpSlotAttrRes oRes = new LevelUpSlotAttrRes();
	}
}
