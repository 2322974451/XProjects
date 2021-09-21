using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C2 RID: 194
	[ProtoContract(Name = "ExecuteLevelScriptNtf")]
	[Serializable]
	public class ExecuteLevelScriptNtf : IExtensible
	{
		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000CFD RID: 3325 RVA: 0x0001B45C File Offset: 0x0001965C
		// (set) Token: 0x06000CFE RID: 3326 RVA: 0x0001B47D File Offset: 0x0001967D
		[ProtoMember(1, IsRequired = false, Name = "script", DataFormat = DataFormat.Default)]
		public string script
		{
			get
			{
				return this._script ?? "";
			}
			set
			{
				this._script = value;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000CFF RID: 3327 RVA: 0x0001B488 File Offset: 0x00019688
		// (set) Token: 0x06000D00 RID: 3328 RVA: 0x0001B4A4 File Offset: 0x000196A4
		[XmlIgnore]
		[Browsable(false)]
		public bool scriptSpecified
		{
			get
			{
				return this._script != null;
			}
			set
			{
				bool flag = value == (this._script == null);
				if (flag)
				{
					this._script = (value ? this.script : null);
				}
			}
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x0001B4D4 File Offset: 0x000196D4
		private bool ShouldSerializescript()
		{
			return this.scriptSpecified;
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x0001B4EC File Offset: 0x000196EC
		private void Resetscript()
		{
			this.scriptSpecified = false;
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x0001B4F8 File Offset: 0x000196F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400033F RID: 831
		private string _script;

		// Token: 0x04000340 RID: 832
		private IExtension extensionObject;
	}
}
