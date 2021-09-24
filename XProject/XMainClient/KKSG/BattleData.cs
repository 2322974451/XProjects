using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleData")]
	[Serializable]
	public class BattleData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "timespan", DataFormat = DataFormat.TwosComplement)]
		public int timespan
		{
			get
			{
				return this._timespan ?? 0;
			}
			set
			{
				this._timespan = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timespanSpecified
		{
			get
			{
				return this._timespan != null;
			}
			set
			{
				bool flag = value == (this._timespan == null);
				if (flag)
				{
					this._timespan = (value ? new int?(this.timespan) : null);
				}
			}
		}

		private bool ShouldSerializetimespan()
		{
			return this.timespanSpecified;
		}

		private void Resettimespan()
		{
			this.timespanSpecified = false;
		}

		[ProtoMember(2, Name = "pickDoodadWaveID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> pickDoodadWaveID
		{
			get
			{
				return this._pickDoodadWaveID;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Combo", DataFormat = DataFormat.TwosComplement)]
		public int Combo
		{
			get
			{
				return this._Combo ?? 0;
			}
			set
			{
				this._Combo = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ComboSpecified
		{
			get
			{
				return this._Combo != null;
			}
			set
			{
				bool flag = value == (this._Combo == null);
				if (flag)
				{
					this._Combo = (value ? new int?(this.Combo) : null);
				}
			}
		}

		private bool ShouldSerializeCombo()
		{
			return this.ComboSpecified;
		}

		private void ResetCombo()
		{
			this.ComboSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "BeHit", DataFormat = DataFormat.TwosComplement)]
		public int BeHit
		{
			get
			{
				return this._BeHit ?? 0;
			}
			set
			{
				this._BeHit = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BeHitSpecified
		{
			get
			{
				return this._BeHit != null;
			}
			set
			{
				bool flag = value == (this._BeHit == null);
				if (flag)
				{
					this._BeHit = (value ? new int?(this.BeHit) : null);
				}
			}
		}

		private bool ShouldSerializeBeHit()
		{
			return this.BeHitSpecified;
		}

		private void ResetBeHit()
		{
			this.BeHitSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "hppercent", DataFormat = DataFormat.TwosComplement)]
		public uint hppercent
		{
			get
			{
				return this._hppercent ?? 0U;
			}
			set
			{
				this._hppercent = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hppercentSpecified
		{
			get
			{
				return this._hppercent != null;
			}
			set
			{
				bool flag = value == (this._hppercent == null);
				if (flag)
				{
					this._hppercent = (value ? new uint?(this.hppercent) : null);
				}
			}
		}

		private bool ShouldSerializehppercent()
		{
			return this.hppercentSpecified;
		}

		private void Resethppercent()
		{
			this.hppercentSpecified = false;
		}

		[ProtoMember(6, Name = "smallmonster", DataFormat = DataFormat.TwosComplement)]
		public List<uint> smallmonster
		{
			get
			{
				return this._smallmonster;
			}
		}

		[ProtoMember(7, Name = "bossrush", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bossrush
		{
			get
			{
				return this._bossrush;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "OpenChest", DataFormat = DataFormat.TwosComplement)]
		public int OpenChest
		{
			get
			{
				return this._OpenChest ?? 0;
			}
			set
			{
				this._OpenChest = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool OpenChestSpecified
		{
			get
			{
				return this._OpenChest != null;
			}
			set
			{
				bool flag = value == (this._OpenChest == null);
				if (flag)
				{
					this._OpenChest = (value ? new int?(this.OpenChest) : null);
				}
			}
		}

		private bool ShouldSerializeOpenChest()
		{
			return this.OpenChestSpecified;
		}

		private void ResetOpenChest()
		{
			this.OpenChestSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "anticheatInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CliAntiCheatInfo anticheatInfo
		{
			get
			{
				return this._anticheatInfo;
			}
			set
			{
				this._anticheatInfo = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "isfailed", DataFormat = DataFormat.Default)]
		public bool isfailed
		{
			get
			{
				return this._isfailed ?? false;
			}
			set
			{
				this._isfailed = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isfailedSpecified
		{
			get
			{
				return this._isfailed != null;
			}
			set
			{
				bool flag = value == (this._isfailed == null);
				if (flag)
				{
					this._isfailed = (value ? new bool?(this.isfailed) : null);
				}
			}
		}

		private bool ShouldSerializeisfailed()
		{
			return this.isfailedSpecified;
		}

		private void Resetisfailed()
		{
			this.isfailedSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "failedinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BattleFailedData failedinfo
		{
			get
			{
				return this._failedinfo;
			}
			set
			{
				this._failedinfo = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "found", DataFormat = DataFormat.TwosComplement)]
		public uint found
		{
			get
			{
				return this._found ?? 0U;
			}
			set
			{
				this._found = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool foundSpecified
		{
			get
			{
				return this._found != null;
			}
			set
			{
				bool flag = value == (this._found == null);
				if (flag)
				{
					this._found = (value ? new uint?(this.found) : null);
				}
			}
		}

		private bool ShouldSerializefound()
		{
			return this.foundSpecified;
		}

		private void Resetfound()
		{
			this.foundSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "npchp", DataFormat = DataFormat.TwosComplement)]
		public uint npchp
		{
			get
			{
				return this._npchp ?? 0U;
			}
			set
			{
				this._npchp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool npchpSpecified
		{
			get
			{
				return this._npchp != null;
			}
			set
			{
				bool flag = value == (this._npchp == null);
				if (flag)
				{
					this._npchp = (value ? new uint?(this.npchp) : null);
				}
			}
		}

		private bool ShouldSerializenpchp()
		{
			return this.npchpSpecified;
		}

		private void Resetnpchp()
		{
			this.npchpSpecified = false;
		}

		[ProtoMember(14, Name = "monster_id", DataFormat = DataFormat.TwosComplement)]
		public List<uint> monster_id
		{
			get
			{
				return this._monster_id;
			}
		}

		[ProtoMember(15, Name = "monster_num", DataFormat = DataFormat.TwosComplement)]
		public List<uint> monster_num
		{
			get
			{
				return this._monster_num;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _timespan;

		private readonly List<uint> _pickDoodadWaveID = new List<uint>();

		private int? _Combo;

		private int? _BeHit;

		private uint? _hppercent;

		private readonly List<uint> _smallmonster = new List<uint>();

		private readonly List<uint> _bossrush = new List<uint>();

		private int? _OpenChest;

		private CliAntiCheatInfo _anticheatInfo = null;

		private bool? _isfailed;

		private BattleFailedData _failedinfo = null;

		private uint? _found;

		private uint? _npchp;

		private readonly List<uint> _monster_id = new List<uint>();

		private readonly List<uint> _monster_num = new List<uint>();

		private IExtension extensionObject;
	}
}
