using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001045 RID: 4165
	internal class RpcC2G_BuyJadeSlot : Rpc
	{
		// Token: 0x0600D5C9 RID: 54729 RVA: 0x00324F4C File Offset: 0x0032314C
		public override uint GetRpcType()
		{
			return 37813U;
		}

		// Token: 0x0600D5CA RID: 54730 RVA: 0x00324F63 File Offset: 0x00323163
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyJadeSlotArg>(stream, this.oArg);
		}

		// Token: 0x0600D5CB RID: 54731 RVA: 0x00324F73 File Offset: 0x00323173
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyJadeSlotRes>(stream);
		}

		// Token: 0x0600D5CC RID: 54732 RVA: 0x00324F82 File Offset: 0x00323182
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyJadeSlot.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D5CD RID: 54733 RVA: 0x00324F9E File Offset: 0x0032319E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyJadeSlot.OnTimeout(this.oArg);
		}

		// Token: 0x04006152 RID: 24914
		public BuyJadeSlotArg oArg = new BuyJadeSlotArg();

		// Token: 0x04006153 RID: 24915
		public BuyJadeSlotRes oRes = new BuyJadeSlotRes();
	}
}
