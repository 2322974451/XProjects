using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftRankData")]
	[Serializable]
	public class RiftRankData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "riftFloor", DataFormat = DataFormat.TwosComplement)]
		public uint riftFloor
		{
			get
			{
				return this._riftFloor ?? 0U;
			}
			set
			{
				this._riftFloor = new uint?(value);
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
					this._riftFloor = (value ? new uint?(this.riftFloor) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "passTime", DataFormat = DataFormat.TwosComplement)]
		public uint passTime
		{
			get
			{
				return this._passTime ?? 0U;
			}
			set
			{
				this._passTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool passTimeSpecified
		{
			get
			{
				return this._passTime != null;
			}
			set
			{
				bool flag = value == (this._passTime == null);
				if (flag)
				{
					this._passTime = (value ? new uint?(this.passTime) : null);
				}
			}
		}

		private bool ShouldSerializepassTime()
		{
			return this.passTimeSpecified;
		}

		private void ResetpassTime()
		{
			this.passTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new uint?(this.ppt) : null);
				}
			}
		}

		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public uint updateTime
		{
			get
			{
				return this._updateTime ?? 0U;
			}
			set
			{
				this._updateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new uint?(this.updateTime) : null);
				}
			}
		}

		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _riftFloor;

		private uint? _passTime;

		private uint? _ppt;

		private uint? _updateTime;

		private IExtension extensionObject;
	}
}
