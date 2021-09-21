using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000385 RID: 901
	[ProtoContract(Name = "LeagueBattleOneResultNtf")]
	[Serializable]
	public class LeagueBattleOneResultNtf : IExtensible
	{
		// Token: 0x17000F21 RID: 3873
		// (get) Token: 0x060030E6 RID: 12518 RVA: 0x0005E430 File Offset: 0x0005C630
		// (set) Token: 0x060030E7 RID: 12519 RVA: 0x0005E448 File Offset: 0x0005C648
		[ProtoMember(1, IsRequired = false, Name = "winrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleRoleBrief winrole
		{
			get
			{
				return this._winrole;
			}
			set
			{
				this._winrole = value;
			}
		}

		// Token: 0x17000F22 RID: 3874
		// (get) Token: 0x060030E8 RID: 12520 RVA: 0x0005E454 File Offset: 0x0005C654
		// (set) Token: 0x060030E9 RID: 12521 RVA: 0x0005E46C File Offset: 0x0005C66C
		[ProtoMember(2, IsRequired = false, Name = "loserole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleRoleBrief loserole
		{
			get
			{
				return this._loserole;
			}
			set
			{
				this._loserole = value;
			}
		}

		// Token: 0x17000F23 RID: 3875
		// (get) Token: 0x060030EA RID: 12522 RVA: 0x0005E478 File Offset: 0x0005C678
		// (set) Token: 0x060030EB RID: 12523 RVA: 0x0005E4A8 File Offset: 0x0005C6A8
		[ProtoMember(3, IsRequired = false, Name = "winhppercent", DataFormat = DataFormat.FixedSize)]
		public float winhppercent
		{
			get
			{
				return this._winhppercent ?? 0f;
			}
			set
			{
				this._winhppercent = new float?(value);
			}
		}

		// Token: 0x17000F24 RID: 3876
		// (get) Token: 0x060030EC RID: 12524 RVA: 0x0005E4B8 File Offset: 0x0005C6B8
		// (set) Token: 0x060030ED RID: 12525 RVA: 0x0005E4D8 File Offset: 0x0005C6D8
		[XmlIgnore]
		[Browsable(false)]
		public bool winhppercentSpecified
		{
			get
			{
				return this._winhppercent != null;
			}
			set
			{
				bool flag = value == (this._winhppercent == null);
				if (flag)
				{
					this._winhppercent = (value ? new float?(this.winhppercent) : null);
				}
			}
		}

		// Token: 0x060030EE RID: 12526 RVA: 0x0005E51C File Offset: 0x0005C71C
		private bool ShouldSerializewinhppercent()
		{
			return this.winhppercentSpecified;
		}

		// Token: 0x060030EF RID: 12527 RVA: 0x0005E534 File Offset: 0x0005C734
		private void Resetwinhppercent()
		{
			this.winhppercentSpecified = false;
		}

		// Token: 0x17000F25 RID: 3877
		// (get) Token: 0x060030F0 RID: 12528 RVA: 0x0005E540 File Offset: 0x0005C740
		// (set) Token: 0x060030F1 RID: 12529 RVA: 0x0005E570 File Offset: 0x0005C770
		[ProtoMember(4, IsRequired = false, Name = "losehppercent", DataFormat = DataFormat.FixedSize)]
		public float losehppercent
		{
			get
			{
				return this._losehppercent ?? 0f;
			}
			set
			{
				this._losehppercent = new float?(value);
			}
		}

		// Token: 0x17000F26 RID: 3878
		// (get) Token: 0x060030F2 RID: 12530 RVA: 0x0005E580 File Offset: 0x0005C780
		// (set) Token: 0x060030F3 RID: 12531 RVA: 0x0005E5A0 File Offset: 0x0005C7A0
		[XmlIgnore]
		[Browsable(false)]
		public bool losehppercentSpecified
		{
			get
			{
				return this._losehppercent != null;
			}
			set
			{
				bool flag = value == (this._losehppercent == null);
				if (flag)
				{
					this._losehppercent = (value ? new float?(this.losehppercent) : null);
				}
			}
		}

		// Token: 0x060030F4 RID: 12532 RVA: 0x0005E5E4 File Offset: 0x0005C7E4
		private bool ShouldSerializelosehppercent()
		{
			return this.losehppercentSpecified;
		}

		// Token: 0x060030F5 RID: 12533 RVA: 0x0005E5FC File Offset: 0x0005C7FC
		private void Resetlosehppercent()
		{
			this.losehppercentSpecified = false;
		}

		// Token: 0x060030F6 RID: 12534 RVA: 0x0005E608 File Offset: 0x0005C808
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C24 RID: 3108
		private LeagueBattleRoleBrief _winrole = null;

		// Token: 0x04000C25 RID: 3109
		private LeagueBattleRoleBrief _loserole = null;

		// Token: 0x04000C26 RID: 3110
		private float? _winhppercent;

		// Token: 0x04000C27 RID: 3111
		private float? _losehppercent;

		// Token: 0x04000C28 RID: 3112
		private IExtension extensionObject;
	}
}
