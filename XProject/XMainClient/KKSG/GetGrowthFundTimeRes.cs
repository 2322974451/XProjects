using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D1 RID: 977
	[ProtoContract(Name = "GetGrowthFundTimeRes")]
	[Serializable]
	public class GetGrowthFundTimeRes : IExtensible
	{
		// Token: 0x17001004 RID: 4100
		// (get) Token: 0x06003406 RID: 13318 RVA: 0x00063D3C File Offset: 0x00061F3C
		// (set) Token: 0x06003407 RID: 13319 RVA: 0x00063D68 File Offset: 0x00061F68
		[ProtoMember(1, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17001005 RID: 4101
		// (get) Token: 0x06003408 RID: 13320 RVA: 0x00063D78 File Offset: 0x00061F78
		// (set) Token: 0x06003409 RID: 13321 RVA: 0x00063D98 File Offset: 0x00061F98
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x0600340A RID: 13322 RVA: 0x00063DDC File Offset: 0x00061FDC
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x0600340B RID: 13323 RVA: 0x00063DF4 File Offset: 0x00061FF4
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x17001006 RID: 4102
		// (get) Token: 0x0600340C RID: 13324 RVA: 0x00063E00 File Offset: 0x00062000
		// (set) Token: 0x0600340D RID: 13325 RVA: 0x00063E2C File Offset: 0x0006202C
		[ProtoMember(2, IsRequired = false, Name = "err", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode err
		{
			get
			{
				return this._err ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._err = new ErrorCode?(value);
			}
		}

		// Token: 0x17001007 RID: 4103
		// (get) Token: 0x0600340E RID: 13326 RVA: 0x00063E3C File Offset: 0x0006203C
		// (set) Token: 0x0600340F RID: 13327 RVA: 0x00063E5C File Offset: 0x0006205C
		[XmlIgnore]
		[Browsable(false)]
		public bool errSpecified
		{
			get
			{
				return this._err != null;
			}
			set
			{
				bool flag = value == (this._err == null);
				if (flag)
				{
					this._err = (value ? new ErrorCode?(this.err) : null);
				}
			}
		}

		// Token: 0x06003410 RID: 13328 RVA: 0x00063EA0 File Offset: 0x000620A0
		private bool ShouldSerializeerr()
		{
			return this.errSpecified;
		}

		// Token: 0x06003411 RID: 13329 RVA: 0x00063EB8 File Offset: 0x000620B8
		private void Reseterr()
		{
			this.errSpecified = false;
		}

		// Token: 0x06003412 RID: 13330 RVA: 0x00063EC4 File Offset: 0x000620C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CED RID: 3309
		private uint? _lefttime;

		// Token: 0x04000CEE RID: 3310
		private ErrorCode? _err;

		// Token: 0x04000CEF RID: 3311
		private IExtension extensionObject;
	}
}
