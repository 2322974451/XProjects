using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000355 RID: 853
	[ProtoContract(Name = "AudioTextArg")]
	[Serializable]
	public class AudioTextArg : IExtensible
	{
		// Token: 0x17000E8B RID: 3723
		// (get) Token: 0x06002EE2 RID: 12002 RVA: 0x0005A95C File Offset: 0x00058B5C
		// (set) Token: 0x06002EE3 RID: 12003 RVA: 0x0005A97D File Offset: 0x00058B7D
		[ProtoMember(1, IsRequired = false, Name = "file_id", DataFormat = DataFormat.Default)]
		public string file_id
		{
			get
			{
				return this._file_id ?? "";
			}
			set
			{
				this._file_id = value;
			}
		}

		// Token: 0x17000E8C RID: 3724
		// (get) Token: 0x06002EE4 RID: 12004 RVA: 0x0005A988 File Offset: 0x00058B88
		// (set) Token: 0x06002EE5 RID: 12005 RVA: 0x0005A9A4 File Offset: 0x00058BA4
		[XmlIgnore]
		[Browsable(false)]
		public bool file_idSpecified
		{
			get
			{
				return this._file_id != null;
			}
			set
			{
				bool flag = value == (this._file_id == null);
				if (flag)
				{
					this._file_id = (value ? this.file_id : null);
				}
			}
		}

		// Token: 0x06002EE6 RID: 12006 RVA: 0x0005A9D4 File Offset: 0x00058BD4
		private bool ShouldSerializefile_id()
		{
			return this.file_idSpecified;
		}

		// Token: 0x06002EE7 RID: 12007 RVA: 0x0005A9EC File Offset: 0x00058BEC
		private void Resetfile_id()
		{
			this.file_idSpecified = false;
		}

		// Token: 0x06002EE8 RID: 12008 RVA: 0x0005A9F8 File Offset: 0x00058BF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BA0 RID: 2976
		private string _file_id;

		// Token: 0x04000BA1 RID: 2977
		private IExtension extensionObject;
	}
}
