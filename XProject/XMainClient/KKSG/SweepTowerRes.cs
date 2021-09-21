using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000196 RID: 406
	[ProtoContract(Name = "SweepTowerRes")]
	[Serializable]
	public class SweepTowerRes : IExtensible
	{
		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x0600186C RID: 6252 RVA: 0x00030A90 File Offset: 0x0002EC90
		// (set) Token: 0x0600186D RID: 6253 RVA: 0x00030ABC File Offset: 0x0002ECBC
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x0600186E RID: 6254 RVA: 0x00030ACC File Offset: 0x0002ECCC
		// (set) Token: 0x0600186F RID: 6255 RVA: 0x00030AEC File Offset: 0x0002ECEC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x00030B30 File Offset: 0x0002ED30
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x00030B48 File Offset: 0x0002ED48
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x06001872 RID: 6258 RVA: 0x00030B54 File Offset: 0x0002ED54
		// (set) Token: 0x06001873 RID: 6259 RVA: 0x00030B80 File Offset: 0x0002ED80
		[ProtoMember(2, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06001874 RID: 6260 RVA: 0x00030B90 File Offset: 0x0002ED90
		// (set) Token: 0x06001875 RID: 6261 RVA: 0x00030BB0 File Offset: 0x0002EDB0
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x00030BF4 File Offset: 0x0002EDF4
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x00030C0C File Offset: 0x0002EE0C
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x00030C18 File Offset: 0x0002EE18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000609 RID: 1545
		private ErrorCode? _error;

		// Token: 0x0400060A RID: 1546
		private int? _leftTime;

		// Token: 0x0400060B RID: 1547
		private IExtension extensionObject;
	}
}
