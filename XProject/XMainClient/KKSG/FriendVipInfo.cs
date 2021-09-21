using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D2 RID: 1746
	[ProtoContract(Name = "FriendVipInfo")]
	[Serializable]
	public class FriendVipInfo : IExtensible
	{
		// Token: 0x170024B5 RID: 9397
		// (get) Token: 0x060073F4 RID: 29684 RVA: 0x000DDDDC File Offset: 0x000DBFDC
		// (set) Token: 0x060073F5 RID: 29685 RVA: 0x000DDDFD File Offset: 0x000DBFFD
		[ProtoMember(1, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		// Token: 0x170024B6 RID: 9398
		// (get) Token: 0x060073F6 RID: 29686 RVA: 0x000DDE08 File Offset: 0x000DC008
		// (set) Token: 0x060073F7 RID: 29687 RVA: 0x000DDE24 File Offset: 0x000DC024
		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		// Token: 0x060073F8 RID: 29688 RVA: 0x000DDE54 File Offset: 0x000DC054
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x060073F9 RID: 29689 RVA: 0x000DDE6C File Offset: 0x000DC06C
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x170024B7 RID: 9399
		// (get) Token: 0x060073FA RID: 29690 RVA: 0x000DDE78 File Offset: 0x000DC078
		// (set) Token: 0x060073FB RID: 29691 RVA: 0x000DDEA4 File Offset: 0x000DC0A4
		[ProtoMember(2, IsRequired = false, Name = "is_vip", DataFormat = DataFormat.Default)]
		public bool is_vip
		{
			get
			{
				return this._is_vip ?? false;
			}
			set
			{
				this._is_vip = new bool?(value);
			}
		}

		// Token: 0x170024B8 RID: 9400
		// (get) Token: 0x060073FC RID: 29692 RVA: 0x000DDEB4 File Offset: 0x000DC0B4
		// (set) Token: 0x060073FD RID: 29693 RVA: 0x000DDED4 File Offset: 0x000DC0D4
		[XmlIgnore]
		[Browsable(false)]
		public bool is_vipSpecified
		{
			get
			{
				return this._is_vip != null;
			}
			set
			{
				bool flag = value == (this._is_vip == null);
				if (flag)
				{
					this._is_vip = (value ? new bool?(this.is_vip) : null);
				}
			}
		}

		// Token: 0x060073FE RID: 29694 RVA: 0x000DDF18 File Offset: 0x000DC118
		private bool ShouldSerializeis_vip()
		{
			return this.is_vipSpecified;
		}

		// Token: 0x060073FF RID: 29695 RVA: 0x000DDF30 File Offset: 0x000DC130
		private void Resetis_vip()
		{
			this.is_vipSpecified = false;
		}

		// Token: 0x170024B9 RID: 9401
		// (get) Token: 0x06007400 RID: 29696 RVA: 0x000DDF3C File Offset: 0x000DC13C
		// (set) Token: 0x06007401 RID: 29697 RVA: 0x000DDF68 File Offset: 0x000DC168
		[ProtoMember(3, IsRequired = false, Name = "is_svip", DataFormat = DataFormat.Default)]
		public bool is_svip
		{
			get
			{
				return this._is_svip ?? false;
			}
			set
			{
				this._is_svip = new bool?(value);
			}
		}

		// Token: 0x170024BA RID: 9402
		// (get) Token: 0x06007402 RID: 29698 RVA: 0x000DDF78 File Offset: 0x000DC178
		// (set) Token: 0x06007403 RID: 29699 RVA: 0x000DDF98 File Offset: 0x000DC198
		[XmlIgnore]
		[Browsable(false)]
		public bool is_svipSpecified
		{
			get
			{
				return this._is_svip != null;
			}
			set
			{
				bool flag = value == (this._is_svip == null);
				if (flag)
				{
					this._is_svip = (value ? new bool?(this.is_svip) : null);
				}
			}
		}

		// Token: 0x06007404 RID: 29700 RVA: 0x000DDFDC File Offset: 0x000DC1DC
		private bool ShouldSerializeis_svip()
		{
			return this.is_svipSpecified;
		}

		// Token: 0x06007405 RID: 29701 RVA: 0x000DDFF4 File Offset: 0x000DC1F4
		private void Resetis_svip()
		{
			this.is_svipSpecified = false;
		}

		// Token: 0x06007406 RID: 29702 RVA: 0x000DE000 File Offset: 0x000DC200
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B8D RID: 7053
		private string _openid;

		// Token: 0x04001B8E RID: 7054
		private bool? _is_vip;

		// Token: 0x04001B8F RID: 7055
		private bool? _is_svip;

		// Token: 0x04001B90 RID: 7056
		private IExtension extensionObject;
	}
}
