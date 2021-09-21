using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000147 RID: 327
	[ProtoContract(Name = "GetFlowerRes")]
	[Serializable]
	public class GetFlowerRes : IExtensible
	{
		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06001414 RID: 5140 RVA: 0x0002886C File Offset: 0x00026A6C
		// (set) Token: 0x06001415 RID: 5141 RVA: 0x00028898 File Offset: 0x00026A98
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

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x000288A8 File Offset: 0x00026AA8
		// (set) Token: 0x06001417 RID: 5143 RVA: 0x000288C8 File Offset: 0x00026AC8
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

		// Token: 0x06001418 RID: 5144 RVA: 0x0002890C File Offset: 0x00026B0C
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x00028924 File Offset: 0x00026B24
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x0600141A RID: 5146 RVA: 0x00028930 File Offset: 0x00026B30
		// (set) Token: 0x0600141B RID: 5147 RVA: 0x0002895C File Offset: 0x00026B5C
		[ProtoMember(2, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x0600141C RID: 5148 RVA: 0x0002896C File Offset: 0x00026B6C
		// (set) Token: 0x0600141D RID: 5149 RVA: 0x0002898C File Offset: 0x00026B8C
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x000289D0 File Offset: 0x00026BD0
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x000289E8 File Offset: 0x00026BE8
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06001420 RID: 5152 RVA: 0x000289F4 File Offset: 0x00026BF4
		// (set) Token: 0x06001421 RID: 5153 RVA: 0x00028A20 File Offset: 0x00026C20
		[ProtoMember(3, IsRequired = false, Name = "canGet", DataFormat = DataFormat.Default)]
		public bool canGet
		{
			get
			{
				return this._canGet ?? false;
			}
			set
			{
				this._canGet = new bool?(value);
			}
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06001422 RID: 5154 RVA: 0x00028A30 File Offset: 0x00026C30
		// (set) Token: 0x06001423 RID: 5155 RVA: 0x00028A50 File Offset: 0x00026C50
		[XmlIgnore]
		[Browsable(false)]
		public bool canGetSpecified
		{
			get
			{
				return this._canGet != null;
			}
			set
			{
				bool flag = value == (this._canGet == null);
				if (flag)
				{
					this._canGet = (value ? new bool?(this.canGet) : null);
				}
			}
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x00028A94 File Offset: 0x00026C94
		private bool ShouldSerializecanGet()
		{
			return this.canGetSpecified;
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x00028AAC File Offset: 0x00026CAC
		private void ResetcanGet()
		{
			this.canGetSpecified = false;
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x00028AB8 File Offset: 0x00026CB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000500 RID: 1280
		private ErrorCode? _errorCode;

		// Token: 0x04000501 RID: 1281
		private int? _leftTime;

		// Token: 0x04000502 RID: 1282
		private bool? _canGet;

		// Token: 0x04000503 RID: 1283
		private IExtension extensionObject;
	}
}
