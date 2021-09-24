using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarFinalAll")]
	[Serializable]
	public class ResWarFinalAll : IExtensible
	{

		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<ResWarFinal> data
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

		private readonly List<ResWarFinal> _data = new List<ResWarFinal>();

		private IExtension extensionObject;
	}
}
