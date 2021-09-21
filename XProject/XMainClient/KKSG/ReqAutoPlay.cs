using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000117 RID: 279
	[ProtoContract(Name = "ReqAutoPlay")]
	[Serializable]
	public class ReqAutoPlay : IExtensible
	{
		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x0600117F RID: 4479 RVA: 0x00023B08 File Offset: 0x00021D08
		// (set) Token: 0x06001180 RID: 4480 RVA: 0x00023B34 File Offset: 0x00021D34
		[ProtoMember(1, IsRequired = false, Name = "isautoplay", DataFormat = DataFormat.Default)]
		public bool isautoplay
		{
			get
			{
				return this._isautoplay ?? false;
			}
			set
			{
				this._isautoplay = new bool?(value);
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06001181 RID: 4481 RVA: 0x00023B44 File Offset: 0x00021D44
		// (set) Token: 0x06001182 RID: 4482 RVA: 0x00023B64 File Offset: 0x00021D64
		[XmlIgnore]
		[Browsable(false)]
		public bool isautoplaySpecified
		{
			get
			{
				return this._isautoplay != null;
			}
			set
			{
				bool flag = value == (this._isautoplay == null);
				if (flag)
				{
					this._isautoplay = (value ? new bool?(this.isautoplay) : null);
				}
			}
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x00023BA8 File Offset: 0x00021DA8
		private bool ShouldSerializeisautoplay()
		{
			return this.isautoplaySpecified;
		}

		// Token: 0x06001184 RID: 4484 RVA: 0x00023BC0 File Offset: 0x00021DC0
		private void Resetisautoplay()
		{
			this.isautoplaySpecified = false;
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x00023BCC File Offset: 0x00021DCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000461 RID: 1121
		private bool? _isautoplay;

		// Token: 0x04000462 RID: 1122
		private IExtension extensionObject;
	}
}
