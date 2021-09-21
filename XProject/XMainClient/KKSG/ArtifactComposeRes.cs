using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003FD RID: 1021
	[ProtoContract(Name = "ArtifactComposeRes")]
	[Serializable]
	public class ArtifactComposeRes : IExtensible
	{
		// Token: 0x1700109F RID: 4255
		// (get) Token: 0x0600360E RID: 13838 RVA: 0x000678D4 File Offset: 0x00065AD4
		// (set) Token: 0x0600360F RID: 13839 RVA: 0x00067900 File Offset: 0x00065B00
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

		// Token: 0x170010A0 RID: 4256
		// (get) Token: 0x06003610 RID: 13840 RVA: 0x00067910 File Offset: 0x00065B10
		// (set) Token: 0x06003611 RID: 13841 RVA: 0x00067930 File Offset: 0x00065B30
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

		// Token: 0x06003612 RID: 13842 RVA: 0x00067974 File Offset: 0x00065B74
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003613 RID: 13843 RVA: 0x0006798C File Offset: 0x00065B8C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170010A1 RID: 4257
		// (get) Token: 0x06003614 RID: 13844 RVA: 0x00067998 File Offset: 0x00065B98
		// (set) Token: 0x06003615 RID: 13845 RVA: 0x000679C5 File Offset: 0x00065BC5
		[ProtoMember(2, IsRequired = false, Name = "newuid", DataFormat = DataFormat.TwosComplement)]
		public ulong newuid
		{
			get
			{
				return this._newuid ?? 0UL;
			}
			set
			{
				this._newuid = new ulong?(value);
			}
		}

		// Token: 0x170010A2 RID: 4258
		// (get) Token: 0x06003616 RID: 13846 RVA: 0x000679D4 File Offset: 0x00065BD4
		// (set) Token: 0x06003617 RID: 13847 RVA: 0x000679F4 File Offset: 0x00065BF4
		[XmlIgnore]
		[Browsable(false)]
		public bool newuidSpecified
		{
			get
			{
				return this._newuid != null;
			}
			set
			{
				bool flag = value == (this._newuid == null);
				if (flag)
				{
					this._newuid = (value ? new ulong?(this.newuid) : null);
				}
			}
		}

		// Token: 0x06003618 RID: 13848 RVA: 0x00067A38 File Offset: 0x00065C38
		private bool ShouldSerializenewuid()
		{
			return this.newuidSpecified;
		}

		// Token: 0x06003619 RID: 13849 RVA: 0x00067A50 File Offset: 0x00065C50
		private void Resetnewuid()
		{
			this.newuidSpecified = false;
		}

		// Token: 0x170010A3 RID: 4259
		// (get) Token: 0x0600361A RID: 13850 RVA: 0x00067A5C File Offset: 0x00065C5C
		[ProtoMember(3, Name = "newuids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> newuids
		{
			get
			{
				return this._newuids;
			}
		}

		// Token: 0x0600361B RID: 13851 RVA: 0x00067A74 File Offset: 0x00065C74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D70 RID: 3440
		private ErrorCode? _errorcode;

		// Token: 0x04000D71 RID: 3441
		private ulong? _newuid;

		// Token: 0x04000D72 RID: 3442
		private readonly List<ulong> _newuids = new List<ulong>();

		// Token: 0x04000D73 RID: 3443
		private IExtension extensionObject;
	}
}
