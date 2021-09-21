using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001478 RID: 5240
	internal class RpcC2G_ForgeEquip : Rpc
	{
		// Token: 0x0600E6E3 RID: 59107 RVA: 0x0033F3C0 File Offset: 0x0033D5C0
		public override uint GetRpcType()
		{
			return 58244U;
		}

		// Token: 0x0600E6E4 RID: 59108 RVA: 0x0033F3D7 File Offset: 0x0033D5D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ForgeEquipArg>(stream, this.oArg);
		}

		// Token: 0x0600E6E5 RID: 59109 RVA: 0x0033F3E7 File Offset: 0x0033D5E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ForgeEquipRes>(stream);
		}

		// Token: 0x0600E6E6 RID: 59110 RVA: 0x0033F3F6 File Offset: 0x0033D5F6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ForgeEquip.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E6E7 RID: 59111 RVA: 0x0033F412 File Offset: 0x0033D612
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ForgeEquip.OnTimeout(this.oArg);
		}

		// Token: 0x04006493 RID: 25747
		public ForgeEquipArg oArg = new ForgeEquipArg();

		// Token: 0x04006494 RID: 25748
		public ForgeEquipRes oRes = null;
	}
}
