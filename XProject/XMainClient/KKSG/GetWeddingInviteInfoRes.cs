using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000472 RID: 1138
	[ProtoContract(Name = "GetWeddingInviteInfoRes")]
	[Serializable]
	public class GetWeddingInviteInfoRes : IExtensible
	{
		// Token: 0x17001231 RID: 4657
		// (get) Token: 0x06003B60 RID: 15200 RVA: 0x00071780 File Offset: 0x0006F980
		// (set) Token: 0x06003B61 RID: 15201 RVA: 0x000717AC File Offset: 0x0006F9AC
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

		// Token: 0x17001232 RID: 4658
		// (get) Token: 0x06003B62 RID: 15202 RVA: 0x000717BC File Offset: 0x0006F9BC
		// (set) Token: 0x06003B63 RID: 15203 RVA: 0x000717DC File Offset: 0x0006F9DC
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

		// Token: 0x06003B64 RID: 15204 RVA: 0x00071820 File Offset: 0x0006FA20
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003B65 RID: 15205 RVA: 0x00071838 File Offset: 0x0006FA38
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001233 RID: 4659
		// (get) Token: 0x06003B66 RID: 15206 RVA: 0x00071844 File Offset: 0x0006FA44
		// (set) Token: 0x06003B67 RID: 15207 RVA: 0x00071870 File Offset: 0x0006FA70
		[ProtoMember(2, IsRequired = false, Name = "permitstranger", DataFormat = DataFormat.Default)]
		public bool permitstranger
		{
			get
			{
				return this._permitstranger ?? false;
			}
			set
			{
				this._permitstranger = new bool?(value);
			}
		}

		// Token: 0x17001234 RID: 4660
		// (get) Token: 0x06003B68 RID: 15208 RVA: 0x00071880 File Offset: 0x0006FA80
		// (set) Token: 0x06003B69 RID: 15209 RVA: 0x000718A0 File Offset: 0x0006FAA0
		[XmlIgnore]
		[Browsable(false)]
		public bool permitstrangerSpecified
		{
			get
			{
				return this._permitstranger != null;
			}
			set
			{
				bool flag = value == (this._permitstranger == null);
				if (flag)
				{
					this._permitstranger = (value ? new bool?(this.permitstranger) : null);
				}
			}
		}

		// Token: 0x06003B6A RID: 15210 RVA: 0x000718E4 File Offset: 0x0006FAE4
		private bool ShouldSerializepermitstranger()
		{
			return this.permitstrangerSpecified;
		}

		// Token: 0x06003B6B RID: 15211 RVA: 0x000718FC File Offset: 0x0006FAFC
		private void Resetpermitstranger()
		{
			this.permitstrangerSpecified = false;
		}

		// Token: 0x17001235 RID: 4661
		// (get) Token: 0x06003B6C RID: 15212 RVA: 0x00071908 File Offset: 0x0006FB08
		[ProtoMember(3, Name = "friends", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> friends
		{
			get
			{
				return this._friends;
			}
		}

		// Token: 0x17001236 RID: 4662
		// (get) Token: 0x06003B6D RID: 15213 RVA: 0x00071920 File Offset: 0x0006FB20
		[ProtoMember(4, Name = "guildmembers", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> guildmembers
		{
			get
			{
				return this._guildmembers;
			}
		}

		// Token: 0x17001237 RID: 4663
		// (get) Token: 0x06003B6E RID: 15214 RVA: 0x00071938 File Offset: 0x0006FB38
		[ProtoMember(5, Name = "invitelist", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> invitelist
		{
			get
			{
				return this._invitelist;
			}
		}

		// Token: 0x17001238 RID: 4664
		// (get) Token: 0x06003B6F RID: 15215 RVA: 0x00071950 File Offset: 0x0006FB50
		[ProtoMember(6, Name = "invite_enter", DataFormat = DataFormat.Default)]
		public List<bool> invite_enter
		{
			get
			{
				return this._invite_enter;
			}
		}

		// Token: 0x17001239 RID: 4665
		// (get) Token: 0x06003B70 RID: 15216 RVA: 0x00071968 File Offset: 0x0006FB68
		[ProtoMember(7, Name = "applylist", DataFormat = DataFormat.Default)]
		public List<WeddingRoleBrief> applylist
		{
			get
			{
				return this._applylist;
			}
		}

		// Token: 0x1700123A RID: 4666
		// (get) Token: 0x06003B71 RID: 15217 RVA: 0x00071980 File Offset: 0x0006FB80
		// (set) Token: 0x06003B72 RID: 15218 RVA: 0x000719AD File Offset: 0x0006FBAD
		[ProtoMember(8, IsRequired = false, Name = "weddingid", DataFormat = DataFormat.TwosComplement)]
		public ulong weddingid
		{
			get
			{
				return this._weddingid ?? 0UL;
			}
			set
			{
				this._weddingid = new ulong?(value);
			}
		}

		// Token: 0x1700123B RID: 4667
		// (get) Token: 0x06003B73 RID: 15219 RVA: 0x000719BC File Offset: 0x0006FBBC
		// (set) Token: 0x06003B74 RID: 15220 RVA: 0x000719DC File Offset: 0x0006FBDC
		[XmlIgnore]
		[Browsable(false)]
		public bool weddingidSpecified
		{
			get
			{
				return this._weddingid != null;
			}
			set
			{
				bool flag = value == (this._weddingid == null);
				if (flag)
				{
					this._weddingid = (value ? new ulong?(this.weddingid) : null);
				}
			}
		}

		// Token: 0x06003B75 RID: 15221 RVA: 0x00071A20 File Offset: 0x0006FC20
		private bool ShouldSerializeweddingid()
		{
			return this.weddingidSpecified;
		}

		// Token: 0x06003B76 RID: 15222 RVA: 0x00071A38 File Offset: 0x0006FC38
		private void Resetweddingid()
		{
			this.weddingidSpecified = false;
		}

		// Token: 0x06003B77 RID: 15223 RVA: 0x00071A44 File Offset: 0x0006FC44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EC4 RID: 3780
		private ErrorCode? _result;

		// Token: 0x04000EC5 RID: 3781
		private bool? _permitstranger;

		// Token: 0x04000EC6 RID: 3782
		private readonly List<WeddingRoleBrief> _friends = new List<WeddingRoleBrief>();

		// Token: 0x04000EC7 RID: 3783
		private readonly List<WeddingRoleBrief> _guildmembers = new List<WeddingRoleBrief>();

		// Token: 0x04000EC8 RID: 3784
		private readonly List<WeddingRoleBrief> _invitelist = new List<WeddingRoleBrief>();

		// Token: 0x04000EC9 RID: 3785
		private readonly List<bool> _invite_enter = new List<bool>();

		// Token: 0x04000ECA RID: 3786
		private readonly List<WeddingRoleBrief> _applylist = new List<WeddingRoleBrief>();

		// Token: 0x04000ECB RID: 3787
		private ulong? _weddingid;

		// Token: 0x04000ECC RID: 3788
		private IExtension extensionObject;
	}
}
