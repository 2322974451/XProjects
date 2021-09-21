using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000626 RID: 1574
	[ProtoContract(Name = "PayconsumeBrief")]
	[Serializable]
	public class PayconsumeBrief : IExtensible
	{
		// Token: 0x17001E5C RID: 7772
		// (get) Token: 0x06006082 RID: 24706 RVA: 0x000B813C File Offset: 0x000B633C
		// (set) Token: 0x06006083 RID: 24707 RVA: 0x000B8168 File Offset: 0x000B6368
		[ProtoMember(1, IsRequired = false, Name = "ts", DataFormat = DataFormat.TwosComplement)]
		public uint ts
		{
			get
			{
				return this._ts ?? 0U;
			}
			set
			{
				this._ts = new uint?(value);
			}
		}

		// Token: 0x17001E5D RID: 7773
		// (get) Token: 0x06006084 RID: 24708 RVA: 0x000B8178 File Offset: 0x000B6378
		// (set) Token: 0x06006085 RID: 24709 RVA: 0x000B8198 File Offset: 0x000B6398
		[XmlIgnore]
		[Browsable(false)]
		public bool tsSpecified
		{
			get
			{
				return this._ts != null;
			}
			set
			{
				bool flag = value == (this._ts == null);
				if (flag)
				{
					this._ts = (value ? new uint?(this.ts) : null);
				}
			}
		}

		// Token: 0x06006086 RID: 24710 RVA: 0x000B81DC File Offset: 0x000B63DC
		private bool ShouldSerializets()
		{
			return this.tsSpecified;
		}

		// Token: 0x06006087 RID: 24711 RVA: 0x000B81F4 File Offset: 0x000B63F4
		private void Resetts()
		{
			this.tsSpecified = false;
		}

		// Token: 0x17001E5E RID: 7774
		// (get) Token: 0x06006088 RID: 24712 RVA: 0x000B8200 File Offset: 0x000B6400
		// (set) Token: 0x06006089 RID: 24713 RVA: 0x000B8221 File Offset: 0x000B6421
		[ProtoMember(2, IsRequired = false, Name = "billno", DataFormat = DataFormat.Default)]
		public string billno
		{
			get
			{
				return this._billno ?? "";
			}
			set
			{
				this._billno = value;
			}
		}

		// Token: 0x17001E5F RID: 7775
		// (get) Token: 0x0600608A RID: 24714 RVA: 0x000B822C File Offset: 0x000B642C
		// (set) Token: 0x0600608B RID: 24715 RVA: 0x000B8248 File Offset: 0x000B6448
		[XmlIgnore]
		[Browsable(false)]
		public bool billnoSpecified
		{
			get
			{
				return this._billno != null;
			}
			set
			{
				bool flag = value == (this._billno == null);
				if (flag)
				{
					this._billno = (value ? this.billno : null);
				}
			}
		}

		// Token: 0x0600608C RID: 24716 RVA: 0x000B8278 File Offset: 0x000B6478
		private bool ShouldSerializebillno()
		{
			return this.billnoSpecified;
		}

		// Token: 0x0600608D RID: 24717 RVA: 0x000B8290 File Offset: 0x000B6490
		private void Resetbillno()
		{
			this.billnoSpecified = false;
		}

		// Token: 0x0600608E RID: 24718 RVA: 0x000B829C File Offset: 0x000B649C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400176D RID: 5997
		private uint? _ts;

		// Token: 0x0400176E RID: 5998
		private string _billno;

		// Token: 0x0400176F RID: 5999
		private IExtension extensionObject;
	}
}
