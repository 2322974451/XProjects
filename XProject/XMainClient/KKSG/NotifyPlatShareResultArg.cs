using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000418 RID: 1048
	[ProtoContract(Name = "NotifyPlatShareResultArg")]
	[Serializable]
	public class NotifyPlatShareResultArg : IExtensible
	{
		// Token: 0x17001120 RID: 4384
		// (get) Token: 0x060037BB RID: 14267 RVA: 0x0006AB70 File Offset: 0x00068D70
		// (set) Token: 0x060037BC RID: 14268 RVA: 0x0006AB9C File Offset: 0x00068D9C
		[ProtoMember(1, IsRequired = false, Name = "scene_id", DataFormat = DataFormat.TwosComplement)]
		public uint scene_id
		{
			get
			{
				return this._scene_id ?? 0U;
			}
			set
			{
				this._scene_id = new uint?(value);
			}
		}

		// Token: 0x17001121 RID: 4385
		// (get) Token: 0x060037BD RID: 14269 RVA: 0x0006ABAC File Offset: 0x00068DAC
		// (set) Token: 0x060037BE RID: 14270 RVA: 0x0006ABCC File Offset: 0x00068DCC
		[XmlIgnore]
		[Browsable(false)]
		public bool scene_idSpecified
		{
			get
			{
				return this._scene_id != null;
			}
			set
			{
				bool flag = value == (this._scene_id == null);
				if (flag)
				{
					this._scene_id = (value ? new uint?(this.scene_id) : null);
				}
			}
		}

		// Token: 0x060037BF RID: 14271 RVA: 0x0006AC10 File Offset: 0x00068E10
		private bool ShouldSerializescene_id()
		{
			return this.scene_idSpecified;
		}

		// Token: 0x060037C0 RID: 14272 RVA: 0x0006AC28 File Offset: 0x00068E28
		private void Resetscene_id()
		{
			this.scene_idSpecified = false;
		}

		// Token: 0x17001122 RID: 4386
		// (get) Token: 0x060037C1 RID: 14273 RVA: 0x0006AC34 File Offset: 0x00068E34
		// (set) Token: 0x060037C2 RID: 14274 RVA: 0x0006AC60 File Offset: 0x00068E60
		[ProtoMember(2, IsRequired = false, Name = "redpoint_disappear", DataFormat = DataFormat.Default)]
		public bool redpoint_disappear
		{
			get
			{
				return this._redpoint_disappear ?? false;
			}
			set
			{
				this._redpoint_disappear = new bool?(value);
			}
		}

		// Token: 0x17001123 RID: 4387
		// (get) Token: 0x060037C3 RID: 14275 RVA: 0x0006AC70 File Offset: 0x00068E70
		// (set) Token: 0x060037C4 RID: 14276 RVA: 0x0006AC90 File Offset: 0x00068E90
		[XmlIgnore]
		[Browsable(false)]
		public bool redpoint_disappearSpecified
		{
			get
			{
				return this._redpoint_disappear != null;
			}
			set
			{
				bool flag = value == (this._redpoint_disappear == null);
				if (flag)
				{
					this._redpoint_disappear = (value ? new bool?(this.redpoint_disappear) : null);
				}
			}
		}

		// Token: 0x060037C5 RID: 14277 RVA: 0x0006ACD4 File Offset: 0x00068ED4
		private bool ShouldSerializeredpoint_disappear()
		{
			return this.redpoint_disappearSpecified;
		}

		// Token: 0x060037C6 RID: 14278 RVA: 0x0006ACEC File Offset: 0x00068EEC
		private void Resetredpoint_disappear()
		{
			this.redpoint_disappearSpecified = false;
		}

		// Token: 0x060037C7 RID: 14279 RVA: 0x0006ACF8 File Offset: 0x00068EF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DCF RID: 3535
		private uint? _scene_id;

		// Token: 0x04000DD0 RID: 3536
		private bool? _redpoint_disappear;

		// Token: 0x04000DD1 RID: 3537
		private IExtension extensionObject;
	}
}
