using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000171 RID: 369
	[ProtoContract(Name = "CreateRoleNewRes")]
	[Serializable]
	public class CreateRoleNewRes : IExtensible
	{
		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001626 RID: 5670 RVA: 0x0002C634 File Offset: 0x0002A834
		// (set) Token: 0x06001627 RID: 5671 RVA: 0x0002C660 File Offset: 0x0002A860
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001628 RID: 5672 RVA: 0x0002C670 File Offset: 0x0002A870
		// (set) Token: 0x06001629 RID: 5673 RVA: 0x0002C690 File Offset: 0x0002A890
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
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x0600162A RID: 5674 RVA: 0x0002C6D4 File Offset: 0x0002A8D4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600162B RID: 5675 RVA: 0x0002C6EC File Offset: 0x0002A8EC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x0002C6F8 File Offset: 0x0002A8F8
		// (set) Token: 0x0600162D RID: 5677 RVA: 0x0002C710 File Offset: 0x0002A910
		[ProtoMember(2, IsRequired = false, Name = "roleData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleAllInfo roleData
		{
			get
			{
				return this._roleData;
			}
			set
			{
				this._roleData = value;
			}
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x0002C71C File Offset: 0x0002A91C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000580 RID: 1408
		private ErrorCode? _result;

		// Token: 0x04000581 RID: 1409
		private RoleAllInfo _roleData = null;

		// Token: 0x04000582 RID: 1410
		private IExtension extensionObject;
	}
}
