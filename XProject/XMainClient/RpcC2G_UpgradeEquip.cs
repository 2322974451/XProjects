using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015DF RID: 5599
	internal class RpcC2G_UpgradeEquip : Rpc
	{
		// Token: 0x0600ECA4 RID: 60580 RVA: 0x00347548 File Offset: 0x00345748
		public override uint GetRpcType()
		{
			return 32424U;
		}

		// Token: 0x0600ECA5 RID: 60581 RVA: 0x0034755F File Offset: 0x0034575F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpgradeEquipArg>(stream, this.oArg);
		}

		// Token: 0x0600ECA6 RID: 60582 RVA: 0x0034756F File Offset: 0x0034576F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UpgradeEquipRes>(stream);
		}

		// Token: 0x0600ECA7 RID: 60583 RVA: 0x0034757E File Offset: 0x0034577E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_UpgradeEquip.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ECA8 RID: 60584 RVA: 0x0034759A File Offset: 0x0034579A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_UpgradeEquip.OnTimeout(this.oArg);
		}

		// Token: 0x040065B4 RID: 26036
		public UpgradeEquipArg oArg = new UpgradeEquipArg();

		// Token: 0x040065B5 RID: 26037
		public UpgradeEquipRes oRes = null;
	}
}
