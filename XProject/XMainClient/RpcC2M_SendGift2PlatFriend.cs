using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001342 RID: 4930
	internal class RpcC2M_SendGift2PlatFriend : Rpc
	{
		// Token: 0x0600E1FC RID: 57852 RVA: 0x00338654 File Offset: 0x00336854
		public override uint GetRpcType()
		{
			return 57764U;
		}

		// Token: 0x0600E1FD RID: 57853 RVA: 0x0033866B File Offset: 0x0033686B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGift2PlatFriendArg>(stream, this.oArg);
		}

		// Token: 0x0600E1FE RID: 57854 RVA: 0x0033867B File Offset: 0x0033687B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendGift2PlatFriendRes>(stream);
		}

		// Token: 0x0600E1FF RID: 57855 RVA: 0x0033868A File Offset: 0x0033688A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SendGift2PlatFriend.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E200 RID: 57856 RVA: 0x003386A6 File Offset: 0x003368A6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SendGift2PlatFriend.OnTimeout(this.oArg);
		}

		// Token: 0x040063A7 RID: 25511
		public SendGift2PlatFriendArg oArg = new SendGift2PlatFriendArg();

		// Token: 0x040063A8 RID: 25512
		public SendGift2PlatFriendRes oRes = null;
	}
}
