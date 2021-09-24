using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CrossGvgRoomStateNtf")]
	[Serializable]
	public class CrossGvgRoomStateNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "room", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CrossGvgRoomInfo room
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

		[ProtoMember(2, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CrossGvgRacePointRecord record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CrossGvgRoomInfo _room = null;

		private CrossGvgRacePointRecord _record = null;

		private IExtension extensionObject;
	}
}
