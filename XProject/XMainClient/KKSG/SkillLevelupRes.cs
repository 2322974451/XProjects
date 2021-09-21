using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000018 RID: 24
	[ProtoContract(Name = "SkillLevelupRes")]
	[Serializable]
	public class SkillLevelupRes : IExtensible
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00006A14 File Offset: 0x00004C14
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00006A40 File Offset: 0x00004C40
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public uint errorcode
		{
			get
			{
				return this._errorcode ?? 0U;
			}
			set
			{
				this._errorcode = new uint?(value);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00006A50 File Offset: 0x00004C50
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00006A70 File Offset: 0x00004C70
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
					this._errorcode = (value ? new uint?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00006AB4 File Offset: 0x00004CB4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00006ACC File Offset: 0x00004CCC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00006AD8 File Offset: 0x00004CD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000084 RID: 132
		private uint? _errorcode;

		// Token: 0x04000085 RID: 133
		private IExtension extensionObject;
	}
}
