using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200014D RID: 333
	[ProtoContract(Name = "GetFlowerRewardListRes")]
	[Serializable]
	public class GetFlowerRewardListRes : IExtensible
	{
		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06001445 RID: 5189 RVA: 0x00028E04 File Offset: 0x00027004
		// (set) Token: 0x06001446 RID: 5190 RVA: 0x00028E30 File Offset: 0x00027030
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

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06001447 RID: 5191 RVA: 0x00028E40 File Offset: 0x00027040
		// (set) Token: 0x06001448 RID: 5192 RVA: 0x00028E60 File Offset: 0x00027060
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

		// Token: 0x06001449 RID: 5193 RVA: 0x00028EA4 File Offset: 0x000270A4
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x00028EBC File Offset: 0x000270BC
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x0600144B RID: 5195 RVA: 0x00028EC8 File Offset: 0x000270C8
		[ProtoMember(2, Name = "briefList", DataFormat = DataFormat.Default)]
		public List<RoleBriefInfo> briefList
		{
			get
			{
				return this._briefList;
			}
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x0600144C RID: 5196 RVA: 0x00028EE0 File Offset: 0x000270E0
		// (set) Token: 0x0600144D RID: 5197 RVA: 0x00028F0C File Offset: 0x0002710C
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

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x0600144E RID: 5198 RVA: 0x00028F1C File Offset: 0x0002711C
		// (set) Token: 0x0600144F RID: 5199 RVA: 0x00028F3C File Offset: 0x0002713C
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

		// Token: 0x06001450 RID: 5200 RVA: 0x00028F80 File Offset: 0x00027180
		private bool ShouldSerializecanGetReward()
		{
			return this.canGetRewardSpecified;
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x00028F98 File Offset: 0x00027198
		private void ResetcanGetReward()
		{
			this.canGetRewardSpecified = false;
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x00028FA4 File Offset: 0x000271A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400050D RID: 1293
		private ErrorCode? _errorCode;

		// Token: 0x0400050E RID: 1294
		private readonly List<RoleBriefInfo> _briefList = new List<RoleBriefInfo>();

		// Token: 0x0400050F RID: 1295
		private bool? _canGetReward;

		// Token: 0x04000510 RID: 1296
		private IExtension extensionObject;
	}
}
