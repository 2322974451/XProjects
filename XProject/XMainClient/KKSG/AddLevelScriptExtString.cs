using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E6 RID: 230
	[ProtoContract(Name = "AddLevelScriptExtString")]
	[Serializable]
	public class AddLevelScriptExtString : IExtensible
	{
		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x0001EAA8 File Offset: 0x0001CCA8
		// (set) Token: 0x06000ED3 RID: 3795 RVA: 0x0001EAC9 File Offset: 0x0001CCC9
		[ProtoMember(1, IsRequired = false, Name = "extString", DataFormat = DataFormat.Default)]
		public string extString
		{
			get
			{
				return this._extString ?? "";
			}
			set
			{
				this._extString = value;
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0001EAD4 File Offset: 0x0001CCD4
		// (set) Token: 0x06000ED5 RID: 3797 RVA: 0x0001EAF0 File Offset: 0x0001CCF0
		[XmlIgnore]
		[Browsable(false)]
		public bool extStringSpecified
		{
			get
			{
				return this._extString != null;
			}
			set
			{
				bool flag = value == (this._extString == null);
				if (flag)
				{
					this._extString = (value ? this.extString : null);
				}
			}
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0001EB20 File Offset: 0x0001CD20
		private bool ShouldSerializeextString()
		{
			return this.extStringSpecified;
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x0001EB38 File Offset: 0x0001CD38
		private void ResetextString()
		{
			this.extStringSpecified = false;
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x0001EB44 File Offset: 0x0001CD44
		// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x0001EB70 File Offset: 0x0001CD70
		[ProtoMember(2, IsRequired = false, Name = "sceneTempID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneTempID
		{
			get
			{
				return this._sceneTempID ?? 0U;
			}
			set
			{
				this._sceneTempID = new uint?(value);
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x0001EB80 File Offset: 0x0001CD80
		// (set) Token: 0x06000EDB RID: 3803 RVA: 0x0001EBA0 File Offset: 0x0001CDA0
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneTempIDSpecified
		{
			get
			{
				return this._sceneTempID != null;
			}
			set
			{
				bool flag = value == (this._sceneTempID == null);
				if (flag)
				{
					this._sceneTempID = (value ? new uint?(this.sceneTempID) : null);
				}
			}
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x0001EBE4 File Offset: 0x0001CDE4
		private bool ShouldSerializesceneTempID()
		{
			return this.sceneTempIDSpecified;
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x0001EBFC File Offset: 0x0001CDFC
		private void ResetsceneTempID()
		{
			this.sceneTempIDSpecified = false;
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x0001EC08 File Offset: 0x0001CE08
		// (set) Token: 0x06000EDF RID: 3807 RVA: 0x0001EC34 File Offset: 0x0001CE34
		[ProtoMember(3, IsRequired = false, Name = "waveID", DataFormat = DataFormat.TwosComplement)]
		public int waveID
		{
			get
			{
				return this._waveID ?? 0;
			}
			set
			{
				this._waveID = new int?(value);
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0001EC44 File Offset: 0x0001CE44
		// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x0001EC64 File Offset: 0x0001CE64
		[XmlIgnore]
		[Browsable(false)]
		public bool waveIDSpecified
		{
			get
			{
				return this._waveID != null;
			}
			set
			{
				bool flag = value == (this._waveID == null);
				if (flag)
				{
					this._waveID = (value ? new int?(this.waveID) : null);
				}
			}
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x0001ECA8 File Offset: 0x0001CEA8
		private bool ShouldSerializewaveID()
		{
			return this.waveIDSpecified;
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0001ECC0 File Offset: 0x0001CEC0
		private void ResetwaveID()
		{
			this.waveIDSpecified = false;
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x0001ECCC File Offset: 0x0001CECC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003B7 RID: 951
		private string _extString;

		// Token: 0x040003B8 RID: 952
		private uint? _sceneTempID;

		// Token: 0x040003B9 RID: 953
		private int? _waveID;

		// Token: 0x040003BA RID: 954
		private IExtension extensionObject;
	}
}
