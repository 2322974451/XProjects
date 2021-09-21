using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200071B RID: 1819
	[ProtoContract(Name = "DHRewrad2State")]
	[Serializable]
	public class DHRewrad2State : IExtensible
	{
		// Token: 0x17002754 RID: 10068
		// (get) Token: 0x06007C15 RID: 31765 RVA: 0x000ED368 File Offset: 0x000EB568
		// (set) Token: 0x06007C16 RID: 31766 RVA: 0x000ED394 File Offset: 0x000EB594
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public int id
		{
			get
			{
				return this._id ?? 0;
			}
			set
			{
				this._id = new int?(value);
			}
		}

		// Token: 0x17002755 RID: 10069
		// (get) Token: 0x06007C17 RID: 31767 RVA: 0x000ED3A4 File Offset: 0x000EB5A4
		// (set) Token: 0x06007C18 RID: 31768 RVA: 0x000ED3C4 File Offset: 0x000EB5C4
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new int?(this.id) : null);
				}
			}
		}

		// Token: 0x06007C19 RID: 31769 RVA: 0x000ED408 File Offset: 0x000EB608
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06007C1A RID: 31770 RVA: 0x000ED420 File Offset: 0x000EB620
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002756 RID: 10070
		// (get) Token: 0x06007C1B RID: 31771 RVA: 0x000ED42C File Offset: 0x000EB62C
		// (set) Token: 0x06007C1C RID: 31772 RVA: 0x000ED458 File Offset: 0x000EB658
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public DHRState state
		{
			get
			{
				return this._state ?? DHRState.DHR_CANNOT;
			}
			set
			{
				this._state = new DHRState?(value);
			}
		}

		// Token: 0x17002757 RID: 10071
		// (get) Token: 0x06007C1D RID: 31773 RVA: 0x000ED468 File Offset: 0x000EB668
		// (set) Token: 0x06007C1E RID: 31774 RVA: 0x000ED488 File Offset: 0x000EB688
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
					this._state = (value ? new DHRState?(this.state) : null);
				}
			}
		}

		// Token: 0x06007C1F RID: 31775 RVA: 0x000ED4CC File Offset: 0x000EB6CC
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06007C20 RID: 31776 RVA: 0x000ED4E4 File Offset: 0x000EB6E4
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06007C21 RID: 31777 RVA: 0x000ED4F0 File Offset: 0x000EB6F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D40 RID: 7488
		private int? _id;

		// Token: 0x04001D41 RID: 7489
		private DHRState? _state;

		// Token: 0x04001D42 RID: 7490
		private IExtension extensionObject;
	}
}
