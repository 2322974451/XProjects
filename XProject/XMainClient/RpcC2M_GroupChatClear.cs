using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001590 RID: 5520
	internal class RpcC2M_GroupChatClear : Rpc
	{
		// Token: 0x0600EB61 RID: 60257 RVA: 0x00345B1C File Offset: 0x00343D1C
		public override uint GetRpcType()
		{
			return 61477U;
		}

		// Token: 0x0600EB62 RID: 60258 RVA: 0x00345B33 File Offset: 0x00343D33
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatClearC2S>(stream, this.oArg);
		}

		// Token: 0x0600EB63 RID: 60259 RVA: 0x00345B43 File Offset: 0x00343D43
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatClearS2C>(stream);
		}

		// Token: 0x0600EB64 RID: 60260 RVA: 0x00345B52 File Offset: 0x00343D52
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatClear.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB65 RID: 60261 RVA: 0x00345B6E File Offset: 0x00343D6E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatClear.OnTimeout(this.oArg);
		}

		// Token: 0x04006578 RID: 25976
		public GroupChatClearC2S oArg = new GroupChatClearC2S();

		// Token: 0x04006579 RID: 25977
		public GroupChatClearS2C oRes = null;
	}
}
