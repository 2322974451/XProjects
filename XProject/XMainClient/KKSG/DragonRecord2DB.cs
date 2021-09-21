using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000618 RID: 1560
	[ProtoContract(Name = "DragonRecord2DB")]
	[Serializable]
	public class DragonRecord2DB : IExtensible
	{
		// Token: 0x17001DBE RID: 7614
		// (get) Token: 0x06005EC2 RID: 24258 RVA: 0x000B4B08 File Offset: 0x000B2D08
		[ProtoMember(1, Name = "record", DataFormat = DataFormat.Default)]
		public List<DragonRecord> record
		{
			get
			{
				return this._record;
			}
		}

		// Token: 0x17001DBF RID: 7615
		// (get) Token: 0x06005EC3 RID: 24259 RVA: 0x000B4B20 File Offset: 0x000B2D20
		// (set) Token: 0x06005EC4 RID: 24260 RVA: 0x000B4B4C File Offset: 0x000B2D4C
		[ProtoMember(2, IsRequired = false, Name = "updateDay", DataFormat = DataFormat.TwosComplement)]
		public int updateDay
		{
			get
			{
				return this._updateDay ?? 0;
			}
			set
			{
				this._updateDay = new int?(value);
			}
		}

		// Token: 0x17001DC0 RID: 7616
		// (get) Token: 0x06005EC5 RID: 24261 RVA: 0x000B4B5C File Offset: 0x000B2D5C
		// (set) Token: 0x06005EC6 RID: 24262 RVA: 0x000B4B7C File Offset: 0x000B2D7C
		[XmlIgnore]
		[Browsable(false)]
		public bool updateDaySpecified
		{
			get
			{
				return this._updateDay != null;
			}
			set
			{
				bool flag = value == (this._updateDay == null);
				if (flag)
				{
					this._updateDay = (value ? new int?(this.updateDay) : null);
				}
			}
		}

		// Token: 0x06005EC7 RID: 24263 RVA: 0x000B4BC0 File Offset: 0x000B2DC0
		private bool ShouldSerializeupdateDay()
		{
			return this.updateDaySpecified;
		}

		// Token: 0x06005EC8 RID: 24264 RVA: 0x000B4BD8 File Offset: 0x000B2DD8
		private void ResetupdateDay()
		{
			this.updateDaySpecified = false;
		}

		// Token: 0x17001DC1 RID: 7617
		// (get) Token: 0x06005EC9 RID: 24265 RVA: 0x000B4BE4 File Offset: 0x000B2DE4
		// (set) Token: 0x06005ECA RID: 24266 RVA: 0x000B4C10 File Offset: 0x000B2E10
		[ProtoMember(3, IsRequired = false, Name = "updateHardDragonDay", DataFormat = DataFormat.TwosComplement)]
		public int updateHardDragonDay
		{
			get
			{
				return this._updateHardDragonDay ?? 0;
			}
			set
			{
				this._updateHardDragonDay = new int?(value);
			}
		}

		// Token: 0x17001DC2 RID: 7618
		// (get) Token: 0x06005ECB RID: 24267 RVA: 0x000B4C20 File Offset: 0x000B2E20
		// (set) Token: 0x06005ECC RID: 24268 RVA: 0x000B4C40 File Offset: 0x000B2E40
		[XmlIgnore]
		[Browsable(false)]
		public bool updateHardDragonDaySpecified
		{
			get
			{
				return this._updateHardDragonDay != null;
			}
			set
			{
				bool flag = value == (this._updateHardDragonDay == null);
				if (flag)
				{
					this._updateHardDragonDay = (value ? new int?(this.updateHardDragonDay) : null);
				}
			}
		}

		// Token: 0x06005ECD RID: 24269 RVA: 0x000B4C84 File Offset: 0x000B2E84
		private bool ShouldSerializeupdateHardDragonDay()
		{
			return this.updateHardDragonDaySpecified;
		}

		// Token: 0x06005ECE RID: 24270 RVA: 0x000B4C9C File Offset: 0x000B2E9C
		private void ResetupdateHardDragonDay()
		{
			this.updateHardDragonDaySpecified = false;
		}

		// Token: 0x17001DC3 RID: 7619
		// (get) Token: 0x06005ECF RID: 24271 RVA: 0x000B4CA8 File Offset: 0x000B2EA8
		// (set) Token: 0x06005ED0 RID: 24272 RVA: 0x000B4CD4 File Offset: 0x000B2ED4
		[ProtoMember(4, IsRequired = false, Name = "updateSmallDragonDay", DataFormat = DataFormat.TwosComplement)]
		public int updateSmallDragonDay
		{
			get
			{
				return this._updateSmallDragonDay ?? 0;
			}
			set
			{
				this._updateSmallDragonDay = new int?(value);
			}
		}

		// Token: 0x17001DC4 RID: 7620
		// (get) Token: 0x06005ED1 RID: 24273 RVA: 0x000B4CE4 File Offset: 0x000B2EE4
		// (set) Token: 0x06005ED2 RID: 24274 RVA: 0x000B4D04 File Offset: 0x000B2F04
		[XmlIgnore]
		[Browsable(false)]
		public bool updateSmallDragonDaySpecified
		{
			get
			{
				return this._updateSmallDragonDay != null;
			}
			set
			{
				bool flag = value == (this._updateSmallDragonDay == null);
				if (flag)
				{
					this._updateSmallDragonDay = (value ? new int?(this.updateSmallDragonDay) : null);
				}
			}
		}

		// Token: 0x06005ED3 RID: 24275 RVA: 0x000B4D48 File Offset: 0x000B2F48
		private bool ShouldSerializeupdateSmallDragonDay()
		{
			return this.updateSmallDragonDaySpecified;
		}

		// Token: 0x06005ED4 RID: 24276 RVA: 0x000B4D60 File Offset: 0x000B2F60
		private void ResetupdateSmallDragonDay()
		{
			this.updateSmallDragonDaySpecified = false;
		}

		// Token: 0x06005ED5 RID: 24277 RVA: 0x000B4D6C File Offset: 0x000B2F6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001700 RID: 5888
		private readonly List<DragonRecord> _record = new List<DragonRecord>();

		// Token: 0x04001701 RID: 5889
		private int? _updateDay;

		// Token: 0x04001702 RID: 5890
		private int? _updateHardDragonDay;

		// Token: 0x04001703 RID: 5891
		private int? _updateSmallDragonDay;

		// Token: 0x04001704 RID: 5892
		private IExtension extensionObject;
	}
}
