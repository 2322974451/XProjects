using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001085 RID: 4229
	internal class RpcC2G_GetGuildCheckinBox : Rpc
	{
		// Token: 0x0600D6D5 RID: 54997 RVA: 0x00326CF0 File Offset: 0x00324EF0
		public override uint GetRpcType()
		{
			return 19269U;
		}

		// Token: 0x0600D6D6 RID: 54998 RVA: 0x00326D07 File Offset: 0x00324F07
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCheckinBoxArg>(stream, this.oArg);
		}

		// Token: 0x0600D6D7 RID: 54999 RVA: 0x00326D17 File Offset: 0x00324F17
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCheckinBoxRes>(stream);
		}

		// Token: 0x0600D6D8 RID: 55000 RVA: 0x00326D26 File Offset: 0x00324F26
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCheckinBox.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6D9 RID: 55001 RVA: 0x00326D42 File Offset: 0x00324F42
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCheckinBox.OnTimeout(this.oArg);
		}

		// Token: 0x0400618C RID: 24972
		public GetGuildCheckinBoxArg oArg = new GetGuildCheckinBoxArg();

		// Token: 0x0400618D RID: 24973
		public GetGuildCheckinBoxRes oRes = new GetGuildCheckinBoxRes();
	}
}
