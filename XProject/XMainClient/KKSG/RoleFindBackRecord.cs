using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleFindBackRecord")]
	[Serializable]
	public class RoleFindBackRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "openTime", DataFormat = DataFormat.TwosComplement)]
		public int openTime
		{
			get
			{
				return this._openTime ?? 0;
			}
			set
			{
				this._openTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openTimeSpecified
		{
			get
			{
				return this._openTime != null;
			}
			set
			{
				bool flag = value == (this._openTime == null);
				if (flag)
				{
					this._openTime = (value ? new int?(this.openTime) : null);
				}
			}
		}

		private bool ShouldSerializeopenTime()
		{
			return this.openTimeSpecified;
		}

		private void ResetopenTime()
		{
			this.openTimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public int updateTime
		{
			get
			{
				return this._updateTime ?? 0;
			}
			set
			{
				this._updateTime = new int?(value);
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
					this._updateTime = (value ? new int?(this.updateTime) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "isFoundBack", DataFormat = DataFormat.Default)]
		public bool isFoundBack
		{
			get
			{
				return this._isFoundBack ?? false;
			}
			set
			{
				this._isFoundBack = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isFoundBackSpecified
		{
			get
			{
				return this._isFoundBack != null;
			}
			set
			{
				bool flag = value == (this._isFoundBack == null);
				if (flag)
				{
					this._isFoundBack = (value ? new bool?(this.isFoundBack) : null);
				}
			}
		}

		private bool ShouldSerializeisFoundBack()
		{
			return this.isFoundBackSpecified;
		}

		private void ResetisFoundBack()
		{
			this.isFoundBackSpecified = false;
		}

		[ProtoMember(4, Name = "usedInfos", DataFormat = DataFormat.Default)]
		public List<ExpFindBackInfo> usedInfos
		{
			get
			{
				return this._usedInfos;
			}
		}

		[ProtoMember(5, Name = "curUsedInfos", DataFormat = DataFormat.Default)]
		public List<ExpFindBackInfo> curUsedInfos
		{
			get
			{
				return this._curUsedInfos;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "findBackOpenTime", DataFormat = DataFormat.TwosComplement)]
		public int findBackOpenTime
		{
			get
			{
				return this._findBackOpenTime ?? 0;
			}
			set
			{
				this._findBackOpenTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool findBackOpenTimeSpecified
		{
			get
			{
				return this._findBackOpenTime != null;
			}
			set
			{
				bool flag = value == (this._findBackOpenTime == null);
				if (flag)
				{
					this._findBackOpenTime = (value ? new int?(this.findBackOpenTime) : null);
				}
			}
		}

		private bool ShouldSerializefindBackOpenTime()
		{
			return this.findBackOpenTimeSpecified;
		}

		private void ResetfindBackOpenTime()
		{
			this.findBackOpenTimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "itemBackUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public int itemBackUpdateTime
		{
			get
			{
				return this._itemBackUpdateTime ?? 0;
			}
			set
			{
				this._itemBackUpdateTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemBackUpdateTimeSpecified
		{
			get
			{
				return this._itemBackUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._itemBackUpdateTime == null);
				if (flag)
				{
					this._itemBackUpdateTime = (value ? new int?(this.itemBackUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializeitemBackUpdateTime()
		{
			return this.itemBackUpdateTimeSpecified;
		}

		private void ResetitemBackUpdateTime()
		{
			this.itemBackUpdateTimeSpecified = false;
		}

		[ProtoMember(8, Name = "itemFindBackInfosHis", DataFormat = DataFormat.Default)]
		public List<ItemFindBackInfo> itemFindBackInfosHis
		{
			get
			{
				return this._itemFindBackInfosHis;
			}
		}

		[ProtoMember(9, Name = "itemFindBackInfoCur", DataFormat = DataFormat.Default)]
		public List<ItemFindBackInfo> itemFindBackInfoCur
		{
			get
			{
				return this._itemFindBackInfoCur;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "unlockSealTime", DataFormat = DataFormat.TwosComplement)]
		public uint unlockSealTime
		{
			get
			{
				return this._unlockSealTime ?? 0U;
			}
			set
			{
				this._unlockSealTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool unlockSealTimeSpecified
		{
			get
			{
				return this._unlockSealTime != null;
			}
			set
			{
				bool flag = value == (this._unlockSealTime == null);
				if (flag)
				{
					this._unlockSealTime = (value ? new uint?(this.unlockSealTime) : null);
				}
			}
		}

		private bool ShouldSerializeunlockSealTime()
		{
			return this.unlockSealTimeSpecified;
		}

		private void ResetunlockSealTime()
		{
			this.unlockSealTimeSpecified = false;
		}

		[ProtoMember(11, Name = "unlockSealData", DataFormat = DataFormat.Default)]
		public List<UnlockSealFindBackData> unlockSealData
		{
			get
			{
				return this._unlockSealData;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "notifyBackTime", DataFormat = DataFormat.TwosComplement)]
		public int notifyBackTime
		{
			get
			{
				return this._notifyBackTime ?? 0;
			}
			set
			{
				this._notifyBackTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool notifyBackTimeSpecified
		{
			get
			{
				return this._notifyBackTime != null;
			}
			set
			{
				bool flag = value == (this._notifyBackTime == null);
				if (flag)
				{
					this._notifyBackTime = (value ? new int?(this.notifyBackTime) : null);
				}
			}
		}

		private bool ShouldSerializenotifyBackTime()
		{
			return this.notifyBackTimeSpecified;
		}

		private void ResetnotifyBackTime()
		{
			this.notifyBackTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _openTime;

		private int? _updateTime;

		private bool? _isFoundBack;

		private readonly List<ExpFindBackInfo> _usedInfos = new List<ExpFindBackInfo>();

		private readonly List<ExpFindBackInfo> _curUsedInfos = new List<ExpFindBackInfo>();

		private int? _findBackOpenTime;

		private int? _itemBackUpdateTime;

		private readonly List<ItemFindBackInfo> _itemFindBackInfosHis = new List<ItemFindBackInfo>();

		private readonly List<ItemFindBackInfo> _itemFindBackInfoCur = new List<ItemFindBackInfo>();

		private uint? _unlockSealTime;

		private readonly List<UnlockSealFindBackData> _unlockSealData = new List<UnlockSealFindBackData>();

		private int? _notifyBackTime;

		private IExtension extensionObject;
	}
}
