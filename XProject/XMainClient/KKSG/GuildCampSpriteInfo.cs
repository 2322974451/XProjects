using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampSpriteInfo")]
	[Serializable]
	public class GuildCampSpriteInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public int position
		{
			get
			{
				return this._position ?? 0;
			}
			set
			{
				this._position = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new int?(this.position) : null);
				}
			}
		}

		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "summoner", DataFormat = DataFormat.Default)]
		public string summoner
		{
			get
			{
				return this._summoner ?? "";
			}
			set
			{
				this._summoner = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool summonerSpecified
		{
			get
			{
				return this._summoner != null;
			}
			set
			{
				bool flag = value == (this._summoner == null);
				if (flag)
				{
					this._summoner = (value ? this.summoner : null);
				}
			}
		}

		private bool ShouldSerializesummoner()
		{
			return this.summonerSpecified;
		}

		private void Resetsummoner()
		{
			this.summonerSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _sprite_id;

		private int? _position;

		private string _summoner;

		private IExtension extensionObject;
	}
}
