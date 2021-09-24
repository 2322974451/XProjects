using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCraftEliRoomNtf")]
	[Serializable]
	public class SkyCraftEliRoomNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "room", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SCEliRoomInfo room
		{
			get
			{
				return this._room;
			}
			set
			{
				this._room = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private SCEliRoomInfo _room = null;

		private IExtension extensionObject;
	}
}
