using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000554 RID: 1364
	[ProtoContract(Name = "GetJadeSealAllInfoRes")]
	[Serializable]
	public class GetJadeSealAllInfoRes : IExtensible
	{
		// Token: 0x1700154B RID: 5451
		// (get) Token: 0x060045B8 RID: 17848 RVA: 0x000847E8 File Offset: 0x000829E8
		// (set) Token: 0x060045B9 RID: 17849 RVA: 0x00084814 File Offset: 0x00082A14
		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700154C RID: 5452
		// (get) Token: 0x060045BA RID: 17850 RVA: 0x00084824 File Offset: 0x00082A24
		// (set) Token: 0x060045BB RID: 17851 RVA: 0x00084844 File Offset: 0x00082A44
		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		// Token: 0x060045BC RID: 17852 RVA: 0x00084888 File Offset: 0x00082A88
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x060045BD RID: 17853 RVA: 0x000848A0 File Offset: 0x00082AA0
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x1700154D RID: 5453
		// (get) Token: 0x060045BE RID: 17854 RVA: 0x000848AC File Offset: 0x00082AAC
		[ProtoMember(2, Name = "jadeSealInfo", DataFormat = DataFormat.Default)]
		public List<JadeSealInfo> jadeSealInfo
		{
			get
			{
				return this._jadeSealInfo;
			}
		}

		// Token: 0x060045BF RID: 17855 RVA: 0x000848C4 File Offset: 0x00082AC4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001168 RID: 4456
		private ErrorCode? _errorCode;

		// Token: 0x04001169 RID: 4457
		private readonly List<JadeSealInfo> _jadeSealInfo = new List<JadeSealInfo>();

		// Token: 0x0400116A RID: 4458
		private IExtension extensionObject;
	}
}
