using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200125B RID: 4699
	internal class RpcC2G_PlayDiceRequest : Rpc
	{
		// Token: 0x0600DE41 RID: 56897 RVA: 0x00333030 File Offset: 0x00331230
		public override uint GetRpcType()
		{
			return 51246U;
		}

		// Token: 0x0600DE42 RID: 56898 RVA: 0x00333047 File Offset: 0x00331247
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceRequestArg>(stream, this.oArg);
		}

		// Token: 0x0600DE43 RID: 56899 RVA: 0x00333057 File Offset: 0x00331257
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlayDiceRequestRes>(stream);
		}

		// Token: 0x0600DE44 RID: 56900 RVA: 0x00333066 File Offset: 0x00331266
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PlayDiceRequest.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE45 RID: 56901 RVA: 0x00333082 File Offset: 0x00331282
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PlayDiceRequest.OnTimeout(this.oArg);
		}

		// Token: 0x040062ED RID: 25325
		public PlayDiceRequestArg oArg = new PlayDiceRequestArg();

		// Token: 0x040062EE RID: 25326
		public PlayDiceRequestRes oRes = new PlayDiceRequestRes();
	}
}
