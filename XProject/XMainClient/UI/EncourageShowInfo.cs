using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	public class EncourageShowInfo
	{

		public uint EncourageCount
		{
			get
			{
				return this._battleSource.GetEncourageCount(this._index);
			}
		}

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

		public void RegisterCourageClick(ButtonClickEventHandler handler)
		{
			bool flag = this._courageBtn != null;
			if (flag)
			{
				this._courageBtn.RegisterClickEventHandler(handler);
			}
		}

		public void SetEncourageValue(int attrValue)
		{
			this._courageLabel.SetText(XStringDefineProxy.GetString(this.encourage_title));
			this._courageValueText.SetVisible(true);
			this._courageValueText.SetText(string.Format("{0}%", (long)attrValue * (long)((ulong)this.EncourageCount)));
			this._courageValueTween.ResetTween(true);
			this._courageValueTween.PlayTween(true, 0.5f);
		}

		public void OnDispose()
		{
			this.ReqEncourage = null;
		}

		public string attr_string;

		public string cost_string;

		public string encourage_type;

		public string encourage_title;

		public string encourage_effect;

		private IWorldBossBattleSource _battleSource;

		private bool _valid = true;

		private IXUIButton _courageBtn;

		private IXUILabel _courageValueText;

		private IXUITweenTool _courageValueTween;

		private IXUILabel _courageLabel;

		private Transform _encourageTransform;

		private Transform _buffTransfrom;

		private int _index;

		public Action ReqEncourage = null;

		public bool isNeedGuild = false;
	}
}
