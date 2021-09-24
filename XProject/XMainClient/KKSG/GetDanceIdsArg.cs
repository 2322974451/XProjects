using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDanceIdsArg")]
	[Serializable]
	public class GetDanceIdsArg : IExtensible
	{

		[ProtoMember(1, Name = "danceid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> danceid
		{
			get
			{
				return this._danceid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _danceid = new List<uint>();

		private IExtension extensionObject;
	}
}
