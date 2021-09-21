using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000016 RID: 22
	[ProtoContract(Name = "ChangedAttribute")]
	[Serializable]
	public class ChangedAttribute : IExtensible
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000650C File Offset: 0x0000470C
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00006539 File Offset: 0x00004739
		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public ulong time
		{
			get
			{
				return this._time ?? 0UL;
			}
			set
			{
				this._time = new ulong?(value);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00006548 File Offset: 0x00004748
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00006568 File Offset: 0x00004768
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new ulong?(this.time) : null);
				}
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000065AC File Offset: 0x000047AC
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000065C4 File Offset: 0x000047C4
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000065D0 File Offset: 0x000047D0
		// (set) Token: 0x060001EA RID: 490 RVA: 0x000065FD File Offset: 0x000047FD
		[ProtoMember(2, IsRequired = false, Name = "uID", DataFormat = DataFormat.TwosComplement)]
		public ulong uID
		{
			get
			{
				return this._uID ?? 0UL;
			}
			set
			{
				this._uID = new ulong?(value);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001EB RID: 491 RVA: 0x0000660C File Offset: 0x0000480C
		// (set) Token: 0x060001EC RID: 492 RVA: 0x0000662C File Offset: 0x0000482C
		[XmlIgnore]
		[Browsable(false)]
		public bool uIDSpecified
		{
			get
			{
				return this._uID != null;
			}
			set
			{
				bool flag = value == (this._uID == null);
				if (flag)
				{
					this._uID = (value ? new ulong?(this.uID) : null);
				}
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00006670 File Offset: 0x00004870
		private bool ShouldSerializeuID()
		{
			return this.uIDSpecified;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00006688 File Offset: 0x00004888
		private void ResetuID()
		{
			this.uIDSpecified = false;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00006694 File Offset: 0x00004894
		[ProtoMember(3, Name = "AttrID", DataFormat = DataFormat.TwosComplement)]
		public List<int> AttrID
		{
			get
			{
				return this._AttrID;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x000066AC File Offset: 0x000048AC
		[ProtoMember(4, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x000066C4 File Offset: 0x000048C4
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x000066F0 File Offset: 0x000048F0
		[ProtoMember(5, IsRequired = false, Name = "showHUD", DataFormat = DataFormat.Default)]
		public bool showHUD
		{
			get
			{
				return this._showHUD ?? false;
			}
			set
			{
				this._showHUD = new bool?(value);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00006700 File Offset: 0x00004900
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00006720 File Offset: 0x00004920
		[XmlIgnore]
		[Browsable(false)]
		public bool showHUDSpecified
		{
			get
			{
				return this._showHUD != null;
			}
			set
			{
				bool flag = value == (this._showHUD == null);
				if (flag)
				{
					this._showHUD = (value ? new bool?(this.showHUD) : null);
				}
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00006764 File Offset: 0x00004964
		private bool ShouldSerializeshowHUD()
		{
			return this.showHUDSpecified;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000677C File Offset: 0x0000497C
		private void ResetshowHUD()
		{
			this.showHUDSpecified = false;
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00006788 File Offset: 0x00004988
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x000067B4 File Offset: 0x000049B4
		[ProtoMember(6, IsRequired = false, Name = "needHUD", DataFormat = DataFormat.Default)]
		public bool needHUD
		{
			get
			{
				return this._needHUD ?? false;
			}
			set
			{
				this._needHUD = new bool?(value);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x000067C4 File Offset: 0x000049C4
		// (set) Token: 0x060001FA RID: 506 RVA: 0x000067E4 File Offset: 0x000049E4
		[XmlIgnore]
		[Browsable(false)]
		public bool needHUDSpecified
		{
			get
			{
				return this._needHUD != null;
			}
			set
			{
				bool flag = value == (this._needHUD == null);
				if (flag)
				{
					this._needHUD = (value ? new bool?(this.needHUD) : null);
				}
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00006828 File Offset: 0x00004A28
		private bool ShouldSerializeneedHUD()
		{
			return this.needHUDSpecified;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00006840 File Offset: 0x00004A40
		private void ResetneedHUD()
		{
			this.needHUDSpecified = false;
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000684C File Offset: 0x00004A4C
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00006879 File Offset: 0x00004A79
		[ProtoMember(7, IsRequired = false, Name = "CasterID", DataFormat = DataFormat.TwosComplement)]
		public ulong CasterID
		{
			get
			{
				return this._CasterID ?? 0UL;
			}
			set
			{
				this._CasterID = new ulong?(value);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00006888 File Offset: 0x00004A88
		// (set) Token: 0x06000200 RID: 512 RVA: 0x000068A8 File Offset: 0x00004AA8
		[XmlIgnore]
		[Browsable(false)]
		public bool CasterIDSpecified
		{
			get
			{
				return this._CasterID != null;
			}
			set
			{
				bool flag = value == (this._CasterID == null);
				if (flag)
				{
					this._CasterID = (value ? new ulong?(this.CasterID) : null);
				}
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000068EC File Offset: 0x00004AEC
		private bool ShouldSerializeCasterID()
		{
			return this.CasterIDSpecified;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00006904 File Offset: 0x00004B04
		private void ResetCasterID()
		{
			this.CasterIDSpecified = false;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00006910 File Offset: 0x00004B10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400007A RID: 122
		private ulong? _time;

		// Token: 0x0400007B RID: 123
		private ulong? _uID;

		// Token: 0x0400007C RID: 124
		private readonly List<int> _AttrID = new List<int>();

		// Token: 0x0400007D RID: 125
		private readonly List<double> _AttrValue = new List<double>();

		// Token: 0x0400007E RID: 126
		private bool? _showHUD;

		// Token: 0x0400007F RID: 127
		private bool? _needHUD;

		// Token: 0x04000080 RID: 128
		private ulong? _CasterID;

		// Token: 0x04000081 RID: 129
		private IExtension extensionObject;
	}
}
