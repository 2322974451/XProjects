using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCraftRankData")]
	[Serializable]
	public class SkyCraftRankData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "stid", DataFormat = DataFormat.TwosComplement)]
		public ulong stid
		{
			get
			{
				return this._stid ?? 0UL;
			}
			set
			{
				this._stid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stidSpecified
		{
			get
			{
				return this._stid != null;
			}
			set
			{
				bool flag = value == (this._stid == null);
				if (flag)
				{
					this._stid = (value ? new ulong?(this.stid) : null);
				}
			}
		}

		private bool ShouldSerializestid()
		{
			return this.stidSpecified;
		}

		private void Resetstid()
		{
			this.stidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "teamname", DataFormat = DataFormat.Default)]
		public string teamname
		{
			get
			{
				return this._teamname ?? "";
			}
			set
			{
				this._teamname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamnameSpecified
		{
			get
			{
				return this._teamname != null;
			}
			set
			{
				bool flag = value == (this._teamname == null);
				if (flag)
				{
					this._teamname = (value ? this.teamname : null);
				}
			}
		}

		private bool ShouldSerializeteamname()
		{
			return this.teamnameSpecified;
		}

		private void Resetteamname()
		{
			this.teamnameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _stid;

		private string _teamname;

		private uint? _point;

		private uint? _winnum;

		private float? _winrate;

		private IExtension extensionObject;
	}
}
