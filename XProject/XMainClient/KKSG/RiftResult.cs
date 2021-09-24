using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftResult")]
	[Serializable]
	public class RiftResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isNewRecord", DataFormat = DataFormat.Default)]
		public bool isNewRecord
		{
			get
			{
				return this._isNewRecord ?? false;
			}
			set
			{
				this._isNewRecord = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isNewRecordSpecified
		{
			get
			{
				return this._isNewRecord != null;
			}
			set
			{
				bool flag = value == (this._isNewRecord == null);
				if (flag)
				{
					this._isNewRecord = (value ? new bool?(this.isNewRecord) : null);
				}
			}
		}

		private bool ShouldSerializeisNewRecord()
		{
			return this.isNewRecordSpecified;
		}

		private void ResetisNewRecord()
		{
			this.isNewRecordSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "riftFloor", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "riftItemFlag", DataFormat = DataFormat.TwosComplement)]
		public uint riftItemFlag
		{
			get
			{
				return this._riftItemFlag ?? 0U;
			}
			set
			{
				this._riftItemFlag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool riftItemFlagSpecified
		{
			get
			{
				return this._riftItemFlag != null;
			}
			set
			{
				bool flag = value == (this._riftItemFlag == null);
				if (flag)
				{
					this._riftItemFlag = (value ? new uint?(this.riftItemFlag) : null);
				}
			}
		}

		private bool ShouldSerializeriftItemFlag()
		{
			return this.riftItemFlagSpecified;
		}

		private void ResetriftItemFlag()
		{
			this.riftItemFlagSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isNewRecord;

		private uint? _riftFloor;

		private uint? _riftItemFlag;

		private IExtension extensionObject;
	}
}
