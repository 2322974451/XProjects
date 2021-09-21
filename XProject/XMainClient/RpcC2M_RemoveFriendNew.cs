using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011A4 RID: 4516
	internal class RpcC2M_RemoveFriendNew : Rpc
	{
		// Token: 0x0600DB56 RID: 56150 RVA: 0x0032EE08 File Offset: 0x0032D008
		public override uint GetRpcType()
		{
			return 2841U;
		}

		// Token: 0x0600DB57 RID: 56151 RVA: 0x0032EE1F File Offset: 0x0032D01F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RemoveFriendArg>(stream, this.oArg);
		}

		// Token: 0x0600DB58 RID: 56152 RVA: 0x0032EE2F File Offset: 0x0032D02F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RemoveFriendRes>(stream);
		}

		// Token: 0x0600DB59 RID: 56153 RVA: 0x0032EE3E File Offset: 0x0032D03E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RemoveFriendNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DB5A RID: 56154 RVA: 0x0032EE5A File Offset: 0x0032D05A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RemoveFriendNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400625E RID: 25182
		public RemoveFriendArg oArg = new RemoveFriendArg();

		// Token: 0x0400625F RID: 25183
		public RemoveFriendRes oRes = null;
	}
}
