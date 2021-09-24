using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildTerrIntellInfoRes")]
	[Serializable]
	public class ReqGuildTerrIntellInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "intellInfo", DataFormat = DataFormat.Default)]
		public List<TerrData> intellInfo
		{
			get
			{
				return this._intellInfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<TerrData> _intellInfo = new List<TerrData>();

		private IExtension extensionObject;
	}
}
