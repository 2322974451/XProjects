using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000035 RID: 53
	[ProtoContract(Name = "GMCmdArg")]
	[Serializable]
	public class GMCmdArg : IExtensible
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00009CF8 File Offset: 0x00007EF8
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x00009D19 File Offset: 0x00007F19
		[ProtoMember(1, IsRequired = false, Name = "cmd", DataFormat = DataFormat.Default)]
		public string cmd
		{
			get
			{
				return this._cmd ?? "";
			}
			set
			{
				this._cmd = value;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00009D24 File Offset: 0x00007F24
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00009D40 File Offset: 0x00007F40
		[XmlIgnore]
		[Browsable(false)]
		public bool cmdSpecified
		{
			get
			{
				return this._cmd != null;
			}
			set
			{
				bool flag = value == (this._cmd == null);
				if (flag)
				{
					this._cmd = (value ? this.cmd : null);
				}
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00009D70 File Offset: 0x00007F70
		private bool ShouldSerializecmd()
		{
			return this.cmdSpecified;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00009D88 File Offset: 0x00007F88
		private void Resetcmd()
		{
			this.cmdSpecified = false;
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00009D94 File Offset: 0x00007F94
		[ProtoMember(2, Name = "args", DataFormat = DataFormat.Default)]
		public List<string> args
		{
			get
			{
				return this._args;
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00009DAC File Offset: 0x00007FAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000F9 RID: 249
		private string _cmd;

		// Token: 0x040000FA RID: 250
		private readonly List<string> _args = new List<string>();

		// Token: 0x040000FB RID: 251
		private IExtension extensionObject;
	}
}
