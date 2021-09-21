using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000499 RID: 1177
	[ProtoContract(Name = "ArtifactDeityStoveOpRes")]
	[Serializable]
	public class ArtifactDeityStoveOpRes : IExtensible
	{
		// Token: 0x170012CF RID: 4815
		// (get) Token: 0x06003D5C RID: 15708 RVA: 0x00075214 File Offset: 0x00073414
		// (set) Token: 0x06003D5D RID: 15709 RVA: 0x00075240 File Offset: 0x00073440
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170012D0 RID: 4816
		// (get) Token: 0x06003D5E RID: 15710 RVA: 0x00075250 File Offset: 0x00073450
		// (set) Token: 0x06003D5F RID: 15711 RVA: 0x00075270 File Offset: 0x00073470
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06003D60 RID: 15712 RVA: 0x000752B4 File Offset: 0x000734B4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003D61 RID: 15713 RVA: 0x000752CC File Offset: 0x000734CC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003D62 RID: 15714 RVA: 0x000752D8 File Offset: 0x000734D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F47 RID: 3911
		private ErrorCode? _errorcode;

		// Token: 0x04000F48 RID: 3912
		private IExtension extensionObject;
	}
}
