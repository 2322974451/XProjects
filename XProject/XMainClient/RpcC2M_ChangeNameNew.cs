using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B55 RID: 2901
	internal class RpcC2M_ChangeNameNew : Rpc
	{
		// Token: 0x0600A8D9 RID: 43225 RVA: 0x001E11CC File Offset: 0x001DF3CC
		public override uint GetRpcType()
		{
			return 46227U;
		}

		// Token: 0x0600A8DA RID: 43226 RVA: 0x001E11E3 File Offset: 0x001DF3E3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeNameArg>(stream, this.oArg);
		}

		// Token: 0x0600A8DB RID: 43227 RVA: 0x001E11F3 File Offset: 0x001DF3F3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeNameRes>(stream);
		}

		// Token: 0x0600A8DC RID: 43228 RVA: 0x001E1202 File Offset: 0x001DF402
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeNameNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8DD RID: 43229 RVA: 0x001E121E File Offset: 0x001DF41E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeNameNew.OnTimeout(this.oArg);
		}

		// Token: 0x04003E8A RID: 16010
		public ChangeNameArg oArg = new ChangeNameArg();

		// Token: 0x04003E8B RID: 16011
		public ChangeNameRes oRes = null;
	}
}
