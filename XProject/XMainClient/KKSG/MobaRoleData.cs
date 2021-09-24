using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaRoleData")]
	[Serializable]
	public class MobaRoleData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public double exp
		{
			get
			{
				return this._exp ?? 0.0;
			}
			set
			{
				this._exp = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new double?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "upgradeNum", DataFormat = DataFormat.TwosComplement)]
		public uint upgradeNum
		{
			get
			{
				return this._upgradeNum ?? 0U;
			}
			set
			{
				this._upgradeNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool upgradeNumSpecified
		{
			get
			{
				return this._upgradeNum != null;
			}
			set
			{
				bool flag = value == (this._upgradeNum == null);
				if (flag)
				{
					this._upgradeNum = (value ? new uint?(this.upgradeNum) : null);
				}
			}
		}

		private bool ShouldSerializeupgradeNum()
		{
			return this.upgradeNumSpecified;
		}

		private void ResetupgradeNum()
		{
			this.upgradeNumSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "killNum", DataFormat = DataFormat.TwosComplement)]
		public uint killNum
		{
			get
			{
				return this._killNum ?? 0U;
			}
			set
			{
				this._killNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killNumSpecified
		{
			get
			{
				return this._killNum != null;
			}
			set
			{
				bool flag = value == (this._killNum == null);
				if (flag)
				{
					this._killNum = (value ? new uint?(this.killNum) : null);
				}
			}
		}

		private bool ShouldSerializekillNum()
		{
			return this.killNumSpecified;
		}

		private void ResetkillNum()
		{
			this.killNumSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "deathNum", DataFormat = DataFormat.TwosComplement)]
		public uint deathNum
		{
			get
			{
				return this._deathNum ?? 0U;
			}
			set
			{
				this._deathNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deathNumSpecified
		{
			get
			{
				return this._deathNum != null;
			}
			set
			{
				bool flag = value == (this._deathNum == null);
				if (flag)
				{
					this._deathNum = (value ? new uint?(this.deathNum) : null);
				}
			}
		}

		private bool ShouldSerializedeathNum()
		{
			return this.deathNumSpecified;
		}

		private void ResetdeathNum()
		{
			this.deathNumSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "assistNum", DataFormat = DataFormat.TwosComplement)]
		public uint assistNum
		{
			get
			{
				return this._assistNum ?? 0U;
			}
			set
			{
				this._assistNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool assistNumSpecified
		{
			get
			{
				return this._assistNum != null;
			}
			set
			{
				bool flag = value == (this._assistNum == null);
				if (flag)
				{
					this._assistNum = (value ? new uint?(this.assistNum) : null);
				}
			}
		}

		private bool ShouldSerializeassistNum()
		{
			return this.assistNumSpecified;
		}

		private void ResetassistNum()
		{
			this.assistNumSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "attackLevel", DataFormat = DataFormat.TwosComplement)]
		public uint attackLevel
		{
			get
			{
				return this._attackLevel ?? 0U;
			}
			set
			{
				this._attackLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool attackLevelSpecified
		{
			get
			{
				return this._attackLevel != null;
			}
			set
			{
				bool flag = value == (this._attackLevel == null);
				if (flag)
				{
					this._attackLevel = (value ? new uint?(this.attackLevel) : null);
				}
			}
		}

		private bool ShouldSerializeattackLevel()
		{
			return this.attackLevelSpecified;
		}

		private void ResetattackLevel()
		{
			this.attackLevelSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "defenseLevel", DataFormat = DataFormat.TwosComplement)]
		public uint defenseLevel
		{
			get
			{
				return this._defenseLevel ?? 0U;
			}
			set
			{
				this._defenseLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool defenseLevelSpecified
		{
			get
			{
				return this._defenseLevel != null;
			}
			set
			{
				bool flag = value == (this._defenseLevel == null);
				if (flag)
				{
					this._defenseLevel = (value ? new uint?(this.defenseLevel) : null);
				}
			}
		}

		private bool ShouldSerializedefenseLevel()
		{
			return this.defenseLevelSpecified;
		}

		private void ResetdefenseLevel()
		{
			this.defenseLevelSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "reviveTime", DataFormat = DataFormat.TwosComplement)]
		public uint reviveTime
		{
			get
			{
				return this._reviveTime ?? 0U;
			}
			set
			{
				this._reviveTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reviveTimeSpecified
		{
			get
			{
				return this._reviveTime != null;
			}
			set
			{
				bool flag = value == (this._reviveTime == null);
				if (flag)
				{
					this._reviveTime = (value ? new uint?(this.reviveTime) : null);
				}
			}
		}

		private bool ShouldSerializereviveTime()
		{
			return this.reviveTimeSpecified;
		}

		private void ResetreviveTime()
		{
			this.reviveTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private string _name;

		private double? _exp;

		private uint? _level;

		private uint? _upgradeNum;

		private uint? _heroid;

		private uint? _killNum;

		private uint? _deathNum;

		private uint? _assistNum;

		private uint? _attackLevel;

		private uint? _defenseLevel;

		private uint? _reviveTime;

		private IExtension extensionObject;
	}
}
