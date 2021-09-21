using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200163E RID: 5694
	internal class RpcC2M_BuyDragonGuildShopItem : Rpc
	{
		// Token: 0x0600EE3B RID: 60987 RVA: 0x003497E8 File Offset: 0x003479E8
		public override uint GetRpcType()
		{
			return 24893U;
		}

		// Token: 0x0600EE3C RID: 60988 RVA: 0x003497FF File Offset: 0x003479FF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyDragonGuildShopItemArg>(stream, this.oArg);
		}

		// Token: 0x0600EE3D RID: 60989 RVA: 0x0034980F File Offset: 0x00347A0F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyDragonGuildShopItemRes>(stream);
		}

		// Token: 0x0600EE3E RID: 60990 RVA: 0x0034981E File Offset: 0x00347A1E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_BuyDragonGuildShopItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE3F RID: 60991 RVA: 0x0034983A File Offset: 0x00347A3A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_BuyDragonGuildShopItem.OnTimeout(this.oArg);
		}

		// Token: 0x04006608 RID: 26120
		public BuyDragonGuildShopItemArg oArg = new BuyDragonGuildShopItemArg();

		// Token: 0x04006609 RID: 26121
		public BuyDragonGuildShopItemRes oRes = null;
	}
}
