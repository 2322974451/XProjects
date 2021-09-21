using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000118 RID: 280
	[ProtoContract(Name = "RetAutoPlay")]
	[Serializable]
	public class RetAutoPlay : IExtensible
	{
		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06001187 RID: 4487 RVA: 0x00023BEC File Offset: 0x00021DEC
		// (set) Token: 0x06001188 RID: 4488 RVA: 0x00023C18 File Offset: 0x00021E18
		[ProtoMember(1, IsRequired = false, Name = "succ", DataFormat = DataFormat.Default)]
		public bool succ
		{
			get
			{
				return this._succ ?? false;
			}
			set
			{
				this._succ = new bool?(value);
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06001189 RID: 4489 RVA: 0x00023C28 File Offset: 0x00021E28
		// (set) Token: 0x0600118A RID: 4490 RVA: 0x00023C48 File Offset: 0x00021E48
		[XmlIgnore]
		[Browsable(false)]
		public bool succSpecified
		{
			get
			{
				return this._succ != null;
			}
			set
			{
				bool flag = value == (this._succ == null);
				if (flag)
				{
					this._succ = (value ? new bool?(this.succ) : null);
				}
			}
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x00023C8C File Offset: 0x00021E8C
		private bool ShouldSerializesucc()
		{
			return this.succSpecified;
		}

		// Token: 0x0600118C RID: 4492 RVA: 0x00023CA4 File Offset: 0x00021EA4
		private void Resetsucc()
		{
			this.succSpecified = false;
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x00023CB0 File Offset: 0x00021EB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000463 RID: 1123
		private bool? _succ;

		// Token: 0x04000464 RID: 1124
		private IExtension extensionObject;
	}
}
