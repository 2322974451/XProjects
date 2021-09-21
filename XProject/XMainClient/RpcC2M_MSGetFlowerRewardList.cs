using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011F3 RID: 4595
	internal class RpcC2M_MSGetFlowerRewardList : Rpc
	{
		// Token: 0x0600DC92 RID: 56466 RVA: 0x003308E8 File Offset: 0x0032EAE8
		public override uint GetRpcType()
		{
			return 16271U;
		}

		// Token: 0x0600DC93 RID: 56467 RVA: 0x003308FF File Offset: 0x0032EAFF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NewGetFlowerRewardListArg>(stream, this.oArg);
		}

		// Token: 0x0600DC94 RID: 56468 RVA: 0x0033090F File Offset: 0x0032EB0F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<NewGetFlowerRewardListRes>(stream);
		}

		// Token: 0x0600DC95 RID: 56469 RVA: 0x0033091E File Offset: 0x0032EB1E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MSGetFlowerRewardList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC96 RID: 56470 RVA: 0x0033093A File Offset: 0x0032EB3A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MSGetFlowerRewardList.OnTimeout(this.oArg);
		}

		// Token: 0x04006298 RID: 25240
		public NewGetFlowerRewardListArg oArg = new NewGetFlowerRewardListArg();

		// Token: 0x04006299 RID: 25241
		public NewGetFlowerRewardListRes oRes = null;
	}
}
