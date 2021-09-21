using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200019A RID: 410
	[ProtoContract(Name = "GmfJoinBattleRes")]
	[Serializable]
	public class GmfJoinBattleRes : IExtensible
	{
		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06001892 RID: 6290 RVA: 0x00030EE4 File Offset: 0x0002F0E4
		// (set) Token: 0x06001893 RID: 6291 RVA: 0x00030F10 File Offset: 0x0002F110
		[ProtoMember(1, IsRequired = false, Name = "join", DataFormat = DataFormat.Default)]
		public bool join
		{
			get
			{
				return this._join ?? false;
			}
			set
			{
				this._join = new bool?(value);
			}
		}

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x06001894 RID: 6292 RVA: 0x00030F20 File Offset: 0x0002F120
		// (set) Token: 0x06001895 RID: 6293 RVA: 0x00030F40 File Offset: 0x0002F140
		[XmlIgnore]
		[Browsable(false)]
		public bool joinSpecified
		{
			get
			{
				return this._join != null;
			}
			set
			{
				bool flag = value == (this._join == null);
				if (flag)
				{
					this._join = (value ? new bool?(this.join) : null);
				}
			}
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x00030F84 File Offset: 0x0002F184
		private bool ShouldSerializejoin()
		{
			return this.joinSpecified;
		}

		// Token: 0x06001897 RID: 6295 RVA: 0x00030F9C File Offset: 0x0002F19C
		private void Resetjoin()
		{
			this.joinSpecified = false;
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x00030FA8 File Offset: 0x0002F1A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000612 RID: 1554
		private bool? _join;

		// Token: 0x04000613 RID: 1555
		private IExtension extensionObject;
	}
}
