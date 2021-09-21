using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200151A RID: 5402
	internal class RpcC2G_GetGuildPartyReceiveInfo : Rpc
	{
		// Token: 0x0600E981 RID: 59777 RVA: 0x00342D88 File Offset: 0x00340F88
		public override uint GetRpcType()
		{
			return 58154U;
		}

		// Token: 0x0600E982 RID: 59778 RVA: 0x00342D9F File Offset: 0x00340F9F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildPartyReceiveInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E983 RID: 59779 RVA: 0x00342DAF File Offset: 0x00340FAF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildPartyReceiveInfoRes>(stream);
		}

		// Token: 0x0600E984 RID: 59780 RVA: 0x00342DBE File Offset: 0x00340FBE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildPartyReceiveInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E985 RID: 59781 RVA: 0x00342DDA File Offset: 0x00340FDA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildPartyReceiveInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006515 RID: 25877
		public GetGuildPartyReceiveInfoArg oArg = new GetGuildPartyReceiveInfoArg();

		// Token: 0x04006516 RID: 25878
		public GetGuildPartyReceiveInfoRes oRes = null;
	}
}
