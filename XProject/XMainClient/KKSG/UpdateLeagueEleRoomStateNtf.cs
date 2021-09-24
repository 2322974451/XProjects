using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateLeagueEleRoomStateNtf")]
	[Serializable]
	public class UpdateLeagueEleRoomStateNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "room", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LBEleRoomInfo room
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

		private LBEleRoomInfo _room = null;

		private IExtension extensionObject;
	}
}
