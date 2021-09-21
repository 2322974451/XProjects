using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001083 RID: 4227
	internal class RpcC2T_ClientLoginRequest : Rpc
	{
		// Token: 0x0600D6CA RID: 54986 RVA: 0x00326AEC File Offset: 0x00324CEC
		public override uint GetRpcType()
		{
			return 10091U;
		}

		// Token: 0x0600D6CB RID: 54987 RVA: 0x00326B03 File Offset: 0x00324D03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginArg>(stream, this.oArg);
		}

		// Token: 0x0600D6CC RID: 54988 RVA: 0x00326B13 File Offset: 0x00324D13
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LoginRes>(stream);
		}

		// Token: 0x0600D6CD RID: 54989 RVA: 0x00326B22 File Offset: 0x00324D22
		public override void Process()
		{
			base.Process();
			Process_RpcC2T_ClientLoginRequest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6CE RID: 54990 RVA: 0x00326B3E File Offset: 0x00324D3E
		public override void OnTimeout(object args)
		{
			Process_RpcC2T_ClientLoginRequest.OnTimeout(this.oArg);
		}

		// Token: 0x0400618A RID: 24970
		public LoginArg oArg = new LoginArg();

		// Token: 0x0400618B RID: 24971
		public LoginRes oRes = new LoginRes();
	}
}
