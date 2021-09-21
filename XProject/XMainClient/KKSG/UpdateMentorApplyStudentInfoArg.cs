using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000312 RID: 786
	[ProtoContract(Name = "UpdateMentorApplyStudentInfoArg")]
	[Serializable]
	public class UpdateMentorApplyStudentInfoArg : IExtensible
	{
		// Token: 0x17000D55 RID: 3413
		// (get) Token: 0x06002B07 RID: 11015 RVA: 0x000535F4 File Offset: 0x000517F4
		// (set) Token: 0x06002B08 RID: 11016 RVA: 0x00053621 File Offset: 0x00051821
		[ProtoMember(1, IsRequired = false, Name = "audioID", DataFormat = DataFormat.TwosComplement)]
		public ulong audioID
		{
			get
			{
				return this._audioID ?? 0UL;
			}
			set
			{
				this._audioID = new ulong?(value);
			}
		}

		// Token: 0x17000D56 RID: 3414
		// (get) Token: 0x06002B09 RID: 11017 RVA: 0x00053630 File Offset: 0x00051830
		// (set) Token: 0x06002B0A RID: 11018 RVA: 0x00053650 File Offset: 0x00051850
		[XmlIgnore]
		[Browsable(false)]
		public bool audioIDSpecified
		{
			get
			{
				return this._audioID != null;
			}
			set
			{
				bool flag = value == (this._audioID == null);
				if (flag)
				{
					this._audioID = (value ? new ulong?(this.audioID) : null);
				}
			}
		}

		// Token: 0x06002B0B RID: 11019 RVA: 0x00053694 File Offset: 0x00051894
		private bool ShouldSerializeaudioID()
		{
			return this.audioIDSpecified;
		}

		// Token: 0x06002B0C RID: 11020 RVA: 0x000536AC File Offset: 0x000518AC
		private void ResetaudioID()
		{
			this.audioIDSpecified = false;
		}

		// Token: 0x17000D57 RID: 3415
		// (get) Token: 0x06002B0D RID: 11021 RVA: 0x000536B8 File Offset: 0x000518B8
		// (set) Token: 0x06002B0E RID: 11022 RVA: 0x000536D9 File Offset: 0x000518D9
		[ProtoMember(2, IsRequired = false, Name = "applyWords", DataFormat = DataFormat.Default)]
		public string applyWords
		{
			get
			{
				return this._applyWords ?? "";
			}
			set
			{
				this._applyWords = value;
			}
		}

		// Token: 0x17000D58 RID: 3416
		// (get) Token: 0x06002B0F RID: 11023 RVA: 0x000536E4 File Offset: 0x000518E4
		// (set) Token: 0x06002B10 RID: 11024 RVA: 0x00053700 File Offset: 0x00051900
		[XmlIgnore]
		[Browsable(false)]
		public bool applyWordsSpecified
		{
			get
			{
				return this._applyWords != null;
			}
			set
			{
				bool flag = value == (this._applyWords == null);
				if (flag)
				{
					this._applyWords = (value ? this.applyWords : null);
				}
			}
		}

		// Token: 0x06002B11 RID: 11025 RVA: 0x00053730 File Offset: 0x00051930
		private bool ShouldSerializeapplyWords()
		{
			return this.applyWordsSpecified;
		}

		// Token: 0x06002B12 RID: 11026 RVA: 0x00053748 File Offset: 0x00051948
		private void ResetapplyWords()
		{
			this.applyWordsSpecified = false;
		}

		// Token: 0x17000D59 RID: 3417
		// (get) Token: 0x06002B13 RID: 11027 RVA: 0x00053754 File Offset: 0x00051954
		// (set) Token: 0x06002B14 RID: 11028 RVA: 0x00053780 File Offset: 0x00051980
		[ProtoMember(3, IsRequired = false, Name = "isNeedStudent", DataFormat = DataFormat.Default)]
		public bool isNeedStudent
		{
			get
			{
				return this._isNeedStudent ?? false;
			}
			set
			{
				this._isNeedStudent = new bool?(value);
			}
		}

		// Token: 0x17000D5A RID: 3418
		// (get) Token: 0x06002B15 RID: 11029 RVA: 0x00053790 File Offset: 0x00051990
		// (set) Token: 0x06002B16 RID: 11030 RVA: 0x000537B0 File Offset: 0x000519B0
		[XmlIgnore]
		[Browsable(false)]
		public bool isNeedStudentSpecified
		{
			get
			{
				return this._isNeedStudent != null;
			}
			set
			{
				bool flag = value == (this._isNeedStudent == null);
				if (flag)
				{
					this._isNeedStudent = (value ? new bool?(this.isNeedStudent) : null);
				}
			}
		}

		// Token: 0x06002B17 RID: 11031 RVA: 0x000537F4 File Offset: 0x000519F4
		private bool ShouldSerializeisNeedStudent()
		{
			return this.isNeedStudentSpecified;
		}

		// Token: 0x06002B18 RID: 11032 RVA: 0x0005380C File Offset: 0x00051A0C
		private void ResetisNeedStudent()
		{
			this.isNeedStudentSpecified = false;
		}

		// Token: 0x17000D5B RID: 3419
		// (get) Token: 0x06002B19 RID: 11033 RVA: 0x00053818 File Offset: 0x00051A18
		// (set) Token: 0x06002B1A RID: 11034 RVA: 0x00053844 File Offset: 0x00051A44
		[ProtoMember(4, IsRequired = false, Name = "onlineNotify", DataFormat = DataFormat.Default)]
		public bool onlineNotify
		{
			get
			{
				return this._onlineNotify ?? false;
			}
			set
			{
				this._onlineNotify = new bool?(value);
			}
		}

		// Token: 0x17000D5C RID: 3420
		// (get) Token: 0x06002B1B RID: 11035 RVA: 0x00053854 File Offset: 0x00051A54
		// (set) Token: 0x06002B1C RID: 11036 RVA: 0x00053874 File Offset: 0x00051A74
		[XmlIgnore]
		[Browsable(false)]
		public bool onlineNotifySpecified
		{
			get
			{
				return this._onlineNotify != null;
			}
			set
			{
				bool flag = value == (this._onlineNotify == null);
				if (flag)
				{
					this._onlineNotify = (value ? new bool?(this.onlineNotify) : null);
				}
			}
		}

		// Token: 0x06002B1D RID: 11037 RVA: 0x000538B8 File Offset: 0x00051AB8
		private bool ShouldSerializeonlineNotify()
		{
			return this.onlineNotifySpecified;
		}

		// Token: 0x06002B1E RID: 11038 RVA: 0x000538D0 File Offset: 0x00051AD0
		private void ResetonlineNotify()
		{
			this.onlineNotifySpecified = false;
		}

		// Token: 0x06002B1F RID: 11039 RVA: 0x000538DC File Offset: 0x00051ADC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AAD RID: 2733
		private ulong? _audioID;

		// Token: 0x04000AAE RID: 2734
		private string _applyWords;

		// Token: 0x04000AAF RID: 2735
		private bool? _isNeedStudent;

		// Token: 0x04000AB0 RID: 2736
		private bool? _onlineNotify;

		// Token: 0x04000AB1 RID: 2737
		private IExtension extensionObject;
	}
}
