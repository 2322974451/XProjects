using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001488 RID: 5256
	internal class RpcC2G_ChangeProfession : Rpc
	{
		// Token: 0x0600E723 RID: 59171 RVA: 0x0033F954 File Offset: 0x0033DB54
		public override uint GetRpcType()
		{
			return 48822U;
		}

		// Token: 0x0600E724 RID: 59172 RVA: 0x0033F96B File Offset: 0x0033DB6B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeProfessionArg>(stream, this.oArg);
		}

		// Token: 0x0600E725 RID: 59173 RVA: 0x0033F97B File Offset: 0x0033DB7B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeProfessionRes>(stream);
		}

		// Token: 0x0600E726 RID: 59174 RVA: 0x0033F98A File Offset: 0x0033DB8A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeProfession.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E727 RID: 59175 RVA: 0x0033F9A6 File Offset: 0x0033DBA6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeProfession.OnTimeout(this.oArg);
		}

		// Token: 0x0400649F RID: 25759
		public ChangeProfessionArg oArg = new ChangeProfessionArg();

		// Token: 0x040064A0 RID: 25760
		public ChangeProfessionRes oRes = null;
	}
}
