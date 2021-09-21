using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000288 RID: 648
	[ProtoContract(Name = "PayNotifyRes")]
	[Serializable]
	public class PayNotifyRes : IExtensible
	{
		// Token: 0x17000B4B RID: 2891
		// (get) Token: 0x06002453 RID: 9299 RVA: 0x00046DE8 File Offset: 0x00044FE8
		// (set) Token: 0x06002454 RID: 9300 RVA: 0x00046E14 File Offset: 0x00045014
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000B4C RID: 2892
		// (get) Token: 0x06002455 RID: 9301 RVA: 0x00046E24 File Offset: 0x00045024
		// (set) Token: 0x06002456 RID: 9302 RVA: 0x00046E44 File Offset: 0x00045044
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x00046E88 File Offset: 0x00045088
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x00046EA0 File Offset: 0x000450A0
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x17000B4D RID: 2893
		// (get) Token: 0x06002459 RID: 9305 RVA: 0x00046EAC File Offset: 0x000450AC
		// (set) Token: 0x0600245A RID: 9306 RVA: 0x00046ECD File Offset: 0x000450CD
		[ProtoMember(2, IsRequired = false, Name = "result", DataFormat = DataFormat.Default)]
		public string result
		{
			get
			{
				return this._result ?? "";
			}
			set
			{
				this._result = value;
			}
		}

		// Token: 0x17000B4E RID: 2894
		// (get) Token: 0x0600245B RID: 9307 RVA: 0x00046ED8 File Offset: 0x000450D8
		// (set) Token: 0x0600245C RID: 9308 RVA: 0x00046EF4 File Offset: 0x000450F4
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? this.result : null);
				}
			}
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x00046F24 File Offset: 0x00045124
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x00046F3C File Offset: 0x0004513C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x00046F48 File Offset: 0x00045148
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008FA RID: 2298
		private ErrorCode? _errcode;

		// Token: 0x040008FB RID: 2299
		private string _result;

		// Token: 0x040008FC RID: 2300
		private IExtension extensionObject;
	}
}
