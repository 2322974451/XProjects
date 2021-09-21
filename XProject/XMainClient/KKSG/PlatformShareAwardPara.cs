using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000417 RID: 1047
	[ProtoContract(Name = "PlatformShareAwardPara")]
	[Serializable]
	public class PlatformShareAwardPara : IExtensible
	{
		// Token: 0x17001118 RID: 4376
		// (get) Token: 0x060037A1 RID: 14241 RVA: 0x0006A840 File Offset: 0x00068A40
		// (set) Token: 0x060037A2 RID: 14242 RVA: 0x0006A86C File Offset: 0x00068A6C
		[ProtoMember(1, IsRequired = false, Name = "share_scene_id", DataFormat = DataFormat.TwosComplement)]
		public uint share_scene_id
		{
			get
			{
				return this._share_scene_id ?? 0U;
			}
			set
			{
				this._share_scene_id = new uint?(value);
			}
		}

		// Token: 0x17001119 RID: 4377
		// (get) Token: 0x060037A3 RID: 14243 RVA: 0x0006A87C File Offset: 0x00068A7C
		// (set) Token: 0x060037A4 RID: 14244 RVA: 0x0006A89C File Offset: 0x00068A9C
		[XmlIgnore]
		[Browsable(false)]
		public bool share_scene_idSpecified
		{
			get
			{
				return this._share_scene_id != null;
			}
			set
			{
				bool flag = value == (this._share_scene_id == null);
				if (flag)
				{
					this._share_scene_id = (value ? new uint?(this.share_scene_id) : null);
				}
			}
		}

		// Token: 0x060037A5 RID: 14245 RVA: 0x0006A8E0 File Offset: 0x00068AE0
		private bool ShouldSerializeshare_scene_id()
		{
			return this.share_scene_idSpecified;
		}

		// Token: 0x060037A6 RID: 14246 RVA: 0x0006A8F8 File Offset: 0x00068AF8
		private void Resetshare_scene_id()
		{
			this.share_scene_idSpecified = false;
		}

		// Token: 0x1700111A RID: 4378
		// (get) Token: 0x060037A7 RID: 14247 RVA: 0x0006A904 File Offset: 0x00068B04
		// (set) Token: 0x060037A8 RID: 14248 RVA: 0x0006A930 File Offset: 0x00068B30
		[ProtoMember(2, IsRequired = false, Name = "weekly_share_number", DataFormat = DataFormat.TwosComplement)]
		public uint weekly_share_number
		{
			get
			{
				return this._weekly_share_number ?? 0U;
			}
			set
			{
				this._weekly_share_number = new uint?(value);
			}
		}

		// Token: 0x1700111B RID: 4379
		// (get) Token: 0x060037A9 RID: 14249 RVA: 0x0006A940 File Offset: 0x00068B40
		// (set) Token: 0x060037AA RID: 14250 RVA: 0x0006A960 File Offset: 0x00068B60
		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_share_numberSpecified
		{
			get
			{
				return this._weekly_share_number != null;
			}
			set
			{
				bool flag = value == (this._weekly_share_number == null);
				if (flag)
				{
					this._weekly_share_number = (value ? new uint?(this.weekly_share_number) : null);
				}
			}
		}

		// Token: 0x060037AB RID: 14251 RVA: 0x0006A9A4 File Offset: 0x00068BA4
		private bool ShouldSerializeweekly_share_number()
		{
			return this.weekly_share_numberSpecified;
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x0006A9BC File Offset: 0x00068BBC
		private void Resetweekly_share_number()
		{
			this.weekly_share_numberSpecified = false;
		}

		// Token: 0x1700111C RID: 4380
		// (get) Token: 0x060037AD RID: 14253 RVA: 0x0006A9C8 File Offset: 0x00068BC8
		// (set) Token: 0x060037AE RID: 14254 RVA: 0x0006A9F4 File Offset: 0x00068BF4
		[ProtoMember(3, IsRequired = false, Name = "weekly_award", DataFormat = DataFormat.Default)]
		public bool weekly_award
		{
			get
			{
				return this._weekly_award ?? false;
			}
			set
			{
				this._weekly_award = new bool?(value);
			}
		}

		// Token: 0x1700111D RID: 4381
		// (get) Token: 0x060037AF RID: 14255 RVA: 0x0006AA04 File Offset: 0x00068C04
		// (set) Token: 0x060037B0 RID: 14256 RVA: 0x0006AA24 File Offset: 0x00068C24
		[XmlIgnore]
		[Browsable(false)]
		public bool weekly_awardSpecified
		{
			get
			{
				return this._weekly_award != null;
			}
			set
			{
				bool flag = value == (this._weekly_award == null);
				if (flag)
				{
					this._weekly_award = (value ? new bool?(this.weekly_award) : null);
				}
			}
		}

		// Token: 0x060037B1 RID: 14257 RVA: 0x0006AA68 File Offset: 0x00068C68
		private bool ShouldSerializeweekly_award()
		{
			return this.weekly_awardSpecified;
		}

		// Token: 0x060037B2 RID: 14258 RVA: 0x0006AA80 File Offset: 0x00068C80
		private void Resetweekly_award()
		{
			this.weekly_awardSpecified = false;
		}

		// Token: 0x1700111E RID: 4382
		// (get) Token: 0x060037B3 RID: 14259 RVA: 0x0006AA8C File Offset: 0x00068C8C
		// (set) Token: 0x060037B4 RID: 14260 RVA: 0x0006AAB8 File Offset: 0x00068CB8
		[ProtoMember(4, IsRequired = false, Name = "disappear_redpoint", DataFormat = DataFormat.Default)]
		public bool disappear_redpoint
		{
			get
			{
				return this._disappear_redpoint ?? false;
			}
			set
			{
				this._disappear_redpoint = new bool?(value);
			}
		}

		// Token: 0x1700111F RID: 4383
		// (get) Token: 0x060037B5 RID: 14261 RVA: 0x0006AAC8 File Offset: 0x00068CC8
		// (set) Token: 0x060037B6 RID: 14262 RVA: 0x0006AAE8 File Offset: 0x00068CE8
		[XmlIgnore]
		[Browsable(false)]
		public bool disappear_redpointSpecified
		{
			get
			{
				return this._disappear_redpoint != null;
			}
			set
			{
				bool flag = value == (this._disappear_redpoint == null);
				if (flag)
				{
					this._disappear_redpoint = (value ? new bool?(this.disappear_redpoint) : null);
				}
			}
		}

		// Token: 0x060037B7 RID: 14263 RVA: 0x0006AB2C File Offset: 0x00068D2C
		private bool ShouldSerializedisappear_redpoint()
		{
			return this.disappear_redpointSpecified;
		}

		// Token: 0x060037B8 RID: 14264 RVA: 0x0006AB44 File Offset: 0x00068D44
		private void Resetdisappear_redpoint()
		{
			this.disappear_redpointSpecified = false;
		}

		// Token: 0x060037B9 RID: 14265 RVA: 0x0006AB50 File Offset: 0x00068D50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DCA RID: 3530
		private uint? _share_scene_id;

		// Token: 0x04000DCB RID: 3531
		private uint? _weekly_share_number;

		// Token: 0x04000DCC RID: 3532
		private bool? _weekly_award;

		// Token: 0x04000DCD RID: 3533
		private bool? _disappear_redpoint;

		// Token: 0x04000DCE RID: 3534
		private IExtension extensionObject;
	}
}
