using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A4 RID: 420
	[ProtoContract(Name = "SynGuildArenaFightUnit")]
	[Serializable]
	public class SynGuildArenaFightUnit : IExtensible
	{
		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x060018EB RID: 6379 RVA: 0x00031898 File Offset: 0x0002FA98
		// (set) Token: 0x060018EC RID: 6380 RVA: 0x000318C4 File Offset: 0x0002FAC4
		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public uint pos
		{
			get
			{
				return this._pos ?? 0U;
			}
			set
			{
				this._pos = new uint?(value);
			}
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x060018ED RID: 6381 RVA: 0x000318D4 File Offset: 0x0002FAD4
		// (set) Token: 0x060018EE RID: 6382 RVA: 0x000318F4 File Offset: 0x0002FAF4
		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new uint?(this.pos) : null);
				}
			}
		}

		// Token: 0x060018EF RID: 6383 RVA: 0x00031938 File Offset: 0x0002FB38
		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x00031950 File Offset: 0x0002FB50
		private void Resetpos()
		{
			this.posSpecified = false;
		}

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x060018F1 RID: 6385 RVA: 0x0003195C File Offset: 0x0002FB5C
		// (set) Token: 0x060018F2 RID: 6386 RVA: 0x00031988 File Offset: 0x0002FB88
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x060018F3 RID: 6387 RVA: 0x00031998 File Offset: 0x0002FB98
		// (set) Token: 0x060018F4 RID: 6388 RVA: 0x000319B8 File Offset: 0x0002FBB8
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
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x000319FC File Offset: 0x0002FBFC
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x00031A14 File Offset: 0x0002FC14
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x00031A20 File Offset: 0x0002FC20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400062E RID: 1582
		private uint? _pos;

		// Token: 0x0400062F RID: 1583
		private uint? _state;

		// Token: 0x04000630 RID: 1584
		private IExtension extensionObject;
	}
}
