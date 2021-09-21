using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200040F RID: 1039
	[ProtoContract(Name = "KMatchCommonRes")]
	[Serializable]
	public class KMatchCommonRes : IExtensible
	{
		// Token: 0x17001102 RID: 4354
		// (get) Token: 0x06003753 RID: 14163 RVA: 0x00069F68 File Offset: 0x00068168
		// (set) Token: 0x06003754 RID: 14164 RVA: 0x00069F94 File Offset: 0x00068194
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

		// Token: 0x17001103 RID: 4355
		// (get) Token: 0x06003755 RID: 14165 RVA: 0x00069FA4 File Offset: 0x000681A4
		// (set) Token: 0x06003756 RID: 14166 RVA: 0x00069FC4 File Offset: 0x000681C4
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

		// Token: 0x06003757 RID: 14167 RVA: 0x0006A008 File Offset: 0x00068208
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003758 RID: 14168 RVA: 0x0006A020 File Offset: 0x00068220
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001104 RID: 4356
		// (get) Token: 0x06003759 RID: 14169 RVA: 0x0006A02C File Offset: 0x0006822C
		// (set) Token: 0x0600375A RID: 14170 RVA: 0x0006A04D File Offset: 0x0006824D
		[ProtoMember(2, IsRequired = false, Name = "problem_name", DataFormat = DataFormat.Default)]
		public string problem_name
		{
			get
			{
				return this._problem_name ?? "";
			}
			set
			{
				this._problem_name = value;
			}
		}

		// Token: 0x17001105 RID: 4357
		// (get) Token: 0x0600375B RID: 14171 RVA: 0x0006A058 File Offset: 0x00068258
		// (set) Token: 0x0600375C RID: 14172 RVA: 0x0006A074 File Offset: 0x00068274
		[XmlIgnore]
		[Browsable(false)]
		public bool problem_nameSpecified
		{
			get
			{
				return this._problem_name != null;
			}
			set
			{
				bool flag = value == (this._problem_name == null);
				if (flag)
				{
					this._problem_name = (value ? this.problem_name : null);
				}
			}
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x0006A0A4 File Offset: 0x000682A4
		private bool ShouldSerializeproblem_name()
		{
			return this.problem_nameSpecified;
		}

		// Token: 0x0600375E RID: 14174 RVA: 0x0006A0BC File Offset: 0x000682BC
		private void Resetproblem_name()
		{
			this.problem_nameSpecified = false;
		}

		// Token: 0x17001106 RID: 4358
		// (get) Token: 0x0600375F RID: 14175 RVA: 0x0006A0C8 File Offset: 0x000682C8
		// (set) Token: 0x06003760 RID: 14176 RVA: 0x0006A0F4 File Offset: 0x000682F4
		[ProtoMember(3, IsRequired = false, Name = "endtime", DataFormat = DataFormat.TwosComplement)]
		public uint endtime
		{
			get
			{
				return this._endtime ?? 0U;
			}
			set
			{
				this._endtime = new uint?(value);
			}
		}

		// Token: 0x17001107 RID: 4359
		// (get) Token: 0x06003761 RID: 14177 RVA: 0x0006A104 File Offset: 0x00068304
		// (set) Token: 0x06003762 RID: 14178 RVA: 0x0006A124 File Offset: 0x00068324
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
					this._endtime = (value ? new uint?(this.endtime) : null);
				}
			}
		}

		// Token: 0x06003763 RID: 14179 RVA: 0x0006A168 File Offset: 0x00068368
		private bool ShouldSerializeendtime()
		{
			return this.endtimeSpecified;
		}

		// Token: 0x06003764 RID: 14180 RVA: 0x0006A180 File Offset: 0x00068380
		private void Resetendtime()
		{
			this.endtimeSpecified = false;
		}

		// Token: 0x06003765 RID: 14181 RVA: 0x0006A18C File Offset: 0x0006838C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DB6 RID: 3510
		private ErrorCode? _errorcode;

		// Token: 0x04000DB7 RID: 3511
		private string _problem_name;

		// Token: 0x04000DB8 RID: 3512
		private uint? _endtime;

		// Token: 0x04000DB9 RID: 3513
		private IExtension extensionObject;
	}
}
