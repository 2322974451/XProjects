﻿using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MobaSignalBroadcast : Protocol
	{

		public override uint GetProtoType()
		{
			return 6250U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaSignalBroadcastData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaSignalBroadcastData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MobaSignalBroadcast.Process(this);
		}

		public MobaSignalBroadcastData Data = new MobaSignalBroadcastData();
	}
}