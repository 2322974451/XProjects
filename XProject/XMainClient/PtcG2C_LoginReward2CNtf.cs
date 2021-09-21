using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011CE RID: 4558
	internal class PtcG2C_LoginReward2CNtf : Protocol
	{
		// Token: 0x0600DBFF RID: 56319 RVA: 0x0032FBCC File Offset: 0x0032DDCC
		public override uint GetProtoType()
		{
			return 51966U;
		}

		// Token: 0x0600DC00 RID: 56320 RVA: 0x0032FBE3 File Offset: 0x0032DDE3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginRewardRet>(stream, this.Data);
		}

		// Token: 0x0600DC01 RID: 56321 RVA: 0x0032FBF3 File Offset: 0x0032DDF3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoginRewardRet>(stream);
		}

		// Token: 0x0600DC02 RID: 56322 RVA: 0x0032FC02 File Offset: 0x0032DE02
		public override void Process()
		{
			Process_PtcG2C_LoginReward2CNtf.Process(this);
		}

		// Token: 0x0400627D RID: 25213
		public LoginRewardRet Data = new LoginRewardRet();
	}
}
