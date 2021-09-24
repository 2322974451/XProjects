using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarRoleRankRes")]
	[Serializable]
	public class ResWarRoleRankRes : IExtensible
	{

		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<ResWarRoleRank> data
		{
			get
			{
				return this._data;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ResWarRoleRank> _data = new List<ResWarRoleRank>();

		private IExtension extensionObject;
	}
}
