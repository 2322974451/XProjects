using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000649 RID: 1609
	[ProtoContract(Name = "BackFlowData")]
	[Serializable]
	public class BackFlowData : IExtensible
	{
		// Token: 0x17001F82 RID: 8066
		// (get) Token: 0x060063EF RID: 25583 RVA: 0x000BEB90 File Offset: 0x000BCD90
		// (set) Token: 0x060063F0 RID: 25584 RVA: 0x000BEBBC File Offset: 0x000BCDBC
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

		// Token: 0x17001F83 RID: 8067
		// (get) Token: 0x060063F1 RID: 25585 RVA: 0x000BEBCC File Offset: 0x000BCDCC
		// (set) Token: 0x060063F2 RID: 25586 RVA: 0x000BEBEC File Offset: 0x000BCDEC
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

		// Token: 0x060063F3 RID: 25587 RVA: 0x000BEC30 File Offset: 0x000BCE30
		private bool ShouldSerializeworldlevel()
		{
			return this.worldlevelSpecified;
		}

		// Token: 0x060063F4 RID: 25588 RVA: 0x000BEC48 File Offset: 0x000BCE48
		private void Resetworldlevel()
		{
			this.worldlevelSpecified = false;
		}

		// Token: 0x17001F84 RID: 8068
		// (get) Token: 0x060063F5 RID: 25589 RVA: 0x000BEC54 File Offset: 0x000BCE54
		// (set) Token: 0x060063F6 RID: 25590 RVA: 0x000BEC80 File Offset: 0x000BCE80
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

		// Token: 0x17001F85 RID: 8069
		// (get) Token: 0x060063F7 RID: 25591 RVA: 0x000BEC90 File Offset: 0x000BCE90
		// (set) Token: 0x060063F8 RID: 25592 RVA: 0x000BECB0 File Offset: 0x000BCEB0
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

		// Token: 0x060063F9 RID: 25593 RVA: 0x000BECF4 File Offset: 0x000BCEF4
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x060063FA RID: 25594 RVA: 0x000BED0C File Offset: 0x000BCF0C
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001F86 RID: 8070
		// (get) Token: 0x060063FB RID: 25595 RVA: 0x000BED18 File Offset: 0x000BCF18
		[ProtoMember(3, Name = "alreadyGet", DataFormat = DataFormat.TwosComplement)]
		public List<uint> alreadyGet
		{
			get
			{
				return this._alreadyGet;
			}
		}

		// Token: 0x17001F87 RID: 8071
		// (get) Token: 0x060063FC RID: 25596 RVA: 0x000BED30 File Offset: 0x000BCF30
		[ProtoMember(4, Name = "payGiftType", DataFormat = DataFormat.Default)]
		public List<string> payGiftType
		{
			get
			{
				return this._payGiftType;
			}
		}

		// Token: 0x17001F88 RID: 8072
		// (get) Token: 0x060063FD RID: 25597 RVA: 0x000BED48 File Offset: 0x000BCF48
		[ProtoMember(5, Name = "payGiftCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> payGiftCount
		{
			get
			{
				return this._payGiftCount;
			}
		}

		// Token: 0x17001F89 RID: 8073
		// (get) Token: 0x060063FE RID: 25598 RVA: 0x000BED60 File Offset: 0x000BCF60
		// (set) Token: 0x060063FF RID: 25599 RVA: 0x000BED8C File Offset: 0x000BCF8C
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

		// Token: 0x17001F8A RID: 8074
		// (get) Token: 0x06006400 RID: 25600 RVA: 0x000BED9C File Offset: 0x000BCF9C
		// (set) Token: 0x06006401 RID: 25601 RVA: 0x000BEDBC File Offset: 0x000BCFBC
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

		// Token: 0x06006402 RID: 25602 RVA: 0x000BEE00 File Offset: 0x000BD000
		private bool ShouldSerializelostDay()
		{
			return this.lostDaySpecified;
		}

		// Token: 0x06006403 RID: 25603 RVA: 0x000BEE18 File Offset: 0x000BD018
		private void ResetlostDay()
		{
			this.lostDaySpecified = false;
		}

		// Token: 0x17001F8B RID: 8075
		// (get) Token: 0x06006404 RID: 25604 RVA: 0x000BEE24 File Offset: 0x000BD024
		// (set) Token: 0x06006405 RID: 25605 RVA: 0x000BEE3C File Offset: 0x000BD03C
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

		// Token: 0x17001F8C RID: 8076
		// (get) Token: 0x06006406 RID: 25606 RVA: 0x000BEE48 File Offset: 0x000BD048
		// (set) Token: 0x06006407 RID: 25607 RVA: 0x000BEE74 File Offset: 0x000BD074
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

		// Token: 0x17001F8D RID: 8077
		// (get) Token: 0x06006408 RID: 25608 RVA: 0x000BEE84 File Offset: 0x000BD084
		// (set) Token: 0x06006409 RID: 25609 RVA: 0x000BEEA4 File Offset: 0x000BD0A4
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

		// Token: 0x0600640A RID: 25610 RVA: 0x000BEEE8 File Offset: 0x000BD0E8
		private bool ShouldSerializelastSmallDragonFinishTime()
		{
			return this.lastSmallDragonFinishTimeSpecified;
		}

		// Token: 0x0600640B RID: 25611 RVA: 0x000BEF00 File Offset: 0x000BD100
		private void ResetlastSmallDragonFinishTime()
		{
			this.lastSmallDragonFinishTimeSpecified = false;
		}

		// Token: 0x17001F8E RID: 8078
		// (get) Token: 0x0600640C RID: 25612 RVA: 0x000BEF0C File Offset: 0x000BD10C
		// (set) Token: 0x0600640D RID: 25613 RVA: 0x000BEF38 File Offset: 0x000BD138
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

		// Token: 0x17001F8F RID: 8079
		// (get) Token: 0x0600640E RID: 25614 RVA: 0x000BEF48 File Offset: 0x000BD148
		// (set) Token: 0x0600640F RID: 25615 RVA: 0x000BEF68 File Offset: 0x000BD168
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

		// Token: 0x06006410 RID: 25616 RVA: 0x000BEFAC File Offset: 0x000BD1AC
		private bool ShouldSerializeisFinishBackFlowScene()
		{
			return this.isFinishBackFlowSceneSpecified;
		}

		// Token: 0x06006411 RID: 25617 RVA: 0x000BEFC4 File Offset: 0x000BD1C4
		private void ResetisFinishBackFlowScene()
		{
			this.isFinishBackFlowSceneSpecified = false;
		}

		// Token: 0x17001F90 RID: 8080
		// (get) Token: 0x06006412 RID: 25618 RVA: 0x000BEFD0 File Offset: 0x000BD1D0
		// (set) Token: 0x06006413 RID: 25619 RVA: 0x000BEFFC File Offset: 0x000BD1FC
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

		// Token: 0x17001F91 RID: 8081
		// (get) Token: 0x06006414 RID: 25620 RVA: 0x000BF00C File Offset: 0x000BD20C
		// (set) Token: 0x06006415 RID: 25621 RVA: 0x000BF02C File Offset: 0x000BD22C
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

		// Token: 0x06006416 RID: 25622 RVA: 0x000BF070 File Offset: 0x000BD270
		private bool ShouldSerializelastNestFinishTime()
		{
			return this.lastNestFinishTimeSpecified;
		}

		// Token: 0x06006417 RID: 25623 RVA: 0x000BF088 File Offset: 0x000BD288
		private void ResetlastNestFinishTime()
		{
			this.lastNestFinishTimeSpecified = false;
		}

		// Token: 0x17001F92 RID: 8082
		// (get) Token: 0x06006418 RID: 25624 RVA: 0x000BF094 File Offset: 0x000BD294
		// (set) Token: 0x06006419 RID: 25625 RVA: 0x000BF0C0 File Offset: 0x000BD2C0
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

		// Token: 0x17001F93 RID: 8083
		// (get) Token: 0x0600641A RID: 25626 RVA: 0x000BF0D0 File Offset: 0x000BD2D0
		// (set) Token: 0x0600641B RID: 25627 RVA: 0x000BF0F0 File Offset: 0x000BD2F0
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

		// Token: 0x0600641C RID: 25628 RVA: 0x000BF134 File Offset: 0x000BD334
		private bool ShouldSerializenestFinishCount()
		{
			return this.nestFinishCountSpecified;
		}

		// Token: 0x0600641D RID: 25629 RVA: 0x000BF14C File Offset: 0x000BD34C
		private void ResetnestFinishCount()
		{
			this.nestFinishCountSpecified = false;
		}

		// Token: 0x0600641E RID: 25630 RVA: 0x000BF158 File Offset: 0x000BD358
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400183A RID: 6202
		private uint? _worldlevel;

		// Token: 0x0400183B RID: 6203
		private uint? _point;

		// Token: 0x0400183C RID: 6204
		private readonly List<uint> _alreadyGet = new List<uint>();

		// Token: 0x0400183D RID: 6205
		private readonly List<string> _payGiftType = new List<string>();

		// Token: 0x0400183E RID: 6206
		private readonly List<uint> _payGiftCount = new List<uint>();

		// Token: 0x0400183F RID: 6207
		private uint? _lostDay;

		// Token: 0x04001840 RID: 6208
		private BackFlowShopData _shop = null;

		// Token: 0x04001841 RID: 6209
		private uint? _lastSmallDragonFinishTime;

		// Token: 0x04001842 RID: 6210
		private bool? _isFinishBackFlowScene;

		// Token: 0x04001843 RID: 6211
		private uint? _lastNestFinishTime;

		// Token: 0x04001844 RID: 6212
		private uint? _nestFinishCount;

		// Token: 0x04001845 RID: 6213
		private IExtension extensionObject;
	}
}
