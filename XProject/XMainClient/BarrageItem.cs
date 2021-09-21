// Decompiled with JetBrains decompiler
// Type: XMainClient.BarrageItem
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class BarrageItem : DlgBehaviourBase
    {
        private List<string> m_colors = new List<string>();
        private List<int> m_sizes = new List<int>();
        public IXUILabel label;
        public GameObject outline;
        public Transform cacheTrans;
        private BarrageQueue mQueue;
        private int labelWidth = 10;
        private Vector3 start;
        private Vector3 end;
        private float t_start;
        private float t_cnt;

        public void Awake()
        {
            this.cacheTrans = this.transform;
            this.label = this.cacheTrans.GetComponent("XUILabel") as IXUILabel;
            this.outline = this.cacheTrans.Find("me").gameObject;
            this.m_colors = XSingleton<XGlobalConfig>.singleton.GetStringList("BarrageColors");
            this.m_sizes = XSingleton<XGlobalConfig>.singleton.GetIntList("BarrageSize");
        }

        public void Make(string txt, BarrageQueue queue, bool outl)
        {
            this.mQueue = queue;
            int index = Random.Range(0, this.m_colors.Count);
            int num = Random.Range(this.m_sizes[0], this.m_sizes[1]);
            txt = XSingleton<XCommon>.singleton.StringCombine(this.m_colors[index], txt, "[-]");
            this.label.SetText(txt);
            this.label.spriteDepth = queue.depth;
            this.label.fontSize = num;
            this.label.SetDepthOffset(queue.queueCnt);
            this.labelWidth = this.label.spriteWidth;
            this.start = this.transform.localPosition;
            this.end = new Vector3((float)((double)this.start.x - (double)(this.labelWidth * 2) - 1136.0), this.start.y, this.start.z);
            this.t_start = Time.time;
            this.t_cnt = (float)BarrageDlg.MOVE_TIME;
            this.outline.SetActive(outl);
        }

        public void Update()
        {
            if (DlgBase<BarrageDlg, BarrageBehaviour>.singleton.IsOutScreen(this.cacheTrans.localPosition.x + (float)this.labelWidth))
            {
                if (this.mQueue != null)
                    this.mQueue.FadeOut(this);
                DlgBase<BarrageDlg, BarrageBehaviour>.singleton.RecycleItem(this);
            }
            else if ((Object)this.cacheTrans != (Object)null)
                this.cacheTrans.localPosition = Vector3.Lerp(this.start, this.end, (Time.time - this.t_start) / this.t_cnt);
        }

        public void Drop()
        {
            if (!((Object)this.gameObject != (Object)null))
                return;
            UnityEngine.Object.Destroy((Object)this.gameObject);
        }
    }
}
