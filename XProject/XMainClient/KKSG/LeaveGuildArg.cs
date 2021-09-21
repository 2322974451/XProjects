using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000090 RID: 144
	[ProtoContract(Name = "LeaveGuildArg")]
	[Serializable]
	public class LeaveGuildArg : IExtensible
	{
		// Token: 0x17000310 RID: 784
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x000144B8 File Offset: 0x000126B8
		// (set) Token: 0x0600094B RID: 2379 RVA: 0x000144E5 File Offset: 0x000126E5
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x000144F4 File Offset: 0x000126F4
		// (set) Token: 0x0600094D RID: 2381 RVA: 0x00014514 File Offset: 0x00012714
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00014558 File Offset: 0x00012758
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00014570 File Offset: 0x00012770
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0001457C File Offset: 0x0001277C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400026C RID: 620
		private ulong? _roleID;

		// Token: 0x0400026D RID: 621
		private IExtension extensionObject;
	}
}
