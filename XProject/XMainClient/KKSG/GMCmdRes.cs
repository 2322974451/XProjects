using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000036 RID: 54
	[ProtoContract(Name = "GMCmdRes")]
	[Serializable]
	public class GMCmdRes : IExtensible
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00009DCC File Offset: 0x00007FCC
		// (set) Token: 0x060003BE RID: 958 RVA: 0x00009DF8 File Offset: 0x00007FF8
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.Default)]
		public bool result
		{
			get
			{
				return this._result ?? false;
			}
			set
			{
				this._result = new bool?(value);
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060003BF RID: 959 RVA: 0x00009E08 File Offset: 0x00008008
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x00009E28 File Offset: 0x00008028
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new bool?(this.result) : null);
				}
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00009E6C File Offset: 0x0000806C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00009E84 File Offset: 0x00008084
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00009E90 File Offset: 0x00008090
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x00009EB1 File Offset: 0x000080B1
		[ProtoMember(2, IsRequired = false, Name = "outputMessage", DataFormat = DataFormat.Default)]
		public string outputMessage
		{
			get
			{
				return this._outputMessage ?? "";
			}
			set
			{
				this._outputMessage = value;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x00009EBC File Offset: 0x000080BC
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x00009ED8 File Offset: 0x000080D8
		[XmlIgnore]
		[Browsable(false)]
		public bool outputMessageSpecified
		{
			get
			{
				return this._outputMessage != null;
			}
			set
			{
				bool flag = value == (this._outputMessage == null);
				if (flag)
				{
					this._outputMessage = (value ? this.outputMessage : null);
				}
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00009F08 File Offset: 0x00008108
		private bool ShouldSerializeoutputMessage()
		{
			return this.outputMessageSpecified;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00009F20 File Offset: 0x00008120
		private void ResetoutputMessage()
		{
			this.outputMessageSpecified = false;
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00009F2C File Offset: 0x0000812C
		// (set) Token: 0x060003CA RID: 970 RVA: 0x00009F49 File Offset: 0x00008149
		[ProtoMember(3, IsRequired = false, Name = "datablob", DataFormat = DataFormat.Default)]
		public byte[] datablob
		{
			get
			{
				return this._datablob ?? null;
			}
			set
			{
				this._datablob = value;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00009F54 File Offset: 0x00008154
		// (set) Token: 0x060003CC RID: 972 RVA: 0x00009F70 File Offset: 0x00008170
		[XmlIgnore]
		[Browsable(false)]
		public bool datablobSpecified
		{
			get
			{
				return this._datablob != null;
			}
			set
			{
				bool flag = value == (this._datablob == null);
				if (flag)
				{
					this._datablob = (value ? this.datablob : null);
				}
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00009FA0 File Offset: 0x000081A0
		private bool ShouldSerializedatablob()
		{
			return this.datablobSpecified;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00009FB8 File Offset: 0x000081B8
		private void Resetdatablob()
		{
			this.datablobSpecified = false;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00009FC4 File Offset: 0x000081C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000FC RID: 252
		private bool? _result;

		// Token: 0x040000FD RID: 253
		private string _outputMessage;

		// Token: 0x040000FE RID: 254
		private byte[] _datablob;

		// Token: 0x040000FF RID: 255
		private IExtension extensionObject;
	}
}
