using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CliAntiCheatInfo")]
	[Serializable]
	public class CliAntiCheatInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "currentHp", DataFormat = DataFormat.TwosComplement)]
		public uint currentHp
		{
			get
			{
				return this._currentHp ?? 0U;
			}
			set
			{
				this._currentHp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool currentHpSpecified
		{
			get
			{
				return this._currentHp != null;
			}
			set
			{
				bool flag = value == (this._currentHp == null);
				if (flag)
				{
					this._currentHp = (value ? new uint?(this.currentHp) : null);
				}
			}
		}

		private bool ShouldSerializecurrentHp()
		{
			return this.currentHpSpecified;
		}

		private void ResetcurrentHp()
		{
			this.currentHpSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "totalDamage", DataFormat = DataFormat.TwosComplement)]
		public uint totalDamage
		{
			get
			{
				return this._totalDamage ?? 0U;
			}
			set
			{
				this._totalDamage = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalDamageSpecified
		{
			get
			{
				return this._totalDamage != null;
			}
			set
			{
				bool flag = value == (this._totalDamage == null);
				if (flag)
				{
					this._totalDamage = (value ? new uint?(this.totalDamage) : null);
				}
			}
		}

		private bool ShouldSerializetotalDamage()
		{
			return this.totalDamageSpecified;
		}

		private void ResettotalDamage()
		{
			this.totalDamageSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "totalHurt", DataFormat = DataFormat.TwosComplement)]
		public uint totalHurt
		{
			get
			{
				return this._totalHurt ?? 0U;
			}
			set
			{
				this._totalHurt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalHurtSpecified
		{
			get
			{
				return this._totalHurt != null;
			}
			set
			{
				bool flag = value == (this._totalHurt == null);
				if (flag)
				{
					this._totalHurt = (value ? new uint?(this.totalHurt) : null);
				}
			}
		}

		private bool ShouldSerializetotalHurt()
		{
			return this.totalHurtSpecified;
		}

		private void ResettotalHurt()
		{
			this.totalHurtSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "totalRecovery", DataFormat = DataFormat.TwosComplement)]
		public uint totalRecovery
		{
			get
			{
				return this._totalRecovery ?? 0U;
			}
			set
			{
				this._totalRecovery = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalRecoverySpecified
		{
			get
			{
				return this._totalRecovery != null;
			}
			set
			{
				bool flag = value == (this._totalRecovery == null);
				if (flag)
				{
					this._totalRecovery = (value ? new uint?(this.totalRecovery) : null);
				}
			}
		}

		private bool ShouldSerializetotalRecovery()
		{
			return this.totalRecoverySpecified;
		}

		private void ResettotalRecovery()
		{
			this.totalRecoverySpecified = false;
		}

		[ProtoMember(5, Name = "monsterRfsTimes", DataFormat = DataFormat.TwosComplement)]
		public List<uint> monsterRfsTimes
		{
			get
			{
				return this._monsterRfsTimes;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "battleStamp", DataFormat = DataFormat.Default)]
		public string battleStamp
		{
			get
			{
				return this._battleStamp ?? "";
			}
			set
			{
				this._battleStamp = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool battleStampSpecified
		{
			get
			{
				return this._battleStamp != null;
			}
			set
			{
				bool flag = value == (this._battleStamp == null);
				if (flag)
				{
					this._battleStamp = (value ? this.battleStamp : null);
				}
			}
		}

		private bool ShouldSerializebattleStamp()
		{
			return this.battleStampSpecified;
		}

		private void ResetbattleStamp()
		{
			this.battleStampSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _currentHp;

		private uint? _totalDamage;

		private uint? _totalHurt;

		private uint? _totalRecovery;

		private readonly List<uint> _monsterRfsTimes = new List<uint>();

		private string _battleStamp;

		private IExtension extensionObject;
	}
}
