using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001235 RID: 4661
	internal class RpcC2G_ChangeOutLookOp : Rpc
	{
		// Token: 0x0600DDA0 RID: 56736 RVA: 0x00332268 File Offset: 0x00330468
		public override uint GetRpcType()
		{
			return 56978U;
		}

		// Token: 0x0600DDA1 RID: 56737 RVA: 0x0033227F File Offset: 0x0033047F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeOutLookOpArg>(stream, this.oArg);
		}

		// Token: 0x0600DDA2 RID: 56738 RVA: 0x0033228F File Offset: 0x0033048F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeOutLookOpRes>(stream);
		}

		// Token: 0x0600DDA3 RID: 56739 RVA: 0x0033229E File Offset: 0x0033049E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeOutLookOp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDA4 RID: 56740 RVA: 0x003322BA File Offset: 0x003304BA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeOutLookOp.OnTimeout(this.oArg);
		}

		// Token: 0x040062CC RID: 25292
		public ChangeOutLookOpArg oArg = new ChangeOutLookOpArg();

		// Token: 0x040062CD RID: 25293
		public ChangeOutLookOpRes oRes = new ChangeOutLookOpRes();
	}
}
