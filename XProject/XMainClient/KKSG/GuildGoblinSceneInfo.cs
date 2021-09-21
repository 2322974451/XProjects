using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E0 RID: 224
	[ProtoContract(Name = "GuildGoblinSceneInfo")]
	[Serializable]
	public class GuildGoblinSceneInfo : IExtensible
	{
		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x0001DCE8 File Offset: 0x0001BEE8
		// (set) Token: 0x06000E61 RID: 3681 RVA: 0x0001DD14 File Offset: 0x0001BF14
		[ProtoMember(1, IsRequired = false, Name = "killNum", DataFormat = DataFormat.TwosComplement)]
		public int killNum
		{
			get
			{
				return this._killNum ?? 0;
			}
			set
			{
				this._killNum = new int?(value);
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x0001DD24 File Offset: 0x0001BF24
		// (set) Token: 0x06000E63 RID: 3683 RVA: 0x0001DD44 File Offset: 0x0001BF44
		[XmlIgnore]
		[Browsable(false)]
		public bool killNumSpecified
		{
			get
			{
				return this._killNum != null;
			}
			set
			{
				bool flag = value == (this._killNum == null);
				if (flag)
				{
					this._killNum = (value ? new int?(this.killNum) : null);
				}
			}
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x0001DD88 File Offset: 0x0001BF88
		private bool ShouldSerializekillNum()
		{
			return this.killNumSpecified;
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x0001DDA0 File Offset: 0x0001BFA0
		private void ResetkillNum()
		{
			this.killNumSpecified = false;
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x0001DDAC File Offset: 0x0001BFAC
		// (set) Token: 0x06000E67 RID: 3687 RVA: 0x0001DDD8 File Offset: 0x0001BFD8
		[ProtoMember(2, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public int contribute
		{
			get
			{
				return this._contribute ?? 0;
			}
			set
			{
				this._contribute = new int?(value);
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x0001DDE8 File Offset: 0x0001BFE8
		// (set) Token: 0x06000E69 RID: 3689 RVA: 0x0001DE08 File Offset: 0x0001C008
		[XmlIgnore]
		[Browsable(false)]
		public bool contributeSpecified
		{
			get
			{
				return this._contribute != null;
			}
			set
			{
				bool flag = value == (this._contribute == null);
				if (flag)
				{
					this._contribute = (value ? new int?(this.contribute) : null);
				}
			}
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x0001DE4C File Offset: 0x0001C04C
		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x0001DE64 File Offset: 0x0001C064
		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x0001DE70 File Offset: 0x0001C070
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400039D RID: 925
		private int? _killNum;

		// Token: 0x0400039E RID: 926
		private int? _contribute;

		// Token: 0x0400039F RID: 927
		private IExtension extensionObject;
	}
}
