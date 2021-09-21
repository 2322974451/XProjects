using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200051B RID: 1307
	[ProtoContract(Name = "EnterLeisureSceneArg")]
	[Serializable]
	public class EnterLeisureSceneArg : IExtensible
	{
		// Token: 0x17001487 RID: 5255
		// (get) Token: 0x0600432B RID: 17195 RVA: 0x0007FC90 File Offset: 0x0007DE90
		// (set) Token: 0x0600432C RID: 17196 RVA: 0x0007FCBC File Offset: 0x0007DEBC
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		// Token: 0x17001488 RID: 5256
		// (get) Token: 0x0600432D RID: 17197 RVA: 0x0007FCCC File Offset: 0x0007DECC
		// (set) Token: 0x0600432E RID: 17198 RVA: 0x0007FCEC File Offset: 0x0007DEEC
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		// Token: 0x0600432F RID: 17199 RVA: 0x0007FD30 File Offset: 0x0007DF30
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06004330 RID: 17200 RVA: 0x0007FD48 File Offset: 0x0007DF48
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06004331 RID: 17201 RVA: 0x0007FD54 File Offset: 0x0007DF54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010BF RID: 4287
		private int? _index;

		// Token: 0x040010C0 RID: 4288
		private IExtension extensionObject;
	}
}
