using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000015 RID: 21
	[ProtoContract(Name = "DeathInfo")]
	[Serializable]
	public class DeathInfo : IExtensible
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00006034 File Offset: 0x00004234
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00006061 File Offset: 0x00004261
		[ProtoMember(1, IsRequired = false, Name = "Killer", DataFormat = DataFormat.TwosComplement)]
		public ulong Killer
		{
			get
			{
				return this._Killer ?? 0UL;
			}
			set
			{
				this._Killer = new ulong?(value);
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00006070 File Offset: 0x00004270
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00006090 File Offset: 0x00004290
		[XmlIgnore]
		[Browsable(false)]
		public bool KillerSpecified
		{
			get
			{
				return this._Killer != null;
			}
			set
			{
				bool flag = value == (this._Killer == null);
				if (flag)
				{
					this._Killer = (value ? new ulong?(this.Killer) : null);
				}
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000060D4 File Offset: 0x000042D4
		private bool ShouldSerializeKiller()
		{
			return this.KillerSpecified;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000060EC File Offset: 0x000042EC
		private void ResetKiller()
		{
			this.KillerSpecified = false;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x000060F8 File Offset: 0x000042F8
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00006125 File Offset: 0x00004325
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

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00006134 File Offset: 0x00004334
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00006154 File Offset: 0x00004354
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

		// Token: 0x060001C7 RID: 455 RVA: 0x00006198 File Offset: 0x00004398
		private bool ShouldSerializeuID()
		{
			return this.uIDSpecified;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000061B0 File Offset: 0x000043B0
		private void ResetuID()
		{
			this.uIDSpecified = false;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000061BC File Offset: 0x000043BC
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000061E8 File Offset: 0x000043E8
		[ProtoMember(3, IsRequired = false, Name = "showSlowCamera", DataFormat = DataFormat.Default)]
		public bool showSlowCamera
		{
			get
			{
				return this._showSlowCamera ?? false;
			}
			set
			{
				this._showSlowCamera = new bool?(value);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001CB RID: 459 RVA: 0x000061F8 File Offset: 0x000043F8
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00006218 File Offset: 0x00004418
		[XmlIgnore]
		[Browsable(false)]
		public bool showSlowCameraSpecified
		{
			get
			{
				return this._showSlowCamera != null;
			}
			set
			{
				bool flag = value == (this._showSlowCamera == null);
				if (flag)
				{
					this._showSlowCamera = (value ? new bool?(this.showSlowCamera) : null);
				}
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000625C File Offset: 0x0000445C
		private bool ShouldSerializeshowSlowCamera()
		{
			return this.showSlowCameraSpecified;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00006274 File Offset: 0x00004474
		private void ResetshowSlowCamera()
		{
			this.showSlowCameraSpecified = false;
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00006280 File Offset: 0x00004480
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x000062AC File Offset: 0x000044AC
		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ReviveType type
		{
			get
			{
				return this._type ?? ReviveType.ReviveNone;
			}
			set
			{
				this._type = new ReviveType?(value);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000062BC File Offset: 0x000044BC
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x000062DC File Offset: 0x000044DC
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new ReviveType?(this.type) : null);
				}
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00006320 File Offset: 0x00004520
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00006338 File Offset: 0x00004538
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00006344 File Offset: 0x00004544
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00006370 File Offset: 0x00004570
		[ProtoMember(5, IsRequired = false, Name = "revivecount", DataFormat = DataFormat.TwosComplement)]
		public uint revivecount
		{
			get
			{
				return this._revivecount ?? 0U;
			}
			set
			{
				this._revivecount = new uint?(value);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00006380 File Offset: 0x00004580
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x000063A0 File Offset: 0x000045A0
		[XmlIgnore]
		[Browsable(false)]
		public bool revivecountSpecified
		{
			get
			{
				return this._revivecount != null;
			}
			set
			{
				bool flag = value == (this._revivecount == null);
				if (flag)
				{
					this._revivecount = (value ? new uint?(this.revivecount) : null);
				}
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000063E4 File Offset: 0x000045E4
		private bool ShouldSerializerevivecount()
		{
			return this.revivecountSpecified;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000063FC File Offset: 0x000045FC
		private void Resetrevivecount()
		{
			this.revivecountSpecified = false;
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00006408 File Offset: 0x00004608
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00006434 File Offset: 0x00004634
		[ProtoMember(6, IsRequired = false, Name = "costrevivecount", DataFormat = DataFormat.TwosComplement)]
		public uint costrevivecount
		{
			get
			{
				return this._costrevivecount ?? 0U;
			}
			set
			{
				this._costrevivecount = new uint?(value);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00006444 File Offset: 0x00004644
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00006464 File Offset: 0x00004664
		[XmlIgnore]
		[Browsable(false)]
		public bool costrevivecountSpecified
		{
			get
			{
				return this._costrevivecount != null;
			}
			set
			{
				bool flag = value == (this._costrevivecount == null);
				if (flag)
				{
					this._costrevivecount = (value ? new uint?(this.costrevivecount) : null);
				}
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000064A8 File Offset: 0x000046A8
		private bool ShouldSerializecostrevivecount()
		{
			return this.costrevivecountSpecified;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000064C0 File Offset: 0x000046C0
		private void Resetcostrevivecount()
		{
			this.costrevivecountSpecified = false;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000064CC File Offset: 0x000046CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000073 RID: 115
		private ulong? _Killer;

		// Token: 0x04000074 RID: 116
		private ulong? _uID;

		// Token: 0x04000075 RID: 117
		private bool? _showSlowCamera;

		// Token: 0x04000076 RID: 118
		private ReviveType? _type;

		// Token: 0x04000077 RID: 119
		private uint? _revivecount;

		// Token: 0x04000078 RID: 120
		private uint? _costrevivecount;

		// Token: 0x04000079 RID: 121
		private IExtension extensionObject;
	}
}
