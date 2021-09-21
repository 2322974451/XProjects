using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000356 RID: 854
	[ProtoContract(Name = "AudioTextRes")]
	[Serializable]
	public class AudioTextRes : IExtensible
	{
		// Token: 0x17000E8D RID: 3725
		// (get) Token: 0x06002EEA RID: 12010 RVA: 0x0005AA18 File Offset: 0x00058C18
		// (set) Token: 0x06002EEB RID: 12011 RVA: 0x0005AA44 File Offset: 0x00058C44
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

		// Token: 0x17000E8E RID: 3726
		// (get) Token: 0x06002EEC RID: 12012 RVA: 0x0005AA54 File Offset: 0x00058C54
		// (set) Token: 0x06002EED RID: 12013 RVA: 0x0005AA74 File Offset: 0x00058C74
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

		// Token: 0x06002EEE RID: 12014 RVA: 0x0005AAB8 File Offset: 0x00058CB8
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002EEF RID: 12015 RVA: 0x0005AAD0 File Offset: 0x00058CD0
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000E8F RID: 3727
		// (get) Token: 0x06002EF0 RID: 12016 RVA: 0x0005AADC File Offset: 0x00058CDC
		// (set) Token: 0x06002EF1 RID: 12017 RVA: 0x0005AAFD File Offset: 0x00058CFD
		[ProtoMember(2, IsRequired = false, Name = "file_text", DataFormat = DataFormat.Default)]
		public string file_text
		{
			get
			{
				return this._file_text ?? "";
			}
			set
			{
				this._file_text = value;
			}
		}

		// Token: 0x17000E90 RID: 3728
		// (get) Token: 0x06002EF2 RID: 12018 RVA: 0x0005AB08 File Offset: 0x00058D08
		// (set) Token: 0x06002EF3 RID: 12019 RVA: 0x0005AB24 File Offset: 0x00058D24
		[XmlIgnore]
		[Browsable(false)]
		public bool file_textSpecified
		{
			get
			{
				return this._file_text != null;
			}
			set
			{
				bool flag = value == (this._file_text == null);
				if (flag)
				{
					this._file_text = (value ? this.file_text : null);
				}
			}
		}

		// Token: 0x06002EF4 RID: 12020 RVA: 0x0005AB54 File Offset: 0x00058D54
		private bool ShouldSerializefile_text()
		{
			return this.file_textSpecified;
		}

		// Token: 0x06002EF5 RID: 12021 RVA: 0x0005AB6C File Offset: 0x00058D6C
		private void Resetfile_text()
		{
			this.file_textSpecified = false;
		}

		// Token: 0x06002EF6 RID: 12022 RVA: 0x0005AB78 File Offset: 0x00058D78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BA2 RID: 2978
		private ErrorCode? _error;

		// Token: 0x04000BA3 RID: 2979
		private string _file_text;

		// Token: 0x04000BA4 RID: 2980
		private IExtension extensionObject;
	}
}
