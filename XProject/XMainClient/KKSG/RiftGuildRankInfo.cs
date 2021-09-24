using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftGuildRankInfo")]
	[Serializable]
	public class RiftGuildRankInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleInfo
		{
			get
			{
				return this._roleInfo;
			}
			set
			{
				this._roleInfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "riftFloor", DataFormat = DataFormat.TwosComplement)]
		public int riftFloor
		{
			get
			{
				return this._riftFloor ?? 0;
			}
			set
			{
				this._riftFloor = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool riftFloorSpecified
		{
			get
			{
				return this._riftFloor != null;
			}
			set
			{
				bool flag = value == (this._riftFloor == null);
				if (flag)
				{
					this._riftFloor = (value ? new int?(this.riftFloor) : null);
				}
			}
		}

		private bool ShouldSerializeriftFloor()
		{
			return this.riftFloorSpecified;
		}

		private void ResetriftFloor()
		{
			this.riftFloorSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "riftStar", DataFormat = DataFormat.TwosComplement)]
		public int riftStar
		{
			get
			{
				return this._riftStar ?? 0;
			}
			set
			{
				this._riftStar = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool riftStarSpecified
		{
			get
			{
				return this._riftStar != null;
			}
			set
			{
				bool flag = value == (this._riftStar == null);
				if (flag)
				{
					this._riftStar = (value ? new int?(this.riftStar) : null);
				}
			}
		}

		private bool ShouldSerializeriftStar()
		{
			return this.riftStarSpecified;
		}

		private void ResetriftStar()
		{
			this.riftStarSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "costTime", DataFormat = DataFormat.TwosComplement)]
		public int costTime
		{
			get
			{
				return this._costTime ?? 0;
			}
			set
			{
				this._costTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costTimeSpecified
		{
			get
			{
				return this._costTime != null;
			}
			set
			{
				bool flag = value == (this._costTime == null);
				if (flag)
				{
					this._costTime = (value ? new int?(this.costTime) : null);
				}
			}
		}

		private bool ShouldSerializecostTime()
		{
			return this.costTimeSpecified;
		}

		private void ResetcostTime()
		{
			this.costTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleBriefInfo _roleInfo = null;

		private int? _riftFloor;

		private int? _riftStar;

		private int? _costTime;

		private int? _sceneID;

		private IExtension extensionObject;
	}
}
