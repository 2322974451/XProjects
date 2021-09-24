using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDanceIdsRes")]
	[Serializable]
	public class GetDanceIdsRes : IExtensible
	{

		[ProtoMember(1, Name = "danceid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> danceid
		{
			get
			{
				return this._danceid;
			}
		}

		[ProtoMember(2, Name = "valid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> valid
		{
			get
			{
				return this._valid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _danceid = new List<uint>();

		private readonly List<uint> _valid = new List<uint>();

		private IExtension extensionObject;
	}
}
