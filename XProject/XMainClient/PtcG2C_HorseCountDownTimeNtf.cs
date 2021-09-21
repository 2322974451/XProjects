using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013FA RID: 5114
	internal class PtcG2C_HorseCountDownTimeNtf : Protocol
	{
		// Token: 0x0600E4ED RID: 58605 RVA: 0x0033C500 File Offset: 0x0033A700
		public override uint GetProtoType()
		{
			return 65307U;
		}

		// Token: 0x0600E4EE RID: 58606 RVA: 0x0033C517 File Offset: 0x0033A717
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseCountDownTime>(stream, this.Data);
		}

		// Token: 0x0600E4EF RID: 58607 RVA: 0x0033C527 File Offset: 0x0033A727
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HorseCountDownTime>(stream);
		}

		// Token: 0x0600E4F0 RID: 58608 RVA: 0x0033C536 File Offset: 0x0033A736
		public override void Process()
		{
			Process_PtcG2C_HorseCountDownTimeNtf.Process(this);
		}

		// Token: 0x04006438 RID: 25656
		public HorseCountDownTime Data = new HorseCountDownTime();
	}
}
