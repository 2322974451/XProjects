using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000622 RID: 1570
	[ProtoContract(Name = "PaytssInfo")]
	[Serializable]
	public class PaytssInfo : IExtensible
	{
		// Token: 0x17001E3C RID: 7740
		// (get) Token: 0x0600601A RID: 24602 RVA: 0x000B747C File Offset: 0x000B567C
		// (set) Token: 0x0600601B RID: 24603 RVA: 0x000B74A8 File Offset: 0x000B56A8
		[ProtoMember(1, IsRequired = false, Name = "begintime", DataFormat = DataFormat.TwosComplement)]
		public int begintime
		{
			get
			{
				return this._begintime ?? 0;
			}
			set
			{
				this._begintime = new int?(value);
			}
		}

		// Token: 0x17001E3D RID: 7741
		// (get) Token: 0x0600601C RID: 24604 RVA: 0x000B74B8 File Offset: 0x000B56B8
		// (set) Token: 0x0600601D RID: 24605 RVA: 0x000B74D8 File Offset: 0x000B56D8
		[XmlIgnore]
		[Browsable(false)]
		public bool begintimeSpecified
		{
			get
			{
				return this._begintime != null;
			}
			set
			{
				bool flag = value == (this._begintime == null);
				if (flag)
				{
					this._begintime = (value ? new int?(this.begintime) : null);
				}
			}
		}

		// Token: 0x0600601E RID: 24606 RVA: 0x000B751C File Offset: 0x000B571C
		private bool ShouldSerializebegintime()
		{
			return this.begintimeSpecified;
		}

		// Token: 0x0600601F RID: 24607 RVA: 0x000B7534 File Offset: 0x000B5734
		private void Resetbegintime()
		{
			this.begintimeSpecified = false;
		}

		// Token: 0x17001E3E RID: 7742
		// (get) Token: 0x06006020 RID: 24608 RVA: 0x000B7540 File Offset: 0x000B5740
		// (set) Token: 0x06006021 RID: 24609 RVA: 0x000B756C File Offset: 0x000B576C
		[ProtoMember(2, IsRequired = false, Name = "endtime", DataFormat = DataFormat.TwosComplement)]
		public int endtime
		{
			get
			{
				return this._endtime ?? 0;
			}
			set
			{
				this._endtime = new int?(value);
			}
		}

		// Token: 0x17001E3F RID: 7743
		// (get) Token: 0x06006022 RID: 24610 RVA: 0x000B757C File Offset: 0x000B577C
		// (set) Token: 0x06006023 RID: 24611 RVA: 0x000B759C File Offset: 0x000B579C
		[XmlIgnore]
		[Browsable(false)]
		public bool endtimeSpecified
		{
			get
			{
				return this._endtime != null;
			}
			set
			{
				bool flag = value == (this._endtime == null);
				if (flag)
				{
					this._endtime = (value ? new int?(this.endtime) : null);
				}
			}
		}

		// Token: 0x06006024 RID: 24612 RVA: 0x000B75E0 File Offset: 0x000B57E0
		private bool ShouldSerializeendtime()
		{
			return this.endtimeSpecified;
		}

		// Token: 0x06006025 RID: 24613 RVA: 0x000B75F8 File Offset: 0x000B57F8
		private void Resetendtime()
		{
			this.endtimeSpecified = false;
		}

		// Token: 0x17001E40 RID: 7744
		// (get) Token: 0x06006026 RID: 24614 RVA: 0x000B7604 File Offset: 0x000B5804
		// (set) Token: 0x06006027 RID: 24615 RVA: 0x000B7630 File Offset: 0x000B5830
		[ProtoMember(3, IsRequired = false, Name = "lastGetAwardTime", DataFormat = DataFormat.TwosComplement)]
		public int lastGetAwardTime
		{
			get
			{
				return this._lastGetAwardTime ?? 0;
			}
			set
			{
				this._lastGetAwardTime = new int?(value);
			}
		}

		// Token: 0x17001E41 RID: 7745
		// (get) Token: 0x06006028 RID: 24616 RVA: 0x000B7640 File Offset: 0x000B5840
		// (set) Token: 0x06006029 RID: 24617 RVA: 0x000B7660 File Offset: 0x000B5860
		[XmlIgnore]
		[Browsable(false)]
		public bool lastGetAwardTimeSpecified
		{
			get
			{
				return this._lastGetAwardTime != null;
			}
			set
			{
				bool flag = value == (this._lastGetAwardTime == null);
				if (flag)
				{
					this._lastGetAwardTime = (value ? new int?(this.lastGetAwardTime) : null);
				}
			}
		}

		// Token: 0x0600602A RID: 24618 RVA: 0x000B76A4 File Offset: 0x000B58A4
		private bool ShouldSerializelastGetAwardTime()
		{
			return this.lastGetAwardTimeSpecified;
		}

		// Token: 0x0600602B RID: 24619 RVA: 0x000B76BC File Offset: 0x000B58BC
		private void ResetlastGetAwardTime()
		{
			this.lastGetAwardTimeSpecified = false;
		}

		// Token: 0x0600602C RID: 24620 RVA: 0x000B76C8 File Offset: 0x000B58C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001759 RID: 5977
		private int? _begintime;

		// Token: 0x0400175A RID: 5978
		private int? _endtime;

		// Token: 0x0400175B RID: 5979
		private int? _lastGetAwardTime;

		// Token: 0x0400175C RID: 5980
		private IExtension extensionObject;
	}
}
