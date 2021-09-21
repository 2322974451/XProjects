using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006CD RID: 1741
	[ProtoContract(Name = "GuildMemberAskItem")]
	[Serializable]
	public class GuildMemberAskItem : IExtensible
	{
		// Token: 0x1700246B RID: 9323
		// (get) Token: 0x0600730C RID: 29452 RVA: 0x000DC160 File Offset: 0x000DA360
		// (set) Token: 0x0600730D RID: 29453 RVA: 0x000DC18C File Offset: 0x000DA38C
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x1700246C RID: 9324
		// (get) Token: 0x0600730E RID: 29454 RVA: 0x000DC19C File Offset: 0x000DA39C
		// (set) Token: 0x0600730F RID: 29455 RVA: 0x000DC1BC File Offset: 0x000DA3BC
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
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06007310 RID: 29456 RVA: 0x000DC200 File Offset: 0x000DA400
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06007311 RID: 29457 RVA: 0x000DC218 File Offset: 0x000DA418
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700246D RID: 9325
		// (get) Token: 0x06007312 RID: 29458 RVA: 0x000DC224 File Offset: 0x000DA424
		// (set) Token: 0x06007313 RID: 29459 RVA: 0x000DC251 File Offset: 0x000DA451
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x1700246E RID: 9326
		// (get) Token: 0x06007314 RID: 29460 RVA: 0x000DC260 File Offset: 0x000DA460
		// (set) Token: 0x06007315 RID: 29461 RVA: 0x000DC280 File Offset: 0x000DA480
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06007316 RID: 29462 RVA: 0x000DC2C4 File Offset: 0x000DA4C4
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007317 RID: 29463 RVA: 0x000DC2DC File Offset: 0x000DA4DC
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700246F RID: 9327
		// (get) Token: 0x06007318 RID: 29464 RVA: 0x000DC2E8 File Offset: 0x000DA4E8
		// (set) Token: 0x06007319 RID: 29465 RVA: 0x000DC314 File Offset: 0x000DA514
		[ProtoMember(3, IsRequired = false, Name = "publishtime", DataFormat = DataFormat.TwosComplement)]
		public uint publishtime
		{
			get
			{
				return this._publishtime ?? 0U;
			}
			set
			{
				this._publishtime = new uint?(value);
			}
		}

		// Token: 0x17002470 RID: 9328
		// (get) Token: 0x0600731A RID: 29466 RVA: 0x000DC324 File Offset: 0x000DA524
		// (set) Token: 0x0600731B RID: 29467 RVA: 0x000DC344 File Offset: 0x000DA544
		[XmlIgnore]
		[Browsable(false)]
		public bool publishtimeSpecified
		{
			get
			{
				return this._publishtime != null;
			}
			set
			{
				bool flag = value == (this._publishtime == null);
				if (flag)
				{
					this._publishtime = (value ? new uint?(this.publishtime) : null);
				}
			}
		}

		// Token: 0x0600731C RID: 29468 RVA: 0x000DC388 File Offset: 0x000DA588
		private bool ShouldSerializepublishtime()
		{
			return this.publishtimeSpecified;
		}

		// Token: 0x0600731D RID: 29469 RVA: 0x000DC3A0 File Offset: 0x000DA5A0
		private void Resetpublishtime()
		{
			this.publishtimeSpecified = false;
		}

		// Token: 0x17002471 RID: 9329
		// (get) Token: 0x0600731E RID: 29470 RVA: 0x000DC3AC File Offset: 0x000DA5AC
		// (set) Token: 0x0600731F RID: 29471 RVA: 0x000DC3D8 File Offset: 0x000DA5D8
		[ProtoMember(4, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x17002472 RID: 9330
		// (get) Token: 0x06007320 RID: 29472 RVA: 0x000DC3E8 File Offset: 0x000DA5E8
		// (set) Token: 0x06007321 RID: 29473 RVA: 0x000DC408 File Offset: 0x000DA608
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06007322 RID: 29474 RVA: 0x000DC44C File Offset: 0x000DA64C
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06007323 RID: 29475 RVA: 0x000DC464 File Offset: 0x000DA664
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17002473 RID: 9331
		// (get) Token: 0x06007324 RID: 29476 RVA: 0x000DC470 File Offset: 0x000DA670
		// (set) Token: 0x06007325 RID: 29477 RVA: 0x000DC49C File Offset: 0x000DA69C
		[ProtoMember(5, IsRequired = false, Name = "needCount", DataFormat = DataFormat.TwosComplement)]
		public uint needCount
		{
			get
			{
				return this._needCount ?? 0U;
			}
			set
			{
				this._needCount = new uint?(value);
			}
		}

		// Token: 0x17002474 RID: 9332
		// (get) Token: 0x06007326 RID: 29478 RVA: 0x000DC4AC File Offset: 0x000DA6AC
		// (set) Token: 0x06007327 RID: 29479 RVA: 0x000DC4CC File Offset: 0x000DA6CC
		[XmlIgnore]
		[Browsable(false)]
		public bool needCountSpecified
		{
			get
			{
				return this._needCount != null;
			}
			set
			{
				bool flag = value == (this._needCount == null);
				if (flag)
				{
					this._needCount = (value ? new uint?(this.needCount) : null);
				}
			}
		}

		// Token: 0x06007328 RID: 29480 RVA: 0x000DC510 File Offset: 0x000DA710
		private bool ShouldSerializeneedCount()
		{
			return this.needCountSpecified;
		}

		// Token: 0x06007329 RID: 29481 RVA: 0x000DC528 File Offset: 0x000DA728
		private void ResetneedCount()
		{
			this.needCountSpecified = false;
		}

		// Token: 0x17002475 RID: 9333
		// (get) Token: 0x0600732A RID: 29482 RVA: 0x000DC534 File Offset: 0x000DA734
		// (set) Token: 0x0600732B RID: 29483 RVA: 0x000DC560 File Offset: 0x000DA760
		[ProtoMember(6, IsRequired = false, Name = "getCount", DataFormat = DataFormat.TwosComplement)]
		public uint getCount
		{
			get
			{
				return this._getCount ?? 0U;
			}
			set
			{
				this._getCount = new uint?(value);
			}
		}

		// Token: 0x17002476 RID: 9334
		// (get) Token: 0x0600732C RID: 29484 RVA: 0x000DC570 File Offset: 0x000DA770
		// (set) Token: 0x0600732D RID: 29485 RVA: 0x000DC590 File Offset: 0x000DA790
		[XmlIgnore]
		[Browsable(false)]
		public bool getCountSpecified
		{
			get
			{
				return this._getCount != null;
			}
			set
			{
				bool flag = value == (this._getCount == null);
				if (flag)
				{
					this._getCount = (value ? new uint?(this.getCount) : null);
				}
			}
		}

		// Token: 0x0600732E RID: 29486 RVA: 0x000DC5D4 File Offset: 0x000DA7D4
		private bool ShouldSerializegetCount()
		{
			return this.getCountSpecified;
		}

		// Token: 0x0600732F RID: 29487 RVA: 0x000DC5EC File Offset: 0x000DA7EC
		private void ResetgetCount()
		{
			this.getCountSpecified = false;
		}

		// Token: 0x17002477 RID: 9335
		// (get) Token: 0x06007330 RID: 29488 RVA: 0x000DC5F8 File Offset: 0x000DA7F8
		// (set) Token: 0x06007331 RID: 29489 RVA: 0x000DC624 File Offset: 0x000DA824
		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17002478 RID: 9336
		// (get) Token: 0x06007332 RID: 29490 RVA: 0x000DC634 File Offset: 0x000DA834
		// (set) Token: 0x06007333 RID: 29491 RVA: 0x000DC654 File Offset: 0x000DA854
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06007334 RID: 29492 RVA: 0x000DC698 File Offset: 0x000DA898
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007335 RID: 29493 RVA: 0x000DC6B0 File Offset: 0x000DA8B0
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002479 RID: 9337
		// (get) Token: 0x06007336 RID: 29494 RVA: 0x000DC6BC File Offset: 0x000DA8BC
		// (set) Token: 0x06007337 RID: 29495 RVA: 0x000DC6E8 File Offset: 0x000DA8E8
		[ProtoMember(8, IsRequired = false, Name = "quality", DataFormat = DataFormat.TwosComplement)]
		public uint quality
		{
			get
			{
				return this._quality ?? 0U;
			}
			set
			{
				this._quality = new uint?(value);
			}
		}

		// Token: 0x1700247A RID: 9338
		// (get) Token: 0x06007338 RID: 29496 RVA: 0x000DC6F8 File Offset: 0x000DA8F8
		// (set) Token: 0x06007339 RID: 29497 RVA: 0x000DC718 File Offset: 0x000DA918
		[XmlIgnore]
		[Browsable(false)]
		public bool qualitySpecified
		{
			get
			{
				return this._quality != null;
			}
			set
			{
				bool flag = value == (this._quality == null);
				if (flag)
				{
					this._quality = (value ? new uint?(this.quality) : null);
				}
			}
		}

		// Token: 0x0600733A RID: 29498 RVA: 0x000DC75C File Offset: 0x000DA95C
		private bool ShouldSerializequality()
		{
			return this.qualitySpecified;
		}

		// Token: 0x0600733B RID: 29499 RVA: 0x000DC774 File Offset: 0x000DA974
		private void Resetquality()
		{
			this.qualitySpecified = false;
		}

		// Token: 0x1700247B RID: 9339
		// (get) Token: 0x0600733C RID: 29500 RVA: 0x000DC780 File Offset: 0x000DA980
		// (set) Token: 0x0600733D RID: 29501 RVA: 0x000DC7AC File Offset: 0x000DA9AC
		[ProtoMember(9, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		// Token: 0x1700247C RID: 9340
		// (get) Token: 0x0600733E RID: 29502 RVA: 0x000DC7BC File Offset: 0x000DA9BC
		// (set) Token: 0x0600733F RID: 29503 RVA: 0x000DC7DC File Offset: 0x000DA9DC
		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		// Token: 0x06007340 RID: 29504 RVA: 0x000DC820 File Offset: 0x000DAA20
		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		// Token: 0x06007341 RID: 29505 RVA: 0x000DC838 File Offset: 0x000DAA38
		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		// Token: 0x1700247D RID: 9341
		// (get) Token: 0x06007342 RID: 29506 RVA: 0x000DC844 File Offset: 0x000DAA44
		// (set) Token: 0x06007343 RID: 29507 RVA: 0x000DC870 File Offset: 0x000DAA70
		[ProtoMember(10, IsRequired = false, Name = "tasktype", DataFormat = DataFormat.TwosComplement)]
		public PeriodTaskType tasktype
		{
			get
			{
				return this._tasktype ?? PeriodTaskType.PeriodTaskType_Daily;
			}
			set
			{
				this._tasktype = new PeriodTaskType?(value);
			}
		}

		// Token: 0x1700247E RID: 9342
		// (get) Token: 0x06007344 RID: 29508 RVA: 0x000DC880 File Offset: 0x000DAA80
		// (set) Token: 0x06007345 RID: 29509 RVA: 0x000DC8A0 File Offset: 0x000DAAA0
		[XmlIgnore]
		[Browsable(false)]
		public bool tasktypeSpecified
		{
			get
			{
				return this._tasktype != null;
			}
			set
			{
				bool flag = value == (this._tasktype == null);
				if (flag)
				{
					this._tasktype = (value ? new PeriodTaskType?(this.tasktype) : null);
				}
			}
		}

		// Token: 0x06007346 RID: 29510 RVA: 0x000DC8E4 File Offset: 0x000DAAE4
		private bool ShouldSerializetasktype()
		{
			return this.tasktypeSpecified;
		}

		// Token: 0x06007347 RID: 29511 RVA: 0x000DC8FC File Offset: 0x000DAAFC
		private void Resettasktype()
		{
			this.tasktypeSpecified = false;
		}

		// Token: 0x1700247F RID: 9343
		// (get) Token: 0x06007348 RID: 29512 RVA: 0x000DC908 File Offset: 0x000DAB08
		// (set) Token: 0x06007349 RID: 29513 RVA: 0x000DC934 File Offset: 0x000DAB34
		[ProtoMember(11, IsRequired = false, Name = "itemtype", DataFormat = DataFormat.TwosComplement)]
		public uint itemtype
		{
			get
			{
				return this._itemtype ?? 0U;
			}
			set
			{
				this._itemtype = new uint?(value);
			}
		}

		// Token: 0x17002480 RID: 9344
		// (get) Token: 0x0600734A RID: 29514 RVA: 0x000DC944 File Offset: 0x000DAB44
		// (set) Token: 0x0600734B RID: 29515 RVA: 0x000DC964 File Offset: 0x000DAB64
		[XmlIgnore]
		[Browsable(false)]
		public bool itemtypeSpecified
		{
			get
			{
				return this._itemtype != null;
			}
			set
			{
				bool flag = value == (this._itemtype == null);
				if (flag)
				{
					this._itemtype = (value ? new uint?(this.itemtype) : null);
				}
			}
		}

		// Token: 0x0600734C RID: 29516 RVA: 0x000DC9A8 File Offset: 0x000DABA8
		private bool ShouldSerializeitemtype()
		{
			return this.itemtypeSpecified;
		}

		// Token: 0x0600734D RID: 29517 RVA: 0x000DC9C0 File Offset: 0x000DABC0
		private void Resetitemtype()
		{
			this.itemtypeSpecified = false;
		}

		// Token: 0x17002481 RID: 9345
		// (get) Token: 0x0600734E RID: 29518 RVA: 0x000DC9CC File Offset: 0x000DABCC
		// (set) Token: 0x0600734F RID: 29519 RVA: 0x000DC9F8 File Offset: 0x000DABF8
		[ProtoMember(12, IsRequired = false, Name = "itemquality", DataFormat = DataFormat.TwosComplement)]
		public uint itemquality
		{
			get
			{
				return this._itemquality ?? 0U;
			}
			set
			{
				this._itemquality = new uint?(value);
			}
		}

		// Token: 0x17002482 RID: 9346
		// (get) Token: 0x06007350 RID: 29520 RVA: 0x000DCA08 File Offset: 0x000DAC08
		// (set) Token: 0x06007351 RID: 29521 RVA: 0x000DCA28 File Offset: 0x000DAC28
		[XmlIgnore]
		[Browsable(false)]
		public bool itemqualitySpecified
		{
			get
			{
				return this._itemquality != null;
			}
			set
			{
				bool flag = value == (this._itemquality == null);
				if (flag)
				{
					this._itemquality = (value ? new uint?(this.itemquality) : null);
				}
			}
		}

		// Token: 0x06007352 RID: 29522 RVA: 0x000DCA6C File Offset: 0x000DAC6C
		private bool ShouldSerializeitemquality()
		{
			return this.itemqualitySpecified;
		}

		// Token: 0x06007353 RID: 29523 RVA: 0x000DCA84 File Offset: 0x000DAC84
		private void Resetitemquality()
		{
			this.itemqualitySpecified = false;
		}

		// Token: 0x17002483 RID: 9347
		// (get) Token: 0x06007354 RID: 29524 RVA: 0x000DCA90 File Offset: 0x000DAC90
		// (set) Token: 0x06007355 RID: 29525 RVA: 0x000DCABC File Offset: 0x000DACBC
		[ProtoMember(13, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x17002484 RID: 9348
		// (get) Token: 0x06007356 RID: 29526 RVA: 0x000DCACC File Offset: 0x000DACCC
		// (set) Token: 0x06007357 RID: 29527 RVA: 0x000DCAEC File Offset: 0x000DACEC
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06007358 RID: 29528 RVA: 0x000DCB30 File Offset: 0x000DAD30
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06007359 RID: 29529 RVA: 0x000DCB48 File Offset: 0x000DAD48
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x0600735A RID: 29530 RVA: 0x000DCB54 File Offset: 0x000DAD54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B63 RID: 7011
		private uint? _id;

		// Token: 0x04001B64 RID: 7012
		private ulong? _roleid;

		// Token: 0x04001B65 RID: 7013
		private uint? _publishtime;

		// Token: 0x04001B66 RID: 7014
		private uint? _itemid;

		// Token: 0x04001B67 RID: 7015
		private uint? _needCount;

		// Token: 0x04001B68 RID: 7016
		private uint? _getCount;

		// Token: 0x04001B69 RID: 7017
		private uint? _level;

		// Token: 0x04001B6A RID: 7018
		private uint? _quality;

		// Token: 0x04001B6B RID: 7019
		private uint? _taskid;

		// Token: 0x04001B6C RID: 7020
		private PeriodTaskType? _tasktype;

		// Token: 0x04001B6D RID: 7021
		private uint? _itemtype;

		// Token: 0x04001B6E RID: 7022
		private uint? _itemquality;

		// Token: 0x04001B6F RID: 7023
		private uint? _index;

		// Token: 0x04001B70 RID: 7024
		private IExtension extensionObject;
	}
}
