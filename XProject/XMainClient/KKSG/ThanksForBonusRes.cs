using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000133 RID: 307
	[ProtoContract(Name = "ThanksForBonusRes")]
	[Serializable]
	public class ThanksForBonusRes : IExtensible
	{
		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x060012D4 RID: 4820 RVA: 0x00026294 File Offset: 0x00024494
		// (set) Token: 0x060012D5 RID: 4821 RVA: 0x000262C0 File Offset: 0x000244C0
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

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x060012D6 RID: 4822 RVA: 0x000262D0 File Offset: 0x000244D0
		// (set) Token: 0x060012D7 RID: 4823 RVA: 0x000262F0 File Offset: 0x000244F0
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

		// Token: 0x060012D8 RID: 4824 RVA: 0x00026334 File Offset: 0x00024534
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x0002634C File Offset: 0x0002454C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x00026358 File Offset: 0x00024558
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004B3 RID: 1203
		private ErrorCode? _errorcode;

		// Token: 0x040004B4 RID: 1204
		private IExtension extensionObject;
	}
}
