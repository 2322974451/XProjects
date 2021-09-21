using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200153B RID: 5435
	internal class PtcG2C_TransSkillNotfiy : Protocol
	{
		// Token: 0x0600EA04 RID: 59908 RVA: 0x003438B8 File Offset: 0x00341AB8
		public override uint GetProtoType()
		{
			return 1366U;
		}

		// Token: 0x0600EA05 RID: 59909 RVA: 0x003438CF File Offset: 0x00341ACF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TransSkillNotfiy>(stream, this.Data);
		}

		// Token: 0x0600EA06 RID: 59910 RVA: 0x003438DF File Offset: 0x00341ADF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TransSkillNotfiy>(stream);
		}

		// Token: 0x0600EA07 RID: 59911 RVA: 0x003438EE File Offset: 0x00341AEE
		public override void Process()
		{
			Process_PtcG2C_TransSkillNotfiy.Process(this);
		}

		// Token: 0x0400652D RID: 25901
		public TransSkillNotfiy Data = new TransSkillNotfiy();
	}
}
