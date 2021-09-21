using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D2 RID: 466
	[ProtoContract(Name = "NewGetFlowerRewardListRes")]
	[Serializable]
	public class NewGetFlowerRewardListRes : IExtensible
	{
		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x06001B18 RID: 6936 RVA: 0x0003594C File Offset: 0x00033B4C
		// (set) Token: 0x06001B19 RID: 6937 RVA: 0x00035978 File Offset: 0x00033B78
		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x06001B1A RID: 6938 RVA: 0x00035988 File Offset: 0x00033B88
		// (set) Token: 0x06001B1B RID: 6939 RVA: 0x000359A8 File Offset: 0x00033BA8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x000359EC File Offset: 0x00033BEC
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x00035A04 File Offset: 0x00033C04
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x06001B1E RID: 6942 RVA: 0x00035A10 File Offset: 0x00033C10
		[ProtoMember(2, Name = "briefList", DataFormat = DataFormat.Default)]
		public List<RoleBriefInfo> briefList
		{
			get
			{
				return this._briefList;
			}
		}

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x06001B1F RID: 6943 RVA: 0x00035A28 File Offset: 0x00033C28
		// (set) Token: 0x06001B20 RID: 6944 RVA: 0x00035A54 File Offset: 0x00033C54
		[ProtoMember(3, IsRequired = false, Name = "canGetReward", DataFormat = DataFormat.Default)]
		public bool canGetReward
		{
			get
			{
				return this._canGetReward ?? false;
			}
			set
			{
				this._canGetReward = new bool?(value);
			}
		}

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x06001B21 RID: 6945 RVA: 0x00035A64 File Offset: 0x00033C64
		// (set) Token: 0x06001B22 RID: 6946 RVA: 0x00035A84 File Offset: 0x00033C84
		[XmlIgnore]
		[Browsable(false)]
		public bool canGetRewardSpecified
		{
			get
			{
				return this._canGetReward != null;
			}
			set
			{
				bool flag = value == (this._canGetReward == null);
				if (flag)
				{
					this._canGetReward = (value ? new bool?(this.canGetReward) : null);
				}
			}
		}

		// Token: 0x06001B23 RID: 6947 RVA: 0x00035AC8 File Offset: 0x00033CC8
		private bool ShouldSerializecanGetReward()
		{
			return this.canGetRewardSpecified;
		}

		// Token: 0x06001B24 RID: 6948 RVA: 0x00035AE0 File Offset: 0x00033CE0
		private void ResetcanGetReward()
		{
			this.canGetRewardSpecified = false;
		}

		// Token: 0x06001B25 RID: 6949 RVA: 0x00035AEC File Offset: 0x00033CEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006BE RID: 1726
		private ErrorCode? _errorCode;

		// Token: 0x040006BF RID: 1727
		private readonly List<RoleBriefInfo> _briefList = new List<RoleBriefInfo>();

		// Token: 0x040006C0 RID: 1728
		private bool? _canGetReward;

		// Token: 0x040006C1 RID: 1729
		private IExtension extensionObject;
	}
}
