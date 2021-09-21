using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200073A RID: 1850
	[ProtoContract(Name = "DailyTaskRefreshInfo")]
	[Serializable]
	public class DailyTaskRefreshInfo : IExtensible
	{
		// Token: 0x170028A5 RID: 10405
		// (get) Token: 0x06008035 RID: 32821 RVA: 0x000F529C File Offset: 0x000F349C
		// (set) Token: 0x06008036 RID: 32822 RVA: 0x000F52C9 File Offset: 0x000F34C9
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028A6 RID: 10406
		// (get) Token: 0x06008037 RID: 32823 RVA: 0x000F52D8 File Offset: 0x000F34D8
		// (set) Token: 0x06008038 RID: 32824 RVA: 0x000F52F8 File Offset: 0x000F34F8
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

		// Token: 0x06008039 RID: 32825 RVA: 0x000F533C File Offset: 0x000F353C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600803A RID: 32826 RVA: 0x000F5354 File Offset: 0x000F3554
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170028A7 RID: 10407
		// (get) Token: 0x0600803B RID: 32827 RVA: 0x000F5360 File Offset: 0x000F3560
		// (set) Token: 0x0600803C RID: 32828 RVA: 0x000F5381 File Offset: 0x000F3581
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170028A8 RID: 10408
		// (get) Token: 0x0600803D RID: 32829 RVA: 0x000F538C File Offset: 0x000F358C
		// (set) Token: 0x0600803E RID: 32830 RVA: 0x000F53A8 File Offset: 0x000F35A8
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x0600803F RID: 32831 RVA: 0x000F53D8 File Offset: 0x000F35D8
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06008040 RID: 32832 RVA: 0x000F53F0 File Offset: 0x000F35F0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170028A9 RID: 10409
		// (get) Token: 0x06008041 RID: 32833 RVA: 0x000F53FC File Offset: 0x000F35FC
		// (set) Token: 0x06008042 RID: 32834 RVA: 0x000F5428 File Offset: 0x000F3628
		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x170028AA RID: 10410
		// (get) Token: 0x06008043 RID: 32835 RVA: 0x000F5438 File Offset: 0x000F3638
		// (set) Token: 0x06008044 RID: 32836 RVA: 0x000F5458 File Offset: 0x000F3658
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06008045 RID: 32837 RVA: 0x000F549C File Offset: 0x000F369C
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06008046 RID: 32838 RVA: 0x000F54B4 File Offset: 0x000F36B4
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170028AB RID: 10411
		// (get) Token: 0x06008047 RID: 32839 RVA: 0x000F54C0 File Offset: 0x000F36C0
		// (set) Token: 0x06008048 RID: 32840 RVA: 0x000F54EC File Offset: 0x000F36EC
		[ProtoMember(4, IsRequired = false, Name = "isnew", DataFormat = DataFormat.Default)]
		public bool isnew
		{
			get
			{
				return this._isnew ?? false;
			}
			set
			{
				this._isnew = new bool?(value);
			}
		}

		// Token: 0x170028AC RID: 10412
		// (get) Token: 0x06008049 RID: 32841 RVA: 0x000F54FC File Offset: 0x000F36FC
		// (set) Token: 0x0600804A RID: 32842 RVA: 0x000F551C File Offset: 0x000F371C
		[XmlIgnore]
		[Browsable(false)]
		public bool isnewSpecified
		{
			get
			{
				return this._isnew != null;
			}
			set
			{
				bool flag = value == (this._isnew == null);
				if (flag)
				{
					this._isnew = (value ? new bool?(this.isnew) : null);
				}
			}
		}

		// Token: 0x0600804B RID: 32843 RVA: 0x000F5560 File Offset: 0x000F3760
		private bool ShouldSerializeisnew()
		{
			return this.isnewSpecified;
		}

		// Token: 0x0600804C RID: 32844 RVA: 0x000F5578 File Offset: 0x000F3778
		private void Resetisnew()
		{
			this.isnewSpecified = false;
		}

		// Token: 0x170028AD RID: 10413
		// (get) Token: 0x0600804D RID: 32845 RVA: 0x000F5584 File Offset: 0x000F3784
		// (set) Token: 0x0600804E RID: 32846 RVA: 0x000F55B0 File Offset: 0x000F37B0
		[ProtoMember(5, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170028AE RID: 10414
		// (get) Token: 0x0600804F RID: 32847 RVA: 0x000F55C0 File Offset: 0x000F37C0
		// (set) Token: 0x06008050 RID: 32848 RVA: 0x000F55E0 File Offset: 0x000F37E0
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
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06008051 RID: 32849 RVA: 0x000F5624 File Offset: 0x000F3824
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06008052 RID: 32850 RVA: 0x000F563C File Offset: 0x000F383C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170028AF RID: 10415
		// (get) Token: 0x06008053 RID: 32851 RVA: 0x000F5648 File Offset: 0x000F3848
		// (set) Token: 0x06008054 RID: 32852 RVA: 0x000F5674 File Offset: 0x000F3874
		[ProtoMember(6, IsRequired = false, Name = "old_score", DataFormat = DataFormat.TwosComplement)]
		public uint old_score
		{
			get
			{
				return this._old_score ?? 0U;
			}
			set
			{
				this._old_score = new uint?(value);
			}
		}

		// Token: 0x170028B0 RID: 10416
		// (get) Token: 0x06008055 RID: 32853 RVA: 0x000F5684 File Offset: 0x000F3884
		// (set) Token: 0x06008056 RID: 32854 RVA: 0x000F56A4 File Offset: 0x000F38A4
		[XmlIgnore]
		[Browsable(false)]
		public bool old_scoreSpecified
		{
			get
			{
				return this._old_score != null;
			}
			set
			{
				bool flag = value == (this._old_score == null);
				if (flag)
				{
					this._old_score = (value ? new uint?(this.old_score) : null);
				}
			}
		}

		// Token: 0x06008057 RID: 32855 RVA: 0x000F56E8 File Offset: 0x000F38E8
		private bool ShouldSerializeold_score()
		{
			return this.old_scoreSpecified;
		}

		// Token: 0x06008058 RID: 32856 RVA: 0x000F5700 File Offset: 0x000F3900
		private void Resetold_score()
		{
			this.old_scoreSpecified = false;
		}

		// Token: 0x06008059 RID: 32857 RVA: 0x000F570C File Offset: 0x000F390C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E0D RID: 7693
		private ulong? _roleid;

		// Token: 0x04001E0E RID: 7694
		private string _name;

		// Token: 0x04001E0F RID: 7695
		private uint? _score;

		// Token: 0x04001E10 RID: 7696
		private bool? _isnew;

		// Token: 0x04001E11 RID: 7697
		private uint? _time;

		// Token: 0x04001E12 RID: 7698
		private uint? _old_score;

		// Token: 0x04001E13 RID: 7699
		private IExtension extensionObject;
	}
}
