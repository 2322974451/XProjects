using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000298 RID: 664
	[ProtoContract(Name = "ResWarExploreRes")]
	[Serializable]
	public class ResWarExploreRes : IExtensible
	{
		// Token: 0x17000B86 RID: 2950
		// (get) Token: 0x06002518 RID: 9496 RVA: 0x000484AC File Offset: 0x000466AC
		// (set) Token: 0x06002519 RID: 9497 RVA: 0x000484D8 File Offset: 0x000466D8
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

		// Token: 0x17000B87 RID: 2951
		// (get) Token: 0x0600251A RID: 9498 RVA: 0x000484E8 File Offset: 0x000466E8
		// (set) Token: 0x0600251B RID: 9499 RVA: 0x00048508 File Offset: 0x00046708
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

		// Token: 0x0600251C RID: 9500 RVA: 0x0004854C File Offset: 0x0004674C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x00048564 File Offset: 0x00046764
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x00048570 File Offset: 0x00046770
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400092B RID: 2347
		private ErrorCode? _error;

		// Token: 0x0400092C RID: 2348
		private IExtension extensionObject;
	}
}
