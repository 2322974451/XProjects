using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E3 RID: 227
	[ProtoContract(Name = "FinishStateInfo")]
	[Serializable]
	public class FinishStateInfo : IExtensible
	{
		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x0001E70C File Offset: 0x0001C90C
		// (set) Token: 0x06000EB4 RID: 3764 RVA: 0x0001E738 File Offset: 0x0001C938
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public SceneFinishState state
		{
			get
			{
				return this._state ?? SceneFinishState.SCENE_FINISH_NONE;
			}
			set
			{
				this._state = new SceneFinishState?(value);
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x0001E748 File Offset: 0x0001C948
		// (set) Token: 0x06000EB6 RID: 3766 RVA: 0x0001E768 File Offset: 0x0001C968
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new SceneFinishState?(this.state) : null);
				}
			}
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x0001E7AC File Offset: 0x0001C9AC
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x0001E7C4 File Offset: 0x0001C9C4
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000EB9 RID: 3769 RVA: 0x0001E7D0 File Offset: 0x0001C9D0
		// (set) Token: 0x06000EBA RID: 3770 RVA: 0x0001E7FC File Offset: 0x0001C9FC
		[ProtoMember(2, IsRequired = false, Name = "countdown", DataFormat = DataFormat.TwosComplement)]
		public int countdown
		{
			get
			{
				return this._countdown ?? 0;
			}
			set
			{
				this._countdown = new int?(value);
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06000EBB RID: 3771 RVA: 0x0001E80C File Offset: 0x0001CA0C
		// (set) Token: 0x06000EBC RID: 3772 RVA: 0x0001E82C File Offset: 0x0001CA2C
		[XmlIgnore]
		[Browsable(false)]
		public bool countdownSpecified
		{
			get
			{
				return this._countdown != null;
			}
			set
			{
				bool flag = value == (this._countdown == null);
				if (flag)
				{
					this._countdown = (value ? new int?(this.countdown) : null);
				}
			}
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x0001E870 File Offset: 0x0001CA70
		private bool ShouldSerializecountdown()
		{
			return this.countdownSpecified;
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x0001E888 File Offset: 0x0001CA88
		private void Resetcountdown()
		{
			this.countdownSpecified = false;
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x0001E894 File Offset: 0x0001CA94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003AF RID: 943
		private SceneFinishState? _state;

		// Token: 0x040003B0 RID: 944
		private int? _countdown;

		// Token: 0x040003B1 RID: 945
		private IExtension extensionObject;
	}
}
