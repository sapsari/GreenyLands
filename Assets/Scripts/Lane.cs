using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Lane : MonoBehaviour
{
    public Zone[] Zones;
    public GameObject[] Arrows;
    public GameObject ArrowsParent;

    public int GreenEnergyProduction => Zones.Sum(z => z.GreenEnergyProduction);
    public int DirtyEneryProduction => Zones.Sum(z => z.DirtyEneryProduction);
    public int EnergyConsumption => Zones.Sum(z => z.EnergyConsumption);

    public void FillEnergyArray(int[] energyLevels)
    {
        foreach (var zone in Zones)
            zone.FillEnergyArray(energyLevels);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    Sequence[] sequences;
    DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions>[] tweens;

    public void SetArrowsVisibility(ZoneKind bpKind)
    {
        if (sequences == null)
            sequences = new Sequence[Zones.Length];
        if (tweens == null)
            tweens = new DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions>[Zones.Length];

        if (Data.Allowances.ContainsKey(bpKind))
        {
            var allowances = Data.Allowances[bpKind];
            ArrowsParent.gameObject.SetActive(true);

            for (int i = 0; i < Arrows.Length; i++)
            {
                if (allowances.Contains(Zones[i].Kind))
                {
                    sequences[i]?.SetLoops(0);
                    sequences[i]?.Complete();
                    sequences[i]?.Kill();

                    tweens[i]?.SetLoops(0);
                    tweens[i]?.Complete();
                    tweens[i]?.Kill();
                    tweens[i] = null;

                    Arrows[i].SetActive(true);

                    //const float timeMultiplier = .3f;
                    //var seq = DOTween.Sequence();
                    //seq.Append(Arrows[i].transform.DOLocalMoveY(10, 2 * timeMultiplier));
                    //seq.Append(Arrows[i].transform.DOLocalMoveY(-10, 4 * timeMultiplier));
                    //seq.Append(Arrows[i].transform.DOLocalMoveY(0, 1 * timeMultiplier));
                    //seq.SetLoops(-1, LoopType.Yoyo);
                    //sequences[i] = seq;

                    //var tw = Arrows[i].transform.DOLocalMoveY(10, .5f);
                    //var twl = tw.SetLoops(-1, LoopType.Yoyo);
                    //tweens[i] = twl;

                    //Arrows[i].transform.DOMoveY(50, 1f).SetLoops(-1);
                    //seq.
                }
                else
                {
                    Arrows[i].SetActive(false);
                }
            }
        }
        else
        {
            ArrowsParent.gameObject.SetActive(false);
        }
    }
}
