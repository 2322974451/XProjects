using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000145 RID: 325
	[ProtoContract(Name = "GetFlowerLeftTimeRes")]
	[Serializable]
	public class GetFlowerLeftTimeRes : IExtensible
	{
		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x060013FE RID: 5118 RVA: 0x000285E0 File Offset: 0x000267E0
		// (set) Token: 0x060013FF RID: 5119 RVA: 0x0002860C File Offset: 0x0002680C
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

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06001400 RID: 5120 RVA: 0x0002861C File Offset: 0x0002681C
		// (set) Token: 0x06001401 RID: 5121 RVA: 0x0002863C File Offset: 0x0002683C
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

		// Token: 0x06001402 RID: 5122 RVA: 0x00028680 File Offset: 0x00026880
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x00028698 File Offset: 0x00026898
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06001404 RID: 5124 RVA: 0x000286A4 File Offset: 0x000268A4
		// (set) Token: 0x06001405 RID: 5125 RVA: 0x000286D0 File Offset: 0x000268D0
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

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06001406 RID: 5126 RVA: 0x000286E0 File Offset: 0x000268E0
		// (set) Token: 0x06001407 RID: 5127 RVA: 0x00028700 File Offset: 0x00026900
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

		// Token: 0x06001408 RID: 5128 RVA: 0x00028744 File Offset: 0x00026944
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x0002875C File Offset: 0x0002695C
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x0600140A RID: 5130 RVA: 0x00028768 File Offset: 0x00026968
		// (set) Token: 0x0600140B RID: 5131 RVA: 0x00028794 File Offset: 0x00026994
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

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x0600140C RID: 5132 RVA: 0x000287A4 File Offset: 0x000269A4
		// (set) Token: 0x0600140D RID: 5133 RVA: 0x000287C4 File Offset: 0x000269C4
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

		// Token: 0x0600140E RID: 5134 RVA: 0x00028808 File Offset: 0x00026A08
		private bool ShouldSerializecanGet()
		{
			return this.canGetSpecified;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x00028820 File Offset: 0x00026A20
		private void ResetcanGet()
		{
			this.canGetSpecified = false;
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x0002882C File Offset: 0x00026A2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004FB RID: 1275
		private ErrorCode? _errorCode;

		// Token: 0x040004FC RID: 1276
		private int? _leftTime;

		// Token: 0x040004FD RID: 1277
		private bool? _canGet;

		// Token: 0x040004FE RID: 1278
		private IExtension extensionObject;
	}
}
