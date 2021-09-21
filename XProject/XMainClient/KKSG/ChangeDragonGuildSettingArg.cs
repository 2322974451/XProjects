using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B0 RID: 1200
	[ProtoContract(Name = "ChangeDragonGuildSettingArg")]
	[Serializable]
	public class ChangeDragonGuildSettingArg : IExtensible
	{
		// Token: 0x1700132D RID: 4909
		// (get) Token: 0x06003E90 RID: 16016 RVA: 0x00077590 File Offset: 0x00075790
		// (set) Token: 0x06003E91 RID: 16017 RVA: 0x000775BC File Offset: 0x000757BC
		[ProtoMember(1, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		// Token: 0x1700132E RID: 4910
		// (get) Token: 0x06003E92 RID: 16018 RVA: 0x000775CC File Offset: 0x000757CC
		// (set) Token: 0x06003E93 RID: 16019 RVA: 0x000775EC File Offset: 0x000757EC
		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		// Token: 0x06003E94 RID: 16020 RVA: 0x00077630 File Offset: 0x00075830
		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		// Token: 0x06003E95 RID: 16021 RVA: 0x00077648 File Offset: 0x00075848
		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		// Token: 0x1700132F RID: 4911
		// (get) Token: 0x06003E96 RID: 16022 RVA: 0x00077654 File Offset: 0x00075854
		// (set) Token: 0x06003E97 RID: 16023 RVA: 0x00077680 File Offset: 0x00075880
		[ProtoMember(2, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.TwosComplement)]
		public uint needapproval
		{
			get
			{
				return this._needapproval ?? 0U;
			}
			set
			{
				this._needapproval = new uint?(value);
			}
		}

		// Token: 0x17001330 RID: 4912
		// (get) Token: 0x06003E98 RID: 16024 RVA: 0x00077690 File Offset: 0x00075890
		// (set) Token: 0x06003E99 RID: 16025 RVA: 0x000776B0 File Offset: 0x000758B0
		[XmlIgnore]
		[Browsable(false)]
		public bool needapprovalSpecified
		{
			get
			{
				return this._needapproval != null;
			}
			set
			{
				bool flag = value == (this._needapproval == null);
				if (flag)
				{
					this._needapproval = (value ? new uint?(this.needapproval) : null);
				}
			}
		}

		// Token: 0x06003E9A RID: 16026 RVA: 0x000776F4 File Offset: 0x000758F4
		private bool ShouldSerializeneedapproval()
		{
			return this.needapprovalSpecified;
		}

		// Token: 0x06003E9B RID: 16027 RVA: 0x0007770C File Offset: 0x0007590C
		private void Resetneedapproval()
		{
			this.needapprovalSpecified = false;
		}

		// Token: 0x17001331 RID: 4913
		// (get) Token: 0x06003E9C RID: 16028 RVA: 0x00077718 File Offset: 0x00075918
		// (set) Token: 0x06003E9D RID: 16029 RVA: 0x00077739 File Offset: 0x00075939
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

		// Token: 0x17001332 RID: 4914
		// (get) Token: 0x06003E9E RID: 16030 RVA: 0x00077744 File Offset: 0x00075944
		// (set) Token: 0x06003E9F RID: 16031 RVA: 0x00077760 File Offset: 0x00075960
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

		// Token: 0x06003EA0 RID: 16032 RVA: 0x00077790 File Offset: 0x00075990
		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		// Token: 0x06003EA1 RID: 16033 RVA: 0x000777A8 File Offset: 0x000759A8
		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		// Token: 0x06003EA2 RID: 16034 RVA: 0x000777B4 File Offset: 0x000759B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F93 RID: 3987
		private uint? _powerpoint;

		// Token: 0x04000F94 RID: 3988
		private uint? _needapproval;

		// Token: 0x04000F95 RID: 3989
		private string _annoucement;

		// Token: 0x04000F96 RID: 3990
		private IExtension extensionObject;
	}
}
