using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001089 RID: 4233
	internal class RpcC2G_StageCountReset : Rpc
	{
		// Token: 0x0600D6E5 RID: 55013 RVA: 0x00326E54 File Offset: 0x00325054
		public override uint GetRpcType()
		{
			return 8496U;
		}

		// Token: 0x0600D6E6 RID: 55014 RVA: 0x00326E6B File Offset: 0x0032506B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StageCountResetArg>(stream, this.oArg);
		}

		// Token: 0x0600D6E7 RID: 55015 RVA: 0x00326E7B File Offset: 0x0032507B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StageCountResetRes>(stream);
		}

		// Token: 0x0600D6E8 RID: 55016 RVA: 0x00326E8A File Offset: 0x0032508A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_StageCountReset.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6E9 RID: 55017 RVA: 0x00326EA6 File Offset: 0x003250A6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_StageCountReset.OnTimeout(this.oArg);
		}

		// Token: 0x0400618F RID: 24975
		public StageCountResetArg oArg = new StageCountResetArg();

		// Token: 0x04006190 RID: 24976
		public StageCountResetRes oRes = new StageCountResetRes();
	}
}
