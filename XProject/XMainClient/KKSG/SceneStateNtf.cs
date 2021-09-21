using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200036B RID: 875
	[ProtoContract(Name = "SceneStateNtf")]
	[Serializable]
	public class SceneStateNtf : IExtensible
	{
		// Token: 0x17000EBA RID: 3770
		// (get) Token: 0x06002F95 RID: 12181 RVA: 0x0005BD10 File Offset: 0x00059F10
		// (set) Token: 0x06002F96 RID: 12182 RVA: 0x0005BD28 File Offset: 0x00059F28
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SSceneState state
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
			}
		}

		// Token: 0x17000EBB RID: 3771
		// (get) Token: 0x06002F97 RID: 12183 RVA: 0x0005BD34 File Offset: 0x00059F34
		// (set) Token: 0x06002F98 RID: 12184 RVA: 0x0005BD60 File Offset: 0x00059F60
		[ProtoMember(2, IsRequired = false, Name = "rolespecialstate", DataFormat = DataFormat.TwosComplement)]
		public uint rolespecialstate
		{
			get
			{
				return this._rolespecialstate ?? 0U;
			}
			set
			{
				this._rolespecialstate = new uint?(value);
			}
		}

		// Token: 0x17000EBC RID: 3772
		// (get) Token: 0x06002F99 RID: 12185 RVA: 0x0005BD70 File Offset: 0x00059F70
		// (set) Token: 0x06002F9A RID: 12186 RVA: 0x0005BD90 File Offset: 0x00059F90
		[XmlIgnore]
		[Browsable(false)]
		public bool rolespecialstateSpecified
		{
			get
			{
				return this._rolespecialstate != null;
			}
			set
			{
				bool flag = value == (this._rolespecialstate == null);
				if (flag)
				{
					this._rolespecialstate = (value ? new uint?(this.rolespecialstate) : null);
				}
			}
		}

		// Token: 0x06002F9B RID: 12187 RVA: 0x0005BDD4 File Offset: 0x00059FD4
		private bool ShouldSerializerolespecialstate()
		{
			return this.rolespecialstateSpecified;
		}

		// Token: 0x06002F9C RID: 12188 RVA: 0x0005BDEC File Offset: 0x00059FEC
		private void Resetrolespecialstate()
		{
			this.rolespecialstateSpecified = false;
		}

		// Token: 0x06002F9D RID: 12189 RVA: 0x0005BDF8 File Offset: 0x00059FF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BCF RID: 3023
		private SSceneState _state = null;

		// Token: 0x04000BD0 RID: 3024
		private uint? _rolespecialstate;

		// Token: 0x04000BD1 RID: 3025
		private IExtension extensionObject;
	}
}
