using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000647 RID: 1607
	[ProtoContract(Name = "ThemeActivityData")]
	[Serializable]
	public class ThemeActivityData : IExtensible
	{
		// Token: 0x17001F7C RID: 8060
		// (get) Token: 0x060063DD RID: 25565 RVA: 0x000BE954 File Offset: 0x000BCB54
		[ProtoMember(1, Name = "firstscene", DataFormat = DataFormat.Default)]
		public List<SpFirstCompleteScene> firstscene
		{
			get
			{
				return this._firstscene;
			}
		}

		// Token: 0x17001F7D RID: 8061
		// (get) Token: 0x060063DE RID: 25566 RVA: 0x000BE96C File Offset: 0x000BCB6C
		// (set) Token: 0x060063DF RID: 25567 RVA: 0x000BE998 File Offset: 0x000BCB98
		[ProtoMember(2, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		// Token: 0x17001F7E RID: 8062
		// (get) Token: 0x060063E0 RID: 25568 RVA: 0x000BE9A8 File Offset: 0x000BCBA8
		// (set) Token: 0x060063E1 RID: 25569 RVA: 0x000BE9C8 File Offset: 0x000BCBC8
		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		// Token: 0x060063E2 RID: 25570 RVA: 0x000BEA0C File Offset: 0x000BCC0C
		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		// Token: 0x060063E3 RID: 25571 RVA: 0x000BEA24 File Offset: 0x000BCC24
		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		// Token: 0x060063E4 RID: 25572 RVA: 0x000BEA30 File Offset: 0x000BCC30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001834 RID: 6196
		private readonly List<SpFirstCompleteScene> _firstscene = new List<SpFirstCompleteScene>();

		// Token: 0x04001835 RID: 6197
		private bool? _ishint;

		// Token: 0x04001836 RID: 6198
		private IExtension extensionObject;
	}
}
