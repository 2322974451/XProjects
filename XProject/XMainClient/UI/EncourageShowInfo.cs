using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001890 RID: 6288
	public class EncourageShowInfo
	{
		// Token: 0x170039D9 RID: 14809
		// (get) Token: 0x060105D3 RID: 67027 RVA: 0x003FB738 File Offset: 0x003F9938
		public uint EncourageCount
		{
			get
			{
				return this._battleSource.GetEncourageCount(this._index);
			}
		}

		// Token: 0x170039DA RID: 14810
		// (get) Token: 0x060105D4 RID: 67028 RVA: 0x003FB75C File Offset: 0x003F995C
		// (set) Token: 0x060105D5 RID: 67029 RVA: 0x003FB774 File Offset: 0x003F9974
		public bool Valid
		{
			get
			{
				return this._valid;
			}
			set
			{
				this._valid = value;
				this.ReqEncourage = null;
				this._encourageTransform.gameObject.SetActive(value);
				this._buffTransfrom.gameObject.SetActive(value);
			}
		}

		// Token: 0x170039DB RID: 14811
		// (get) Token: 0x060105D6 RID: 67030 RVA: 0x003FB7AC File Offset: 0x003F99AC
		// (set) Token: 0x060105D7 RID: 67031 RVA: 0x003FB7C4 File Offset: 0x003F99C4
		public IWorldBossBattleSource BattleSource
		{
			get
			{
				return this._battleSource;
			}
			set
			{
				this._battleSource = value;
			}
		}

		// Token: 0x060105D8 RID: 67032 RVA: 0x003FB7D0 File Offset: 0x003F99D0
		public EncourageShowInfo(Transform encourage, Transform buff, int index)
		{
			this._index = index;
			this._encourageTransform = encourage;
			this._buffTransfrom = buff;
			this._courageBtn = (encourage.GetComponent("XUIButton") as IXUIButton);
			this._courageValueText = (buff.transform.Find("buff").GetComponent("XUILabel") as IXUILabel);
			this._courageValueTween = (buff.transform.Find("buff").GetComponent("XUIPlayTween") as IXUITweenTool);
			this._courageLabel = (buff.transform.Find("text").GetComponent("XUILabel") as IXUILabel);
			this._courageValueText.SetText("0%");
			this._courageBtn.ID = (ulong)((long)index);
		}

		// Token: 0x060105D9 RID: 67033 RVA: 0x003FB8B4 File Offset: 0x003F9AB4
		public void RegisterCourageClick(ButtonClickEventHandler handler)
		{
			bool flag = this._courageBtn != null;
			if (flag)
			{
				this._courageBtn.RegisterClickEventHandler(handler);
			}
		}

		// Token: 0x060105DA RID: 67034 RVA: 0x003FB8DC File Offset: 0x003F9ADC
		public void SetEncourageValue(int attrValue)
		{
			this._courageLabel.SetText(XStringDefineProxy.GetString(this.encourage_title));
			this._courageValueText.SetVisible(true);
			this._courageValueText.SetText(string.Format("{0}%", (long)attrValue * (long)((ulong)this.EncourageCount)));
			this._courageValueTween.ResetTween(true);
			this._courageValueTween.PlayTween(true, 0.5f);
		}

		// Token: 0x060105DB RID: 67035 RVA: 0x003FB952 File Offset: 0x003F9B52
		public void OnDispose()
		{
			this.ReqEncourage = null;
		}

		// Token: 0x040075F5 RID: 30197
		public string attr_string;

		// Token: 0x040075F6 RID: 30198
		public string cost_string;

		// Token: 0x040075F7 RID: 30199
		public string encourage_type;

		// Token: 0x040075F8 RID: 30200
		public string encourage_title;

		// Token: 0x040075F9 RID: 30201
		public string encourage_effect;

		// Token: 0x040075FA RID: 30202
		private IWorldBossBattleSource _battleSource;

		// Token: 0x040075FB RID: 30203
		private bool _valid = true;

		// Token: 0x040075FC RID: 30204
		private IXUIButton _courageBtn;

		// Token: 0x040075FD RID: 30205
		private IXUILabel _courageValueText;

		// Token: 0x040075FE RID: 30206
		private IXUITweenTool _courageValueTween;

		// Token: 0x040075FF RID: 30207
		private IXUILabel _courageLabel;

		// Token: 0x04007600 RID: 30208
		private Transform _encourageTransform;

		// Token: 0x04007601 RID: 30209
		private Transform _buffTransfrom;

		// Token: 0x04007602 RID: 30210
		private int _index;

		// Token: 0x04007603 RID: 30211
		public Action ReqEncourage = null;

		// Token: 0x04007604 RID: 30212
		public bool isNeedGuild = false;
	}
}
