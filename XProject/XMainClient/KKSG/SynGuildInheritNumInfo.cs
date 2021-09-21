using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E3 RID: 739
	[ProtoContract(Name = "SynGuildInheritNumInfo")]
	[Serializable]
	public class SynGuildInheritNumInfo : IExtensible
	{
		// Token: 0x17000CA3 RID: 3235
		// (get) Token: 0x060028AE RID: 10414 RVA: 0x0004F080 File Offset: 0x0004D280
		// (set) Token: 0x060028AF RID: 10415 RVA: 0x0004F0AC File Offset: 0x0004D2AC
		[ProtoMember(1, IsRequired = false, Name = "reqNum", DataFormat = DataFormat.TwosComplement)]
		public uint reqNum
		{
			get
			{
				return this._reqNum ?? 0U;
			}
			set
			{
				this._reqNum = new uint?(value);
			}
		}

		// Token: 0x17000CA4 RID: 3236
		// (get) Token: 0x060028B0 RID: 10416 RVA: 0x0004F0BC File Offset: 0x0004D2BC
		// (set) Token: 0x060028B1 RID: 10417 RVA: 0x0004F0DC File Offset: 0x0004D2DC
		[XmlIgnore]
		[Browsable(false)]
		public bool reqNumSpecified
		{
			get
			{
				return this._reqNum != null;
			}
			set
			{
				bool flag = value == (this._reqNum == null);
				if (flag)
				{
					this._reqNum = (value ? new uint?(this.reqNum) : null);
				}
			}
		}

		// Token: 0x060028B2 RID: 10418 RVA: 0x0004F120 File Offset: 0x0004D320
		private bool ShouldSerializereqNum()
		{
			return this.reqNumSpecified;
		}

		// Token: 0x060028B3 RID: 10419 RVA: 0x0004F138 File Offset: 0x0004D338
		private void ResetreqNum()
		{
			this.reqNumSpecified = false;
		}

		// Token: 0x17000CA5 RID: 3237
		// (get) Token: 0x060028B4 RID: 10420 RVA: 0x0004F144 File Offset: 0x0004D344
		// (set) Token: 0x060028B5 RID: 10421 RVA: 0x0004F170 File Offset: 0x0004D370
		[ProtoMember(2, IsRequired = false, Name = "teacherNum", DataFormat = DataFormat.TwosComplement)]
		public uint teacherNum
		{
			get
			{
				return this._teacherNum ?? 0U;
			}
			set
			{
				this._teacherNum = new uint?(value);
			}
		}

		// Token: 0x17000CA6 RID: 3238
		// (get) Token: 0x060028B6 RID: 10422 RVA: 0x0004F180 File Offset: 0x0004D380
		// (set) Token: 0x060028B7 RID: 10423 RVA: 0x0004F1A0 File Offset: 0x0004D3A0
		[XmlIgnore]
		[Browsable(false)]
		public bool teacherNumSpecified
		{
			get
			{
				return this._teacherNum != null;
			}
			set
			{
				bool flag = value == (this._teacherNum == null);
				if (flag)
				{
					this._teacherNum = (value ? new uint?(this.teacherNum) : null);
				}
			}
		}

		// Token: 0x060028B8 RID: 10424 RVA: 0x0004F1E4 File Offset: 0x0004D3E4
		private bool ShouldSerializeteacherNum()
		{
			return this.teacherNumSpecified;
		}

		// Token: 0x060028B9 RID: 10425 RVA: 0x0004F1FC File Offset: 0x0004D3FC
		private void ResetteacherNum()
		{
			this.teacherNumSpecified = false;
		}

		// Token: 0x17000CA7 RID: 3239
		// (get) Token: 0x060028BA RID: 10426 RVA: 0x0004F208 File Offset: 0x0004D408
		// (set) Token: 0x060028BB RID: 10427 RVA: 0x0004F234 File Offset: 0x0004D434
		[ProtoMember(3, IsRequired = false, Name = "studentNum", DataFormat = DataFormat.TwosComplement)]
		public uint studentNum
		{
			get
			{
				return this._studentNum ?? 0U;
			}
			set
			{
				this._studentNum = new uint?(value);
			}
		}

		// Token: 0x17000CA8 RID: 3240
		// (get) Token: 0x060028BC RID: 10428 RVA: 0x0004F244 File Offset: 0x0004D444
		// (set) Token: 0x060028BD RID: 10429 RVA: 0x0004F264 File Offset: 0x0004D464
		[XmlIgnore]
		[Browsable(false)]
		public bool studentNumSpecified
		{
			get
			{
				return this._studentNum != null;
			}
			set
			{
				bool flag = value == (this._studentNum == null);
				if (flag)
				{
					this._studentNum = (value ? new uint?(this.studentNum) : null);
				}
			}
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x0004F2A8 File Offset: 0x0004D4A8
		private bool ShouldSerializestudentNum()
		{
			return this.studentNumSpecified;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x0004F2C0 File Offset: 0x0004D4C0
		private void ResetstudentNum()
		{
			this.studentNumSpecified = false;
		}

		// Token: 0x17000CA9 RID: 3241
		// (get) Token: 0x060028C0 RID: 10432 RVA: 0x0004F2CC File Offset: 0x0004D4CC
		// (set) Token: 0x060028C1 RID: 10433 RVA: 0x0004F2F8 File Offset: 0x0004D4F8
		[ProtoMember(4, IsRequired = false, Name = "lastTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastTime
		{
			get
			{
				return this._lastTime ?? 0U;
			}
			set
			{
				this._lastTime = new uint?(value);
			}
		}

		// Token: 0x17000CAA RID: 3242
		// (get) Token: 0x060028C2 RID: 10434 RVA: 0x0004F308 File Offset: 0x0004D508
		// (set) Token: 0x060028C3 RID: 10435 RVA: 0x0004F328 File Offset: 0x0004D528
		[XmlIgnore]
		[Browsable(false)]
		public bool lastTimeSpecified
		{
			get
			{
				return this._lastTime != null;
			}
			set
			{
				bool flag = value == (this._lastTime == null);
				if (flag)
				{
					this._lastTime = (value ? new uint?(this.lastTime) : null);
				}
			}
		}

		// Token: 0x060028C4 RID: 10436 RVA: 0x0004F36C File Offset: 0x0004D56C
		private bool ShouldSerializelastTime()
		{
			return this.lastTimeSpecified;
		}

		// Token: 0x060028C5 RID: 10437 RVA: 0x0004F384 File Offset: 0x0004D584
		private void ResetlastTime()
		{
			this.lastTimeSpecified = false;
		}

		// Token: 0x060028C6 RID: 10438 RVA: 0x0004F390 File Offset: 0x0004D590
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A1D RID: 2589
		private uint? _reqNum;

		// Token: 0x04000A1E RID: 2590
		private uint? _teacherNum;

		// Token: 0x04000A1F RID: 2591
		private uint? _studentNum;

		// Token: 0x04000A20 RID: 2592
		private uint? _lastTime;

		// Token: 0x04000A21 RID: 2593
		private IExtension extensionObject;
	}
}
