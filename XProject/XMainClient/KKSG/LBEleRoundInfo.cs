using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LBEleRoundInfo")]
	[Serializable]
	public class LBEleRoundInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public uint round
		{
			get
			{
				return this._round ?? 0U;
			}
			set
			{
				this._round = new uint?(value);
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
					this._round = (value ? new uint?(this.round) : null);
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
		public List<LBEleRoomInfo> rooms
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

		private uint? _round;

		private readonly List<LBEleRoomInfo> _rooms = new List<LBEleRoomInfo>();

		private IExtension extensionObject;
	}
}
