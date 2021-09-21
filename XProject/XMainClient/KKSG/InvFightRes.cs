using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000326 RID: 806
	[ProtoContract(Name = "InvFightRes")]
	[Serializable]
	public class InvFightRes : IExtensible
	{
		// Token: 0x17000DC7 RID: 3527
		// (get) Token: 0x06002C71 RID: 11377 RVA: 0x0005614C File Offset: 0x0005434C
		// (set) Token: 0x06002C72 RID: 11378 RVA: 0x00056178 File Offset: 0x00054378
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

		// Token: 0x17000DC8 RID: 3528
		// (get) Token: 0x06002C73 RID: 11379 RVA: 0x00056188 File Offset: 0x00054388
		// (set) Token: 0x06002C74 RID: 11380 RVA: 0x000561A8 File Offset: 0x000543A8
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

		// Token: 0x06002C75 RID: 11381 RVA: 0x000561EC File Offset: 0x000543EC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002C76 RID: 11382 RVA: 0x00056204 File Offset: 0x00054404
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000DC9 RID: 3529
		// (get) Token: 0x06002C77 RID: 11383 RVA: 0x00056210 File Offset: 0x00054410
		[ProtoMember(2, Name = "roles", DataFormat = DataFormat.Default)]
		public List<InvFightRoleBrief> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x17000DCA RID: 3530
		// (get) Token: 0x06002C78 RID: 11384 RVA: 0x00056228 File Offset: 0x00054428
		// (set) Token: 0x06002C79 RID: 11385 RVA: 0x00056254 File Offset: 0x00054454
		[ProtoMember(3, IsRequired = false, Name = "isPlatFriendOnline", DataFormat = DataFormat.Default)]
		public bool isPlatFriendOnline
		{
			get
			{
				return this._isPlatFriendOnline ?? false;
			}
			set
			{
				this._isPlatFriendOnline = new bool?(value);
			}
		}

		// Token: 0x17000DCB RID: 3531
		// (get) Token: 0x06002C7A RID: 11386 RVA: 0x00056264 File Offset: 0x00054464
		// (set) Token: 0x06002C7B RID: 11387 RVA: 0x00056284 File Offset: 0x00054484
		[XmlIgnore]
		[Browsable(false)]
		public bool isPlatFriendOnlineSpecified
		{
			get
			{
				return this._isPlatFriendOnline != null;
			}
			set
			{
				bool flag = value == (this._isPlatFriendOnline == null);
				if (flag)
				{
					this._isPlatFriendOnline = (value ? new bool?(this.isPlatFriendOnline) : null);
				}
			}
		}

		// Token: 0x06002C7C RID: 11388 RVA: 0x000562C8 File Offset: 0x000544C8
		private bool ShouldSerializeisPlatFriendOnline()
		{
			return this.isPlatFriendOnlineSpecified;
		}

		// Token: 0x06002C7D RID: 11389 RVA: 0x000562E0 File Offset: 0x000544E0
		private void ResetisPlatFriendOnline()
		{
			this.isPlatFriendOnlineSpecified = false;
		}

		// Token: 0x06002C7E RID: 11390 RVA: 0x000562EC File Offset: 0x000544EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AFF RID: 2815
		private ErrorCode? _errorcode;

		// Token: 0x04000B00 RID: 2816
		private readonly List<InvFightRoleBrief> _roles = new List<InvFightRoleBrief>();

		// Token: 0x04000B01 RID: 2817
		private bool? _isPlatFriendOnline;

		// Token: 0x04000B02 RID: 2818
		private IExtension extensionObject;
	}
}
