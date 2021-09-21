using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001114 RID: 4372
	internal class RpcC2G_AskForCheckInBonus : Rpc
	{
		// Token: 0x0600D912 RID: 55570 RVA: 0x0032A72C File Offset: 0x0032892C
		public override uint GetRpcType()
		{
			return 32843U;
		}

		// Token: 0x0600D913 RID: 55571 RVA: 0x0032A743 File Offset: 0x00328943
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskForCheckInBonusArg>(stream, this.oArg);
		}

		// Token: 0x0600D914 RID: 55572 RVA: 0x0032A753 File Offset: 0x00328953
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskForCheckInBonusRes>(stream);
		}

		// Token: 0x0600D915 RID: 55573 RVA: 0x0032A762 File Offset: 0x00328962
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AskForCheckInBonus.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D916 RID: 55574 RVA: 0x0032A77E File Offset: 0x0032897E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AskForCheckInBonus.OnTimeout(this.oArg);
		}

		// Token: 0x040061F3 RID: 25075
		public AskForCheckInBonusArg oArg = new AskForCheckInBonusArg();

		// Token: 0x040061F4 RID: 25076
		public AskForCheckInBonusRes oRes = new AskForCheckInBonusRes();
	}
}
