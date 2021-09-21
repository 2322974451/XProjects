using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005AA RID: 1450
	[ProtoContract(Name = "ChatParamDragonGuild")]
	[Serializable]
	public class ChatParamDragonGuild : IExtensible
	{
		// Token: 0x1700183C RID: 6204
		// (get) Token: 0x06004E8D RID: 20109 RVA: 0x00095660 File Offset: 0x00093860
		// (set) Token: 0x06004E8E RID: 20110 RVA: 0x0009568D File Offset: 0x0009388D
		[ProtoMember(1, IsRequired = false, Name = "dragonguildId", DataFormat = DataFormat.TwosComplement)]
		public ulong dragonguildId
		{
			get
			{
				return this._dragonguildId ?? 0UL;
			}
			set
			{
				this._dragonguildId = new ulong?(value);
			}
		}

		// Token: 0x1700183D RID: 6205
		// (get) Token: 0x06004E8F RID: 20111 RVA: 0x0009569C File Offset: 0x0009389C
		// (set) Token: 0x06004E90 RID: 20112 RVA: 0x000956BC File Offset: 0x000938BC
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildIdSpecified
		{
			get
			{
				return this._dragonguildId != null;
			}
			set
			{
				bool flag = value == (this._dragonguildId == null);
				if (flag)
				{
					this._dragonguildId = (value ? new ulong?(this.dragonguildId) : null);
				}
			}
		}

		// Token: 0x06004E91 RID: 20113 RVA: 0x00095700 File Offset: 0x00093900
		private bool ShouldSerializedragonguildId()
		{
			return this.dragonguildIdSpecified;
		}

		// Token: 0x06004E92 RID: 20114 RVA: 0x00095718 File Offset: 0x00093918
		private void ResetdragonguildId()
		{
			this.dragonguildIdSpecified = false;
		}

		// Token: 0x1700183E RID: 6206
		// (get) Token: 0x06004E93 RID: 20115 RVA: 0x00095724 File Offset: 0x00093924
		// (set) Token: 0x06004E94 RID: 20116 RVA: 0x00095745 File Offset: 0x00093945
		[ProtoMember(2, IsRequired = false, Name = "dragonguildname", DataFormat = DataFormat.Default)]
		public string dragonguildname
		{
			get
			{
				return this._dragonguildname ?? "";
			}
			set
			{
				this._dragonguildname = value;
			}
		}

		// Token: 0x1700183F RID: 6207
		// (get) Token: 0x06004E95 RID: 20117 RVA: 0x00095750 File Offset: 0x00093950
		// (set) Token: 0x06004E96 RID: 20118 RVA: 0x0009576C File Offset: 0x0009396C
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildnameSpecified
		{
			get
			{
				return this._dragonguildname != null;
			}
			set
			{
				bool flag = value == (this._dragonguildname == null);
				if (flag)
				{
					this._dragonguildname = (value ? this.dragonguildname : null);
				}
			}
		}

		// Token: 0x06004E97 RID: 20119 RVA: 0x0009579C File Offset: 0x0009399C
		private bool ShouldSerializedragonguildname()
		{
			return this.dragonguildnameSpecified;
		}

		// Token: 0x06004E98 RID: 20120 RVA: 0x000957B4 File Offset: 0x000939B4
		private void Resetdragonguildname()
		{
			this.dragonguildnameSpecified = false;
		}

		// Token: 0x06004E99 RID: 20121 RVA: 0x000957C0 File Offset: 0x000939C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400136D RID: 4973
		private ulong? _dragonguildId;

		// Token: 0x0400136E RID: 4974
		private string _dragonguildname;

		// Token: 0x0400136F RID: 4975
		private IExtension extensionObject;
	}
}
