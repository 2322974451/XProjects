using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildInheritInfoRes")]
	[Serializable]
	public class ReqGuildInheritInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<InheritData> data
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

		private readonly List<InheritData> _data = new List<InheritData>();

		private IExtension extensionObject;
	}
}
