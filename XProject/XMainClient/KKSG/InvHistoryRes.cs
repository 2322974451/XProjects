using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000167 RID: 359
	[ProtoContract(Name = "InvHistoryRes")]
	[Serializable]
	public class InvHistoryRes : IExtensible
	{
		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060015A5 RID: 5541 RVA: 0x0002B754 File Offset: 0x00029954
		[ProtoMember(1, Name = "invUnfH", DataFormat = DataFormat.Default)]
		public List<TeamInvite> invUnfH
		{
			get
			{
				return this._invUnfH;
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060015A6 RID: 5542 RVA: 0x0002B76C File Offset: 0x0002996C
		// (set) Token: 0x060015A7 RID: 5543 RVA: 0x0002B798 File Offset: 0x00029998
		[ProtoMember(2, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060015A8 RID: 5544 RVA: 0x0002B7A8 File Offset: 0x000299A8
		// (set) Token: 0x060015A9 RID: 5545 RVA: 0x0002B7C8 File Offset: 0x000299C8
		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0002B80C File Offset: 0x00029A0C
		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x0002B824 File Offset: 0x00029A24
		private void Resetret()
		{
			this.retSpecified = false;
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x0002B830 File Offset: 0x00029A30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000563 RID: 1379
		private readonly List<TeamInvite> _invUnfH = new List<TeamInvite>();

		// Token: 0x04000564 RID: 1380
		private ErrorCode? _ret;

		// Token: 0x04000565 RID: 1381
		private IExtension extensionObject;
	}
}
