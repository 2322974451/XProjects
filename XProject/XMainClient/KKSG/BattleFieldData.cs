using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleFieldData")]
	[Serializable]
	public class BattleFieldData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "firstrankcount", DataFormat = DataFormat.TwosComplement)]
		public uint firstrankcount
		{
			get
			{
				return this._firstrankcount ?? 0U;
			}
			set
			{
				this._firstrankcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firstrankcountSpecified
		{
			get
			{
				return this._firstrankcount != null;
			}
			set
			{
				bool flag = value == (this._firstrankcount == null);
				if (flag)
				{
					this._firstrankcount = (value ? new uint?(this.firstrankcount) : null);
				}
			}
		}

		private bool ShouldSerializefirstrankcount()
		{
			return this.firstrankcountSpecified;
		}

		private void Resetfirstrankcount()
		{
			this.firstrankcountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "totalkillcount", DataFormat = DataFormat.TwosComplement)]
		public uint totalkillcount
		{
			get
			{
				return this._totalkillcount ?? 0U;
			}
			set
			{
				this._totalkillcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalkillcountSpecified
		{
			get
			{
				return this._totalkillcount != null;
			}
			set
			{
				bool flag = value == (this._totalkillcount == null);
				if (flag)
				{
					this._totalkillcount = (value ? new uint?(this.totalkillcount) : null);
				}
			}
		}

		private bool ShouldSerializetotalkillcount()
		{
			return this.totalkillcountSpecified;
		}

		private void Resettotalkillcount()
		{
			this.totalkillcountSpecified = false;
		}

		[ProtoMember(3, Name = "point", DataFormat = DataFormat.Default)]
		public List<BattleFieldPoint> point
		{
			get
			{
				return this._point;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "lastupdatetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastupdatetime
		{
			get
			{
				return this._lastupdatetime ?? 0U;
			}
			set
			{
				this._lastupdatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastupdatetimeSpecified
		{
			get
			{
				return this._lastupdatetime != null;
			}
			set
			{
				bool flag = value == (this._lastupdatetime == null);
				if (flag)
				{
					this._lastupdatetime = (value ? new uint?(this.lastupdatetime) : null);
				}
			}
		}

		private bool ShouldSerializelastupdatetime()
		{
			return this.lastupdatetimeSpecified;
		}

		private void Resetlastupdatetime()
		{
			this.lastupdatetimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "hell", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HellDropInfoAll hell
		{
			get
			{
				return this._hell;
			}
			set
			{
				this._hell = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "weekpoint", DataFormat = DataFormat.TwosComplement)]
		public uint weekpoint
		{
			get
			{
				return this._weekpoint ?? 0U;
			}
			set
			{
				this._weekpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekpointSpecified
		{
			get
			{
				return this._weekpoint != null;
			}
			set
			{
				bool flag = value == (this._weekpoint == null);
				if (flag)
				{
					this._weekpoint = (value ? new uint?(this.weekpoint) : null);
				}
			}
		}

		private bool ShouldSerializeweekpoint()
		{
			return this.weekpointSpecified;
		}

		private void Resetweekpoint()
		{
			this.weekpointSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "dayupdatetime", DataFormat = DataFormat.TwosComplement)]
		public uint dayupdatetime
		{
			get
			{
				return this._dayupdatetime ?? 0U;
			}
			set
			{
				this._dayupdatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dayupdatetimeSpecified
		{
			get
			{
				return this._dayupdatetime != null;
			}
			set
			{
				bool flag = value == (this._dayupdatetime == null);
				if (flag)
				{
					this._dayupdatetime = (value ? new uint?(this.dayupdatetime) : null);
				}
			}
		}

		private bool ShouldSerializedayupdatetime()
		{
			return this.dayupdatetimeSpecified;
		}

		private void Resetdayupdatetime()
		{
			this.dayupdatetimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "version", DataFormat = DataFormat.TwosComplement)]
		public uint version
		{
			get
			{
				return this._version ?? 0U;
			}
			set
			{
				this._version = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? new uint?(this.version) : null);
				}
			}
		}

		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _firstrankcount;

		private uint? _totalkillcount;

		private readonly List<BattleFieldPoint> _point = new List<BattleFieldPoint>();

		private uint? _lastupdatetime;

		private HellDropInfoAll _hell = null;

		private uint? _weekpoint;

		private uint? _dayupdatetime;

		private uint? _version;

		private IExtension extensionObject;
	}
}
