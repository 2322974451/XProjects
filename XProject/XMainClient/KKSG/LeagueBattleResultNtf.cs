using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LeagueBattleResultNtf")]
	[Serializable]
	public class LeagueBattleResultNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleType type
		{
			get
			{
				return this._type ?? LeagueBattleType.LeagueBattleType_RacePoint;
			}
			set
			{
				this._type = new LeagueBattleType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new LeagueBattleType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "winteam", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleResultTeam winteam
		{
			get
			{
				return this._winteam;
			}
			set
			{
				this._winteam = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "loseteam", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleResultTeam loseteam
		{
			get
			{
				return this._loseteam;
			}
			set
			{
				this._loseteam = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LeagueBattleType? _type;

		private LeagueBattleResultTeam _winteam = null;

		private LeagueBattleResultTeam _loseteam = null;

		private IExtension extensionObject;
	}
}
