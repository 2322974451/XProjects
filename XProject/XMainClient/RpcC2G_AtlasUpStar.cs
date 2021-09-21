using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001474 RID: 5236
	internal class RpcC2G_AtlasUpStar : Rpc
	{
		// Token: 0x0600E6D3 RID: 59091 RVA: 0x0033F0F8 File Offset: 0x0033D2F8
		public override uint GetRpcType()
		{
			return 41051U;
		}

		// Token: 0x0600E6D4 RID: 59092 RVA: 0x0033F10F File Offset: 0x0033D30F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AtlasUpStarArg>(stream, this.oArg);
		}

		// Token: 0x0600E6D5 RID: 59093 RVA: 0x0033F11F File Offset: 0x0033D31F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AtlasUpStarRes>(stream);
		}

		// Token: 0x0600E6D6 RID: 59094 RVA: 0x0033F12E File Offset: 0x0033D32E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AtlasUpStar.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E6D7 RID: 59095 RVA: 0x0033F14A File Offset: 0x0033D34A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AtlasUpStar.OnTimeout(this.oArg);
		}

		// Token: 0x04006490 RID: 25744
		public AtlasUpStarArg oArg = new AtlasUpStarArg();

		// Token: 0x04006491 RID: 25745
		public AtlasUpStarRes oRes = null;
	}
}
