using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000421 RID: 1057
	[ProtoContract(Name = "SceneMobaOpRes")]
	[Serializable]
	public class SceneMobaOpRes : IExtensible
	{
		// Token: 0x17001137 RID: 4407
		// (get) Token: 0x06003810 RID: 14352 RVA: 0x0006B528 File Offset: 0x00069728
		// (set) Token: 0x06003811 RID: 14353 RVA: 0x0006B554 File Offset: 0x00069754
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

		// Token: 0x17001138 RID: 4408
		// (get) Token: 0x06003812 RID: 14354 RVA: 0x0006B564 File Offset: 0x00069764
		// (set) Token: 0x06003813 RID: 14355 RVA: 0x0006B584 File Offset: 0x00069784
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

		// Token: 0x06003814 RID: 14356 RVA: 0x0006B5C8 File Offset: 0x000697C8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003815 RID: 14357 RVA: 0x0006B5E0 File Offset: 0x000697E0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001139 RID: 4409
		// (get) Token: 0x06003816 RID: 14358 RVA: 0x0006B5EC File Offset: 0x000697EC
		// (set) Token: 0x06003817 RID: 14359 RVA: 0x0006B618 File Offset: 0x00069818
		[ProtoMember(2, IsRequired = false, Name = "nowparam", DataFormat = DataFormat.TwosComplement)]
		public uint nowparam
		{
			get
			{
				return this._nowparam ?? 0U;
			}
			set
			{
				this._nowparam = new uint?(value);
			}
		}

		// Token: 0x1700113A RID: 4410
		// (get) Token: 0x06003818 RID: 14360 RVA: 0x0006B628 File Offset: 0x00069828
		// (set) Token: 0x06003819 RID: 14361 RVA: 0x0006B648 File Offset: 0x00069848
		[XmlIgnore]
		[Browsable(false)]
		public bool nowparamSpecified
		{
			get
			{
				return this._nowparam != null;
			}
			set
			{
				bool flag = value == (this._nowparam == null);
				if (flag)
				{
					this._nowparam = (value ? new uint?(this.nowparam) : null);
				}
			}
		}

		// Token: 0x0600381A RID: 14362 RVA: 0x0006B68C File Offset: 0x0006988C
		private bool ShouldSerializenowparam()
		{
			return this.nowparamSpecified;
		}

		// Token: 0x0600381B RID: 14363 RVA: 0x0006B6A4 File Offset: 0x000698A4
		private void Resetnowparam()
		{
			this.nowparamSpecified = false;
		}

		// Token: 0x0600381C RID: 14364 RVA: 0x0006B6B0 File Offset: 0x000698B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DE4 RID: 3556
		private ErrorCode? _errorcode;

		// Token: 0x04000DE5 RID: 3557
		private uint? _nowparam;

		// Token: 0x04000DE6 RID: 3558
		private IExtension extensionObject;
	}
}
