using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroKillUnit")]
	[Serializable]
	public class HeroKillUnit : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public HeroKillUnitType type
		{
			get
			{
				return this._type ?? HeroKillUnitType.HeroKillUnit_Hero;
			}
			set
			{
				this._type = new HeroKillUnitType?(value);
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
					this._type = (value ? new HeroKillUnitType?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "continueCounts", DataFormat = DataFormat.TwosComplement)]
		public uint continueCounts
		{
			get
			{
				return this._continueCounts ?? 0U;
			}
			set
			{
				this._continueCounts = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool continueCountsSpecified
		{
			get
			{
				return this._continueCounts != null;
			}
			set
			{
				bool flag = value == (this._continueCounts == null);
				if (flag)
				{
					this._continueCounts = (value ? new uint?(this.continueCounts) : null);
				}
			}
		}

		private bool ShouldSerializecontinueCounts()
		{
			return this.continueCountsSpecified;
		}

		private void ResetcontinueCounts()
		{
			this.continueCountsSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private HeroKillUnitType? _type;

		private uint? _id;

		private uint? _teamid;

		private uint? _continueCounts;

		private IExtension extensionObject;
	}
}
