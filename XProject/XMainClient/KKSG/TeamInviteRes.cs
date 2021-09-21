using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000164 RID: 356
	[ProtoContract(Name = "TeamInviteRes")]
	[Serializable]
	public class TeamInviteRes : IExtensible
	{
		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x0600158A RID: 5514 RVA: 0x0002B474 File Offset: 0x00029674
		[ProtoMember(1, Name = "friend", DataFormat = DataFormat.Default)]
		public List<TeamInvRoleInfo> friend
		{
			get
			{
				return this._friend;
			}
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x0600158B RID: 5515 RVA: 0x0002B48C File Offset: 0x0002968C
		[ProtoMember(2, Name = "guild", DataFormat = DataFormat.Default)]
		public List<TeamInvRoleInfo> guild
		{
			get
			{
				return this._guild;
			}
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x0600158C RID: 5516 RVA: 0x0002B4A4 File Offset: 0x000296A4
		[ProtoMember(3, Name = "rec", DataFormat = DataFormat.Default)]
		public List<TeamInvRoleInfo> rec
		{
			get
			{
				return this._rec;
			}
		}

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x0600158D RID: 5517 RVA: 0x0002B4BC File Offset: 0x000296BC
		// (set) Token: 0x0600158E RID: 5518 RVA: 0x0002B4E8 File Offset: 0x000296E8
		[ProtoMember(4, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x0600158F RID: 5519 RVA: 0x0002B4F8 File Offset: 0x000296F8
		// (set) Token: 0x06001590 RID: 5520 RVA: 0x0002B518 File Offset: 0x00029718
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001591 RID: 5521 RVA: 0x0002B55C File Offset: 0x0002975C
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001592 RID: 5522 RVA: 0x0002B574 File Offset: 0x00029774
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06001593 RID: 5523 RVA: 0x0002B580 File Offset: 0x00029780
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400055A RID: 1370
		private readonly List<TeamInvRoleInfo> _friend = new List<TeamInvRoleInfo>();

		// Token: 0x0400055B RID: 1371
		private readonly List<TeamInvRoleInfo> _guild = new List<TeamInvRoleInfo>();

		// Token: 0x0400055C RID: 1372
		private readonly List<TeamInvRoleInfo> _rec = new List<TeamInvRoleInfo>();

		// Token: 0x0400055D RID: 1373
		private ErrorCode? _errcode;

		// Token: 0x0400055E RID: 1374
		private IExtension extensionObject;
	}
}
