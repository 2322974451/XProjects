using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowData")]
	[Serializable]
	public class BackFlowData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "worldlevel", DataFormat = DataFormat.TwosComplement)]
		public uint worldlevel
		{
			get
			{
				return this._worldlevel ?? 0U;
			}
			set
			{
				this._worldlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool worldlevelSpecified
		{
			get
			{
				return this._worldlevel != null;
			}
			set
			{
				bool flag = value == (this._worldlevel == null);
				if (flag)
				{
					this._worldlevel = (value ? new uint?(this.worldlevel) : null);
				}
			}
		}

		private bool ShouldSerializeworldlevel()
		{
			return this.worldlevelSpecified;
		}

		private void Resetworldlevel()
		{
			this.worldlevelSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(3, Name = "alreadyGet", DataFormat = DataFormat.TwosComplement)]
		public List<uint> alreadyGet
		{
			get
			{
				return this._alreadyGet;
			}
		}

		[ProtoMember(4, Name = "payGiftType", DataFormat = DataFormat.Default)]
		public List<string> payGiftType
		{
			get
			{
				return this._payGiftType;
			}
		}

		[ProtoMember(5, Name = "payGiftCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> payGiftCount
		{
			get
			{
				return this._payGiftCount;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "lostDay", DataFormat = DataFormat.TwosComplement)]
		public uint lostDay
		{
			get
			{
				return this._lostDay ?? 0U;
			}
			set
			{
				this._lostDay = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lostDaySpecified
		{
			get
			{
				return this._lostDay != null;
			}
			set
			{
				bool flag = value == (this._lostDay == null);
				if (flag)
				{
					this._lostDay = (value ? new uint?(this.lostDay) : null);
				}
			}
		}

		private bool ShouldSerializelostDay()
		{
			return this.lostDaySpecified;
		}

		private void ResetlostDay()
		{
			this.lostDaySpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "shop", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowShopData shop
		{
			get
			{
				return this._shop;
			}
			set
			{
				this._shop = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "lastSmallDragonFinishTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastSmallDragonFinishTime
		{
			get
			{
				return this._lastSmallDragonFinishTime ?? 0U;
			}
			set
			{
				this._lastSmallDragonFinishTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastSmallDragonFinishTimeSpecified
		{
			get
			{
				return this._lastSmallDragonFinishTime != null;
			}
			set
			{
				bool flag = value == (this._lastSmallDragonFinishTime == null);
				if (flag)
				{
					this._lastSmallDragonFinishTime = (value ? new uint?(this.lastSmallDragonFinishTime) : null);
				}
			}
		}

		private bool ShouldSerializelastSmallDragonFinishTime()
		{
			return this.lastSmallDragonFinishTimeSpecified;
		}

		private void ResetlastSmallDragonFinishTime()
		{
			this.lastSmallDragonFinishTimeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "isFinishBackFlowScene", DataFormat = DataFormat.Default)]
		public bool isFinishBackFlowScene
		{
			get
			{
				return this._isFinishBackFlowScene ?? false;
			}
			set
			{
				this._isFinishBackFlowScene = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isFinishBackFlowSceneSpecified
		{
			get
			{
				return this._isFinishBackFlowScene != null;
			}
			set
			{
				bool flag = value == (this._isFinishBackFlowScene == null);
				if (flag)
				{
					this._isFinishBackFlowScene = (value ? new bool?(this.isFinishBackFlowScene) : null);
				}
			}
		}

		private bool ShouldSerializeisFinishBackFlowScene()
		{
			return this.isFinishBackFlowSceneSpecified;
		}

		private void ResetisFinishBackFlowScene()
		{
			this.isFinishBackFlowSceneSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "lastNestFinishTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastNestFinishTime
		{
			get
			{
				return this._lastNestFinishTime ?? 0U;
			}
			set
			{
				this._lastNestFinishTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastNestFinishTimeSpecified
		{
			get
			{
				return this._lastNestFinishTime != null;
			}
			set
			{
				bool flag = value == (this._lastNestFinishTime == null);
				if (flag)
				{
					this._lastNestFinishTime = (value ? new uint?(this.lastNestFinishTime) : null);
				}
			}
		}

		private bool ShouldSerializelastNestFinishTime()
		{
			return this.lastNestFinishTimeSpecified;
		}

		private void ResetlastNestFinishTime()
		{
			this.lastNestFinishTimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "nestFinishCount", DataFormat = DataFormat.TwosComplement)]
		public uint nestFinishCount
		{
			get
			{
				return this._nestFinishCount ?? 0U;
			}
			set
			{
				this._nestFinishCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nestFinishCountSpecified
		{
			get
			{
				return this._nestFinishCount != null;
			}
			set
			{
				bool flag = value == (this._nestFinishCount == null);
				if (flag)
				{
					this._nestFinishCount = (value ? new uint?(this.nestFinishCount) : null);
				}
			}
		}

		private bool ShouldSerializenestFinishCount()
		{
			return this.nestFinishCountSpecified;
		}

		private void ResetnestFinishCount()
		{
			this.nestFinishCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _worldlevel;

		private uint? _point;

		private readonly List<uint> _alreadyGet = new List<uint>();

		private readonly List<string> _payGiftType = new List<string>();

		private readonly List<uint> _payGiftCount = new List<uint>();

		private uint? _lostDay;

		private BackFlowShopData _shop = null;

		private uint? _lastSmallDragonFinishTime;

		private bool? _isFinishBackFlowScene;

		private uint? _lastNestFinishTime;

		private uint? _nestFinishCount;

		private IExtension extensionObject;
	}
}
