using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FlowerRecord")]
	[Serializable]
	public class FlowerRecord : IExtensible
	{

		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		[ProtoMember(2, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<uint> count
		{
			get
			{
				return this._count;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "updateday", DataFormat = DataFormat.TwosComplement)]
		public uint updateday
		{
			get
			{
				return this._updateday ?? 0U;
			}
			set
			{
				this._updateday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatedaySpecified
		{
			get
			{
				return this._updateday != null;
			}
			set
			{
				bool flag = value == (this._updateday == null);
				if (flag)
				{
					this._updateday = (value ? new uint?(this.updateday) : null);
				}
			}
		}

		private bool ShouldSerializeupdateday()
		{
			return this.updatedaySpecified;
		}

		private void Resetupdateday()
		{
			this.updatedaySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "getRankReward", DataFormat = DataFormat.Default)]
		public bool getRankReward
		{
			get
			{
				return this._getRankReward ?? false;
			}
			set
			{
				this._getRankReward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getRankRewardSpecified
		{
			get
			{
				return this._getRankReward != null;
			}
			set
			{
				bool flag = value == (this._getRankReward == null);
				if (flag)
				{
					this._getRankReward = (value ? new bool?(this.getRankReward) : null);
				}
			}
		}

		private bool ShouldSerializegetRankReward()
		{
			return this.getRankRewardSpecified;
		}

		private void ResetgetRankReward()
		{
			this.getRankRewardSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "getFlowerTime", DataFormat = DataFormat.TwosComplement)]
		public uint getFlowerTime
		{
			get
			{
				return this._getFlowerTime ?? 0U;
			}
			set
			{
				this._getFlowerTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getFlowerTimeSpecified
		{
			get
			{
				return this._getFlowerTime != null;
			}
			set
			{
				bool flag = value == (this._getFlowerTime == null);
				if (flag)
				{
					this._getFlowerTime = (value ? new uint?(this.getFlowerTime) : null);
				}
			}
		}

		private bool ShouldSerializegetFlowerTime()
		{
			return this.getFlowerTimeSpecified;
		}

		private void ResetgetFlowerTime()
		{
			this.getFlowerTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "getFlowerNum", DataFormat = DataFormat.TwosComplement)]
		public uint getFlowerNum
		{
			get
			{
				return this._getFlowerNum ?? 0U;
			}
			set
			{
				this._getFlowerNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getFlowerNumSpecified
		{
			get
			{
				return this._getFlowerNum != null;
			}
			set
			{
				bool flag = value == (this._getFlowerNum == null);
				if (flag)
				{
					this._getFlowerNum = (value ? new uint?(this.getFlowerNum) : null);
				}
			}
		}

		private bool ShouldSerializegetFlowerNum()
		{
			return this.getFlowerNumSpecified;
		}

		private void ResetgetFlowerNum()
		{
			this.getFlowerNumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _roleid = new List<ulong>();

		private readonly List<uint> _count = new List<uint>();

		private uint? _updateday;

		private bool? _getRankReward;

		private uint? _getFlowerTime;

		private uint? _getFlowerNum;

		private IExtension extensionObject;
	}
}
