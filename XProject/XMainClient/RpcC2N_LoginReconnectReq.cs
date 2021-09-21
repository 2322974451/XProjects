using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200154F RID: 5455
	internal class RpcC2N_LoginReconnectReq : Rpc
	{
		// Token: 0x0600EA56 RID: 59990 RVA: 0x003440D8 File Offset: 0x003422D8
		public override uint GetRpcType()
		{
			return 25422U;
		}

		// Token: 0x0600EA57 RID: 59991 RVA: 0x003440EF File Offset: 0x003422EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginReconnectReqArg>(stream, this.oArg);
		}

		// Token: 0x0600EA58 RID: 59992 RVA: 0x003440FF File Offset: 0x003422FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LoginReconnectReqRes>(stream);
		}

		// Token: 0x0600EA59 RID: 59993 RVA: 0x0034410E File Offset: 0x0034230E
		public override void Process()
		{
			base.Process();
			Process_RpcC2N_LoginReconnectReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA5A RID: 59994 RVA: 0x0034412A File Offset: 0x0034232A
		public override void OnTimeout(object args)
		{
			Process_RpcC2N_LoginReconnectReq.OnTimeout(this.oArg);
		}

		// Token: 0x0400653D RID: 25917
		public LoginReconnectReqArg oArg = new LoginReconnectReqArg();

		// Token: 0x0400653E RID: 25918
		public LoginReconnectReqRes oRes = null;
	}
}
