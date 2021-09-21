using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000131 RID: 305
	[ProtoContract(Name = "AskForCheckInBonusRes")]
	[Serializable]
	public class AskForCheckInBonusRes : IExtensible
	{
		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x060012C4 RID: 4804 RVA: 0x000260CC File Offset: 0x000242CC
		// (set) Token: 0x060012C5 RID: 4805 RVA: 0x000260F8 File Offset: 0x000242F8
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

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x060012C6 RID: 4806 RVA: 0x00026108 File Offset: 0x00024308
		// (set) Token: 0x060012C7 RID: 4807 RVA: 0x00026128 File Offset: 0x00024328
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

		// Token: 0x060012C8 RID: 4808 RVA: 0x0002616C File Offset: 0x0002436C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x00026184 File Offset: 0x00024384
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x00026190 File Offset: 0x00024390
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004AF RID: 1199
		private ErrorCode? _errorcode;

		// Token: 0x040004B0 RID: 1200
		private IExtension extensionObject;
	}
}
