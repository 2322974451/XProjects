using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000315 RID: 789
	[ProtoContract(Name = "MentorRelationOpRes")]
	[Serializable]
	public class MentorRelationOpRes : IExtensible
	{
		// Token: 0x17000D65 RID: 3429
		// (get) Token: 0x06002B3D RID: 11069 RVA: 0x00053C4C File Offset: 0x00051E4C
		// (set) Token: 0x06002B3E RID: 11070 RVA: 0x00053C78 File Offset: 0x00051E78
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

		// Token: 0x17000D66 RID: 3430
		// (get) Token: 0x06002B3F RID: 11071 RVA: 0x00053C88 File Offset: 0x00051E88
		// (set) Token: 0x06002B40 RID: 11072 RVA: 0x00053CA8 File Offset: 0x00051EA8
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

		// Token: 0x06002B41 RID: 11073 RVA: 0x00053CEC File Offset: 0x00051EEC
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002B42 RID: 11074 RVA: 0x00053D04 File Offset: 0x00051F04
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000D67 RID: 3431
		// (get) Token: 0x06002B43 RID: 11075 RVA: 0x00053D10 File Offset: 0x00051F10
		// (set) Token: 0x06002B44 RID: 11076 RVA: 0x00053D3C File Offset: 0x00051F3C
		[ProtoMember(2, IsRequired = false, Name = "curTime", DataFormat = DataFormat.TwosComplement)]
		public int curTime
		{
			get
			{
				return this._curTime ?? 0;
			}
			set
			{
				this._curTime = new int?(value);
			}
		}

		// Token: 0x17000D68 RID: 3432
		// (get) Token: 0x06002B45 RID: 11077 RVA: 0x00053D4C File Offset: 0x00051F4C
		// (set) Token: 0x06002B46 RID: 11078 RVA: 0x00053D6C File Offset: 0x00051F6C
		[XmlIgnore]
		[Browsable(false)]
		public bool curTimeSpecified
		{
			get
			{
				return this._curTime != null;
			}
			set
			{
				bool flag = value == (this._curTime == null);
				if (flag)
				{
					this._curTime = (value ? new int?(this.curTime) : null);
				}
			}
		}

		// Token: 0x06002B47 RID: 11079 RVA: 0x00053DB0 File Offset: 0x00051FB0
		private bool ShouldSerializecurTime()
		{
			return this.curTimeSpecified;
		}

		// Token: 0x06002B48 RID: 11080 RVA: 0x00053DC8 File Offset: 0x00051FC8
		private void ResetcurTime()
		{
			this.curTimeSpecified = false;
		}

		// Token: 0x06002B49 RID: 11081 RVA: 0x00053DD4 File Offset: 0x00051FD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AB8 RID: 2744
		private ErrorCode? _error;

		// Token: 0x04000AB9 RID: 2745
		private int? _curTime;

		// Token: 0x04000ABA RID: 2746
		private IExtension extensionObject;
	}
}
