using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TowerSceneInfoData")]
	[Serializable]
	public class TowerSceneInfoData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "curTowerFloor", DataFormat = DataFormat.TwosComplement)]
		public int curTowerFloor
		{
			get
			{
				return this._curTowerFloor ?? 0;
			}
			set
			{
				this._curTowerFloor = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curTowerFloorSpecified
		{
			get
			{
				return this._curTowerFloor != null;
			}
			set
			{
				bool flag = value == (this._curTowerFloor == null);
				if (flag)
				{
					this._curTowerFloor = (value ? new int?(this.curTowerFloor) : null);
				}
			}
		}

		private bool ShouldSerializecurTowerFloor()
		{
			return this.curTowerFloorSpecified;
		}

		private void ResetcurTowerFloor()
		{
			this.curTowerFloorSpecified = false;
		}

		[ProtoMember(3, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _leftTime;

		private int? _curTowerFloor;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
