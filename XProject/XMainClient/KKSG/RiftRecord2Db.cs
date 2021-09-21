using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000681 RID: 1665
	[ProtoContract(Name = "RiftRecord2Db")]
	[Serializable]
	public class RiftRecord2Db : IExtensible
	{
		// Token: 0x170021CA RID: 8650
		// (get) Token: 0x06006AC7 RID: 27335 RVA: 0x000CC394 File Offset: 0x000CA594
		// (set) Token: 0x06006AC8 RID: 27336 RVA: 0x000CC3C0 File Offset: 0x000CA5C0
		[ProtoMember(1, IsRequired = false, Name = "riftID", DataFormat = DataFormat.TwosComplement)]
		public uint riftID
		{
			get
			{
				return this._riftID ?? 0U;
			}
			set
			{
				this._riftID = new uint?(value);
			}
		}

		// Token: 0x170021CB RID: 8651
		// (get) Token: 0x06006AC9 RID: 27337 RVA: 0x000CC3D0 File Offset: 0x000CA5D0
		// (set) Token: 0x06006ACA RID: 27338 RVA: 0x000CC3F0 File Offset: 0x000CA5F0
		[XmlIgnore]
		[Browsable(false)]
		public bool riftIDSpecified
		{
			get
			{
				return this._riftID != null;
			}
			set
			{
				bool flag = value == (this._riftID == null);
				if (flag)
				{
					this._riftID = (value ? new uint?(this.riftID) : null);
				}
			}
		}

		// Token: 0x06006ACB RID: 27339 RVA: 0x000CC434 File Offset: 0x000CA634
		private bool ShouldSerializeriftID()
		{
			return this.riftIDSpecified;
		}

		// Token: 0x06006ACC RID: 27340 RVA: 0x000CC44C File Offset: 0x000CA64C
		private void ResetriftID()
		{
			this.riftIDSpecified = false;
		}

		// Token: 0x170021CC RID: 8652
		// (get) Token: 0x06006ACD RID: 27341 RVA: 0x000CC458 File Offset: 0x000CA658
		// (set) Token: 0x06006ACE RID: 27342 RVA: 0x000CC484 File Offset: 0x000CA684
		[ProtoMember(2, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170021CD RID: 8653
		// (get) Token: 0x06006ACF RID: 27343 RVA: 0x000CC494 File Offset: 0x000CA694
		// (set) Token: 0x06006AD0 RID: 27344 RVA: 0x000CC4B4 File Offset: 0x000CA6B4
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

		// Token: 0x06006AD1 RID: 27345 RVA: 0x000CC4F8 File Offset: 0x000CA6F8
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x06006AD2 RID: 27346 RVA: 0x000CC510 File Offset: 0x000CA710
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x170021CE RID: 8654
		// (get) Token: 0x06006AD3 RID: 27347 RVA: 0x000CC51C File Offset: 0x000CA71C
		// (set) Token: 0x06006AD4 RID: 27348 RVA: 0x000CC548 File Offset: 0x000CA748
		[ProtoMember(3, IsRequired = false, Name = "passFloor", DataFormat = DataFormat.TwosComplement)]
		public uint passFloor
		{
			get
			{
				return this._passFloor ?? 0U;
			}
			set
			{
				this._passFloor = new uint?(value);
			}
		}

		// Token: 0x170021CF RID: 8655
		// (get) Token: 0x06006AD5 RID: 27349 RVA: 0x000CC558 File Offset: 0x000CA758
		// (set) Token: 0x06006AD6 RID: 27350 RVA: 0x000CC578 File Offset: 0x000CA778
		[XmlIgnore]
		[Browsable(false)]
		public bool passFloorSpecified
		{
			get
			{
				return this._passFloor != null;
			}
			set
			{
				bool flag = value == (this._passFloor == null);
				if (flag)
				{
					this._passFloor = (value ? new uint?(this.passFloor) : null);
				}
			}
		}

		// Token: 0x06006AD7 RID: 27351 RVA: 0x000CC5BC File Offset: 0x000CA7BC
		private bool ShouldSerializepassFloor()
		{
			return this.passFloorSpecified;
		}

		// Token: 0x06006AD8 RID: 27352 RVA: 0x000CC5D4 File Offset: 0x000CA7D4
		private void ResetpassFloor()
		{
			this.passFloorSpecified = false;
		}

		// Token: 0x170021D0 RID: 8656
		// (get) Token: 0x06006AD9 RID: 27353 RVA: 0x000CC5E0 File Offset: 0x000CA7E0
		// (set) Token: 0x06006ADA RID: 27354 RVA: 0x000CC60C File Offset: 0x000CA80C
		[ProtoMember(4, IsRequired = false, Name = "helpSuccessCount", DataFormat = DataFormat.TwosComplement)]
		public uint helpSuccessCount
		{
			get
			{
				return this._helpSuccessCount ?? 0U;
			}
			set
			{
				this._helpSuccessCount = new uint?(value);
			}
		}

		// Token: 0x170021D1 RID: 8657
		// (get) Token: 0x06006ADB RID: 27355 RVA: 0x000CC61C File Offset: 0x000CA81C
		// (set) Token: 0x06006ADC RID: 27356 RVA: 0x000CC63C File Offset: 0x000CA83C
		[XmlIgnore]
		[Browsable(false)]
		public bool helpSuccessCountSpecified
		{
			get
			{
				return this._helpSuccessCount != null;
			}
			set
			{
				bool flag = value == (this._helpSuccessCount == null);
				if (flag)
				{
					this._helpSuccessCount = (value ? new uint?(this.helpSuccessCount) : null);
				}
			}
		}

		// Token: 0x06006ADD RID: 27357 RVA: 0x000CC680 File Offset: 0x000CA880
		private bool ShouldSerializehelpSuccessCount()
		{
			return this.helpSuccessCountSpecified;
		}

		// Token: 0x06006ADE RID: 27358 RVA: 0x000CC698 File Offset: 0x000CA898
		private void ResethelpSuccessCount()
		{
			this.helpSuccessCountSpecified = false;
		}

		// Token: 0x170021D2 RID: 8658
		// (get) Token: 0x06006ADF RID: 27359 RVA: 0x000CC6A4 File Offset: 0x000CA8A4
		[ProtoMember(5, Name = "gotWeekFirstPassReward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> gotWeekFirstPassReward
		{
			get
			{
				return this._gotWeekFirstPassReward;
			}
		}

		// Token: 0x170021D3 RID: 8659
		// (get) Token: 0x06006AE0 RID: 27360 RVA: 0x000CC6BC File Offset: 0x000CA8BC
		[ProtoMember(6, Name = "gotItems", DataFormat = DataFormat.Default)]
		public List<MapIntItem> gotItems
		{
			get
			{
				return this._gotItems;
			}
		}

		// Token: 0x170021D4 RID: 8660
		// (get) Token: 0x06006AE1 RID: 27361 RVA: 0x000CC6D4 File Offset: 0x000CA8D4
		// (set) Token: 0x06006AE2 RID: 27362 RVA: 0x000CC700 File Offset: 0x000CA900
		[ProtoMember(7, IsRequired = false, Name = "thisWeekStartFloor", DataFormat = DataFormat.TwosComplement)]
		public uint thisWeekStartFloor
		{
			get
			{
				return this._thisWeekStartFloor ?? 0U;
			}
			set
			{
				this._thisWeekStartFloor = new uint?(value);
			}
		}

		// Token: 0x170021D5 RID: 8661
		// (get) Token: 0x06006AE3 RID: 27363 RVA: 0x000CC710 File Offset: 0x000CA910
		// (set) Token: 0x06006AE4 RID: 27364 RVA: 0x000CC730 File Offset: 0x000CA930
		[XmlIgnore]
		[Browsable(false)]
		public bool thisWeekStartFloorSpecified
		{
			get
			{
				return this._thisWeekStartFloor != null;
			}
			set
			{
				bool flag = value == (this._thisWeekStartFloor == null);
				if (flag)
				{
					this._thisWeekStartFloor = (value ? new uint?(this.thisWeekStartFloor) : null);
				}
			}
		}

		// Token: 0x06006AE5 RID: 27365 RVA: 0x000CC774 File Offset: 0x000CA974
		private bool ShouldSerializethisWeekStartFloor()
		{
			return this.thisWeekStartFloorSpecified;
		}

		// Token: 0x06006AE6 RID: 27366 RVA: 0x000CC78C File Offset: 0x000CA98C
		private void ResetthisWeekStartFloor()
		{
			this.thisWeekStartFloorSpecified = false;
		}

		// Token: 0x170021D6 RID: 8662
		// (get) Token: 0x06006AE7 RID: 27367 RVA: 0x000CC798 File Offset: 0x000CA998
		[ProtoMember(8, Name = "hisMaxFloor", DataFormat = DataFormat.Default)]
		public List<MapIntItem> hisMaxFloor
		{
			get
			{
				return this._hisMaxFloor;
			}
		}

		// Token: 0x06006AE8 RID: 27368 RVA: 0x000CC7B0 File Offset: 0x000CA9B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019B5 RID: 6581
		private uint? _riftID;

		// Token: 0x040019B6 RID: 6582
		private uint? _updateTime;

		// Token: 0x040019B7 RID: 6583
		private uint? _passFloor;

		// Token: 0x040019B8 RID: 6584
		private uint? _helpSuccessCount;

		// Token: 0x040019B9 RID: 6585
		private readonly List<uint> _gotWeekFirstPassReward = new List<uint>();

		// Token: 0x040019BA RID: 6586
		private readonly List<MapIntItem> _gotItems = new List<MapIntItem>();

		// Token: 0x040019BB RID: 6587
		private uint? _thisWeekStartFloor;

		// Token: 0x040019BC RID: 6588
		private readonly List<MapIntItem> _hisMaxFloor = new List<MapIntItem>();

		// Token: 0x040019BD RID: 6589
		private IExtension extensionObject;
	}
}
