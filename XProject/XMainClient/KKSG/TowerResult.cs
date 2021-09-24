using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TowerResult")]
	[Serializable]
	public class TowerResult : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "towerFloor", DataFormat = DataFormat.TwosComplement)]
		public int towerFloor
		{
			get
			{
				return this._towerFloor ?? 0;
			}
			set
			{
				this._towerFloor = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool towerFloorSpecified
		{
			get
			{
				return this._towerFloor != null;
			}
			set
			{
				bool flag = value == (this._towerFloor == null);
				if (flag)
				{
					this._towerFloor = (value ? new int?(this.towerFloor) : null);
				}
			}
		}

		private bool ShouldSerializetowerFloor()
		{
			return this.towerFloorSpecified;
		}

		private void ResettowerFloor()
		{
			this.towerFloorSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isNewRecord;

		private int? _towerFloor;

		private IExtension extensionObject;
	}
}
