using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000292 RID: 658
	[ProtoContract(Name = "ReqPlatFriendRankListRes")]
	[Serializable]
	public class ReqPlatFriendRankListRes : IExtensible
	{
		// Token: 0x17000B74 RID: 2932
		// (get) Token: 0x060024D9 RID: 9433 RVA: 0x00047DB8 File Offset: 0x00045FB8
		// (set) Token: 0x060024DA RID: 9434 RVA: 0x00047DE4 File Offset: 0x00045FE4
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

		// Token: 0x17000B75 RID: 2933
		// (get) Token: 0x060024DB RID: 9435 RVA: 0x00047DF4 File Offset: 0x00045FF4
		// (set) Token: 0x060024DC RID: 9436 RVA: 0x00047E14 File Offset: 0x00046014
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

		// Token: 0x060024DD RID: 9437 RVA: 0x00047E58 File Offset: 0x00046058
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x00047E70 File Offset: 0x00046070
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000B76 RID: 2934
		// (get) Token: 0x060024DF RID: 9439 RVA: 0x00047E7C File Offset: 0x0004607C
		[ProtoMember(2, Name = "platFriends", DataFormat = DataFormat.Default)]
		public List<PlatFriendRankInfo2Client> platFriends
		{
			get
			{
				return this._platFriends;
			}
		}

		// Token: 0x17000B77 RID: 2935
		// (get) Token: 0x060024E0 RID: 9440 RVA: 0x00047E94 File Offset: 0x00046094
		// (set) Token: 0x060024E1 RID: 9441 RVA: 0x00047EAC File Offset: 0x000460AC
		[ProtoMember(3, IsRequired = false, Name = "selfInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatFriendRankInfo2Client selfInfo
		{
			get
			{
				return this._selfInfo;
			}
			set
			{
				this._selfInfo = value;
			}
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x00047EB8 File Offset: 0x000460B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400091B RID: 2331
		private ErrorCode? _error;

		// Token: 0x0400091C RID: 2332
		private readonly List<PlatFriendRankInfo2Client> _platFriends = new List<PlatFriendRankInfo2Client>();

		// Token: 0x0400091D RID: 2333
		private PlatFriendRankInfo2Client _selfInfo = null;

		// Token: 0x0400091E RID: 2334
		private IExtension extensionObject;
	}
}
