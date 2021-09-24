using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SetPreShowArg")]
	[Serializable]
	public class SetPreShowArg : IExtensible
	{

		[ProtoMember(1, Name = "showid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> showid
		{
			get
			{
				return this._showid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _showid = new List<uint>();

		private IExtension extensionObject;
	}
}
