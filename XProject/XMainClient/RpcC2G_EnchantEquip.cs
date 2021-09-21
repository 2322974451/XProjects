using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200147A RID: 5242
	internal class RpcC2G_EnchantEquip : Rpc
	{
		// Token: 0x0600E6EC RID: 59116 RVA: 0x0033F454 File Offset: 0x0033D654
		public override uint GetRpcType()
		{
			return 55166U;
		}

		// Token: 0x0600E6ED RID: 59117 RVA: 0x0033F46B File Offset: 0x0033D66B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnchantEquipArg>(stream, this.oArg);
		}

		// Token: 0x0600E6EE RID: 59118 RVA: 0x0033F47B File Offset: 0x0033D67B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnchantEquipRes>(stream);
		}

		// Token: 0x0600E6EF RID: 59119 RVA: 0x0033F48A File Offset: 0x0033D68A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnchantEquip.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E6F0 RID: 59120 RVA: 0x0033F4A6 File Offset: 0x0033D6A6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnchantEquip.OnTimeout(this.oArg);
		}

		// Token: 0x04006495 RID: 25749
		public EnchantEquipArg oArg = new EnchantEquipArg();

		// Token: 0x04006496 RID: 25750
		public EnchantEquipRes oRes = null;
	}
}
