using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B2 RID: 1202
	[ProtoContract(Name = "DragonGuildSettingChanged")]
	[Serializable]
	public class DragonGuildSettingChanged : IExtensible
	{
		// Token: 0x17001335 RID: 4917
		// (get) Token: 0x06003EAC RID: 16044 RVA: 0x000778B8 File Offset: 0x00075AB8
		// (set) Token: 0x06003EAD RID: 16045 RVA: 0x000778E4 File Offset: 0x00075AE4
		[ProtoMember(1, IsRequired = false, Name = "recuitPPT", DataFormat = DataFormat.TwosComplement)]
		public uint recuitPPT
		{
			get
			{
				return this._recuitPPT ?? 0U;
			}
			set
			{
				this._recuitPPT = new uint?(value);
			}
		}

		// Token: 0x17001336 RID: 4918
		// (get) Token: 0x06003EAE RID: 16046 RVA: 0x000778F4 File Offset: 0x00075AF4
		// (set) Token: 0x06003EAF RID: 16047 RVA: 0x00077914 File Offset: 0x00075B14
		[XmlIgnore]
		[Browsable(false)]
		public bool recuitPPTSpecified
		{
			get
			{
				return this._recuitPPT != null;
			}
			set
			{
				bool flag = value == (this._recuitPPT == null);
				if (flag)
				{
					this._recuitPPT = (value ? new uint?(this.recuitPPT) : null);
				}
			}
		}

		// Token: 0x06003EB0 RID: 16048 RVA: 0x00077958 File Offset: 0x00075B58
		private bool ShouldSerializerecuitPPT()
		{
			return this.recuitPPTSpecified;
		}

		// Token: 0x06003EB1 RID: 16049 RVA: 0x00077970 File Offset: 0x00075B70
		private void ResetrecuitPPT()
		{
			this.recuitPPTSpecified = false;
		}

		// Token: 0x17001337 RID: 4919
		// (get) Token: 0x06003EB2 RID: 16050 RVA: 0x0007797C File Offset: 0x00075B7C
		// (set) Token: 0x06003EB3 RID: 16051 RVA: 0x000779A8 File Offset: 0x00075BA8
		[ProtoMember(2, IsRequired = false, Name = "needApproval", DataFormat = DataFormat.TwosComplement)]
		public uint needApproval
		{
			get
			{
				return this._needApproval ?? 0U;
			}
			set
			{
				this._needApproval = new uint?(value);
			}
		}

		// Token: 0x17001338 RID: 4920
		// (get) Token: 0x06003EB4 RID: 16052 RVA: 0x000779B8 File Offset: 0x00075BB8
		// (set) Token: 0x06003EB5 RID: 16053 RVA: 0x000779D8 File Offset: 0x00075BD8
		[XmlIgnore]
		[Browsable(false)]
		public bool needApprovalSpecified
		{
			get
			{
				return this._needApproval != null;
			}
			set
			{
				bool flag = value == (this._needApproval == null);
				if (flag)
				{
					this._needApproval = (value ? new uint?(this.needApproval) : null);
				}
			}
		}

		// Token: 0x06003EB6 RID: 16054 RVA: 0x00077A1C File Offset: 0x00075C1C
		private bool ShouldSerializeneedApproval()
		{
			return this.needApprovalSpecified;
		}

		// Token: 0x06003EB7 RID: 16055 RVA: 0x00077A34 File Offset: 0x00075C34
		private void ResetneedApproval()
		{
			this.needApprovalSpecified = false;
		}

		// Token: 0x17001339 RID: 4921
		// (get) Token: 0x06003EB8 RID: 16056 RVA: 0x00077A40 File Offset: 0x00075C40
		// (set) Token: 0x06003EB9 RID: 16057 RVA: 0x00077A61 File Offset: 0x00075C61
		[ProtoMember(3, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
		public string annoucement
		{
			get
			{
				return this._annoucement ?? "";
			}
			set
			{
				this._annoucement = value;
			}
		}

		// Token: 0x1700133A RID: 4922
		// (get) Token: 0x06003EBA RID: 16058 RVA: 0x00077A6C File Offset: 0x00075C6C
		// (set) Token: 0x06003EBB RID: 16059 RVA: 0x00077A88 File Offset: 0x00075C88
		[XmlIgnore]
		[Browsable(false)]
		public bool annoucementSpecified
		{
			get
			{
				return this._annoucement != null;
			}
			set
			{
				bool flag = value == (this._annoucement == null);
				if (flag)
				{
					this._annoucement = (value ? this.annoucement : null);
				}
			}
		}

		// Token: 0x06003EBC RID: 16060 RVA: 0x00077AB8 File Offset: 0x00075CB8
		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		// Token: 0x06003EBD RID: 16061 RVA: 0x00077AD0 File Offset: 0x00075CD0
		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		// Token: 0x06003EBE RID: 16062 RVA: 0x00077ADC File Offset: 0x00075CDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F99 RID: 3993
		private uint? _recuitPPT;

		// Token: 0x04000F9A RID: 3994
		private uint? _needApproval;

		// Token: 0x04000F9B RID: 3995
		private string _annoucement;

		// Token: 0x04000F9C RID: 3996
		private IExtension extensionObject;
	}
}
