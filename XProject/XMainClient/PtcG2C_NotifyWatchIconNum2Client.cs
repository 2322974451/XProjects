using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyWatchIconNum2Client : Protocol
	{

		public override uint GetProtoType()
		{
			return 48952U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IconWatchListNum>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IconWatchListNum>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyWatchIconNum2Client.Process(this);
		}

		public IconWatchListNum Data = new IconWatchListNum();
	}
}
