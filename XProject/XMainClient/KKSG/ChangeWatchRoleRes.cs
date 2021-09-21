using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000180 RID: 384
	[ProtoContract(Name = "ChangeWatchRoleRes")]
	[Serializable]
	public class ChangeWatchRoleRes : IExtensible
	{
		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x0600173C RID: 5948 RVA: 0x0002E75C File Offset: 0x0002C95C
		// (set) Token: 0x0600173D RID: 5949 RVA: 0x0002E788 File Offset: 0x0002C988
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

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x0600173E RID: 5950 RVA: 0x0002E798 File Offset: 0x0002C998
		// (set) Token: 0x0600173F RID: 5951 RVA: 0x0002E7B8 File Offset: 0x0002C9B8
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

		// Token: 0x06001740 RID: 5952 RVA: 0x0002E7FC File Offset: 0x0002C9FC
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x0002E814 File Offset: 0x0002CA14
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001742 RID: 5954 RVA: 0x0002E820 File Offset: 0x0002CA20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005BF RID: 1471
		private ErrorCode? _error;

		// Token: 0x040005C0 RID: 1472
		private IExtension extensionObject;
	}
}
