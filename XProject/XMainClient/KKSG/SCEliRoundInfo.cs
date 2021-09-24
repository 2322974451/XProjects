using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SCEliRoundInfo")]
	[Serializable]
	public class SCEliRoundInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public SCEliRoundType round
		{
			get
			{
				return this._round ?? SCEliRoundType.SCEliRound_None;
			}
			set
			{
				this._round = new SCEliRoundType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roundSpecified
		{
			get
			{
				return this._round != null;
			}
			set
			{
				bool flag = value == (this._round == null);
				if (flag)
				{
					this._round = (value ? new SCEliRoundType?(this.round) : null);
				}
			}
		}

		private bool ShouldSerializeround()
		{
			return this.roundSpecified;
		}

		private void Resetround()
		{
			this.roundSpecified = false;
		}

		[ProtoMember(2, Name = "rooms", DataFormat = DataFormat.Default)]
		public List<SCEliRoomInfo> rooms
		{
			get
			{
				return this._rooms;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private SCEliRoundType? _round;

		private readonly List<SCEliRoomInfo> _rooms = new List<SCEliRoomInfo>();

		private IExtension extensionObject;
	}
}
