using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A2 RID: 1698
	[ProtoContract(Name = "ItemFindBackInfo2Client")]
	[Serializable]
	public class ItemFindBackInfo2Client : IExtensible
	{
		// Token: 0x170022FE RID: 8958
		// (get) Token: 0x06006E92 RID: 28306 RVA: 0x000D3920 File Offset: 0x000D1B20
		// (set) Token: 0x06006E93 RID: 28307 RVA: 0x000D394C File Offset: 0x000D1B4C
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ItemFindBackType id
		{
			get
			{
				return this._id ?? ItemFindBackType.TOWER;
			}
			set
			{
				this._id = new ItemFindBackType?(value);
			}
		}

		// Token: 0x170022FF RID: 8959
		// (get) Token: 0x06006E94 RID: 28308 RVA: 0x000D395C File Offset: 0x000D1B5C
		// (set) Token: 0x06006E95 RID: 28309 RVA: 0x000D397C File Offset: 0x000D1B7C
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ItemFindBackType?(this.id) : null);
				}
			}
		}

		// Token: 0x06006E96 RID: 28310 RVA: 0x000D39C0 File Offset: 0x000D1BC0
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06006E97 RID: 28311 RVA: 0x000D39D8 File Offset: 0x000D1BD8
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002300 RID: 8960
		// (get) Token: 0x06006E98 RID: 28312 RVA: 0x000D39E4 File Offset: 0x000D1BE4
		// (set) Token: 0x06006E99 RID: 28313 RVA: 0x000D3A10 File Offset: 0x000D1C10
		[ProtoMember(2, IsRequired = false, Name = "findBackCount", DataFormat = DataFormat.TwosComplement)]
		public int findBackCount
		{
			get
			{
				return this._findBackCount ?? 0;
			}
			set
			{
				this._findBackCount = new int?(value);
			}
		}

		// Token: 0x17002301 RID: 8961
		// (get) Token: 0x06006E9A RID: 28314 RVA: 0x000D3A20 File Offset: 0x000D1C20
		// (set) Token: 0x06006E9B RID: 28315 RVA: 0x000D3A40 File Offset: 0x000D1C40
		[XmlIgnore]
		[Browsable(false)]
		public bool findBackCountSpecified
		{
			get
			{
				return this._findBackCount != null;
			}
			set
			{
				bool flag = value == (this._findBackCount == null);
				if (flag)
				{
					this._findBackCount = (value ? new int?(this.findBackCount) : null);
				}
			}
		}

		// Token: 0x06006E9C RID: 28316 RVA: 0x000D3A84 File Offset: 0x000D1C84
		private bool ShouldSerializefindBackCount()
		{
			return this.findBackCountSpecified;
		}

		// Token: 0x06006E9D RID: 28317 RVA: 0x000D3A9C File Offset: 0x000D1C9C
		private void ResetfindBackCount()
		{
			this.findBackCountSpecified = false;
		}

		// Token: 0x17002302 RID: 8962
		// (get) Token: 0x06006E9E RID: 28318 RVA: 0x000D3AA8 File Offset: 0x000D1CA8
		// (set) Token: 0x06006E9F RID: 28319 RVA: 0x000D3AD4 File Offset: 0x000D1CD4
		[ProtoMember(3, IsRequired = false, Name = "dragonCoinCost", DataFormat = DataFormat.TwosComplement)]
		public int dragonCoinCost
		{
			get
			{
				return this._dragonCoinCost ?? 0;
			}
			set
			{
				this._dragonCoinCost = new int?(value);
			}
		}

		// Token: 0x17002303 RID: 8963
		// (get) Token: 0x06006EA0 RID: 28320 RVA: 0x000D3AE4 File Offset: 0x000D1CE4
		// (set) Token: 0x06006EA1 RID: 28321 RVA: 0x000D3B04 File Offset: 0x000D1D04
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonCoinCostSpecified
		{
			get
			{
				return this._dragonCoinCost != null;
			}
			set
			{
				bool flag = value == (this._dragonCoinCost == null);
				if (flag)
				{
					this._dragonCoinCost = (value ? new int?(this.dragonCoinCost) : null);
				}
			}
		}

		// Token: 0x06006EA2 RID: 28322 RVA: 0x000D3B48 File Offset: 0x000D1D48
		private bool ShouldSerializedragonCoinCost()
		{
			return this.dragonCoinCostSpecified;
		}

		// Token: 0x06006EA3 RID: 28323 RVA: 0x000D3B60 File Offset: 0x000D1D60
		private void ResetdragonCoinCost()
		{
			this.dragonCoinCostSpecified = false;
		}

		// Token: 0x17002304 RID: 8964
		// (get) Token: 0x06006EA4 RID: 28324 RVA: 0x000D3B6C File Offset: 0x000D1D6C
		[ProtoMember(4, Name = "dragonCoinFindBackItems", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dragonCoinFindBackItems
		{
			get
			{
				return this._dragonCoinFindBackItems;
			}
		}

		// Token: 0x17002305 RID: 8965
		// (get) Token: 0x06006EA5 RID: 28325 RVA: 0x000D3B84 File Offset: 0x000D1D84
		// (set) Token: 0x06006EA6 RID: 28326 RVA: 0x000D3BB0 File Offset: 0x000D1DB0
		[ProtoMember(5, IsRequired = false, Name = "goldCoinCost", DataFormat = DataFormat.TwosComplement)]
		public int goldCoinCost
		{
			get
			{
				return this._goldCoinCost ?? 0;
			}
			set
			{
				this._goldCoinCost = new int?(value);
			}
		}

		// Token: 0x17002306 RID: 8966
		// (get) Token: 0x06006EA7 RID: 28327 RVA: 0x000D3BC0 File Offset: 0x000D1DC0
		// (set) Token: 0x06006EA8 RID: 28328 RVA: 0x000D3BE0 File Offset: 0x000D1DE0
		[XmlIgnore]
		[Browsable(false)]
		public bool goldCoinCostSpecified
		{
			get
			{
				return this._goldCoinCost != null;
			}
			set
			{
				bool flag = value == (this._goldCoinCost == null);
				if (flag)
				{
					this._goldCoinCost = (value ? new int?(this.goldCoinCost) : null);
				}
			}
		}

		// Token: 0x06006EA9 RID: 28329 RVA: 0x000D3C24 File Offset: 0x000D1E24
		private bool ShouldSerializegoldCoinCost()
		{
			return this.goldCoinCostSpecified;
		}

		// Token: 0x06006EAA RID: 28330 RVA: 0x000D3C3C File Offset: 0x000D1E3C
		private void ResetgoldCoinCost()
		{
			this.goldCoinCostSpecified = false;
		}

		// Token: 0x17002307 RID: 8967
		// (get) Token: 0x06006EAB RID: 28331 RVA: 0x000D3C48 File Offset: 0x000D1E48
		[ProtoMember(6, Name = "goldCoinFindBackItems", DataFormat = DataFormat.Default)]
		public List<ItemBrief> goldCoinFindBackItems
		{
			get
			{
				return this._goldCoinFindBackItems;
			}
		}

		// Token: 0x17002308 RID: 8968
		// (get) Token: 0x06006EAC RID: 28332 RVA: 0x000D3C60 File Offset: 0x000D1E60
		// (set) Token: 0x06006EAD RID: 28333 RVA: 0x000D3C8C File Offset: 0x000D1E8C
		[ProtoMember(7, IsRequired = false, Name = "dayTime", DataFormat = DataFormat.TwosComplement)]
		public int dayTime
		{
			get
			{
				return this._dayTime ?? 0;
			}
			set
			{
				this._dayTime = new int?(value);
			}
		}

		// Token: 0x17002309 RID: 8969
		// (get) Token: 0x06006EAE RID: 28334 RVA: 0x000D3C9C File Offset: 0x000D1E9C
		// (set) Token: 0x06006EAF RID: 28335 RVA: 0x000D3CBC File Offset: 0x000D1EBC
		[XmlIgnore]
		[Browsable(false)]
		public bool dayTimeSpecified
		{
			get
			{
				return this._dayTime != null;
			}
			set
			{
				bool flag = value == (this._dayTime == null);
				if (flag)
				{
					this._dayTime = (value ? new int?(this.dayTime) : null);
				}
			}
		}

		// Token: 0x06006EB0 RID: 28336 RVA: 0x000D3D00 File Offset: 0x000D1F00
		private bool ShouldSerializedayTime()
		{
			return this.dayTimeSpecified;
		}

		// Token: 0x06006EB1 RID: 28337 RVA: 0x000D3D18 File Offset: 0x000D1F18
		private void ResetdayTime()
		{
			this.dayTimeSpecified = false;
		}

		// Token: 0x1700230A RID: 8970
		// (get) Token: 0x06006EB2 RID: 28338 RVA: 0x000D3D24 File Offset: 0x000D1F24
		// (set) Token: 0x06006EB3 RID: 28339 RVA: 0x000D3D50 File Offset: 0x000D1F50
		[ProtoMember(8, IsRequired = false, Name = "roleLevel", DataFormat = DataFormat.TwosComplement)]
		public int roleLevel
		{
			get
			{
				return this._roleLevel ?? 0;
			}
			set
			{
				this._roleLevel = new int?(value);
			}
		}

		// Token: 0x1700230B RID: 8971
		// (get) Token: 0x06006EB4 RID: 28340 RVA: 0x000D3D60 File Offset: 0x000D1F60
		// (set) Token: 0x06006EB5 RID: 28341 RVA: 0x000D3D80 File Offset: 0x000D1F80
		[XmlIgnore]
		[Browsable(false)]
		public bool roleLevelSpecified
		{
			get
			{
				return this._roleLevel != null;
			}
			set
			{
				bool flag = value == (this._roleLevel == null);
				if (flag)
				{
					this._roleLevel = (value ? new int?(this.roleLevel) : null);
				}
			}
		}

		// Token: 0x06006EB6 RID: 28342 RVA: 0x000D3DC4 File Offset: 0x000D1FC4
		private bool ShouldSerializeroleLevel()
		{
			return this.roleLevelSpecified;
		}

		// Token: 0x06006EB7 RID: 28343 RVA: 0x000D3DDC File Offset: 0x000D1FDC
		private void ResetroleLevel()
		{
			this.roleLevelSpecified = false;
		}

		// Token: 0x06006EB8 RID: 28344 RVA: 0x000D3DE8 File Offset: 0x000D1FE8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A76 RID: 6774
		private ItemFindBackType? _id;

		// Token: 0x04001A77 RID: 6775
		private int? _findBackCount;

		// Token: 0x04001A78 RID: 6776
		private int? _dragonCoinCost;

		// Token: 0x04001A79 RID: 6777
		private readonly List<ItemBrief> _dragonCoinFindBackItems = new List<ItemBrief>();

		// Token: 0x04001A7A RID: 6778
		private int? _goldCoinCost;

		// Token: 0x04001A7B RID: 6779
		private readonly List<ItemBrief> _goldCoinFindBackItems = new List<ItemBrief>();

		// Token: 0x04001A7C RID: 6780
		private int? _dayTime;

		// Token: 0x04001A7D RID: 6781
		private int? _roleLevel;

		// Token: 0x04001A7E RID: 6782
		private IExtension extensionObject;
	}
}
