using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpBattleBeginData")]
	[Serializable]
	public class PvpBattleBeginData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "thisGameCount", DataFormat = DataFormat.TwosComplement)]
		public int thisGameCount
		{
			get
			{
				return this._thisGameCount ?? 0;
			}
			set
			{
				this._thisGameCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool thisGameCountSpecified
		{
			get
			{
				return this._thisGameCount != null;
			}
			set
			{
				bool flag = value == (this._thisGameCount == null);
				if (flag)
				{
					this._thisGameCount = (value ? new int?(this.thisGameCount) : null);
				}
			}
		}

		private bool ShouldSerializethisGameCount()
		{
			return this.thisGameCountSpecified;
		}

		private void ResetthisGameCount()
		{
			this.thisGameCountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "allGameCount", DataFormat = DataFormat.TwosComplement)]
		public int allGameCount
		{
			get
			{
				return this._allGameCount ?? 0;
			}
			set
			{
				this._allGameCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allGameCountSpecified
		{
			get
			{
				return this._allGameCount != null;
			}
			set
			{
				bool flag = value == (this._allGameCount == null);
				if (flag)
				{
					this._allGameCount = (value ? new int?(this.allGameCount) : null);
				}
			}
		}

		private bool ShouldSerializeallGameCount()
		{
			return this.allGameCountSpecified;
		}

		private void ResetallGameCount()
		{
			this.allGameCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "group1Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group1Leader
		{
			get
			{
				return this._group1Leader ?? 0UL;
			}
			set
			{
				this._group1Leader = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool group1LeaderSpecified
		{
			get
			{
				return this._group1Leader != null;
			}
			set
			{
				bool flag = value == (this._group1Leader == null);
				if (flag)
				{
					this._group1Leader = (value ? new ulong?(this.group1Leader) : null);
				}
			}
		}

		private bool ShouldSerializegroup1Leader()
		{
			return this.group1LeaderSpecified;
		}

		private void Resetgroup1Leader()
		{
			this.group1LeaderSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "group2Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group2Leader
		{
			get
			{
				return this._group2Leader ?? 0UL;
			}
			set
			{
				this._group2Leader = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool group2LeaderSpecified
		{
			get
			{
				return this._group2Leader != null;
			}
			set
			{
				bool flag = value == (this._group2Leader == null);
				if (flag)
				{
					this._group2Leader = (value ? new ulong?(this.group2Leader) : null);
				}
			}
		}

		private bool ShouldSerializegroup2Leader()
		{
			return this.group2LeaderSpecified;
		}

		private void Resetgroup2Leader()
		{
			this.group2LeaderSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "contiTime", DataFormat = DataFormat.TwosComplement)]
		public uint contiTime
		{
			get
			{
				return this._contiTime ?? 0U;
			}
			set
			{
				this._contiTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool contiTimeSpecified
		{
			get
			{
				return this._contiTime != null;
			}
			set
			{
				bool flag = value == (this._contiTime == null);
				if (flag)
				{
					this._contiTime = (value ? new uint?(this.contiTime) : null);
				}
			}
		}

		private bool ShouldSerializecontiTime()
		{
			return this.contiTimeSpecified;
		}

		private void ResetcontiTime()
		{
			this.contiTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _thisGameCount;

		private int? _allGameCount;

		private ulong? _group1Leader;

		private ulong? _group2Leader;

		private uint? _contiTime;

		private IExtension extensionObject;
	}
}
