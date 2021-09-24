using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarAllTeamBaseInfo")]
	[Serializable]
	public class ResWarAllTeamBaseInfo : IExtensible
	{

		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<ResWarTeamBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ResWarTeamBaseInfo> _info = new List<ResWarTeamBaseInfo>();

		private IExtension extensionObject;
	}
}
