using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F9 RID: 1273
	[ProtoContract(Name = "GetDailyTaskRefreshInfoRes")]
	[Serializable]
	public class GetDailyTaskRefreshInfoRes : IExtensible
	{
		// Token: 0x17001420 RID: 5152
		// (get) Token: 0x060041BF RID: 16831 RVA: 0x0007D2B8 File Offset: 0x0007B4B8
		// (set) Token: 0x060041C0 RID: 16832 RVA: 0x0007D2E4 File Offset: 0x0007B4E4
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

		// Token: 0x17001421 RID: 5153
		// (get) Token: 0x060041C1 RID: 16833 RVA: 0x0007D2F4 File Offset: 0x0007B4F4
		// (set) Token: 0x060041C2 RID: 16834 RVA: 0x0007D314 File Offset: 0x0007B514
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

		// Token: 0x060041C3 RID: 16835 RVA: 0x0007D358 File Offset: 0x0007B558
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060041C4 RID: 16836 RVA: 0x0007D370 File Offset: 0x0007B570
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001422 RID: 5154
		// (get) Token: 0x060041C5 RID: 16837 RVA: 0x0007D37C File Offset: 0x0007B57C
		// (set) Token: 0x060041C6 RID: 16838 RVA: 0x0007D3A8 File Offset: 0x0007B5A8
		[ProtoMember(2, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		// Token: 0x17001423 RID: 5155
		// (get) Token: 0x060041C7 RID: 16839 RVA: 0x0007D3B8 File Offset: 0x0007B5B8
		// (set) Token: 0x060041C8 RID: 16840 RVA: 0x0007D3D8 File Offset: 0x0007B5D8
		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		// Token: 0x060041C9 RID: 16841 RVA: 0x0007D41C File Offset: 0x0007B61C
		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		// Token: 0x060041CA RID: 16842 RVA: 0x0007D434 File Offset: 0x0007B634
		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		// Token: 0x17001424 RID: 5156
		// (get) Token: 0x060041CB RID: 16843 RVA: 0x0007D440 File Offset: 0x0007B640
		// (set) Token: 0x060041CC RID: 16844 RVA: 0x0007D46C File Offset: 0x0007B66C
		[ProtoMember(3, IsRequired = false, Name = "refresh_num", DataFormat = DataFormat.TwosComplement)]
		public uint refresh_num
		{
			get
			{
				return this._refresh_num ?? 0U;
			}
			set
			{
				this._refresh_num = new uint?(value);
			}
		}

		// Token: 0x17001425 RID: 5157
		// (get) Token: 0x060041CD RID: 16845 RVA: 0x0007D47C File Offset: 0x0007B67C
		// (set) Token: 0x060041CE RID: 16846 RVA: 0x0007D49C File Offset: 0x0007B69C
		[XmlIgnore]
		[Browsable(false)]
		public bool refresh_numSpecified
		{
			get
			{
				return this._refresh_num != null;
			}
			set
			{
				bool flag = value == (this._refresh_num == null);
				if (flag)
				{
					this._refresh_num = (value ? new uint?(this.refresh_num) : null);
				}
			}
		}

		// Token: 0x060041CF RID: 16847 RVA: 0x0007D4E0 File Offset: 0x0007B6E0
		private bool ShouldSerializerefresh_num()
		{
			return this.refresh_numSpecified;
		}

		// Token: 0x060041D0 RID: 16848 RVA: 0x0007D4F8 File Offset: 0x0007B6F8
		private void Resetrefresh_num()
		{
			this.refresh_numSpecified = false;
		}

		// Token: 0x17001426 RID: 5158
		// (get) Token: 0x060041D1 RID: 16849 RVA: 0x0007D504 File Offset: 0x0007B704
		// (set) Token: 0x060041D2 RID: 16850 RVA: 0x0007D530 File Offset: 0x0007B730
		[ProtoMember(4, IsRequired = false, Name = "extra_refresh_num", DataFormat = DataFormat.TwosComplement)]
		public uint extra_refresh_num
		{
			get
			{
				return this._extra_refresh_num ?? 0U;
			}
			set
			{
				this._extra_refresh_num = new uint?(value);
			}
		}

		// Token: 0x17001427 RID: 5159
		// (get) Token: 0x060041D3 RID: 16851 RVA: 0x0007D540 File Offset: 0x0007B740
		// (set) Token: 0x060041D4 RID: 16852 RVA: 0x0007D560 File Offset: 0x0007B760
		[XmlIgnore]
		[Browsable(false)]
		public bool extra_refresh_numSpecified
		{
			get
			{
				return this._extra_refresh_num != null;
			}
			set
			{
				bool flag = value == (this._extra_refresh_num == null);
				if (flag)
				{
					this._extra_refresh_num = (value ? new uint?(this.extra_refresh_num) : null);
				}
			}
		}

		// Token: 0x060041D5 RID: 16853 RVA: 0x0007D5A4 File Offset: 0x0007B7A4
		private bool ShouldSerializeextra_refresh_num()
		{
			return this.extra_refresh_numSpecified;
		}

		// Token: 0x060041D6 RID: 16854 RVA: 0x0007D5BC File Offset: 0x0007B7BC
		private void Resetextra_refresh_num()
		{
			this.extra_refresh_numSpecified = false;
		}

		// Token: 0x17001428 RID: 5160
		// (get) Token: 0x060041D7 RID: 16855 RVA: 0x0007D5C8 File Offset: 0x0007B7C8
		// (set) Token: 0x060041D8 RID: 16856 RVA: 0x0007D5F4 File Offset: 0x0007B7F4
		[ProtoMember(5, IsRequired = false, Name = "today_buy_num", DataFormat = DataFormat.TwosComplement)]
		public uint today_buy_num
		{
			get
			{
				return this._today_buy_num ?? 0U;
			}
			set
			{
				this._today_buy_num = new uint?(value);
			}
		}

		// Token: 0x17001429 RID: 5161
		// (get) Token: 0x060041D9 RID: 16857 RVA: 0x0007D604 File Offset: 0x0007B804
		// (set) Token: 0x060041DA RID: 16858 RVA: 0x0007D624 File Offset: 0x0007B824
		[XmlIgnore]
		[Browsable(false)]
		public bool today_buy_numSpecified
		{
			get
			{
				return this._today_buy_num != null;
			}
			set
			{
				bool flag = value == (this._today_buy_num == null);
				if (flag)
				{
					this._today_buy_num = (value ? new uint?(this.today_buy_num) : null);
				}
			}
		}

		// Token: 0x060041DB RID: 16859 RVA: 0x0007D668 File Offset: 0x0007B868
		private bool ShouldSerializetoday_buy_num()
		{
			return this.today_buy_numSpecified;
		}

		// Token: 0x060041DC RID: 16860 RVA: 0x0007D680 File Offset: 0x0007B880
		private void Resettoday_buy_num()
		{
			this.today_buy_numSpecified = false;
		}

		// Token: 0x1700142A RID: 5162
		// (get) Token: 0x060041DD RID: 16861 RVA: 0x0007D68C File Offset: 0x0007B88C
		[ProtoMember(6, Name = "friendinfo", DataFormat = DataFormat.Default)]
		public List<DailyTaskRefreshRoleInfo> friendinfo
		{
			get
			{
				return this._friendinfo;
			}
		}

		// Token: 0x060041DE RID: 16862 RVA: 0x0007D6A4 File Offset: 0x0007B8A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001066 RID: 4198
		private ErrorCode? _result;

		// Token: 0x04001067 RID: 4199
		private uint? _luck;

		// Token: 0x04001068 RID: 4200
		private uint? _refresh_num;

		// Token: 0x04001069 RID: 4201
		private uint? _extra_refresh_num;

		// Token: 0x0400106A RID: 4202
		private uint? _today_buy_num;

		// Token: 0x0400106B RID: 4203
		private readonly List<DailyTaskRefreshRoleInfo> _friendinfo = new List<DailyTaskRefreshRoleInfo>();

		// Token: 0x0400106C RID: 4204
		private IExtension extensionObject;
	}
}
