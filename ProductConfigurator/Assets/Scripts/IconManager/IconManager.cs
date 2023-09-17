using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IconManager : MonoBehaviour, IMenuLoadStep
{
    [SerializeField]
    private int loadPriority;
    public int Priority { get => loadPriority; }
    [SerializeField]
    private BeastieIconKeyValue[] BeastieIcons;
    private Dictionary<BeastieType, Sprite> beastieMap;
    [SerializeField]
    private EffectIconKeyValue[] SpecialEffectIcons;
    private Dictionary<SpecialEffectType, Sprite> effectMap;
    [SerializeField]
    private StatIconKeyValue[] StatIcons;
    private Dictionary<StatType, Sprite> statMap;
    [SerializeField]
    private ColourIconKeyValue[] ColourIcons;
    private Dictionary<ColourType, Sprite> colourMap;
    [SerializeField]
    private AuraIconKeyValue[] AuraIcons;
    private Dictionary<AuraType, Sprite> auraMap;
    [SerializeField]
    private Sprite defaultIcon;

    public static IconManager Icons;

    public IEnumerator LoadStep()
    {
        beastieMap = BeastieIcons.ToDictionary(pair => pair.Type, pair => pair.Value);
        effectMap = SpecialEffectIcons.ToDictionary(pair => pair.Type, pair => pair.Value);
        statMap = StatIcons.ToDictionary(pair => pair.Type, pair => pair.Value);
        colourMap = ColourIcons.ToDictionary(pair => pair.Type, pair => pair.Value);
        auraMap = AuraIcons.ToDictionary(pair => pair.Type, pair => pair.Value);
        Icons = this;
        yield break;
    }

    public Sprite GetBeastieIcon(BeastieType typeToGet)
    {
        Sprite beatieIcon = null;
        if (beastieMap.ContainsKey(typeToGet))
        {
            beatieIcon = beastieMap[typeToGet];
        }
        return beatieIcon;
    }

    public Sprite GetEffectIcon(SpecialEffectType typeToGet)
    {
        Sprite effectIcon = null;
        if (effectMap.ContainsKey(typeToGet))
        {
            effectIcon = effectMap[typeToGet];
        }
        return effectIcon;
    }

    public Sprite GetStatIcon(StatType typeToGet)
    {
        Sprite statIcon = null;
        if (statMap.ContainsKey(typeToGet))
        {
            statIcon = statMap[typeToGet];
        }
        return statIcon;
    }

    public Sprite GetColourIcon(ColourType typeToGet)
    {
        Sprite colourIcon = null;
        if (colourMap.ContainsKey(typeToGet))
        {
            colourIcon = colourMap[typeToGet];
        }
        return colourIcon;
    }

    public Sprite GetAuraIcon(AuraType typeToGet)
    {
        Sprite auraIcon = null;
        if (auraMap.ContainsKey(typeToGet))
        {
            auraIcon = auraMap[typeToGet];
        }
        return auraIcon;
    }

    public Sprite GetDefaultIcon()
    {
        return defaultIcon; 
    }
}
